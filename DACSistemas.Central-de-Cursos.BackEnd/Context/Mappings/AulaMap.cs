using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class AulaMap : EntityTypeConfiguration<Aula>
    {
        public AulaMap()
        {
            // Primary Key
            this.HasKey(k => new { k.AulaID, k.UsuarioID, k.AgendaID });

            // Properties

            // Table & Collumn Mappings
            this.ToTable("Agenda");
            this.Property(u => u.AulaID).HasColumnName("AulaID");
            this.Property(u => u.AgendaID).HasColumnName("AgendaID");
            this.Property(u => u.UsuarioID).HasColumnName("UsuarioID");


            // Relationships
            this.HasRequired(r => r.Usuario).WithMany(d => d.Aulas).HasForeignKey(fk => fk.UsuarioID);
            this.HasRequired(r => r.Agenda).WithMany(d => d.Aulas).HasForeignKey(fk => fk.AgendaID);

            
        }
    }
}