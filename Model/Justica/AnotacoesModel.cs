using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFamiliaAdvogado.Model.Justica
{
    public class AnotacoesModel
    {
        [PrimaryKey, AutoIncrement]
        public int IdAnotacoes { get; set; }

        public string Usuario { get; set; }

        public string Cliente { get; set; }

        public string Processo { get; set; }

        public string Texto { get; set; }

        public DateTime? DataAudiencia { get; set; }
    }
}
