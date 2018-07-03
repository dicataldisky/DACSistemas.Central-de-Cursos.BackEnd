using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class AuditoriaAlteracaoMap : EntityTypeConfiguration<AuditoriaAlteracao>
    {
        public AuditoriaAlteracaoMap()
        {
            // Primary Key
            this.HasKey(t => t.AlteracaoID);

            // Properties
            this.Property(t => t.AuditoriaID)
                .IsRequired();

            this.Property(t => t.Operacao)
                .IsRequired();

            this.Property(t => t.Tabela)
                .HasMaxLength(250)
                .IsRequired();

            this.Property(t => t.Campo)
                .HasMaxLength(250)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("AuditoriaAlteracao");
            this.Property(t => t.AlteracaoID).HasColumnName("AlteracaoID");
            this.Property(t => t.AuditoriaID).HasColumnName("AuditoriaID");
            this.Property(t => t.Operacao).HasColumnName("Operacao");
            this.Property(t => t.Tabela).HasColumnName("Tabela");
            this.Property(t => t.Campo).HasColumnName("Campo");
            this.Property(t => t.ID).HasColumnName("ID");
            this.Property(t => t.InfoAnterior).HasColumnName("InfoAnterior");
            this.Property(t => t.InfoAtual).HasColumnName("InfoAtual");

            //Relatioship
            this.HasRequired(t => t.Auditoria)
                .WithMany(t => t.Alteracoes)
                .HasForeignKey(t => t.AuditoriaID)
                .WillCascadeOnDelete(true);
        }
    }
}