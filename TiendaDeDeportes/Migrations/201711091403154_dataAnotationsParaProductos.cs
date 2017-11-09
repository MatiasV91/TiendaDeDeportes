namespace TiendaDeDeportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnotationsParaProductos : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Productoes", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Productoes", "Categoria", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productoes", "Categoria", c => c.String());
            AlterColumn("dbo.Productoes", "Descripcion", c => c.String());
            AlterColumn("dbo.Productoes", "Nombre", c => c.String());
        }
    }
}
