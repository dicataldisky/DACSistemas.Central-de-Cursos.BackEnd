using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class UsuarioCursoMap : EntityTypeConfiguration<UsuarioCurso>
    {
        public UsuarioCursoMap()
        {
            // Primary Key
            this.HasKey(k => new { k.UsuarioID, k.CursoID});

            // Properties
            this.Property(uc => uc.CursoID).HasColumnName("CursoID");
            this.Property(uc => uc.UsuarioID).HasColumnName("UsuarioID");
            this.Property(uc => uc.DataInclusao).HasColumnName("DataInclusao");

            // Table & Collumn Mappings
            this.ToTable("Usuario_Cursos");

            // Relationships
            this.HasRequired(r => r.Curso).WithMany(d => d.UsuarioCurso).HasForeignKey(fk => fk.CursoID);
            this.HasRequired(r => r.Usuario).WithMany(d => d.UsuarioCurso).HasForeignKey(fk => fk.UsuarioID);
        }
    }
}