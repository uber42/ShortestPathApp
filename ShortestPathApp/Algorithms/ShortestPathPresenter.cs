/********************************************************************
	@created:	2020/09/23
	@filename: 	ShortestPathPresenter.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortestPathApp.Algorithms.Interfaces;
using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.MVP.Support;
using ShortestPathApp.Algorithms.Dijkstra;
using ShortestPathApp.Algorithms.Floyd;

namespace ShortestPathApp.Algorithms
{
    class ShortestPathPresenter : PresenterBase<IShortestPathPresenter, IShortestPathView>, IShortestPathPresenter
    {
        /// <summary>
        /// Модель графа
        /// </summary>
        private IGraphModel m_cGraph;

        /// <summary>
        /// Модель
        /// </summary>
        private IShortestPathModel m_cModel;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="model">Модель кратчайщего пути</param>
        /// <param name="Graph">Модель графа</param>
        public ShortestPathPresenter(IShortestPathModel model, IGraphModel graph)
        {
            m_cModel = model;
            m_cGraph = graph;

            m_cModel.OnWeightsUpdate += M_cModel_OnPathUpdated;
            m_cModel.OnUpdateGraph += M_cModel_OnUpdateGraph;
        }

        /// <summary>
        /// Посчитать пути
        /// </summary>
        /// <param name="graph">Модель графа</param>
        /// <param name="nBeginVertex">Начальная вершина</param>
        public void CalculatePath(int nBeginVertex)
        {
            m_cModel?.CalculatePath(m_cGraph, nBeginVertex);
        }

        /// <summary>
        /// Установить алгоритм
        /// </summary>
        /// <param name="algorithm">Алгоритм</param>
        public void SetAlgorithm(EShortestPathAlgorithm algorithm)
        {
            IShortestPathAlgorithm algorithmInstance = null;
            switch (algorithm)
            {
                case EShortestPathAlgorithm.Dijkstra:
                    algorithmInstance = new DijkstraModel();
                    break;

                case EShortestPathAlgorithm.Floyd:
                    algorithmInstance = new FloydModel();
                    break;

                default:
                    throw new ArgumentException();
            }

            m_cModel?.SetAlgorithm(algorithmInstance);
        }

        /// <summary>
        /// Собрать путь
        /// </summary>
        /// <param name="paths">Путь</param>
        public void BuildPath(int nEndVertex)
        {
            List<int> lPathOrder = new List<int>();

            m_cModel.BuildMinPath(nEndVertex, ref lPathOrder);
            m_cGraph?.BuildPath(lPathOrder);
        }

        /// <summary>
        /// Получить указатель на себя
        /// </summary>
        /// <returns></returns>
        protected override IShortestPathPresenter GetPresenterEndpoint()
        {
            return this;
        }

        /// <summary>
        /// Обновить данные на представлении
        /// </summary>
        /// <param name="viewInstance">Экземпляр представления</param>
        protected override void RefreshView(IShortestPathView viewInstance)
        {
            if (viewInstance == null)
            {
                throw new ArgumentNullException(nameof(viewInstance));
            }

            SetAlgorithm(EShortestPathAlgorithm.Dijkstra);
        }

        private void M_cModel_OnPathUpdated(object sender, EventArgs e)
        {
            var shortestPathModel = sender as IShortestPathModel;
            this.views
                .ToList()
                .ForEach((view) =>
                {
                    if(view is IShortestPathDataView)
                    {
                        (view as IShortestPathDataView).NodesWeight = shortestPathModel.NodesWeight;
                        (view as IShortestPathDataView).NodesOrder = shortestPathModel.NodesOrder;
                    }
                    else if(view is IShortestPathControlView)
                    {
                        (view as IShortestPathControlView).VertexCount = m_cGraph.Vertices.Count;
                    }
                });
        }


        private void M_cModel_OnUpdateGraph(object sender, EventArgs e)
        {
            var shortestPathModel = sender as IShortestPathModel;
            this.views
                .ToList()
                .ForEach((view) =>
                {
                    if (view is IShortestPathControlView)
                    {
                        (view as IShortestPathControlView).VertexCount = m_cGraph.Vertices.Count;
                    }
                    else if (view is IShortestPathDataView)
                    {
                        (view as IShortestPathDataView).GraphUpdated();
                    }
                });
        }
    }
}
