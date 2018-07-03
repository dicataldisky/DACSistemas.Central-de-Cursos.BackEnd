using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class AuditoriaMap : EntityTypeConfiguration<Auditoria>
    {
        public AuditoriaMap()
        {
            // Primary Key
            this.HasKey(t => t.AuditoriaID);

            // Properties
            this.Property(t => t.UsuarioID)
                .IsRequired();

            this.Property(t => t.Tela)
                .HasMaxLength(500)
                .IsRequired();

            this.Property(t => t.IP)
                .HasMaxLength(40)
                .IsRequired();

            this.Property(t => t.DataCadastro)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Auditoria");
            this.Property(t => t.AuditoriaID).HasColumnName("AuditoriaID");
            this.Property(t => t.UsuarioID).HasColumnName("UsuarioID");
            this.Property(t => t.DataCadastro).HasColumnName("DataCadastro");
            this.Property(t => t.Tela).HasColumnName("Tela");
            this.Property(t => t.IP).HasColumnName("IP");

            //Relatioship
        }
    }
}