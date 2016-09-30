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
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    p.SetValue(dest, sourceProp.GetValue(source), null);
                }
            }
        }
    }
}