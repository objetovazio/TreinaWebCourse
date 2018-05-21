﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Web.Models.Album;
using TreinaWeb.Musicas.Web.Models.Musica;

namespace TreinaWeb.Musicas.Web.AutoMapper
{
    public class ViewModelParaDominioProfile : Profile
    {
        public ViewModelParaDominioProfile()
        {
            CreateMap<AlbumViewModel, Album>();
            CreateMap<MusicaViewModel, Musica>();
        }
    }
}