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

        }
    }
}
