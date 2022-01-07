using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Receitas_XPTO.Models
{
    public class GrauDificuldade
    {
        [Key]
        public int DificuldadeID { get; set; }

        [MaxLength(20, ErrorMessage = "O grau de dificuldade deverá ter no mínimo 4 e no máximo 20 carateres"), MinLength(4)]
        public string Dificuldade { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }
    }
}