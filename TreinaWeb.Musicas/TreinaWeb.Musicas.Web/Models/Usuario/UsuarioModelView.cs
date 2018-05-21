using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.Models.Usuario
{
    public class UsuarioViewModel
    {
        [Required(ErrorMessage = "O email é obrigatório!")]
        [MaxLength(50, ErrorMessage = "O email pode ter no máxim 50 caracteres.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "A senha é obrigatória")]
        [MinLength(3, ErrorMessage = "A senha deve ter no mínimo 3 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}