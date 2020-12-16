/********************************************************************
	@created:	2020/09/16
	@filename: 	GraphPresenter.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Algorithms.Interfaces;
using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.Views.Interfaces;
using ShortestPathApp.MVP.Support;
using System;
using System.Linq;

namespace ShortestPathApp.Graph
{
    internal class GraphPresenter : PresenterBase<IGraphPresenter, IGraphView>, IGraphPresenter
    {
        /// <summary>
        /// Модель графа
        /// </summary>
        private IGraphModel m_cModel;

        /// <summary>
        /// Модель кратчайшего пути
        /// </summary>
        private IShortestPathModel m_cShortestPath;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="model">Модель</param>
        public GraphPresenter(IGraphModel model, IShortestPathModel shortestPath)
        {
            m_cModel = model ??
                throw new ArgumentNullException(nameof(model));

            m_cShortestPath = shortestPath;

            m_cModel.OnUpdateCell += HandleUpdateCell;
            m_cModel.OnUpdateMatrix += HandleUpdateMatrix;
            m_cModel.OnRemoveVertex += HandleRemoveVertex;
            m_cModel.OnAddVertex += HandleAddVertex;

            m_cModel.OnPathBuilt += HandleBuildPath;
        }

        #region Переопределение методов PresenterBase

        /// <summary>
        /// Предоставить ссылку на самого себя
        /// </summary>
        /// <returns>Ссылка на экземпляр класса</returns>
        protected override IGraphPresenter GetPresenterEndpoint()
        {
            return this;
        }

        /// <summary>
        /// Установить значения представления из модели
        /// </summary>
        /// <param name="viewInstance"></param>
        protected override void RefreshView(IGraphView viewInstance)
        {
            if (viewInstance == null)
            {
                throw new ArgumentNullException(nameof(viewInstance));
            }

            viewInstance.Vertices = m_cModel.Vertices;
            m_cShortestPath?.UpdateFromGraph();
        }

        #endregion Переопределение методов PresenterBase

        #region Обработчики событий порядка модель->представления

        /// <summary>
        /// Обработчик события изменения модели графа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleUpdateMatrix(object sender, EventArgs e)
        {
            m_cModel = sender as IGraphModel;
            lock (views)
            {
                views
                .ToList()
                .ForEach((x) =>
                {
                    x.UpdateView();
                });
            }

            m_cShortestPath?.UpdateFromGraph();
        }

        /// <summary>
        /// Обработчик события изменения модели графа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleAddVertex(object sender, EventArgs e)
        {
            lock (views)
            {
                views
                .ToList()
                .ForEach((x) =>
                {
                    if (x is IGraphDataView)
                    {
                        (x as IGraphDataView).AddVertex();
                    }
                });
            }

            m_cShortestPath?.UpdateFromGraph();
        }

        /// <summary>
        /// Обработчик события обновления клетки матрицы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="edge"></param>
        private void HandleUpdateCell(object sender, Tuple<int, int> edge)
        {
            lock (views)
            {
                views
                .ToList()
                .ForEach((x) =>
                {
                    if (x is IGraphDataView)
                    {
                        (x as IGraphDataView).SetEdge(edge.Item1, edge.Item2, m_cModel.Vertices[edge.Item1][edge.Item2]);
                    }
                });
            }

            m_cShortestPath?.UpdateFromGraph();
        }

        /// <summary>
        /// Обработчик события удаления вершины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="nVertex">Номер вершины</param>
        private void HandleRemoveVertex(object sender, int nVertex)
        {
            views
                .ToList()
                .ForEach((x) =>
                {
                    if (x is IGraphDataView)
                    {
                        (x as IGraphDataView).RemoveVertex(nVertex);
                    }
                });

            m_cShortestPath?.UpdateFromGraph();
        }

        private void HandleBuildPath(object sender, System.Collections.Generic.List<int> e)
        {
            views
                .ToList()
                .ForEach((x) =>
                {
                    if (x is IGraphLogicalView)
                    {
                        (x as IGraphLogicalView).BuildPath(e);
                    }
                });
        }

        #endregion Обработчики событий порядка модель->представления

        #region Обработчики порядка представления->модель

        /// <summary>
        /// Установить новый вес между вершинами графа
        /// </summary>
        /// <param name="nFirstVertex">Номер первой вершины</param>
        /// <param name="nSecondVertex">Номер второй вершины</param>
        /// <param name="nWeight">Вес ребра</param>
        public void SetEdge(int nFirstVertex, int nSecondVertex, int nWeight)
        {
            m_cModel?.SetEdge(nFirstVertex, nSecondVertex, nWeight);
            m_cShortestPath?.InvalidateAlgorithmData();
        }

        /// <summary>
        /// Чтение графа
        /// </summary>
        /// <param name="reader">Стратегия</param>
        public void ReadGraph(IGraphReader reader)
        {
            m_cModel?.ReadGraph(reader);
            m_cShortestPath?.InvalidateAlgorithmData();
        }

        /// <summary>
        /// Добавить вершину
        /// </summary>
        public void AddVertex()
        {
            m_cModel?.AddVertex();
            m_cShortestPath?.InvalidateAlgorithmData();
        }

        /// <summary>
        /// Удалить вершину
        /// </summary>
        /// <param name="nVertex">Номер вершины</param>
        public void RemoveVertex(int nVertex)
        {
            m_cModel?.RemoveVertex(nVertex);
            m_cShortestPath?.InvalidateAlgorithmData();
        }

        #endregion Обработчики порядка представления->модель
    }
}