
using Microsoft.EntityFrameworkCore;
using MS2Api.Data;
using System.Linq.Expressions;

namespace Admin.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyContext _context;
        private DbSet<TEntity> _entities;



        public Repository(MyContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _entities.AsNoTracking();
        }


        public TEntity FindByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities
                .AsNoTracking()
                .SingleOrDefault(predicate);
        }

        public IQueryable<TEntity> FindManyByExpression(Expression<Func<TEntity, bool>> predicate)
        {
            return _entities
                .AsNoTracking()
                .Where(predicate);
        }


        public TEntity FindById(int id)
        {
            return _entities.Find(id);
        }

        public void Insert(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _entities.Add(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _context.Entry(entity).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(TEntity entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _entities.Remove(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public void SaveChanges()
        {
            _context.SaveChanges();
        }

    
    }
}
