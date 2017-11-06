using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Dominio.Entities;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace TiendaDeDeportes.Dominio.Concrete
{

    public class ProcesarOrdenEmail : IProcesarOrden
    {
        private EmailConfiguracion emailConfiguracion;

        public ProcesarOrdenEmail(EmailConfiguracion configuracion)
        {
            emailConfiguracion = configuracion;
        }

        public void ProcesarOrden(Carrito carrito, DetallesEnvio detallesEnvio)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = emailConfiguracion.UseSsl;
                smtpClient.Host = emailConfiguracion.ServerName;
                smtpClient.Port = emailConfiguracion.ServerPort;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials
                = new NetworkCredential(emailConfiguracion.Username,
                emailConfiguracion.Password);
                if (emailConfiguracion.WriteAsFile)
                {
                    smtpClient.DeliveryMethod
                    = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = emailConfiguracion.FileLocation;
                    smtpClient.EnableSsl = false;
                }
                StringBuilder body = new StringBuilder()
                .AppendLine("Se registro una nueva orden")
                .AppendLine("---")
                .AppendLine("Items:");
                foreach (var item in carrito.Items)
                {
                    var subtotal = item.Producto.Precio * item.Cantidad;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", item.Cantidad,
                    item.Producto.Nombre,
                    subtotal);
                }
                body.AppendFormat("Total de la Orden: {0:c}", carrito.CalcularValorTotal())
                .AppendLine("---")
                .AppendLine("Enviar a:")
                .AppendLine(detallesEnvio.Nombre)
                .AppendLine(detallesEnvio.Direccion)
                .AppendLine(detallesEnvio.Localidad)
                .AppendLine(detallesEnvio.Provincia)
                .AppendLine(detallesEnvio.Pais)
                .AppendLine(detallesEnvio.CodigoPostal)
                .AppendLine("---")
                .AppendFormat("Envolver Para Regalo: {0}",
                detallesEnvio.EnvolverParaRegalo ? "Si" : "No");
                MailMessage MensajeMail = new MailMessage(
                emailConfiguracion.MailFromAddress, // From
                emailConfiguracion.MailToAddress, // To
                "Orden Enviada", // Subject
                body.ToString()); // Body
                if (emailConfiguracion.WriteAsFile)
                {
                    MensajeMail.BodyEncoding = Encoding.ASCII;
                }
                smtpClient.Send(MensajeMail);
            }
        }
    }

    public class EmailConfiguracion
    {
        public string MailToAddress = "ordenes@tiedadedeportes.com";
        public string MailFromAddress = "sportsstore@tiedadedeportes.com";
        public bool UseSsl = true;
        public string Username = "MySmtpUsername";
        public string Password = "MySmtpPassword";
        public string ServerName = "smtp.example.com";
        public int ServerPort = 587;
        public bool WriteAsFile = false;
        public string FileLocation = @"c:\TiendaDeDeportes_emails"; //Tiene que Existir
    }
}