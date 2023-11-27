using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Models
{
    public class ProdutosObj
    {
        public int Id_Produto { get; set; }
        public string Nome_Produto { get; set; }
        public int Id_Categoria { get; set; }
        public string Marca { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string imagem { get; set; }
        public string Tamanho { get; set; }
        public int Id_Cliente { get; set; }
    }
}