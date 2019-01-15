using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Core.DataService
{
    public class EntityContextFactoryDataService<TEntity> : IEntityDataService<TEntity> where TEntity : class, new()
    {
        protected readonly IDesignTimeDbContextFactory<DbContext> DbContextFactory;
        protected readonly string[] Args;

        public EntityContextFactoryDataService(IDesignTimeDbContextFactory<DbContext> dbContextFactory)
        {
            DbContextFactory = dbContextFactory;
            Args = new[] {""};
        }

        public virtual TEntity GetById<TId>(TId id)
        {
            using (var ctx = DbContextFactory.CreateDbContext(Args))
            {
                return ctx.Find<TEntity>(id);
            }
        }

        public virtual TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> criteria)
        {
            using (var ctx = DbContextFactory.CreateDbContext(Args))
            {
                return ctx.Set<TEntity>().FirstOrDefault(criteria);
            }
        }

        public virtual IList<TEntity> GetMultiple(Expression<Func<TEntity, bool>> criteria)
        {
            using (var ctx = DbContextFactory.CreateDbContext(Args))
            {
                return ctx.Set<TEntity>().Where(criteria).ToList();
            }
        }

        public virtual IList<TEntity> GetAll()
        {
            using (var ctx = DbContextFactory.CreateDbContext(Args))
            {
                return ctx.Set<TEntity>().ToList();
            }
        }

        public virtual TEntity Add(TEntity entity)
        {
            using (var ctx = DbContextFactory.CreateDbContext(Args))
            {
                var obj = ctx.Add(entity);

                ctx.SaveChanges();

                return obj.Entity;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            using (var ctx = DbContextFactory.CreateDbContext(Args))
            {
                var obj = ctx.Update(entity);

                ctx.SaveChanges();

                return obj.Entity;
            }
        }

        public virtual void Delete(TEntity entity)
        {
            using (var ctx = DbContextFactory.CreateDbContext(Args))
            {
                ctx.Remove(entity);

                ctx.SaveChanges();

            }
        }

    }
}