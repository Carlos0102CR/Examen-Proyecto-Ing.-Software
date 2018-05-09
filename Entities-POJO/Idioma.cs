using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Idioma : BaseEntity
    {
        public string Nombre { get; set; }
        public int Popularidad { get; set; }

        public Idioma()
        {
            
        }

        public Idioma(string[] infoArray)
        {
            Nombre = infoArray[0];
        }
    }
}
