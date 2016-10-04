using System;
using System.Linq;

namespace TinyTwoProjectManager.Models.Extensions
{
    public static class ObjectExtensions
    {
        // Copies all non-null properties.
        public static void CopyPropertiesTo<T1, T2>(this T1 source, T2 dest)
        {
            var sourceProps = typeof(T1)
                .GetProperties()
                .Where(p => p.CanRead && p.GetValue(source) != null)
                .ToList();

            var destProps = typeof(T2)
                .GetProperties()
                .Where(x => x.CanWrite)
                .ToList();

            foreach (var sourceProp in sourceProps)
            {
                var destProp = destProps.FirstOrDefault(dp => dp.Name == sourceProp.Name);
                if (destProps != null)
                {
                    // Add unit tests for specific conditions
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    var value = sourceProp.GetValue(source);
                    DateTime dateValue;

                    if (destProp.PropertyType == typeof(DateTime?))
                    {
                        if (DateTime.TryParse(value.ToString(), out dateValue))
                        {
                            p.SetValue(dest, dateValue, null);
                        }

                        else
                        {
                            p.SetValue(dest, null, null);
                        }
                    }

                    else
                    {
                        p.SetValue(dest, value, null);
                    }
                }
            }
        }
    }
}