namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colaboradors",
                c => new
                    {
                        Cedula = c.Long(nullable: false, identity: false),
                        Nombre = c.String(maxLength: 50),
                        Apellidos = c.String(maxLength: 80),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.String(),
                    })
                .PrimaryKey(t => t.Cedula);
            
            CreateTable(
                "dbo.PrestarHerramientas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CedulaId = c.Long(nullable: false),
                        CodigoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaboradors", t => t.CedulaId, cascadeDelete: true)
                .ForeignKey("dbo.Herramientas", t => t.CodigoId, cascadeDelete: true)
                .Index(t => t.CedulaId)
                .Index(t => t.CodigoId);
            
            CreateTable(
                "dbo.Herramientas",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 50),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrestarHerramientas", "CodigoId", "dbo.Herramientas");
            DropForeignKey("dbo.PrestarHerramientas", "CedulaId", "dbo.Colaboradors");
            DropIndex("dbo.PrestarHerramientas", new[] { "CodigoId" });
            DropIndex("dbo.PrestarHerramientas", new[] { "CedulaId" });
            DropTable("dbo.Herramientas");
            DropTable("dbo.PrestarHerramientas");
            DropTable("dbo.Colaboradors");
        }
    }
}
