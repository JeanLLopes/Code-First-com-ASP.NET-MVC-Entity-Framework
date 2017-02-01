namespace Code_First_com_ASP.NET_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlunoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        CursoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CursoModel", t => t.CursoID, cascadeDelete: true)
                .Index(t => t.CursoID);
            
            CreateTable(
                "dbo.CursoModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        UniversidadeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UniversidadeModel", t => t.UniversidadeID, cascadeDelete: true)
                .Index(t => t.UniversidadeID);
            
            CreateTable(
                "dbo.UniversidadeModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Cidade = c.String(),
                        UF = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlunoModel", "CursoID", "dbo.CursoModel");
            DropForeignKey("dbo.CursoModel", "UniversidadeID", "dbo.UniversidadeModel");
            DropIndex("dbo.CursoModel", new[] { "UniversidadeID" });
            DropIndex("dbo.AlunoModel", new[] { "CursoID" });
            DropTable("dbo.UniversidadeModel");
            DropTable("dbo.CursoModel");
            DropTable("dbo.AlunoModel");
        }
    }
}
