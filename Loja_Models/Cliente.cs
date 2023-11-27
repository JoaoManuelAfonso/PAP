using Loja_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class ClienteObj
    {
        public int Id_Cliente { get; set; }
        public string Primeiro_Nome { get; set; }
        public string Ultimo_Nome { get; set; }
        public int Telemovel { get; set; }
        public string Email { get; set; }
        public string Morada { get; set; }
        public string Password { get; set; }
        public char Role { get; set; }
        public bool? isloocked { get; set; }
        public bool? Auth { get; set; }
        public int? nr_attempts { get; set; }
        public DateTime? lock_date { get; set; }
    }
}