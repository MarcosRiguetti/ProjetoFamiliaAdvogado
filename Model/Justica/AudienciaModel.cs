using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFamiliaAdvogado.Model.Justica
{
    public class AudienciaModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdAudiencia { get; set; }

        public string Usuario { get; set; }

        public string NumeroProcesso { get; set; }

        public string TipoProcesso { get; set; }

        public DateTime DataAudiencia { get; set; }

        public string Cliente { get; set; }
    }
}
