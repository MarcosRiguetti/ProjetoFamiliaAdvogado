using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFamiliaAdvogado.Model.Cadastro
{
    public class ClienteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ClienteModelID { get; set; }

        public string UsuarioLogin { get; set; }

        [Required]
        public string Advogado { get; set; }

        [Required]
        public string Cliente { get; set; }

        [Required]
        public string Contato { get; set; }

        public string Email { get; set; }

        public string Acusada { get; set; }
    }
}
