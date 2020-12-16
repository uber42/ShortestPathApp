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

        public void BuildMinPath(int nBegin, int nEndVertex, ref List<int> endPath)
        {
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
        public void Execute(int nBegin, ref List<int> Dist, ref List<int> Paths)
        {
            LastSearch = nBegin;
            if (ParentsMatrix != null)
            {
                Dist = PathsMatrix[nBegin].ToList();
                Paths = ParentsMatrix[nBegin].ToList();

                return;
            }

            ParentsMatrix = new List<List<int>>();
            PathsMatrix = new List<List<int>>();

            var GraphMatrix = Graph.Vertices;

            for(int i = 0;i < GraphMatrix.Count;i++)
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

            Dist = PathsMatrix[nBegin].ToList();
            Paths = ParentsMatrix[nBegin].ToList();
        }

        /// <summary>
        /// Сбросить данные
        /// </summary>
        public void Invalidate()
        {
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
