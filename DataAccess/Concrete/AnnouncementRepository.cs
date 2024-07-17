using Core.DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.DbContexts;
using Entities.Concrete.OtherEntities;
using Entities.Concrete.VmDtos.AnnouncementDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using Tools.Concrete.HelperTools.BusinessHelpers;
using Tools.Concrete.HelperTools.EntityHelpers;

namespace DataAccess.Concrete
{
    public class AnnouncementRepository : EntityReposiyoryBase<Announcement, AppIdentityDbContext>, IAnnouncementRepository
    {
        public Announcement GetFull(Expression<Func<Announcement, bool>> expression)
        {
            using (var context = new AppIdentityDbContext())
            {
                var x = context.Set<Announcement>()
                    .Include("AnnouncementRoles")
                    .Include("AnnouncementUsers")
                    .Where(expression)
                    .FirstOrDefault();
                return x;
            }
        }

        public List<Announcement> GetWithPagination(FilterQueryStringModel filterQueryStringModel)
        {
            using (var context = new AppIdentityDbContext())
            {
                return context.Set<Announcement>().TableFilter_WithoutSkipping(filterQueryStringModel)
                    .Skip(filterQueryStringModel.Offset)
                    .Take(filterQueryStringModel.Limit).ToList();
            }
        }

        public List<Announcement> GetWithPagination(FilterQueryStringModel model, List<int> filteredIds)
        {
            using (var context = new AppIdentityDbContext())
            {

                IQueryable<Announcement> source = context.Set<Announcement>();

                var elementType = source.ElementType;


                // Get all properys singed the TextSearch Attirebute
                var selectedProps = elementType.CustomAttributes.ToList().Where(o => o.AttributeType.Name == typeof(TextSearchAttribute).Name)
                .Select(a =>
                {
                    ReadOnlyCollection<CustomAttributeTypedArgument> costuctorArgumentsReadOnlyCollection = (ReadOnlyCollection<CustomAttributeTypedArgument>)a.ConstructorArguments.Select(x => x.Value).FirstOrDefault();
                    string[] contructorParams = costuctorArgumentsReadOnlyCollection?.ToArray().Select(x => x.Value.ToString()).ToArray();
                    return contructorParams;
                }).ToList();

                // Get all the string property names on this specific type.
                var stringProperties =
                    elementType.GetProperties()
                        .Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(TextSearchAttribute)) || selectedProps.Exists(o => o.FirstOrDefault() == x.Name))
                        .ToArray();


                // Build the string expression
                string filterExpr = string.Join(
                    " || ",
                    stringProperties.Select(prp => prp.PropertyType == typeof(string) ? $"{prp.Name}.Contains(@0)" : $"{prp.Name}.ToString().Contains(@0)")
                );
                IQueryable<Announcement> TextFilterAfter = source;
                if (model.Search != null)
                {
                    TextFilterAfter = source.Where(filterExpr, model.Search);

                }



                IQueryable<Announcement> AfterFilterAdded = TextFilterAfter;


                if (model.Order != null)
                {
                    AfterFilterAdded = AfterFilterAdded.OrderBy(model.Sort + " " + model.Order);
                }





                AfterFilterAdded = AfterFilterAdded.Where("IsDeleted == false");
                if (model.Offset != 0)
                {
                    AfterFilterAdded = AfterFilterAdded.Skip(model.Offset).Take(model.Limit);
                }

                //Null Users And Roles





                AfterFilterAdded = AfterFilterAdded.Where(o => filteredIds.Any(x => x == o.Id) || o.Type == "1");





                return AfterFilterAdded.ToList();

            }

        }



        public int GetWithPaginationcCount(FilterQueryStringModel model, List<int> filteredIds)
        {
            using (var context = new AppIdentityDbContext())
            {
                IQueryable<Announcement> source = context.Set<Announcement>();

                var elementType = source.ElementType;


                // Get all properys singed the TextSearch Attirebute
                var selectedProps = elementType.CustomAttributes.ToList().Where(o => o.AttributeType.Name == typeof(TextSearchAttribute).Name)
                .Select(a =>
                {
                    ReadOnlyCollection<CustomAttributeTypedArgument> costuctorArgumentsReadOnlyCollection = (ReadOnlyCollection<CustomAttributeTypedArgument>)a.ConstructorArguments.Select(x => x.Value).FirstOrDefault();
                    string[] contructorParams = costuctorArgumentsReadOnlyCollection?.ToArray().Select(x => x.Value.ToString()).ToArray();
                    return contructorParams;
                }).ToList();

                // Get all the string property names on this specific type.
                var stringProperties =
                    elementType.GetProperties()
                        .Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(TextSearchAttribute)) || selectedProps.Exists(o => o.FirstOrDefault() == x.Name))
                        .ToArray();


                // Build the string expression
                string filterExpr = string.Join(
                    " || ",
                    stringProperties.Select(prp => prp.PropertyType == typeof(string) ? $"{prp.Name}.Contains(@0)" : $"{prp.Name}.ToString().Contains(@0)")
                );
                IQueryable<Announcement> TextFilterAfter = source;
                if (model.Search != null)
                {
                    TextFilterAfter = source.Where(filterExpr, model.Search);
                }



                IQueryable<Announcement> AfterFilterAdded = TextFilterAfter;


                if (model.Order != null)
                {
                    AfterFilterAdded = AfterFilterAdded.OrderBy(model.Sort + " " + model.Order);
                }







                AfterFilterAdded = AfterFilterAdded.Where(o => filteredIds.Any(x => x == o.Id) || o.Type == "1");

                return AfterFilterAdded.Count();
            }
        }

        public int GetWithPaginationCount(FilterQueryStringModel filterQueryStringModel)
        {
            using (var context = new AppIdentityDbContext())
            {
                return context.Set<Announcement>().TableFilter_WithoutSkipping(filterQueryStringModel).Count();
            }
        }
    }
}
