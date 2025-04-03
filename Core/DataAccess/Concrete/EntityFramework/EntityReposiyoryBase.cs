using Core.DataAccess.Abstract;
using Core.Entities;
using Entities.Abstract;
using Entities.Concrete.BaseEntities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers.Extensions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EntityReposiyoryBase<TEntity, TContext> : IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {

                var addedEntry = context.Entry(entity);
                addedEntry.State = EntityState.Added;
                context.SaveChanges();
                return addedEntry.Entity;
            }
        }
        public void Delete(TEntity entity, bool isCompletelyDelete = false)
        {
            if (isCompletelyDelete)
            {
                using (var context = new TContext())
                {
                    var deleteEntry = context.Entry(entity);
                    deleteEntry.State = EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            else
            {
                using (var context = new TContext())
                {
                    var entityInt = entity as BaseEntity;
                    var removeEntity = context.Set<TEntity>().Find(entityInt.Id) as BaseEntity;
                    removeEntity.IsDeleted = true;
                    removeEntity.UpdateDate = DateTime.Now;
                    var updateEntry = context.Entry(removeEntity);
                    updateEntry.State = EntityState.Modified;
                    context.SaveChanges();
                }
            }
        }
        public void Update(TEntity entity)
        {


            using (var context = new TContext())
            {
                var updateEntry = context.Entry(entity);
                updateEntry.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public int Count()
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().Where("IsDeleted == false").Count();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var entity = context.Set<TEntity>().Where("IsDeleted == false").FirstOrDefault(filter);
                return entity;
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                var entities = filter == null
                    ? context.Set<TEntity>().Where("IsDeleted == false").ToList()
                    : context.Set<TEntity>().Where("IsDeleted == false").Where(filter).ToList();
                return entities;
            }
        }
        public List<TEntity> GetWithTableFilter(FilterQueryStringModel filterQueryStringModel)
        {
            using (var context = new TContext())
            {
                var entities = context.Set<TEntity>().TableFilter(filterQueryStringModel).Where("IsDeleted == false").ToList();
                return entities;
            }
        }
        public int GetWithTableFilterCount(FilterQueryStringModel filterQueryStringModel)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().TableFilter_WithoutSkipping(filterQueryStringModel).Where("IsDeleted == false").Count();
            }
        }
        public List<TEntity> GetAllIncluded(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> queryable = context.Set<TEntity>();
                if (filter != null)
                    queryable = queryable.Where(filter);
                queryable = include(queryable);
                return queryable.Where("IsDeleted == false").ToList();
            }
        }

        public List<TEntity> GetAllIncludedPagination(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new TContext())
            {
                IQueryable<TEntity> queryable = context.Set<TEntity>();
                if (filter != null)
                    queryable = queryable.Where(filter);
                queryable = queryable.Skip(Convert.ToInt32(offset));
                if (include != null)
                    queryable = include(queryable);
                queryable = queryable.Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit));
                return queryable.Where("IsDeleted == false").ToList();
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<TEntity, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new TContext())
            {
                var entities = filter == null
                    ? context.Set<TEntity>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<TEntity>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }


    }
}
