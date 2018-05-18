using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreinaWeb.Musicas.Comum
{
    public abstract class TreinaWebEntityAbstractConfig<TEntidade> : EntityTypeConfiguration<TEntidade>
        where TEntidade : class
    {
        public TreinaWebEntityAbstractConfig()
        {
            ConfigTableNome();
            ConfigFieldsTable();
            ConfigPrimaryKey();
            ConfigForeignKey();
        }

        protected abstract void ConfigTableNome();
        protected abstract void ConfigFieldsTable();
        protected abstract void ConfigPrimaryKey();
        protected abstract void ConfigForeignKey();
        
        
        
    }
}
