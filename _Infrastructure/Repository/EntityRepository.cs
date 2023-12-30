using Academia.GestionInventario.WebApi._Infrastructure;
using System.Linq.Expressions;

namespace Academia.Transporte.WebApi._Infrastructure.Repository
{
    public class EntityRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly GestionInventarioDbContext _context;
        public EntityRepository(GestionInventarioDbContext context)
        {
            _context = context;
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public TEntity? FirstOrDefault(Expression<Func<TEntity, bool>> query)
        {
            return _context.Set<TEntity>().FirstOrDefault();
        }

        public List<TEntity> Where(Expression<Func<TEntity, bool>> query)
        {
            return _context.Set<TEntity>().Where(query).ToList();
        }
    }
}
