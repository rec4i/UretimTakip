﻿using Entities.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepositoryBase<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity Get(Expression<Func<TEntity, bool>> filter);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        TEntity Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity, bool isCompletelyDelete = false);
        int Count();
        List<TEntity> GetWithTableFilter(FilterQueryStringModel filterQueryStringModel);
        int GetWithTableFilterCount(FilterQueryStringModel filterQueryStringModel);

        List<TEntity> GetAllIncluded(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null);
        List<TEntity> GetAllIncludedPagination(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null, string offset = null, string limit = null, string search = null);
        int GetAllIncludedPaginationCount(Expression<Func<TEntity, bool>> filter = null, string offset = null, string limit = null, string search = null);

    }
}
