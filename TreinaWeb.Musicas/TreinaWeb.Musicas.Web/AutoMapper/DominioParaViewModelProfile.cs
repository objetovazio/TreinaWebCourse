﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Web.Models.Album;

namespace TreinaWeb.Musicas.Web.AutoMapper
{
    public class DominioParaViewModelProfile : Profile
    {
        public DominioParaViewModelProfile()
        {
            CreateMap<Album, AlbumViewModel>();
        }
        
    }
}