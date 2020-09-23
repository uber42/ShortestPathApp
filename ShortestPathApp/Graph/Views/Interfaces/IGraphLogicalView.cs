using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Graph.Views.Interfaces
{
    interface IGraphLogicalView : IGraphDataView
    {
        /// <summary>
        /// Построить минимальный путь
        /// </summary>
        /// <param name="path">Путь</param>
        void BuildPath(List<int> path);
    }
}
