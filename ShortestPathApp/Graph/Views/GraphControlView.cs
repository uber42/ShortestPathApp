/********************************************************************
	@created:	2020/09/16
	@filename: 	GraphControlView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.ReadStrategies;
using ShortestPathApp.Graph.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Views
{
    public partial class GraphControlView : UserControl, IGraphControlView
    {
        private List<List<int>> m_lVertices;

        public GraphControlView()
        {
            InitializeComponent();
        }

        public List<List<int>> Vertices
        {
            get
            {
                return m_lVertices;
            }
            set
            {
                if (value == null)
                {
                    return;
                }

                m_lVertices = value;
                vertexCountValueLabel.Text = m_lVertices.Count.ToString();
                numericUpDown1.Maximum = m_lVertices.Count;
            }
        }

        /// <summary>
        /// Презентер
        /// </summary>
        public IGraphPresenter Presenter
        {
            get;
            private set;
        }

        public event EventHandler<string> OnMessage;

        /// <summary>
        /// Подключиться к презентеру
        /// </summary>
        /// <param name="presenter">Презентер</param>
        /// <param name="requiresInitialState">Нужно ли обновление данных с модели для представлния</param>
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
        /// Отключиться от презентера
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

        /// <summary>
        /// Обновить представление
        /// </summary>
        public void UpdateView()
        {
            vertexCountValueLabel.Text = m_lVertices.Count.ToString();
            numericUpDown1.Maximum = m_lVertices.Count;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку чтения фейкового графа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FakeReadButton_Click(object sender, EventArgs e)
        {
            Presenter?.ReadGraph(new GraphReadFake());
        }

        /// <summary>
        /// Обработчик нажатия на кнопку добавления вершины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVertex_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter?.AddVertex();
                UpdateView();
            }
            catch (Exception ex)
            {
                OnMessage?.Invoke(this, ex.Message);
            }
        }

        /// <summary>
        /// Обработчик кнопки удаления вершины
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveVertex_Click(object sender, EventArgs e)
        {
            Presenter?.RemoveVertex((int)numericUpDown1.Value - 1);
            UpdateView();
        }
    }
}