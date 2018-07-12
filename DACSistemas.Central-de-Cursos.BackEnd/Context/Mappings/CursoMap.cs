using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class CursoMap : EntityTypeConfiguration<Curso>
    {
        public CursoMap()
        {
            // Primary Key
            this.HasKey(e => e.CursoID);

            // Properties
            this.Property(u => u.Titulo)
                    .HasMaxLength(150)
                    .IsRequired();

            this.Property(u => u.Descricao)
                    .HasMaxLength(250);

            // Table & Collumn Mappings
            this.ToTable("Cursos");
            this.Property(c => c.Titulo).HasColumnName("Nome");
            this.Property(c => c.Descricao).HasColumnName("Descricao");
            this.Property(c => c.CargaHoraria).HasColumnName("CargaHoraria");
            this.Property(c => c.FinalDeSemana).HasColumnName("FinalDeSemana");
            this.Property(c => c.Apagado).HasColumnName("Apagado");

            // Relationships
        }
    }
}