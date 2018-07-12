using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class AgendaMap : EntityTypeConfiguration<Agenda>
    {
        public AgendaMap()
        {
            // Primary Key
            this.HasKey(k => k.AgendaID);

            // Properties

            // Table & Collumn Mappings
            this.ToTable("Agenda");
            this.Property(a => a.AgendaID).HasColumnName("AgendaID");
            this.Property(a => a.Descricao).HasColumnName("Descricao");
            this.Property(a => a.CursoID).HasColumnName("CursoID");
            this.Property(a => a.UsuarioID).HasColumnName("UsuarioID");
            this.Property(a => a.EnderecoID).HasColumnName("EnderecoID");
            this.Property(a => a.Inicio).HasColumnName("Inicio");
            this.Property(a => a.Termino).HasColumnName("Termino");

            // Relationships
            this.HasRequired(r => r.Endereco).WithMany(d => d.Agendas).HasForeignKey(fk => fk.EnderecoID);
            this.HasRequired(r => r.Usuario).WithMany(d => d.Agendas).HasForeignKey(fk => fk.UsuarioID);
            this.HasRequired(r => r.Curso).WithMany(d => d.Agendas).HasForeignKey(fk => fk.CursoID);
        }
    }
}