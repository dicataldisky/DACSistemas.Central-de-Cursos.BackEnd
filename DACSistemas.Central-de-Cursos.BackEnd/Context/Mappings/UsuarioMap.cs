using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System.Data.Entity.ModelConfiguration;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            // Primary Key
            this.HasKey(u => u.UsuarioID);

            // Properties
            this.Property(u => u.Token)
                .HasMaxLength(64)
                .IsRequired();

            this.Property(u => u.Nome)
                .HasMaxLength(150)
                .IsRequired();

            this.Property(u => u.Email)
                .HasMaxLength(200)
                .IsRequired();

            this.Property(u => u.Senha)
                .HasMaxLength(65)
                .IsRequired();

            this.Property(u => u.Foto)
                .HasMaxLength(255)
                .IsRequired();

            this.Property(u => u.CPF)
                .HasMaxLength(11);

            this.Property(u => u.RG)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("Usuarios");
            this.Property(u => u.Token).HasColumnName("Token");
            this.Property(u => u.Nome).HasColumnName("Nome");
            this.Property(u => u.Email).HasColumnName("Email");
            this.Property(u => u.Senha).HasColumnName("Senha");
            this.Property(u => u.Foto).HasColumnName("Foto");
            this.Property(u => u.RG).HasColumnName("RG");
            this.Property(u => u.CPF).HasColumnName("CPF");
            this.Property(u => u.EstadoCivil).HasColumnName("EstadoCivil");
            this.Property(u => u.Sexo).HasColumnName("Sexo");
            this.Property(u => u.DataNascimento).HasColumnName("DataNascimento");
            this.Property(u => u.Telefone).HasColumnName("Telefone");
            this.Property(u => u.TelefoneEmergencia).HasColumnName("TelefoneEmergencia");
            this.Property(u => u.Celular).HasColumnName("Celular");
            this.Property(u => u.Ativo).HasColumnName("Ativo");
            this.Property(u => u.DataCadastro).HasColumnName("DataCadastro");
            this.Property(u => u.DataUltAlteracao).HasColumnName("DataUltAlteracao");
            this.Property(u => u.Apagado).HasColumnName("Apagado");

            // Relationships
            this.HasMany<Endereco>(e => e.Enderecos)
                .WithMany(t => t.Usuarios)
                .Map(ue =>
                {
                    ue.ToTable("Usuario_Enderecos");   // Nome da tabela de ligacao
                    ue.MapLeftKey("UsuarioID");        // LEFT eh a classe atual
                    ue.MapRightKey("EnderecoID");      // RIGHT eh classe q está sendo ligada   
                });

            this.HasMany<Grupo>(g => g.Grupos)
                .WithMany(t => t.Usuarios)
                .Map(ug =>
                {
                    ug.ToTable("Usuario_Grupos");      // Nome da tabela de ligacao
                    ug.MapLeftKey("UsuarioID");        // LEFT eh a classe atual
                    ug.MapRightKey("GrupoID");         // RIGHT eh classe q está sendo ligada   
                });

            this.HasMany<Curso>(c => c.Cursos)
                .WithMany(t => t.Usuarios)
                .Map(uc =>
                {
                    uc.ToTable("Usuario_Cursos");      // Nome da tabela de ligacao
                    uc.MapLeftKey("UsuarioID");        // LEFT eh a classe atual
                    uc.MapRightKey("CursoID");         // RIGHT eh classe q está sendo ligada   
                });

            this.HasMany<Habilitacao>(c => c.Habilitacoes)
                .WithMany(t => t.Usuarios)
                .Map(uh =>
                {
                    uh.ToTable("Usuario_Habilitacoes");// Nome da tabela de ligacao
                    uh.MapLeftKey("UsuarioID");        // LEFT eh a classe atual
                    uh.MapRightKey("HabilitacaoID");   // RIGHT eh classe q está sendo ligada   
                });
        }
    }
}