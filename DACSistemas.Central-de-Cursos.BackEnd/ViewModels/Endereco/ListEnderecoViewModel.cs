namespace DACSistemas.Central_de_Cursos.BackEnd.ViewModels
{
    public class ListEnderecoViewModel
    {
        public int? EnderecoID { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}