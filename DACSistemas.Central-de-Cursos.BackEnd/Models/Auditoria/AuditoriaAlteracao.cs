namespace DACSistemas.Central_de_Cursos.BackEnd.Models
{
    public class AuditoriaAlteracao
    {
        //ID
        public int AlteracaoID { get; set; }

        //Foreign keys
        public int AuditoriaID { get; set; }
        public TipoOperacaoAuditoria Operacao { get; set; }

        //Fields
        public string Tabela { get; set; }
        public string Campo { get; set; }
        public int ID { get; set; }
        public string InfoAnterior { get; set; }
        public string InfoAtual { get; set; }

        //Virtual Properties
        public virtual Auditoria Auditoria { get; set; }
    }

    public enum TipoOperacaoAuditoria : byte { Adicionar = 1, Atualizar = 2, Remover = 3, Listar = 4, }
}