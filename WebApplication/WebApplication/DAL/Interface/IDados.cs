using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DAL.Interface
{
    public interface IDados<T>
    {
        /// <summary>
        /// Realiza o insert na base de dados
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Insert(T value);

        /// <summary>
        /// Realiza o Updade na base de dados
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public T Updade(T value);

        /// <summary>
        /// Realiza o Delete na base de dados
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Task<bool> Delete(T value);

        /// <summary>
        /// Realiza o Consulta na base de dados
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<T> Consult(T value);

        /// <summary>
        /// Retonar todos os dados
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public List<T> GetAll();
    }
}
