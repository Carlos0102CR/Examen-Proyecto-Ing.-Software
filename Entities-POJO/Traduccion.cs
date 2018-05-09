using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Traduccion : BaseEntity
    {
        public string Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public string Idioma { get; set; }
        public string FraseEspannol { get; set; }
        public string FraseIdioma { get; set; }
        public int Popularidad { get; set; }

        public Traduccion()
        {
            Fecha = DateTime.Now;
        }

        public Traduccion(string[] infoArray)
        {
            Usuario = infoArray[0];
            Fecha = DateTime.Now;
            Idioma = infoArray[1];
            FraseEspannol = infoArray[2];
            FraseIdioma = infoArray[3];
            Popularidad = int.Parse(infoArray[4]);
        }
    }
}
