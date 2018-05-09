using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Usuario : BaseEntity
    {
        public string Nombre { get; set; }
        public string Contrasenna { get; set; }

        public Usuario()
        {
            
        }

        public Usuario(string[] infoArray)
        {
            Nombre = infoArray[0];
            Contrasenna = infoArray[1];
        }
    }
}
