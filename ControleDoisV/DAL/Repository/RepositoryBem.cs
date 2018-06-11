using DAL.Context;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryBem : IRepository<Bem>
    {
        private C2VContext _dbContext;

        public RepositoryBem(C2VContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Bem> Delete(Bem entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Bem> Delete(long?  Id)
        {
            var entity = await LocalizarPorId((long)Id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<Bem> GetAllOrderByDescricao()
        {
            return _dbContext.Bens.Include(x => x.GrupoBem).OrderBy(x => x.Descricao);
        }

        public async Task<Bem> LocalizarPorId(long Id)
        {
            return await _dbContext.Bens.FindAsync(Id);
        }

        public async Task<Bem> Save(Bem entity)
        {
            _dbContext.Bens.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Bem> Update(Bem entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
