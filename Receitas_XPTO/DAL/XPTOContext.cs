using Receitas_XPTO.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Receitas_XPTO.DAL
{
    public class XPTOContext : DbContext
    {

        public XPTOContext() : base("XPTOContext")
        {
        }

        public DbSet<Receita> Receita { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<GrauDificuldade> Dificuldade { get; set; }
        public DbSet<Utilizador> Utilizador { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}