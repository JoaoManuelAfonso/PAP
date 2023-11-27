using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Models
{
    public class EmailObj
    {
        public int Id_Mensagem { get; set; }
        public string Nome_Vendedor { get; set; }
        public string Email_Vendedor { get; set; }
        public string Nome_Comprador { get; set; }
        public string Email_Comprador { get; set; }
        public string Nome_Produto { get; set; }
        public int Id_Produto { get; set; }
        public DateTime Dia_Hora {get;set;}

        public int Id_Emissor { get; set; }
        public string Texto { get; set; }
        public int Id_Recedor { get; set; }

    }
}
