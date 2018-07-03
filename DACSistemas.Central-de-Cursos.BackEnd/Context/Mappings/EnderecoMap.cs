using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            // Primary Key
            this.HasKey(e => e.EnderecoID);

            // Properties
            this.Property(u => u.CEP)
                    .HasMaxLength(8)
                    .IsRequired();

            this.Property(u => u.Logradouro)
                    .HasMaxLength(200)
                    .IsRequired();

            this.Property(u => u.Numero)
                    .HasMaxLength(6)
                    .IsRequired();

            this.Property(u => u.Complemento)
                    .HasMaxLength(100);

            this.Property(u => u.Bairro)
                    .HasMaxLength(45)
                    .IsRequired();

            this.Property(u => u.Localidade)
                    .HasMaxLength(65)
                    .IsRequired();

            this.Property(u => u.UF)
                    .HasMaxLength(2)
                    .IsRequired();



            this.Property(u => u.CodGIA)
                    .HasMaxLength(11);

            this.Property(u => u.CodGIA)
                    .HasMaxLength(11);

            // Table & Collumn Mappings
            this.ToTable("Enderecos");
            this.Property(u => u.CEP).HasColumnName("CEP");
            this.Property(u => u.Logradouro).HasColumnName("Logradouro");
            this.Property(u => u.Numero).HasColumnName("Numero");
            this.Property(u => u.Complemento).HasColumnName("Complemento");
            this.Property(u => u.Bairro).HasColumnName("Bairro");
            this.Property(u => u.Localidade).HasColumnName("Localidade");
            this.Property(u => u.UF).HasColumnName("UF");
            this.Property(u => u.CodIBGE).HasColumnName("CodIBGE");
            this.Property(u => u.CodGIA).HasColumnName("CodGIA");
            this.Property(u => u.Apagado).HasColumnName("Apagado");

            // Relationships
        }
    }
}