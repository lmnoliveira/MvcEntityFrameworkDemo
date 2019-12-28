using System;
using System.Linq.Expressions;

namespace Common.Helpers.Reflection
{
    public class ObjectMembers
    {
        public static string GetMemberName<T, TValue>(Expression<Func<T, TValue>> memberAccess)
        {
            return ((MemberExpression)memberAccess.Body).Member.Name;
        }
    }
}
