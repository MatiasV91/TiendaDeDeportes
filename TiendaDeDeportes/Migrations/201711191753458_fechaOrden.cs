namespace TiendaDeDeportes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fechaOrden : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetallesEnvios", "FechaOrden", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetallesEnvios", "FechaOrden");
        }
    }
}
