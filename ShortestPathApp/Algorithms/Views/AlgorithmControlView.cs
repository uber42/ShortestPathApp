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
using ShortestPathApp.Algorithms.Benchmark;

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
        public long BenchmarkTime
        {
            get
            {
                long result;
                try
                {
                    result = Int64.Parse(ExecutionTimeValueLabel.Text);
                }
                catch
                {
                    result = 0;
                }

                return result;
            }
            set
            {
                ExecutionTimeValueLabel.Text = value.ToString();
            }
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

        private void AlgorithmsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var algorithmComboBox = sender as ComboBox;

            string selected = (string)algorithmComboBox.SelectedItem;

            if(selected == "Алгоритм Дейкстры")
            {
                Presenter?.SetAlgorithm(EShortestPathAlgorithm.Dijkstra);
            }
            else
            {
                Presenter?.SetAlgorithm(EShortestPathAlgorithm.Floyd);
            }
        }

        private void BenchmarkStartButton_Click(object sender, EventArgs e)
        {
            BenchmarkModel benchmark = new BenchmarkModel();

            var result = benchmark.Start((int)benchmarkRepeatsNumber.Value);

            string message = null;
            foreach(var item in result)
            {
                message += $"{item.algorithmName} : {item.lTime} тиков\n";
            }

            MessageBox.Show(Parent, message, "Результаты");
        }
    }
}