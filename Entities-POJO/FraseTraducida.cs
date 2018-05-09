using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class FraseTraducida : BaseEntity
    {
        public string Palabra { get; set; }
        public string NombreIdioma { get; set; }
        public string PalabraTraducida { get; set; }

        public FraseTraducida()
        {
            
        }

        public FraseTraducida(string[] infoArray)
        {
            Palabra = infoArray[0];
            NombreIdioma = infoArray[1];
            PalabraTraducida = infoArray[2];
        }
    }
}
