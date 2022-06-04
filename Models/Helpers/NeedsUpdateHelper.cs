using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.Helpers
{
    public static class NeedsUpdateHelper
    {

        public static bool NeedsUpdate<T>(T self, T to, params string[] ignore)
        {
            if (self == null && to == null)
                return true;

            if (self == null || to == null)
                return false;

            var type = typeof(T);
            var ignoreList = new List<string>(ignore);
            var unequalProps =
                from pi in type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                where !ignoreList.Contains(pi.Name)
                let selfValue = type.GetProperty(pi.Name).GetValue(self, null)
                let toValue = type.GetProperty(pi.Name).GetValue(to, null)
                where selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue))
                select selfValue;

            return unequalProps.Any();
        }
    }
}
