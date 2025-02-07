﻿using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class StokRepository : EntityReposiyoryBase<Stok, AppIdentityDbContext>, IStokRepository
    {
        public List<Stok> GetAllIncluded(Expression<Func<Stok, bool>> filter = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Stok>().Where("IsDeleted == false")
                    .Include("FiyatListesi")
                    .Include("Birim")
                    .Include("StokHarekets")
                    .ToList().ToList()
                    : context.Set<Stok>().Where("IsDeleted == false").Where(filter)
                    .Include("Birim")
                    .Include("FiyatListesi")

                    .Include("StokHarekets")

                    .ToList();
                return entities;
            }
        }

        public List<Stok> GetAllIncludedPagination(Expression<Func<Stok, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Stok>().Where("IsDeleted == false")
                    .Include("StokHarekets")
                    .Include("StokHarekets.FaturaBaslık")
                    .Include("StokHarekets.FaturaBaslık.FaturaDetays")
                    .Include("Birim")
                    .Include("FiyatListesi")
                    .Where(o =>
                    search == null ? o.StokAdı == o.StokAdı :
                    o.StokAdı.ToLower().Contains(search.ToLower())
                    )
                    .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList()
                    : context.Set<Stok>().Where("IsDeleted == false").Where(filter)
                    .Include("StokHarekets")
                      .Include("StokHarekets.FaturaBaslık")
                    .Include("StokHarekets.FaturaBaslık.FaturaDetays")
                    .Include("Birim")
                    .Include("FiyatListesi")
                    .Where(o =>
                    search == null ? o.StokAdı == o.StokAdı :
                    o.StokAdı.ToLower().Contains(search.ToLower())
                    )
                     .ToList().Skip(Convert.ToInt32(offset)).Take(Convert.ToInt32(Convert.ToInt32(limit) == 0 ? int.MaxValue : limit)).ToList();
                return entities;
            }
        }


        public int GetAllIncludedPaginationCount(Expression<Func<Stok, bool>> filter = null, string offset = null, string limit = null, string search = null)
        {
            using (var context = new AppIdentityDbContext())
            {
                var entities = filter == null
                    ? context.Set<Stok>().Where("IsDeleted == false").ToList().Count()
                    : context.Set<Stok>().Where("IsDeleted == false").Where(filter).ToList().Count();
                return entities;
            }
        }
    }
}
