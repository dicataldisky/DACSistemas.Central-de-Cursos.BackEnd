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
            this.Property(u => u.HabilitacaoID).HasColumnName("HabilitacaoID");
            this.Property(u => u.Associacao).HasColumnName("Associacao");
            this.Property(u => u.Nivel).HasColumnName("Nivel");
            this.Property(u => u.DataDeFiliacao).HasColumnName("Filiacao");
            this.Property(u => u.Apagado).HasColumnName("Apagado");

            // Relationships
        }
    }
}