using ShortestPathApp.Algorithms.Interfaces;
using ShortestPathApp.Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Algorithms.Floyd
{
    class FloydModel : IShortestPathAlgorithm
    {
        public IGraphModel Graph
        {
            get;
            set;
        }

        public void Execute(int nBegin, ref List<int> Dist, ref List<int> Paths)
        {
            
        }
    }
}
