/********************************************************************
	@created:	2020/09/23
	@filename: 	IShortestPathDataView.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Algorithms.Interfaces
{
    interface IShortestPathDataView : IShortestPathView
    {
        /// <summary>
        /// Порядок узлов для прохождения между двумя вершинами наименьшим путем
        /// </summary>
        List<int> NodesOrder
        {
            get;
            set;
        }

        /// <summary>
        /// Список минимальных расстояний до вершин
        /// </summary>
        List<int> NodesWeight
        {
            get;
            set;
        }

        /// <summary>
        /// Граф обновлен
        /// </summary>
        void GraphUpdated();
    }
}
