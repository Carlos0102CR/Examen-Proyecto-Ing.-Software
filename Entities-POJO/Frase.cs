using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Frase : BaseEntity
    {
        public string Palabra { get; set; }
        public int Popularidad { get; set; }

        public Frase()
        {
            
        }

        public Frase(string[] infoArray)
        {
            Palabra = infoArray[0];
        }
    }
}
