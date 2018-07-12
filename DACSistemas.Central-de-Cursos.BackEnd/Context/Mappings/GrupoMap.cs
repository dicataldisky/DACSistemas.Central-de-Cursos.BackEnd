using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class GrupoMap : EntityTypeConfiguration<Grupo>
    {
        public GrupoMap()
        {
            // Primary Key
            this.HasKey(e => e.GrupoID);

            // Properties
            this.Property(u => u.Descricao)
                    .HasMaxLength(150)
                    .IsRequired();

            // Table & Collumn Mappings
            this.ToTable("Grupos");
            this.Property(g => g.Descricao).HasColumnName("Descricao");
            this.Property(g => g.Instrutor).HasColumnName("Instrutor");
            this.Property(g => g.Apagado).HasColumnName("Apagado");

            // Relationships
        }
    }
}