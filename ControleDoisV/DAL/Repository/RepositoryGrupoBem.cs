using DAL.Context;
using Dominio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class RepositoryGrupoBem : IRepository<GrupoBem>
    {
        private C2VContext _dbContext;

        public RepositoryGrupoBem(C2VContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GrupoBem> Delete(GrupoBem entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<GrupoBem> LocalizarPorId(long Id)
        {
            return await _dbContext.GrupoBens.FindAsync(Id);
        }

        public async Task<GrupoBem> Save(GrupoBem entity)
        {
            _dbContext.GrupoBens.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<GrupoBem> Update(GrupoBem entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<GrupoBem> GetAllOrderByDescricao()
        {
            return _dbContext.GrupoBens.OrderBy(x => x.Descricao);
        }
    }
}
