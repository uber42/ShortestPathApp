/********************************************************************
	@created:	2020/09/16
	@filename: 	GraphReadFromFile.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using System;
using System.Collections.Generic;

namespace ShortestPathApp.Graph.ReadStrategies
{
    internal class GraphReadFromFile : IGraphReader
    {
        /// <summary>
        /// Стратегия чтения графа из файла
        /// </summary>
        /// <returns>Граф</returns>
        public List<List<int>> ReadGraph()
        {
            throw new NotImplementedException();
        }
    }
}