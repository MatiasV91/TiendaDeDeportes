namespace TiendaDeDeportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class envio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CompraItems",
                c => new
                    {
                        CompraItemId = c.Int(nullable: false, identity: true),
                        Cantidad = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        DetallesEnvioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CompraItemId)
                .ForeignKey("dbo.DetallesEnvios", t => t.DetallesEnvioId)
                .ForeignKey("dbo.Productoes", t => t.ProductoId)
                .Index(t => t.ProductoId)
                .Index(t => t.DetallesEnvioId);
            
            CreateTable(
                "dbo.DetallesEnvios",
                c => new
                    {
                        DetallesEnvioId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Direccion = c.String(nullable: false),
                        Localidad = c.String(nullable: false),
                        Provincia = c.String(nullable: false),
                        Pais = c.String(nullable: false),
                        CodigoPostal = c.String(nullable: false),
                        EnvolverParaRegalo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.DetallesEnvioId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CompraItems", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.CompraItems", "DetallesEnvioId", "dbo.DetallesEnvios");
            DropIndex("dbo.CompraItems", new[] { "DetallesEnvioId" });
            DropIndex("dbo.CompraItems", new[] { "ProductoId" });
            DropTable("dbo.DetallesEnvios");
            DropTable("dbo.CompraItems");
        }
    }
}
