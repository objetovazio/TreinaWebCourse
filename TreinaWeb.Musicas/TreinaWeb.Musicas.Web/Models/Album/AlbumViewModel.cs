using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.Models.Album
{
    public class AlbumViewModel
    {
        [Required(ErrorMessage = "O ID do álbum é obrigatório.")]
        public int Id { get; set; }

        [Display(Name = "Nome do Album")]
        [Required(ErrorMessage = "O Nome do álbum é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do álbum pode conter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Ano do Album")]
        [Required(ErrorMessage = "O Ano do álbum é obrigatório.")]
        public int Ano { get; set; }

        [Display(Name = "Observacoes")]
        [MaxLength(1000, ErrorMessage = "As observações do álbum pode conter no máximo 1000 caracteres.")]
        public string Observacoes { get; set; }

        [Display(Name = "Email do produtor")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O email não pode conter mais do que 50 caracteres.")]
        public string Email { get; set; }
    }
}