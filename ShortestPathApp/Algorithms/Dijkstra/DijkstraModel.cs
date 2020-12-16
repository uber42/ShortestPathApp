/********************************************************************
        	@created:	2020/09/16
        	@filename: 	DijkstraModel.cs
        	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Algorithms.Interfaces;
using ShortestPathApp.Graph.Interfaces;
using System;
using System.Collections.Generic;

namespace ShortestPathApp.Algorithms.Dijkstra
{
    internal class DijkstraModel : IShortestPathAlgorithm
    {
        /// <summary>
        /// Граф
        /// </summary>
        public IGraphModel Graph
        {
            get;
            set;
        }

        public List<int> LastPath
        {
            private set;
            get;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public DijkstraModel()
        {
        }

        /// <summary>
        /// Выполнить алгоритм
        /// </summary>
        /// <param name="nBegin">Начальная вершина</param>
        /// <param name="Dist">Список расстояний до каждой из вершин</param>
        /// <param name="Paths">Список путей</param>
        public void Execute(int nBegin, ref List<int> Dist, ref List<int> Paths)
        {
            int nVertices = Graph.Vertices.Count;
            var Matrix = Graph.Vertices;

            List<int> lDistances = new List<int>();
            List<bool> lVisited = new List<bool>();
            List<int> lPaths = new List<int>();

            for (int i = 0; i < nVertices; i++)
            {
                lDistances.Add(int.MaxValue);
                lVisited.Add(false);
                lPaths.Add(0);
            }

            lDistances[nBegin] = 0;
            lPaths[nBegin] = -1;

            for (int i = 1; i < nVertices; i++)
            {
                int currentVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int j = 0; j < nVertices; j++)
                {
                    if (!lVisited[j] && lDistances[j] < shortestDistance)
                    {
                        currentVertex = j;
                        shortestDistance = lDistances[j];
                    }
                }

                if(currentVertex == -1)
                {
                    throw new Exception("Неверная матрица");
                }

                lVisited[currentVertex] = true;

                for (int j = 0; j < nVertices; j++)
                {
                    int weight = Matrix[currentVertex][j];

                    if (weight > 0 && (shortestDistance + weight) < lDistances[j])
                    {
                        lPaths[j] = currentVertex;
                        lDistances[j] = shortestDistance + weight;
                    }
                }
            }

            Dist.AddRange(lDistances);
            Paths.AddRange(lPaths);

            LastPath = lPaths;
        }

        /// <summary>
        /// Вычислить последовательность обхода вершин
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="nEndVertex"></param>
        /// <param name="endPath"></param>
        public void BuildMinPath(int nEndVertex, ref List<int> endPath)
        {
            if (nEndVertex == -1)
            {
                return;
            }

            BuildMinPath(LastPath[nEndVertex], ref endPath);
            endPath.Add(nEndVertex);
        }

        /// <summary>
        /// Вычислить последовательность обхода вершин
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="nEndVertex"></param>
        /// <param name="endPath"></param>
        public void BuildMinPath(int nBegin, int nEndVertex, ref List<int> endPath)
        {
            List<int> paths = new List<int>();
            List<int> mockList = null;
            this.Execute(nBegin, ref mockList, ref paths);

            BuildMinPathInternal(paths, nEndVertex, ref endPath);
        }

        public void BuildMinPathInternal(List<int> paths, int nEndVertex, ref List<int> endPath)
        {
            if (nEndVertex == -1)
            {
                return;
            }

            BuildMinPath(LastPath[nEndVertex], ref endPath);
            endPath.Add(nEndVertex);
        }

        public void Invalidate()
        {
            return;
        }
    }
}