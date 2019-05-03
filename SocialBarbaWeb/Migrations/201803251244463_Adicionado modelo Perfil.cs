namespace Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadomodeloPerfil : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atividades",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Barbas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PerfilID = c.Int(nullable: false),
                        UserId = c.String(),
                        nome = c.String(),
                        tipo = c.String(),
                        data = c.DateTime(nullable: false),
                        capacidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Bigodes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        BarbaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Barbas", t => t.BarbaId, cascadeDelete: true)
                .Index(t => t.BarbaId);
            
            CreateTable(
                "dbo.Perfils",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        NomeExibicao = c.String(),
                        FotoPerfil = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Postagems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PerfilId = c.Int(nullable: false),
                        UserId = c.String(),
                        DataPostagem = c.DateTime(nullable: false),
                        FotoPostagem = c.String(),
                        TextoPostagem = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Seguirs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        SeguidorId = c.String(),
                        PerfilID = c.Int(nullable: false),
                        BarbaID = c.Int(nullable: false),
                        BigodeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bigodes", "BarbaId", "dbo.Barbas");
            DropIndex("dbo.Bigodes", new[] { "BarbaId" });
            DropTable("dbo.Seguirs");
            DropTable("dbo.Postagems");
            DropTable("dbo.Perfils");
            DropTable("dbo.Bigodes");
            DropTable("dbo.Barbas");
            DropTable("dbo.Atividades");
        }
    }
}
