using SQLite;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFamiliaAdvogado.Model.Login
{
    public class LoginSessaoModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdLogin { get; set; }

        [Required]
        public string Usuario { get; set; }
    }
}
