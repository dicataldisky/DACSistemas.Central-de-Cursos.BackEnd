using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class AgendaMap : EntityTypeConfiguration<Agenda>
    {
        public AgendaMap()
        {

            // Primary Key
            this.HasKey(k => new { k.AgendaID, k.EnderecoID, k.UsuarioID, k.CursoID });


            // Properties

            // Table & Collumn Mappings
            this.ToTable("Agenda");
            this.Property(u => u.AgendaID).HasColumnName("AgendaID");
            this.Property(u => u.Descricao).HasColumnName("Descricao");
            this.Property(u => u.CursoID).HasColumnName("CursoID");
            this.Property(u => u.UsuarioID).HasColumnName("UsuarioID");
            this.Property(u => u.EnderecoID).HasColumnName("EnderecoID");
            this.Property(u => u.Inicio).HasColumnName("Inicio");
            this.Property(u => u.Termino).HasColumnName("Termino");



            // Relationships
            this.HasRequired(r => r.Endereco).WithMany(d => d.Agendas).HasForeignKey(fk => fk.EnderecoID);
            this.HasRequired(r => r.Usuario).WithMany(d => d.Agendas).HasForeignKey(fk => fk.UsuarioID);
            this.HasRequired(r => r.Curso).WithMany(d => d.Agendas).HasForeignKey(fk => fk.CursoID);

        }
    }
}