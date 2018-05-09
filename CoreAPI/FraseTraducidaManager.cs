
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreAPI
{
    public class FraseTraducidaManager : BaseManager
    {
        private FraseTraducidaCrudFactory crudFraseTraducida;

        public FraseTraducidaManager()
        {
            crudFraseTraducida = new FraseTraducidaCrudFactory();
        }

        public void Create(FraseTraducida fraseTraducida)
        {
            crudFraseTraducida.Create(fraseTraducida);
        }

        public List<FraseTraducida> RetrieveAll()
        {
            return crudFraseTraducida.RetrieveAll<FraseTraducida>();
        }

        public List<FraseTraducida> RetrieveAllByIdioma(FraseTraducida fraseTraducida)
        {
            return crudFraseTraducida.RetrieveAllByIdioma<FraseTraducida>(fraseTraducida);
        }

        public List<FraseTraducida> RetrieveAllByPalabra(FraseTraducida fraseTraducida)
        {
            return crudFraseTraducida.RetrieveAllByPalabra<FraseTraducida>(fraseTraducida);
        }

        public FraseTraducida RetrieveByName(FraseTraducida fraseTraducida)
        {
            return crudFraseTraducida.Retrieve<FraseTraducida>(fraseTraducida);
        }

        internal void Update(FraseTraducida fraseTraducida)
        {
            throw new NotImplementedException();
        }

        internal void Delete(FraseTraducida fraseTraducida)
        {
            throw new NotImplementedException();
        }
    }
}
