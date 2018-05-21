using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Web.Models.Album;
using TreinaWeb.Musicas.Web.Models.Musica;

namespace TreinaWeb.Musicas.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        public DominioParaViewModelProfile()
        {
            CreateMap<Album, AlbumViewModel>()
                .ForMember(p => p.Nome, opt =>
                {
                    opt.MapFrom(src => string.Format("{0}({1})", src.Nome, src.Ano));
                });

            CreateMap<Musica, MusicaViewModel>()
                .ForMember(p => p.NomeAlbum, opt =>
                {
                    opt.MapFrom(src => src.Album.Nome);
                });
        }
    }
}