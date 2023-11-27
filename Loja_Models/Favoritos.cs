using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
   public class FavoritosObj
    {
        public int Id_Favorito { get; set; }
        public int Id_Produto { get; set; }
        public int Id_Cliente { get; set; }
        public string  Imagem { get; set; }
        public string Nome_Produto { get; set; }
        public decimal Preco { get; set; }

    }
}
