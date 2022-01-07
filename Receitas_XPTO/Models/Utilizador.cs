using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Receitas_XPTO.Models
{
    public class Utilizador
    {
        public int UtilizadorID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public Int16 Pin { get; set; }

        public virtual ICollection<Receita> Receitas { get; set; }
        
    }
}