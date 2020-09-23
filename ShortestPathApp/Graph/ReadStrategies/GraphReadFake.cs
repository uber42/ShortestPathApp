/********************************************************************
	@created:	2020/09/16
	@filename: 	GraphReadFake.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using System.Collections.Generic;

namespace ShortestPathApp.Graph.ReadStrategies
{
    internal class GraphReadFake : IGraphReader
    {
        public List<List<int>> ReadGraph()
        {
            List<List<int>> gResult = new List<List<int>>()
            {
                new List<int>() { 0, 10, 0, 0, 0, 0, 3, 6, 12 },
                new List<int>() { 10, 0, 18, 0, 0, 0, 2, 0, 13 },
                new List<int>() { 0, 18, 0, 25, 0, 20, 0, 0, 7 },
                new List<int>() { 0, 0, 25, 0, 5, 16, 4, 0, 0 },
                new List<int>() { 0, 0, 0, 5, 0, 10, 0, 0, 0 },
                new List<int>() { 0, 0, 20, 0, 10, 0, 14, 15, 9 },
                new List<int>() { 0, 2, 0, 4, 0, 14, 0, 0, 24 },
                new List<int>() { 6, 0, 0, 0, 23, 15, 0, 0, 5 },
                new List<int>() { 12, 13, 0, 0, 0, 9, 24, 5, 0 }
            };

            return gResult;
        }
    }
}