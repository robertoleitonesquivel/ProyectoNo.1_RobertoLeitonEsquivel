namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTipoDatoCedula : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PrestarHerramientas", "CedulaId", "dbo.Colaboradors");
            DropIndex("dbo.PrestarHerramientas", new[] { "CedulaId" });
            DropPrimaryKey("dbo.Colaboradors");
            AlterColumn("dbo.Colaboradors", "Cedula", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PrestarHerramientas", "CedulaId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Colaboradors", "Cedula");
            CreateIndex("dbo.PrestarHerramientas", "CedulaId");
            AddForeignKey("dbo.PrestarHerramientas", "CedulaId", "dbo.Colaboradors", "Cedula");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PrestarHerramientas", "CedulaId", "dbo.Colaboradors");
            DropIndex("dbo.PrestarHerramientas", new[] { "CedulaId" });
            DropPrimaryKey("dbo.Colaboradors");
            AlterColumn("dbo.PrestarHerramientas", "CedulaId", c => c.Long(nullable: false));
            AlterColumn("dbo.Colaboradors", "Cedula", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Colaboradors", "Cedula");
            CreateIndex("dbo.PrestarHerramientas", "CedulaId");
            AddForeignKey("dbo.PrestarHerramientas", "CedulaId", "dbo.Colaboradors", "Cedula", cascadeDelete: true);
        }
    }
}
