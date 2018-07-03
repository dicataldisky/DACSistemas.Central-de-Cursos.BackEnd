using DACSistemas.Central_de_Cursos.BackEnd.Context.Mappings;
using DACSistemas.Central_de_Cursos.BackEnd.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace DACSistemas.Central_de_Cursos.BackEnd.Context
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class CentralDeCursosContext : DbContext
    {
        public CentralDeCursosContext()
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true;
            Database.SetInitializer<CentralDeCursosContext>(null);
        }

        // Entities
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Habilitacao> Habilitacoes { get; set; }
        public DbSet<Agenda> Agendas { get; set; }

        #region Auditoria 
        public DbSet<Auditoria> Auditorias { get; set; }
        public DbSet<AuditoriaAlteracao> AuditoriaAlteracoes { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mappings
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new EnderecoMap());
            modelBuilder.Configurations.Add(new GrupoMap());
            modelBuilder.Configurations.Add(new CursoMap());
            modelBuilder.Configurations.Add(new HabilitacaoMap());
            modelBuilder.Configurations.Add(new AgendaMap());


            #region Auditoria
            modelBuilder.Configurations.Add(new AuditoriaMap());
            modelBuilder.Configurations.Add(new AuditoriaAlteracaoMap());
            #endregion
        }

        public override int SaveChanges()
        {
            //Preenche automaticamente as Datas de Cadastro e Ultima Alteracao
            var auditables = ChangeTracker.Entries().Where(x => x.Entity is DataLog);
            foreach (var entity in auditables)
            {
                var auditableEntity = (DataLog)entity.Entity;

                switch (entity.State)
                {
                    case EntityState.Added:
                        if (auditableEntity.DataCadastro == default(DateTime))
                            auditableEntity.DataCadastro = DateTime.Now;
                        if (auditableEntity.DataUltAlteracao == default(DateTime))
                            auditableEntity.DataUltAlteracao = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        auditableEntity.DataUltAlteracao = DateTime.Now;
                        break;
                }
            }

            return base.SaveChanges();
        }

        #region Auditoria
        public int SaveChanges(Auditoria auditoria)
        {
            foreach (var entry in ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Deleted || p.State == EntityState.Modified))
            {
                if (entry.Entity == null)
                    continue;

                var tableName = GetTableName(entry.Entity.GetType());
                var primaryKeyObject = GetPrimaryKeyValue(entry);
                var primaryKey = 0;

                if (!int.TryParse(primaryKeyObject.ToString(), out primaryKey))
                    primaryKey = 0;

                switch (entry.State)
                {
                    case EntityState.Added:
                        foreach (string prop in entry.CurrentValues.PropertyNames)
                        {
                            var currentValue = entry.CurrentValues[prop] != null ? entry.CurrentValues[prop].ToString() : string.Empty;
                            var originalValue = string.Empty;

                            if (string.IsNullOrEmpty(currentValue))
                                continue;

                            auditoria.Alteracoes.Add(new AuditoriaAlteracao { Operacao = TipoOperacaoAuditoria.Adicionar, Tabela = tableName, Campo = prop, ID = primaryKey, InfoAnterior = originalValue, InfoAtual = currentValue });
                        }
                        break;
                    case EntityState.Deleted:
                        foreach (string prop in entry.OriginalValues.PropertyNames)
                        {
                            var currentValue = string.Empty;
                            var originalValue = entry.OriginalValues[prop] != null ? entry.OriginalValues[prop].ToString() : string.Empty;

                            if (string.IsNullOrEmpty(originalValue))
                                continue;

                            auditoria.Alteracoes.Add(new AuditoriaAlteracao { Operacao = TipoOperacaoAuditoria.Remover, Tabela = tableName, Campo = prop, ID = primaryKey, InfoAnterior = originalValue, InfoAtual = currentValue });
                        }
                        break;
                    case EntityState.Modified:
                        foreach (string prop in entry.OriginalValues.PropertyNames)
                        {
                            var currentValue = entry.CurrentValues[prop] != null ? entry.CurrentValues[prop].ToString() : string.Empty;
                            var originalValue = entry.OriginalValues[prop] != null ? entry.OriginalValues[prop].ToString() : string.Empty;

                            if (currentValue.Equals(originalValue)) { continue; }

                            auditoria.Alteracoes.Add(new AuditoriaAlteracao { Operacao = TipoOperacaoAuditoria.Atualizar, Tabela = tableName, Campo = prop, ID = primaryKey, InfoAnterior = originalValue, InfoAtual = currentValue });
                        }
                        break;
                }
            }

            Auditorias.Add(auditoria);

            return base.SaveChanges();
        }

        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);

            if (objectStateEntry.EntityKey.EntityKeyValues == null || !objectStateEntry.EntityKey.EntityKeyValues.Any())
                return 0;

            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }

        private string GetTableName(Type entityType)
        {
            System.Data.Entity.Core.Objects.ObjectContext octx = (this as IObjectContextAdapter).ObjectContext;
            System.Data.Entity.Core.Metadata.Edm.EntitySetBase et = octx.MetadataWorkspace.GetItemCollection(System.Data.Entity.Core.Metadata.Edm.DataSpace.SSpace)
                .GetItems<System.Data.Entity.Core.Metadata.Edm.EntityContainer>()
                .Single()
                .BaseEntitySets
                .Where(x => x.Name == entityType.Name)
                .Single();

            //String tableName = String.Concat(et.MetadataProperties["Schema"].Value, ".", et.MetadataProperties["Table"].Value);
            return et.MetadataProperties["Table"].Value.ToString();
        }
    }
    #endregion
}