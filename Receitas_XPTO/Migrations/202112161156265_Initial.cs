namespace Receitas_XPTO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            CreateTable(
                "dbo.Receita",
                c => new
                    {
                        ReceitaID = c.Int(nullable: false, identity: true),
                        ReceitaNome = c.String(nullable: false, maxLength: 40),
                        Duracao = c.Short(nullable: false),
                        Descricao = c.String(maxLength: 500),
                        DificuldadeID = c.Int(nullable: false),
                        CategoriaID = c.Int(nullable: false),
                        UtilizadorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReceitaID)
                .ForeignKey("dbo.Categoria", t => t.CategoriaID, cascadeDelete: true)
                .ForeignKey("dbo.GrauDificuldade", t => t.DificuldadeID, cascadeDelete: true)
                .ForeignKey("dbo.Utilizador", t => t.UtilizadorID, cascadeDelete: true)
                .Index(t => t.DificuldadeID)
                .Index(t => t.CategoriaID)
                .Index(t => t.UtilizadorID);
            
            CreateTable(
                "dbo.GrauDificuldade",
                c => new
                    {
                        DificuldadeID = c.Int(nullable: false, identity: true),
                        Dificuldade = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.DificuldadeID);
            
            CreateTable(
                "dbo.Utilizador",
                c => new
                    {
                        UtilizadorID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Pin = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.UtilizadorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Receita", "UtilizadorID", "dbo.Utilizador");
            DropForeignKey("dbo.Receita", "DificuldadeID", "dbo.GrauDificuldade");
            DropForeignKey("dbo.Receita", "CategoriaID", "dbo.Categoria");
            DropIndex("dbo.Receita", new[] { "UtilizadorID" });
            DropIndex("dbo.Receita", new[] { "CategoriaID" });
            DropIndex("dbo.Receita", new[] { "DificuldadeID" });
            DropTable("dbo.Utilizador");
            DropTable("dbo.GrauDificuldade");
            DropTable("dbo.Receita");
            DropTable("dbo.Categoria");
        }
    }
}
