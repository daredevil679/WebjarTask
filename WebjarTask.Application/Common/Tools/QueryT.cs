using ErrorOr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebjarTask.Application.Common.Tools
{
    public static class QueryT<T> where T : class
    {
        #region Errors
        public static Error NotFound => Error.Validation(
            code: "PEQuery.NotFound",
            description: "field not found");
        #endregion
        public static ErrorOr<Expression<Func<T, object>>> GetExpressionWithString(string property)
        {
            try
            {
                property = property.Replace(" ", "").Trim();
                Expression<Func<T, object>> order = u => true;
                if (!string.IsNullOrEmpty(property))
                {
                    var props = typeof(T).GetProperties();
                    string propertyname = "";
                    foreach (var prop in props)
                    {
                        if (prop.Name.ToLowerInvariant() == property.ToLowerInvariant())
                        {
                            propertyname = prop.Name;
                            continue;
                        }
                    }
                    if (!string.IsNullOrEmpty(propertyname))
                    {
                        Type entityType = typeof(T);
                        PropertyInfo propertyInfo = entityType.GetProperty(propertyname);
                        ParameterExpression parameterExpression = Expression.Parameter(entityType, propertyname);

                        var t = Expression.Lambda<Func<T, object>>(
                            Expression.Property(parameterExpression, propertyInfo),
                            parameterExpression
                        );
                        order = t;
                    }
                }
                return order;
            }
            catch (Exception)
            {
                return NotFound;
            }

        }
    }
}
