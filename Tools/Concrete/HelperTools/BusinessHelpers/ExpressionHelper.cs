using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Reflection;
using Tools.Concrete.HelperClasses.BusinessHelpers;
using Tools.Concrete.HelperTools.EntityHelpers;

namespace Tools.Concrete.HelperTools.BusinessHelpers
{
    public static class ExpressionHelper
    {
        public static Expression<Func<T, string>> CreateSelectorExpression<T>(string propertyName)
        {
            var paramterExpression = Expression.Parameter(typeof(T));
            if (propertyName == null)
            {
                return (Expression<Func<T, string>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, "Id"),
                                                                    paramterExpression);
            }
            return (Expression<Func<T, string>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, propertyName),
                                                                    paramterExpression);
        }

        public static IQueryable<T> TextFilter<T>(IQueryable<T> source, string term)
        {
            if (string.IsNullOrEmpty(term)) { return source; }

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
            if (!stringProperties.Any()) { return source; }

            // Build the string expression
            string filterExpr = string.Join(
                " || ",
                stringProperties.Select(prp => prp.PropertyType == typeof(string) ? $"{prp.Name}.Contains(@0)" : $"{prp.Name}.ToString().Contains(@0)")
            );

            return source.Where(filterExpr, term);
        }


        public static IQueryable<T> TableFilter<T>(this DbSet<T> context, FilterQueryStringModel model)
            where T : class
        {

            IQueryable<T> source = context;
            if (model == null) { return source; }

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
            if (!stringProperties.Any()) { return source; }

            // Build the string expression
            string filterExpr = string.Join(
                " || ",
                stringProperties.Select(prp => prp.PropertyType == typeof(string) ? $"{prp.Name}.Contains(@0)" : $"{prp.Name}.ToString().Contains(@0)")
            );
            IQueryable<T> TextFilterAfter = source;
            if (model.Search != null)
            {
                TextFilterAfter = source.Where(filterExpr, model.Search);

            }



            IQueryable<T> AfterFilterAdded = TextFilterAfter;


            if (model.Order != null)
            {
                AfterFilterAdded = AfterFilterAdded.OrderBy(model.Sort + " " + model.Order);
            }




            AfterFilterAdded = AfterFilterAdded.Where("IsDeleted == false");
            if (model.Offset != 0)
            {
                AfterFilterAdded = AfterFilterAdded.Skip(model.Offset).Take(model.Limit);
            }



            //AfterFilterAdded = AfterFilterAdded.Where("Grade.GradeName == \"Ddee\"");


            return AfterFilterAdded;


        }


        public static IQueryable<T> TableFilter_WithoutSkipping<T>(this DbSet<T> context, FilterQueryStringModel model)
            where T : class
        {

            IQueryable<T> source = context;
            if (model == null) { return source; }

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
            if (!stringProperties.Any()) { return source; }

            // Build the string expression
            string filterExpr = string.Join(
                " || ",
                stringProperties.Select(prp => prp.PropertyType == typeof(string) ? $"{prp.Name}.Contains(@0)" : $"{prp.Name}.ToString().Contains(@0)")
            );
            IQueryable<T> TextFilterAfter = source;
            if (model.Search != null)
            {
                TextFilterAfter = source.Where(filterExpr, model.Search);

            }



            IQueryable<T> AfterFilterAdded = TextFilterAfter;


            if (model.Order != null)
            {
                AfterFilterAdded = AfterFilterAdded.OrderBy(model.Sort + " " + model.Order);
            }

            AfterFilterAdded = AfterFilterAdded.Where("IsDeleted == false");




            return AfterFilterAdded;


        }



    }
}
