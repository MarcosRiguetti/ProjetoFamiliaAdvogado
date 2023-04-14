using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFamiliaAdvogado.Model.Cadastro
{
    public class UsuarioModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }

        [Required]
        public string UsuarioLogin { get; set; }

        public string UsuarioSessao { get; set; }

        [Required]
        public string Nome { get; set; }

        public string NameImage { get; set; }

        [Required]
        public string Sobrenome { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public string Password { get; set; }

        public byte[] UserAvatar { get; set; }
    }
}
