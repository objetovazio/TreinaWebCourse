using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.Repositorio.Comum;

namespace TreinaWeb.Musicas.Repositorio.Comum.Entity
{
    public class RepositorioGenericoEntity<TEntidade, TChave> : IRepositorioGenerico<TEntidade, TChave>
        where TEntidade : class
    {
        protected DbContext context;

        public RepositorioGenericoEntity(DbContext context)
        {
            this.context = context;
        }

        public virtual List<TEntidade> Selecionar()
        {
            return context.Set<TEntidade>().ToList();
        }

        public virtual TEntidade SelecionarPorId(TChave id)
        {
            return context.Set<TEntidade>().Find(id);
        }

        public void Alterar(TEntidade entidade)
        {
            context.Set<TEntidade>().Attach(entidade);
            context.Entry(entidade).State = EntityState.Added;
            context.SaveChanges();
        }

        public void Excluir(TEntidade entidade)
        {
            context.Set<TEntidade>().Attach(entidade);
            context.Entry(entidade).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public void ExcluirPorId(TChave id)
        {
            TEntidade entidade = SelecionarPorId(id);
            Excluir(entidade);
        }

        public void Inserir(TEntidade entidade)
        {
            context.Set<TEntidade>().Add(entidade);
            context.SaveChanges();
        }
    }
}
