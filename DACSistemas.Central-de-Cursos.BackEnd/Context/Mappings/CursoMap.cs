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
            this.Property(u => u.Nome)
                    .HasMaxLength(150)
                    .IsRequired();

            this.Property(u => u.Descricao)
                    .HasMaxLength(250);


            // Table & Collumn Mappings
            this.ToTable("Cursos");
            this.Property(u => u.Nome).HasColumnName("Nome");
            this.Property(u => u.Descricao).HasColumnName("Descricao");
            this.Property(u => u.CargaHoraria).HasColumnName("CargaHoraria");
            this.Property(u => u.FinalDeSemana).HasColumnName("FinalDeSemana");
            this.Property(u => u.Apagado).HasColumnName("Apagado");

            // Relationships
        }
    }
}