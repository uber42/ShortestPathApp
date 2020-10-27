/********************************************************************
	@created:	2020/09/19
	@filename: 	ShortestPathModel.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortestPathApp.Algorithms.Interfaces;
using ShortestPathApp.Graph.Interfaces;

namespace ShortestPathApp.Algorithms
{
    class ShortestPathModel : IShortestPathModel
    {
        private List<int> m_lNodesOrder;
        private List<int> m_lNodesWeight;

        /// <summary>
        /// Экземпляр модели алгоритма
        /// </summary>
        public IShortestPathAlgorithm Algorithm
        {
            get;
            private set;
        }

        /// <summary>
        /// Путь найденный алгоритмом
        /// </summary>
        public List<int> NodesOrder
        {
            get
            {
                return m_lNodesOrder;
            }
        }

        /// <summary>
        /// Список путей
        /// </summary>
        public List<int> NodesWeight
        {
            get
            {
                return m_lNodesWeight;
            }
        }

        /// <summary>
        /// Событие обновления пути
        /// </summary>
        public event EventHandler OnWeightsUpdate;

        /// <summary>
        /// Событие обновления графа
        /// </summary>
        public event EventHandler OnUpdateGraph;

        /// <summary>
        /// Событие обновления времени исполнения
        /// </summary>
        public event EventHandler<long> OnBenchmarkTimeUpdate;

        /// <summary>
        /// Конструктор
        /// </summary>
        public ShortestPathModel()
        {
            m_lNodesOrder = new List<int>();
            m_lNodesWeight = new List<int>();
        }

        /// <summary>
        /// Инвалидировать списки
        /// </summary>
        private void InvalidateLists()
        {
            NodesOrder.Clear();
            NodesWeight.Clear();
        }

        /// <summary>
        /// Вычислить путь
        /// </summary>
        /// <param name="graph">Модель графа</param>
        /// <param name="nBeginVertex">Начальная вершина</param>
        public void CalculatePath(IGraphModel graph, int nBeginVertex)
        {
            InvalidateLists();

            Algorithm.Graph = graph;
            long BenchmarkTime = Algorithm.Execute(nBeginVertex, ref m_lNodesWeight, ref m_lNodesOrder);

            OnBenchmarkTimeUpdate?.Invoke(this, BenchmarkTime);
            OnWeightsUpdate?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Вычислить последовательность обхода вершин
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="nEndVertex"></param>
        /// <param name="endPath"></param>
        public void BuildMinPath(int nEndVertex, ref List<int> endPath)
        {
            Algorithm.BuildMinPath(nEndVertex, ref endPath);
        }

        /// <summary>
        /// Установить алгоритм
        /// </summary>
        /// <param name="algorithm">Модель алгоритма</param>
        public void SetAlgorithm(IShortestPathAlgorithm algorithm)
        {
            Algorithm = algorithm;
        }

        /// <summary>
        /// Обновить представления из презентера графа
        /// </summary>
        public void UpdateFromGraph()
        {
            OnUpdateGraph?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Инвалидировать данные алгоритма
        /// </summary>
        public void InvalidateAlgorithmData()
        {
            Algorithm.Invalidate();
        }
    }
}
