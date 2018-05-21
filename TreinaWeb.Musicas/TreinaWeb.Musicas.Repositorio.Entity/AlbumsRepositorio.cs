using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Repositorio.Comum.Entity;

namespace TreinaWeb.Musicas.Repositorio.Entity
{
    public class AlbumsRepositorio : RepositorioGenericoEntity<Album, int>
    {
        public AlbumsRepositorio(MusicasDbContext context)
            : base(context) { }

        public override List<Album> Selecionar()
        {
            return context.Set<Album>()
                .Include(a => a.Musicas)
                .ToList();
        }

        public override Album SelecionarPorId(int id)
        {
            return context.Set<Album>()
                .Include(a => a.Musicas)
                .SingleOrDefault(a => a.Id == id);
        }
    }
}
