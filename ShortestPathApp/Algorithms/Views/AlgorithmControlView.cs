/********************************************************************
	@created:	2020/09/16
	@filename: 	AlgorithmControlView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Algorithms.Interfaces;
using System;
using System.Windows.Forms;
using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.Views.Interfaces;
using ShortestPathApp.MVP;
using System.Collections.Generic;

namespace ShortestPathApp.Algorithms.Views
{
    public partial class AlgorithmControlView : UserControl, IShortestPathControlView
    {
        private int m_nVertexCount;

        public AlgorithmControlView()
        {
            InitializeComponent();

            algorithmsComboBox.SelectedIndex = 0;

            numericUpDown1.Maximum = 1;
            numericUpDown1.Minimum = 1;
        }

        /// <summary>
        /// Количество вершин
        /// </summary>
        public int VertexCount
        {
            get
            {
                return m_nVertexCount;
            }
            set
            {
                m_nVertexCount = value;
                numericUpDown1.Maximum = m_nVertexCount;
                numericUpDown1.Minimum = 1;
            }
        }

        /// <summary>
        /// Презентер
        /// </summary>
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

        private void ExecuteButton_Click(object sender, System.EventArgs e)
        {
            int nBegin = (int)numericUpDown1.Value - 1;

            try
            {
                Presenter?.CalculatePath(nBegin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}