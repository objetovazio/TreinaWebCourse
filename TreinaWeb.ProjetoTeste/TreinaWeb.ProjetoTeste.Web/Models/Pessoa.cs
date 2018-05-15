using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.ProjetoTeste.Web.Models
{
    public class Pessoa
    {
        [Required]
        [MinLength(5, ErrorMessage = "Use no mínimo 5 letras.")]
        public string Nome { get; set; }

        [Required]
        [Range(18, int.MaxValue, ErrorMessage = "Apenas pessoas maiores de idade podem cadastrar-se.")]
        public int Idade { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Máximo de caracteres 200.")]
        public String Endereco { get; set; }
    }
}