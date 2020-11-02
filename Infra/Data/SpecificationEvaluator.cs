using System.Linq;
using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(
            IQueryable<TEntity> query,
            ISpecification<TEntity> spectication)
        {
            if (spectication.Criteria != null)
            {
                query = query.Where(spectication.Criteria);
            }

            return spectication.Includes
                .Aggregate(query, (current, include) => current.Include(include));
        }
    }
}