using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Receitas_XPTO.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaID { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "A categoria deverá ter no mínimo 5 e no máximo 20 carateres"), MinLength(5)]
        public string CategoriaNome { get; set; }


        public virtual ICollection<Receita> Receitas { get; set; }

    }
}