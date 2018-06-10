using DAL.Context;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryPessoa : IRepository<Pessoa>
    {
        private C2VContext _dbContext;

        public RepositoryPessoa(C2VContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pessoa> Delete(Pessoa entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Pessoa> Delete(long? Id)
        {
            var entity = await LocalizarPorId((long)Id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Pessoa> GetAllOrderByDescricao()
        {
            return null;
        }

        public IQueryable<Pessoa> GetAllOrderByName()
        {
            return _dbContext.Pessoas.OrderBy(x => x.Nome);
        }

        public async Task<Pessoa> LocalizarPorId(long Id)
        {
            return await _dbContext.Pessoas.FindAsync(Id);
        }

        public async Task<Pessoa> Save(Pessoa entity)
        {
            _dbContext.Pessoas.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Pessoa> Update(Pessoa entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
