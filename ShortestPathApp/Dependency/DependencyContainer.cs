using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Dependency
{
    static class DependencyContainer
    {
        private static Dictionary<string, object> dependencies;

        static DependencyContainer()
        {
            dependencies = new Dictionary<string, object>();
        }

        public static void AddDependency(string name, object dependency)
        {
            dependencies.Add(name, dependency);
        }

        public static object GetDependency(string name)
        {
            return dependencies[name];
        }
    }
}
