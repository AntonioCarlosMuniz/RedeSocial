namespace Dados.Migrations
{
    using Negocio.Dominio;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dados.SocialWebContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
        protected override void Seed(Dados.SocialWebContext context)
        {
            /*context.Perfils.AddOrUpdate(
                p => p.NomeExibicao,
                new Perfil { NomeExibicao = "Logan", FotoPerfil = "http://cdn.ofuxico.com.br/img/upload/noticias/2013/02/22/163998_36.jpg", UserID = "0101" },
                new Perfil { NomeExibicao = "Piquet", FotoPerfil = "https://static.noticiasaominuto.com.br/stockimages/1920/naom_59158eee575a2.jpg", UserID = "0102" },
                new Perfil { NomeExibicao = "Chris Evans", FotoPerfil = "http://contamais.com.br/upload/galeria/medium/9630.jpg", UserID = "0103" },
                new Perfil { NomeExibicao = "Ben Affleck", FotoPerfil = "https://i.pinimg.com/originals/8a/7d/bc/8a7dbc91de846022e20813651824f082.jpg", UserID = "0104" },
                new Perfil { NomeExibicao = "José de Abreu", FotoPerfil = "https://cdn1.mundodastribos.com/531169-Famosos-que-j%C3%A1-usaram-barba-comprida-fotos-1.jpg", UserID = "0105" }

            );

            Perfil perfil1 = db.Perfis.Where(x => x.UserID == "0101").FirstOrDefault();
            Perfil perfil2 = db.Perfis.Where(x => x.UserID == "0102").FirstOrDefault();
            Perfil perfil3 = db.Perfis.Where(x => x.UserID == "0103").FirstOrDefault();
            Perfil perfil4 = db.Perfis.Where(x => x.UserID == "0104").FirstOrDefault();
            Perfil perfil5 = db.Perfis.Where(x => x.UserID == "0105").FirstOrDefault();

            context.Postagems.AddOrUpdate(
                p => p.PerfilId,
                new Postagem { PerfilId = perfil1.id, UserId = "0101", TextoPostagem = "A natureza me fez uma aberração. O homem me fez uma arma. E Deus fez isso durar muito tempo.", DataPostagem = DateTime.Now.AddDays(-1) },
                new Postagem { PerfilId = perfil2.id, UserId = "0102", TextoPostagem = "Shakira Shakira", DataPostagem = DateTime.Now.AddHours(2) },
                new Postagem { PerfilId = perfil3.id, UserId = "0103", TextoPostagem = "Eu entendi a referencia", DataPostagem = DateTime.Now.AddDays(-4).AddMinutes(30) },
                new Postagem { PerfilId = perfil4.id, UserId = "0104", TextoPostagem = "I am Batman", DataPostagem = DateTime.Now.AddDays(-4) },
                new Postagem { PerfilId = perfil5.id, UserId = "0105", TextoPostagem = "Tá olhando o quê? Quer tomar uma cuspida?", DataPostagem = DateTime.Now.AddDays(-2) }

            );*/
        }
    }
}
