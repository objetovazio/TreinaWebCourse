using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TreinaWeb.Musicas.Web.Models.Musica
{
    public class MusicaViewModel
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Nome da música:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Selecione um album válido.")]
        public int IdAlbum { get; set; }

        public string NomeAlbum { get; set; }

        [Required]
        public Dominio.Album Album { get; set; }
    }
}