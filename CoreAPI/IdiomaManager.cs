
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
    public class IdiomaManager : BaseManager
    {
        private IdiomaCrudFactory crudIdioma;

        public IdiomaManager()
        {
            crudIdioma = new IdiomaCrudFactory();
        }

        public void Create(Idioma idioma)
        {
            crudIdioma.Create(idioma);
        }

        public List<Idioma> RetrieveAll()
        {
            return crudIdioma.RetrieveAll<Idioma>();
        }

        public Idioma RetrieveByName(Idioma idioma)
        {
            return crudIdioma.Retrieve<Idioma>(idioma);
        }

        public Idioma RetrieveMostPopular()
        {
            return crudIdioma.RetrieveMostPopular<Idioma>();
        }

        internal void Update(Idioma idioma)
        {
            throw new NotImplementedException();
        }

        internal void Delete(Idioma idioma)
        {
            throw new NotImplementedException();
        }
    }
}
