using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class HabilitacaoMap : EntityTypeConfiguration<Habilitacao>
    {
        public HabilitacaoMap()
        {
            // Primary Key
            this.HasKey(e => e.HabilitacaoID);

            // Properties
            this.Property(u => u.Nivel)
                    .HasMaxLength(5)
                    .IsRequired();

            // Table & Collumn Mappings
            this.ToTable("Habilitacoes");
            this.Property(h => h.HabilitacaoID).HasColumnName("HabilitacaoID");
            this.Property(h => h.Associacao).HasColumnName("Associacao");
            this.Property(h => h.Nivel).HasColumnName("Nivel");
            this.Property(h => h.DataDeFiliacao).HasColumnName("Filiacao");
            this.Property(h => h.Apagado).HasColumnName("Apagado");

            // Relationships
        }
    }
}