namespace Receitas_XPTO.Migrations
{
    using Receitas_XPTO.DAL;
    using Receitas_XPTO.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Receitas_XPTO.DAL.XPTOContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XPTOContext context)
        {

            var dificuldade = new List<GrauDificuldade>
            {
            new GrauDificuldade{DificuldadeID = 4, Dificuldade = "Fácil", },
            new GrauDificuldade{DificuldadeID = 5, Dificuldade = "Médio", },
            new GrauDificuldade{DificuldadeID = 6, Dificuldade = "Difícil", },

            };
            dificuldade.ForEach(s => context.Dificuldade.Add(s));
            context.SaveChanges();

            var categorias = new List<Categoria>
            {
            new Categoria{CategoriaID =5, CategoriaNome = "Entradas"},
            new Categoria{CategoriaID =6, CategoriaNome = "Prato Principal"},
            new Categoria{CategoriaID =7, CategoriaNome = "Sobremesas"},
            new Categoria{CategoriaID =8, CategoriaNome = "Outros"},
            };
            categorias.ForEach(s => context.Categoria.Add(s));
            context.SaveChanges();

            var utilizador = new List<Utilizador>
            {
            new Utilizador{UtilizadorID =1, Username = "User1", Password = "pass", Pin = 1234},
            new Utilizador{UtilizadorID =2, Username = "User2", Password = "qwerty", Pin = 4444},
            new Utilizador{UtilizadorID =3, Username = "User3", Password = "qwerty123", Pin = 2563},

            };
            utilizador.ForEach(s => context.Utilizador.Add(s));
            context.SaveChanges();

            var receitas = new List<Receita>
            {
            new Receita{ReceitaID =10, CategoriaID=1, DificuldadeID= 1, ReceitaNome = "Sopa da avó", Duracao =40, Descricao = "Descascar batatas...", UtilizadorID = 1},
            new Receita{ReceitaID =11, CategoriaID=2, DificuldadeID= 3, ReceitaNome = "Bacalhau à brás", Duracao =40, Descricao = "Desfiar bacalhau...", UtilizadorID = 3},
            new Receita{ReceitaID =12, CategoriaID=3, DificuldadeID= 1, ReceitaNome = "Gelatina", Duracao =10, Descricao = "Ferver água...", UtilizadorID = 2},
            new Receita{ReceitaID =13, CategoriaID=2, DificuldadeID= 3, ReceitaNome = "Polvo à Lagareiro", Duracao =90, Descricao = "Descascar batatas e desfiar bacalhau...", UtilizadorID = 1},
            };
            receitas.ForEach(s => context.Receita.Add(s));
            context.SaveChanges();


        }
    }
}
