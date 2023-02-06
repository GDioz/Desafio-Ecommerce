using System.Collections.Generic;
using System.Reflection;

namespace DF.Ecommerce.Api.Assemblies
{
    /// <summary>
    /// Assembly Util
    /// </summary>
    public class AssemblyReflection
    {
        public static IEnumerable<Assembly> GetCurrentAssemblies()
        {
            return new Assembly[]
            {
                Assembly.Load("DF.Ecommerce.Api"),
                Assembly.Load("DF.Ecommerce.Domain"),
                Assembly.Load("DF.Ecommerce.Application"),
                Assembly.Load("DF.Ecommerce.Infrastructure")
            };
        }
    }
}
