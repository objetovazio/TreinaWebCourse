using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TreinaWeb.Musicas.AcessoDados.Entity.Context;
using TreinaWeb.Musicas.Dominio;
using TreinaWeb.Musicas.Repositorio.Comum.Entity;

namespace TreinaWeb.Musicas.Repositorio.Entity
{
    public class MusicasRepositorio : RepositorioGenericoEntity<Musica, long>
    {
        public MusicasRepositorio(MusicasDbContext context)
            : base(context)
        {

        }

        public override List<Musica> Selecionar()
        {
            return context.Set<Musica>().Include(p => p.Album).ToList();
        }

        public override Musica SelecionarPorId(long id)
        {
            return context.Set<Musica>()
                .Include(p => p.Album)
                .SingleOrDefault(p => p.Id == id);
        }
    }
}
