using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Receitas_XPTO.Models
{
    public class Receita
    {
        public int ReceitaID { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 5)]
        public string ReceitaNome { get; set; }

        [Range(1, 999)]
        public Int16 Duracao { get; set; }

        [StringLength(500, MinimumLength = 5)]
        public string Descricao { get; set; }

        public int DificuldadeID { get; set; }
        public int CategoriaID { get; set; }
        public int UtilizadorID { get; set; }

        public virtual GrauDificuldade Dificuldade { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Utilizador Utilizador { get; set; }
    }
}