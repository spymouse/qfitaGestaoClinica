using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Interface;
using WebApplication.Models.Data;

namespace WebApplication.DAL
{
    public class DALCliente : IDados<Models.Data.Cliente>
    {
        public List<Cliente> Consult(Cliente value)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Cliente value)
        {
            throw new NotImplementedException();
        }

        public List<Cliente> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Insert(Cliente value)
        {
            throw new NotImplementedException();
        }

        public Cliente Updade(Cliente value)
        {
            throw new NotImplementedException();
        }
    }
}
