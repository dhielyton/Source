using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public  interface IRepository<T> where T: Entity
    {
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> LocalizarPorId(long Id);
        
    }
}
