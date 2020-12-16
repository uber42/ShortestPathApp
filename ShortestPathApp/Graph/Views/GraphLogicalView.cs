/********************************************************************
	@created:	2020/09/16
	@filename: 	GraphLogicalView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Controls;
using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Views
{
    public partial class GraphLogicalView : UserControl, IGraphLogicalView
    {
        private List<List<int>> Matrix;

        private List<int> m_lMinPath;

        public GraphLogicalView()
        {
            InitializeComponent();

            graphPanel.Vertices = Vertices;
        }

        #region Имплементация интерфейса IView

        /// <summary>
        /// Презентер
        /// </summary>
        public IGraphPresenter Presenter
        {
            get;
            private set;
        }

        /// <summary>
        /// Связать представление с презентером
        /// </summary>
        /// <param name="presenter">Презентер</param>
        /// <param name="requiresInitialState">Нужна ли инициализация представления ?</param>
        public void AttachToPresenter(IGraphPresenter presenter, bool requiresInitialState)
        {
            if (presenter == null)
            {
                throw new ArgumentNullException(nameof(presenter));
            }

            DetatchFromPresenter();

            Presenter = presenter;
            Presenter.ConnectView(this, requiresInitialState);
        }

        /// <summary>
        /// Разорвать связь между текущим презентером и представлением
        /// </summary>
        public void DetatchFromPresenter()
        {
            lock (this)
            {
                if (Presenter != null)
                {
                    Presenter.DisconnectView(this);
                    Presenter = null;
                }
            }
        }

        #endregion Имплементация интерфейса IView

        #region Имплементация интерфейса IGraphView

        /// <summary>
        /// Список вершин графа
        /// </summary>
        public List<List<int>> Vertices
        {
            get
            {
                return Matrix;
            }
            set
            {
                Matrix = value;
                graphPanel.Vertices = Vertices;
            }
        }

        #endregion Имплементация интерфейса IGraphView

        #region Имплементация интерфейса IGraphOperations

        /// <summary>
        /// Обновление представления
        /// </summary>
        public void UpdateView()
        {
            graphPanel.Invalidate();
        }

        /// <summary>
        /// Добавить вершину
        /// </summary>
        public void AddVertex()
        {
            graphPanel.AddVertex();
        }

        /// <summary>
        /// Удалить вершину
        /// </summary>
        /// <param name="nvertex"></param>
        public void RemoveVertex(int nvertex)
        {
            graphPanel.RemoveVertex(nvertex);
        }

        /// <summary>
        /// Установить вес дуги
        /// </summary>
        /// <param name="nvertexFirst">Начальная вершина</param>
        /// <param name="nvertexSecond">Конечная вершина</param>
        /// <param name="nWeight">Вес</param>
        public void SetEdge(int nvertexFirst, int nvertexSecond, int nWeight)
        {
            graphPanel.SetEdge(nvertexFirst, nvertexSecond, nWeight);
        }


        #endregion Имплементация интерфейса IGraphOperations

        /// <summary>
        /// Получить узел графа
        /// </summary>
        /// <param name="index">Номер узла</param>
        /// <returns></returns>
        public NodeGraph GetGraphNodeAt(int index)
        {
            if(graphPanel.Nodes.Count <= index)
            {
                throw new Exception();
            }

            return graphPanel.Nodes[index];
        }

        public IGraphControl GetPanel()
        {
            return graphPanel;
        }


        public void BuildPath(List<int> path)
        {
            graphPanel.SetMinPath(path);
        }
    }
}