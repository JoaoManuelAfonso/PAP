using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja_Models
{
   public class PasswordObj
    {
        public int Id_PwdRecoveryRequest { get; set; }
        public string Guid{ get; set; }
        public string email { get; set; }
        public DateTime Date_Recovery_Request { get; set; }
    }
}
