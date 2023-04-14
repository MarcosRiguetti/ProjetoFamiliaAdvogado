using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFamiliaAdvogado.Model.Login
{
    public class LoginModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdLogin { get; set; }

        [Required]
        public string Usuario { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
