using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Scout.UI
{
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles the expression and gets return value
        /// </summary>
        /// <typeparam name="T">Type of return value</typeparam>
        /// <param name="lambda">Expression to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda)
        {
            return lambda.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying property's value to the given value
        /// from an expression that contains that property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambda">The expression</param>
        /// <param name="value">The value to set</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            // converts a lambda () => some.Property to some.Property
            var expression = (lambda as LambdaExpression).Body as MemberExpression;

            // Get property info so that we could set it
            var propertyInfo = (PropertyInfo)expression.Member;
            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Set the property value
            propertyInfo.SetValue(target, value);
        }
    }
}
