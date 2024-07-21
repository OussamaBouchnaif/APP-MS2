﻿using System.Linq.Expressions;

namespace Admin.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();

        TEntity FindByExpression(Expression<Func<TEntity, bool>> predicate);

        IQueryable<TEntity> FindManyByExpression(Expression<Func<TEntity, bool>> predicate);

        TEntity FindById(int id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void SaveChanges();
    }
}