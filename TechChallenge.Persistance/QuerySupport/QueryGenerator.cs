using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TechChallenge.Persistance.QuerySupport
{
    public static class QueryGenerator
    {
        public static Expression<Func<T, bool>> GenerateQueryByFilter<T>(
            T entityFilter,
            List<string>? attributesToIgnore = null,
            bool useLikeOperationInStrings = false,
            bool considerNullAttributes = false)
        {
            attributesToIgnore ??= [];

            var parameter = CreateParameterExpression<T>();

            var finalExpression = BuildConditions(entityFilter, attributesToIgnore, useLikeOperationInStrings, considerNullAttributes, parameter);

            if (finalExpression == null)
                return e => true;

            return Expression.Lambda<Func<T, bool>>(finalExpression, parameter);
        }

        private static ParameterExpression CreateParameterExpression<T>()
        {
            var entityType = typeof(T);
            return Expression.Parameter(entityType, entityType.Name[0].ToString().ToLower());
        }

        private static Expression? BuildConditions<T>(
            T entityFilter,
            List<string> attributesToIgnore,
            bool useLikeOperationInStrings,
            bool considerNullAttributes,
            ParameterExpression parameter)
        {
            Expression? finalExpression = null;

            foreach (var property in typeof(T).GetProperties())
            {
                if (ShouldIgnoreProperty(attributesToIgnore, property))
                    continue;

                var value = property.GetValue(entityFilter);
                if (ShouldSkipNullProperty(value, considerNullAttributes))
                    continue;

                var condition = GenerateConditionExpression(property, value, parameter, useLikeOperationInStrings);
                finalExpression = CombineExpressions(finalExpression, condition);
            }

            return finalExpression;
        }

        private static bool ShouldIgnoreProperty(List<string> attributesToIgnore, PropertyInfo property)
        {
            return attributesToIgnore.Contains(property.Name, StringComparer.OrdinalIgnoreCase);
        }

        private static bool ShouldSkipNullProperty(object? value, bool considerNullAttributes)
        {
            return value == null && !considerNullAttributes;
        }

        private static Expression? GenerateConditionExpression(
            PropertyInfo property,
            object? value,
            ParameterExpression parameter,
            bool useLikeOperationInStrings)
        {
            var propertyExpression = Expression.Property(parameter, property);

            if (property.PropertyType == typeof(string))
            {
                return GenerateStringCondition(propertyExpression, value, useLikeOperationInStrings);
            }

            if (IsNullableType(property.PropertyType))
            {
                return GenerateNullableCondition(propertyExpression, value, property.PropertyType);
            }

            return GenerateValueTypeCondition(propertyExpression, value);
        }

        private static Expression? GenerateStringCondition(Expression propertyExpression, object? value, bool useLikeOperationInStrings)
        {
            if (value == null) return null;

            if (useLikeOperationInStrings)
            {
                var containsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });
                return Expression.Call(propertyExpression, containsMethod!, Expression.Constant(value));
            }

            return Expression.Equal(propertyExpression, Expression.Constant(value));
        }

        private static BinaryExpression GenerateNullableCondition(Expression propertyExpression, object? value, Type propertyType)
        {
            return Expression.Equal(propertyExpression, Expression.Constant(value, propertyType));
        }

        private static BinaryExpression GenerateValueTypeCondition(Expression propertyExpression, object? value)
        {
            return Expression.Equal(propertyExpression, Expression.Constant(value));
        }

        private static bool IsNullableType(Type type)
        {
            return Nullable.GetUnderlyingType(type) != null;
        }

        private static Expression? CombineExpressions(Expression? finalExpression, Expression? condition)
        {
            if (condition == null)
                return finalExpression;

            return finalExpression == null ? condition : Expression.AndAlso(finalExpression, condition);
        }
    }
}
