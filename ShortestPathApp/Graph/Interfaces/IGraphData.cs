/********************************************************************
	@created:	2020/09/22
	@filename: 	IGraphData.cs
	@author:	Pavel Chursin
*********************************************************************/

using System.Collections.Generic;

namespace ShortestPathApp.Graph.Interfaces
{
    public interface IGraphData
    {
        /// <summary>
        /// Матрица весов графа
        /// </summary>
        List<List<int>> Vertices
        {
            get;
            set;
        }
    }
}