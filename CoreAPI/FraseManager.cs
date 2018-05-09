
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
    public class FraseManager : BaseManager
    {
        private FraseCrudFactory crudFrase;

        public FraseManager()
        {
            crudFrase = new FraseCrudFactory();
        }

        public void Create(Frase frase)
        {
            crudFrase.Create(frase);
        }

        public void AddPopularidad(Frase frase)
        {
            crudFrase.AddPopularidad(frase);
        }

        public List<Frase> RetrieveAll()
        {
            return crudFrase.RetrieveAll<Frase>();
        }

        public Frase RetrieveByName(Frase frase)
        {
            return crudFrase.Retrieve<Frase>(frase);
        }

        public List<Frase> RetrieveByPopularity()
        {
            return crudFrase.RetrieveAllByPopularity<Frase>();
        }

        internal void Update(Frase frase)
        {
            throw new NotImplementedException();
        }

        internal void Delete(Frase frase)
        {
            throw new NotImplementedException();
        }
    }
}