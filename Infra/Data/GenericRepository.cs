using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public GenericRepository(StoreContext context)
            => _context = context ?? throw new ArgumentNullException();

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<IReadOnlyList<T>> ListAllAsync()
            => await _context.Set<T>().ToListAsync();

        public async Task<T> GetEntityWithSpec(ISpecification<T> specification)
            => await ApplySpecification(specification).FirstOrDefaultAsync();

        public async Task<IReadOnlyList<T>> ListWithSpecAsync(ISpecification<T> specification)
            => await ApplySpecification(specification).ToListAsync();

        public async Task<int> CountAsync(ISpecification<T> specification)
            => await ApplySpecification(specification).CountAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> specification)
            => SpecificationEvaluator<T>.GetQuery(
                _context.Set<T>().AsQueryable(), specification);
    }
}