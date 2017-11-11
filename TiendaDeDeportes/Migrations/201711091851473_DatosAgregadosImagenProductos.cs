namespace TiendaDeDeportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatosAgregadosImagenProductos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "ImagenData", c => c.Binary());
            AddColumn("dbo.Productoes", "ImagenMimeType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Productoes", "ImagenMimeType");
            DropColumn("dbo.Productoes", "ImagenData");
        }
    }
}
