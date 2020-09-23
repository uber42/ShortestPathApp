/********************************************************************
	@created:	2020/09/16
	@filename: 	IGraphReader.cs
	@author:	Pavel Chursin
*********************************************************************/

using System.Collections.Generic;

namespace ShortestPathApp.Graph.Interfaces
{
    public interface IGraphReader
    {
        /// <summary>
        /// Стратегия чтения графа
        /// </summary>
        /// <returns></returns>
        List<List<int>> ReadGraph();
    }
}