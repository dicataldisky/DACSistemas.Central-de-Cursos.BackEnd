using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using DACSistemas.Central_de_Cursos.BackEnd.Models;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class UsuarioCursoMap : EntityTypeConfiguration<UsuarioCurso>
    {
        public UsuarioCursoMap()
        {
            this.ToTable("Usuario_Cursos");
            this.HasKey(k => new { k.UsuarioID, k.CursoID});
            this.HasRequired(r => r.Curso).WithMany(d => d.UsuarioCurso).HasForeignKey(fk => fk.CursoID);
            this.HasRequired(r => r.Usuario).WithMany(d => d.UsuarioCurso).HasForeignKey(fk => fk.UsuarioID);

            this.Property(u => u.CursoID).HasColumnName("CursoID");
            this.Property(u => u.UsuarioID).HasColumnName("UsuarioID");
            this.Property(u => u.DataInclusao).HasColumnName("DataInclusao");
        }
    }
}