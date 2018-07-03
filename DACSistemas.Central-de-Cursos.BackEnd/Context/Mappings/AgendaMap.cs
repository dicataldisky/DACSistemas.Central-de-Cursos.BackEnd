using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings
{
    public class AgendaMap : EntityTypeConfiguration<Agenda>
    {
        public AgendaMap()
        {
            // Primary Key
            this.HasKey(p => new { p.AgendaID, p.CursoID });

            // Properties


            // Table & Collumn Mappings
            this.ToTable("Agenda");
            this.Property(u => u.AgendaID).HasColumnName("AgendaID");
            this.Property(u => u.CursoID).HasColumnName("CursoID");
            this.Property(u => u.EnderecoID).HasColumnName("EnderecoID");
            this.Property(u => u.InstrutorID).HasColumnName("InstrutorID");


            // Relationships

        }
    }
}