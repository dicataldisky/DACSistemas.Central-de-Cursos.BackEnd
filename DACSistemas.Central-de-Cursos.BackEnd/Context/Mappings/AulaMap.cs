using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class AulaMap : EntityTypeConfiguration<Aula>
    {
        public AulaMap()
        {
            // Primary Key
            this.HasKey(k => k.AulaID);

            // Properties
            this.Property(u => u.Observacao)
                .HasMaxLength(255);

            // Table & Collumn Mappings
            this.ToTable("Aula");
            this.Property(a => a.AulaID).HasColumnName("AulaID");
            this.Property(a => a.AgendaID).HasColumnName("AgendaID");
            this.Property(a => a.UsuarioID).HasColumnName("UsuarioID");
            this.Property(a => a.CursoID).HasColumnName("CursoID");
            this.Property(a => a.Entrada).HasColumnName("Entrada");
            this.Property(a => a.Saida).HasColumnName("Saida");
            this.Property(a => a.Observacao).HasColumnName("Observacao");
            
            // Relationships
            this.HasRequired(r => r.Usuario).WithMany(d => d.Aulas).HasForeignKey(fk => fk.UsuarioID);
            this.HasRequired(r => r.Agenda).WithMany(d => d.Aulas).HasForeignKey(fk => fk.AgendaID);
            this.HasRequired(r => r.Curso).WithMany(d => d.Aulas).HasForeignKey(fk => fk.CursoID);
        }
    }
}