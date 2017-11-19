using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaDeDeportes.Dominio.Abstract;
using TiendaDeDeportes.Dominio.Concrete;

namespace TiendaDeDeportes.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IProductoRepositorio>().To<EFProductoRepositorio>();
            //EmailConfiguracion emailConfiguracion = new EmailConfiguracion
            //{
            //    WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            //};
            //kernel.Bind<IProcesarOrden>().To<ProcesarOrdenEmail>().WithConstructorArgument("configuracion", emailConfiguracion);
            kernel.Bind<IProcesarOrden>().To<ProcesarOrdenDb>();
            kernel.Bind<ICompraItemRepositorio>().To<EFCompraItemRepositorio>();
            kernel.Bind<IDetallesEnvioRepositorio>().To<EFDetallesEnvioRepositorio>();

        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}