using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinaWeb.Musicas.Comum;
using TreinaWeb.Musicas.Dominio;

namespace TreinaWeb.Musicas.AcessoDados.Entity.TypeConfiguration
{
    internal class AlbumTypeConfiguration : TreinaWebEntityAbstractConfig<Album>
    {
        protected override void ConfigTableNome()
        {
            ToTable("ALB_ALBUNS");
        }

        protected override void ConfigFieldsTable()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("ALB_ID");

            Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("ALB_NOME")
                .HasMaxLength(100);

            Property(p => p.Ano)
                .IsRequired()
                .HasColumnName("ALB_ANO");

            Property(p => p.Observacoes)
                .IsOptional()
                .HasColumnName("ALB_OBSERVACOES")
                .HasMaxLength(1000);

            Property(p => p.Email)
                .IsOptional()
                .HasColumnName("ALB_EMAIL")
                .HasMaxLength(50);
        }

        
        protected override void ConfigPrimaryKey()
        {
            HasKey(p => p.Id);
        }

        protected override void ConfigForeignKey()
        {
            //HasMany(album => album.Musicas)
            //    .WithRequired(musica => musica.Album)
            //    .HasForeignKey(musica => musica.IdAlbum);
        }

    }
}
