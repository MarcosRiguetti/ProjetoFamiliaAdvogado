using SQLite;

namespace ProjetoFamiliaAdvogado.Model.Erro
{
    public class ErroModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdErro { get; set; }

        public string Classe { get; set; }

        public string Metodo { get; set; }

        public string Mensagem { get; set; }

        public string MensagemInterna { get; set; }

        public DateTime DataErro { get; set; }
    }
}
