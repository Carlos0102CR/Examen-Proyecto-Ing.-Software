
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
    public class TraduccionManager : BaseManager
    {
        private TraduccionCrudFactory crudTraduccion;

        public TraduccionManager()
        {
            crudTraduccion = new TraduccionCrudFactory();
        }

        public void Create(Traduccion traduccion)
        {
            crudTraduccion.Create(traduccion);
        }

        public List<Traduccion> RetrieveAll()
        {
            return crudTraduccion.RetrieveAll<Traduccion>();
        }

        public List<Traduccion> RetrieveAllByPalabra(Traduccion traduccion)
        {
            return crudTraduccion.RetrieveAllByPalabra<Traduccion>(traduccion);
        }

        public Traduccion RetrieveById(Traduccion traduccion)
        {
            return crudTraduccion.Retrieve<Traduccion>(traduccion);
        }

        internal void Update(Traduccion traduccion)
        {
            throw new NotImplementedException();
        }

        internal void Delete(Traduccion traduccion)
        {
            throw new NotImplementedException();
        }
    }
}