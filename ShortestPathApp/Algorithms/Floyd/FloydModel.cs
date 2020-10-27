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
        /// <summary>
        /// Модель графа
        /// </summary>
        public IGraphModel Graph
        {
            get;
            set;
        }

        /// <summary>
        /// Пути
        /// </summary>
        private List<List<int>> PathsMatrix
        {
            get;
            set;
        }

        /// <summary>
        /// Матрица предков
        /// </summary>
        private List<List<int>> ParentsMatrix
        {
            get;
            set;
        }

        private int LastSearch
        {
            get;
            set;
        }

        private long LastTimeExecution
        {
            get;
            set;
        }

        public void BuildMinPath(int nEndVertex, ref List<int> endPath)
        {
            int nBegin = LastSearch;
            while (nBegin != nEndVertex)
            {
                endPath.Add(nBegin);
                nBegin = ParentsMatrix[nBegin][nEndVertex];
            }

            endPath.Add(nBegin);
        }

        /// <summary>
        /// Выполнить алгоритм
        /// </summary>
        /// <param name="nBegin">Начальная вершина</param>
        /// <param name="Dist">Список расстояний</param>
        /// <param name="Paths">Список путей</param>
        /// <returns>Время исполнения</returns>
        public long Execute(int nBegin, ref List<int> Dist, ref List<int> Paths)
        {
            LastSearch = nBegin;
            if (ParentsMatrix != null)
            {
                Dist = PathsMatrix[nBegin].ToList();
                Paths = ParentsMatrix[nBegin].ToList();

                return LastTimeExecution;
            }

            ParentsMatrix = new List<List<int>>();
            PathsMatrix = new List<List<int>>();

            var GraphMatrix = Graph.Vertices;
            int nVertices = Graph.Vertices.Count;

            for (int i = 1; i < nVertices; i++)
            {
                int currentVertex = -1;
                int shortestDistance = int.MaxValue;
                for (int j = 0; j < nVertices; j++)
                {
                    if (GraphMatrix[i][j] != 0 && GraphMatrix[i][j] < shortestDistance)
                    {
                        currentVertex = j;
                        shortestDistance = GraphMatrix[i][j];
                    }
                }

                if (currentVertex == -1)
                {
                    throw new Exception("Неверная матрица");
                }
            }

            for (int i = 0;i < GraphMatrix.Count;i++)
            {
                ParentsMatrix.Add(new List<int>());
                PathsMatrix.Add(new List<int>());

                for(int j = 0;j < GraphMatrix.Count;j++)
                {
                    ParentsMatrix[i].Add(j);
                    if (GraphMatrix[i][j] != 0 || i == j)
                    {
                        PathsMatrix[i].Add(GraphMatrix[i][j]);
                    }
                    else
                    {
                        PathsMatrix[i].Add(int.MaxValue);
                    }
                }
            }

            DateTime start = DateTime.Now;
            
            for (int k = 0; k < GraphMatrix.Count; k++)
            {
                for (int i = 0; i < GraphMatrix.Count; i++)
                {
                    for (int j = 0; j < GraphMatrix.Count; j++)
                    {
                        if (PathsMatrix[i][k] < int.MaxValue && PathsMatrix[k][j] < int.MaxValue)
                        {
                            long lTemp = (long)PathsMatrix[i][k] + (long)PathsMatrix[k][j];

                            if (lTemp < (long)PathsMatrix[i][j])
                            {
                                PathsMatrix[i][j] = (int)lTemp;

                                ParentsMatrix[i][j] = ParentsMatrix[i][k];
                            }
                        }
                    }
                }
            }

            DateTime end = DateTime.Now;

            LastTimeExecution = (end - start).Ticks;

            Dist = PathsMatrix[nBegin].ToList();
            Paths = ParentsMatrix[nBegin].ToList();

            return LastTimeExecution;
        }

        public long Benchmark()
        {
            long lTotalTime = 0;

            List<int> mockList = null;
            lTotalTime = this.Execute(0, ref mockList, ref mockList);

            return lTotalTime;
        }

        /// <summary>
        /// Сбросить данные
        /// </summary>
        public void Invalidate()
        {
            if(ParentsMatrix == null)
            {
                return;
            }

            for(int i = 0;i < ParentsMatrix.Count;i++)
            {
                ParentsMatrix[i].Clear();
                PathsMatrix[i].Clear();
            }

            PathsMatrix.Clear();
            ParentsMatrix.Clear();

            ParentsMatrix = null;
            PathsMatrix = null;
        }
    }
}
