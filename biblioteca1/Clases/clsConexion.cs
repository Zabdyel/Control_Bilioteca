using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca1.Clases
{
    internal class clsConexion
    {
        public static String cadenaConexion()
        {
            String sCon = "server=127.0.0.1; Database=controlE; Uid=root; pwd=;";
            return (sCon);
        }
    }
}
