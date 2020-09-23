/********************************************************************
	@created:	2020/09/16
	@filename: 	GraphMatrixView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShortestPathApp.Graph.Views
{
    public partial class GraphMatrixView : UserControl, IGraphDataView
    {
        /// <summary>
        /// Граф
        /// </summary>
        private List<List<int>> m_lVertices;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GraphMatrixView()
        {
            InitializeComponent();
            InitializeEvents();
        }

        /// <summary>
        /// Подписки на события
        /// </summary>
        private void InitializeEvents()
        {
            Matrix.CellEndEdit += Matrix_CellValueChanged;
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
                return m_lVertices;
            }
            set
            {
                m_lVertices = value;

                if (m_lVertices != null)
                {
                    Matrix.Rows.Clear();
                    Matrix.Columns.Clear();

                    for (int i = 0; i < m_lVertices.Count; i++)
                    {
                        string columnName = (i + 1).ToString();

                        Matrix.Columns.Add(columnName, columnName);
                        Matrix.Rows.Add();
                    }

                    for (int i = 0; i < m_lVertices.Count; i++)
                    {
                        for (int j = 0; j < m_lVertices.Count; j++)
                        {
                            Matrix.Rows[i].Cells[j].Value = m_lVertices[i][j];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обновление данных представления
        /// </summary>
        public void UpdateView()
        {
            int nDifference = m_lVertices.Count - Matrix.RowCount;
            if (nDifference < 0)
            {
                nDifference = Math.Abs(nDifference);
                for (int i = 0; i < nDifference; i++)
                {
                    RemoveVertex(Matrix.Rows.Count - 1);
                }
            }
            else if (nDifference > 0)
            {
                for (int i = 0; i < nDifference; i++)
                {
                    AddVertex();
                }
            }

            for (int i = 0; i < m_lVertices.Count; i++)
            {
                for (int j = 0; j < m_lVertices.Count; j++)
                {
                    Matrix.Rows[i].Cells[j].Value = m_lVertices[i][j];
                }
            }
        }

        /// <summary>
        /// Добавить вершину
        /// </summary>
        public void AddVertex()
        {
            string columnName = (Matrix.RowCount + 1).ToString();

            Matrix.Columns.Add(columnName, columnName);
            Matrix.Rows.Add();

            int lastIndex = Matrix.RowCount - 1;

            Matrix.Rows[lastIndex].Cells[lastIndex].Value = 0;
            for (int i = 0; i < Matrix.RowCount - 1; i++)
            {
                Matrix.Rows[lastIndex].Cells[i].Value = 0;
                Matrix.Rows[i].Cells[lastIndex].Value = 0;
            }
        }

        /// <summary>
        /// Обновить вес
        /// </summary>
        /// <param name="firstVertex">Первая вершина</param>
        /// <param name="secondVertex">Вторая вершина</param>
        /// <param name="weight">Вес</param>
        public void SetEdge(int firstVertex, int secondVertex, int weight)
        {
            Matrix.Rows[firstVertex].Cells[secondVertex].Value = weight;
        }

        /// <summary>
        /// Удалить вершину
        /// </summary>
        /// <param name="nVertex">Номер вершины</param>
        public void RemoveVertex(int nVertex)
        {
            Matrix.Rows.RemoveAt(nVertex);
            Matrix.Columns.RemoveAt(nVertex);

            UpdateHeaders(nVertex);
        }

        #endregion Имплементация интерфейса IGraphView

        /// <summary>
        /// Обновить заголовки таблицы
        /// </summary>
        /// <param name="nFrom">Начиная с вершины</param>
        private void UpdateHeaders(int nFrom = 0)
        {
            for (int i = nFrom; i < Matrix.Rows.Count; i++)
            {
                string headerValue = (i + 1).ToString();

                Matrix.Rows[i].HeaderCell.Value = headerValue;
                Matrix.Columns[i].HeaderCell.Value = headerValue;
            }
        }

        #region Обработчики событий которые приходят от контролов

        /// <summary>
        /// Обработчик события изменения клетки таблицы весов графа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matrix_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var dataGrid = sender as DataGridView;
            int nWeight = 0;

            try
            {
                nWeight = Int32.Parse(dataGrid[e.ColumnIndex, e.RowIndex].Value.ToString());
            }
            catch
            {
                // TODO: вывести в статус панель на форме
            }
            finally
            {
                Presenter?.SetEdge(e.RowIndex, e.ColumnIndex, nWeight);
            }
        }

        /// <summary>
        /// Обработчик события добавления полей, для заполнения значений по умолчанию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Matrix_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            var cells = e.Row.Cells;
            for (int i = 0; i < cells.Count; i++)
            {
                cells[i].Value = 0;
            }
        }

        #endregion Обработчики событий которые приходят от контролов
    }
}