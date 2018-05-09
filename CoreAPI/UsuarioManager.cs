
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
    public class UsuarioManager : BaseManager
    {
        private UsuarioCrudFactory crudUsuario;

        public UsuarioManager()
        {
            crudUsuario = new UsuarioCrudFactory();
        }

        public void Create(Usuario usuario)
        {
            crudUsuario.Create(usuario);
        }

        public List<Usuario> RetrieveAll()
        {
            return crudUsuario.RetrieveAll<Usuario>();
        }

        public Usuario RetrieveByName(Usuario usuario)
        {
            return crudUsuario.Retrieve<Usuario>(usuario);
        }

        public Usuario RetrieveByTraduccion()
        {
            return crudUsuario.RetrieveByTraduccion<Usuario>();
        }

        internal void Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        internal void Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
