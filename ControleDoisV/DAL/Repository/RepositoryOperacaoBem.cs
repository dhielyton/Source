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
    public class RepositoryOperacaoBem : IRepository<OperacaoBem>
    {
        private C2VContext _dbContext;

        public RepositoryOperacaoBem(C2VContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<OperacaoBem> Delete(OperacaoBem entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<OperacaoBem> Delete(long? Id)
        {
            var entity = await LocalizarPorId((long)Id);
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<OperacaoBem> GetAllOrderByDescricao()
        {
            return null;
        }

        public IQueryable<OperacaoBem> GetAllOrderByName()
        {
            return null;
        }

        public IQueryable<OperacaoBem> GetAllOrderByData()
        {
            return _dbContext.OperacaoBens
                .Include(x => x.Tomador)
                .Include(x => x.Bens)
                .OrderByDescending(x => x.Data);
        }

        public async Task<OperacaoBem> LocalizarPorId(long Id)
        {
            return await _dbContext.OperacaoBens.Include(x => x.Tomador)
                .Include(x => x.Bens).SingleAsync(x => x.OperacaoBemID == Id);
        }

        public async Task<OperacaoBem> Save(OperacaoBem entity)
        {
            _dbContext.OperacaoBens.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<OperacaoBem> Update(OperacaoBem entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
