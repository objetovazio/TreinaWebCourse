using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.Comum;
using TreinaWeb.Musicas.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration
{
    class MusicaTypeConfiguration : TreinaWebEntityAbstractConfig<Musica>
    {
        protected override void ConfigFieldsTable()
        {
            Property(p => p.Id)
                .HasColumnName("MUS_ID")
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("MUS_NOME")
                .HasMaxLength(100)
                .IsRequired();

            Property(p => p.IdAlbum)
                .HasColumnName("ALB_ID")
                .IsRequired();
        }

        protected override void ConfigForeignKey()
        {
            HasRequired(m => m.Album)
                .WithMany(al => al.Musicas)
                .HasForeignKey(fk => fk.IdAlbum);
        }

        protected override void ConfigPrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        protected override void ConfigTableNome()
        {
            ToTable("MUS_MUSICAS");
        }
    }
}
