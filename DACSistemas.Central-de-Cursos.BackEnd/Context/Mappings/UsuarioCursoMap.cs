using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class UsuarioCursoMap : EntityTypeConfiguration<UsuarioCurso>
    {
        public UsuarioCursoMap()
        {
            this.ToTable("Usuario_Cursos");
            // Primary Key
            this.HasKey(k => new { k.UsuarioID, k.CursoID});

            // Properties
            this.Property(u => u.CursoID).HasColumnName("CursoID");
            this.Property(u => u.UsuarioID).HasColumnName("UsuarioID");
            this.Property(u => u.DataInclusao).HasColumnName("DataInclusao");

            // Table & Collumn Mappings
            this.HasRequired(r => r.Curso).WithMany(d => d.UsuarioCurso).HasForeignKey(fk => fk.CursoID);
            this.HasRequired(r => r.Usuario).WithMany(d => d.UsuarioCurso).HasForeignKey(fk => fk.UsuarioID);


        }
    }
}