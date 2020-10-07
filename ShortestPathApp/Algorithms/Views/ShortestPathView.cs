/********************************************************************
	@created:	2020/09/22
	@filename: 	ShortestPathView.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShortestPathApp.Algorithms.Interfaces;

namespace ShortestPathApp.Algorithms.Views
{
    public partial class ShortestPathView : UserControl, IShortestPathDataView
    {
        private List<int> m_lNodesWeights;


        /// <summary>
        /// Конструктор
        /// </summary>
        public ShortestPathView()
        {
            InitializeComponent();
        }

        #region Имплементация интерфейса IShortestPathView
        /// <summary>
        /// Список пути
        /// </summary>
        public List<int> NodesOrder
        {
            get;
            set;
        }

        
        /// <summary>
        /// Список
        /// </summary>
        public List<int> NodesWeight
        {
            get
            {
                return m_lNodesWeights;
            }
            set
            {
                m_lNodesWeights = value;
                if(m_lNodesWeights != null)
                {
                    FillTable();
                }
                
            }
        }

        public IShortestPathPresenter Presenter
        {
            get;
            private set;
        }

        /// <summary>
        /// Подключиться к презентеру
        /// </summary>
        /// <param name="presenter">Презентер</param>
        /// <param name="requiresInitialState">Нужно ли обновление данных с модели для представлния</param>
        public void AttachToPresenter(IShortestPathPresenter presenter, bool requiresInitialState)
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

        #endregion

        /// <summary>
        /// Инвалидировать таблицу весов
        /// </summary>
        private void InvalidateWeightTable()
        {
            weightsTable.Rows.Clear();
            weightsTable.Columns.Clear();
        }

        /// <summary>
        /// Заполнить таблицу
        /// </summary>
        private void FillTable()
        {
            if(weightsTable.ColumnCount != m_lNodesWeights.Count)
            {
                int nCount = m_lNodesWeights.Count;
                InvalidateWeightTable();
                for (int i = 0; i < nCount; i++)
                {
                    string columnName = (i + 1).ToString();
                    weightsTable.Columns.Add(columnName, columnName);
                }
                weightsTable.Rows.Add();
            }
            
            for(int i = 0;i < weightsTable.ColumnCount; i++)
            {
                if(m_lNodesWeights[i] > 0)
                {
                    weightsTable.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.White;
                    weightsTable.Rows[0].Cells[i].Value = m_lNodesWeights[i].ToString();
                }
                else
                {
                    weightsTable.Rows[0].Cells[i].Style.BackColor = System.Drawing.Color.Red;
                    weightsTable.Rows[0].Cells[i].Value = null;
                }
            }
        }

        private void WeightsTable_Click(object sender, EventArgs e)
        {
            var selectedCells = weightsTable.SelectedCells;
            if (selectedCells.Count == 1 && selectedCells[0].Value != null)
            {
                Presenter?.BuildPath(selectedCells[0].ColumnIndex);
            }
        }

        /// <summary>
        /// Граф обновлен
        /// </summary>
        public void GraphUpdated()
        {
            InvalidateWeightTable();
        }
    }
}
