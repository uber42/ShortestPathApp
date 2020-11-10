using ShortestPathApp.Algorithms;
using ShortestPathApp.Algorithms.Dijkstra;
using ShortestPathApp.Algorithms.Floyd;
using ShortestPathApp.Graph;
using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.ReadStrategies;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathApp.Forms.Main
{
    public partial class BenchmarkForm : Form
    {
        private GraphModel graphFloyd;
        private GraphPresenter presenterFloyd;
        private ShortestPathModel FloydAlgorithml;

        private GraphModel graphDijkstra;
        private GraphPresenter presenterDijkstra;
        private ShortestPathModel dijkstraAlgorithml;

        private GraphModel graphResultDijkstra;
        private GraphModel graphResultFloyd;

        private GraphPresenter presenterResultDijkstra;
        private GraphPresenter presenterResultFloyd;

        private bool bInited;

        public BenchmarkForm()
        {
            InitializeComponent();

            graphFloyd = new GraphModel();
            graphDijkstra = new GraphModel();

            FloydAlgorithml = new ShortestPathModel();
            dijkstraAlgorithml = new ShortestPathModel();

            FloydAlgorithml.SetAlgorithm(new FloydModel());
            dijkstraAlgorithml.SetAlgorithm(new DijkstraModel());

            presenterFloyd = new GraphPresenter(graphFloyd, FloydAlgorithml);
            presenterDijkstra = new GraphPresenter(graphDijkstra, dijkstraAlgorithml);

            presenterFloyd.ConnectView(dijkstraGraphMatrixView, true);
            presenterDijkstra.ConnectView(FloydGraphMatrixView, true);

            graphResultDijkstra = new GraphModel();
            graphResultFloyd = new GraphModel();

            presenterResultDijkstra = new GraphPresenter(graphResultDijkstra, null);
            presenterResultFloyd = new GraphPresenter(graphResultFloyd, null);

            presenterResultDijkstra.ConnectView(graphMatrixView1, true);
            presenterResultFloyd.ConnectView(graphMatrixView2, true);

            bInited = false;
        }

        private void DijkstraBenchmark()
        {
            if(!bInited)
            {
                return;
            }

            dijkstraAlgorithml.Algorithm.Graph = graphDijkstra;
            var result = dijkstraAlgorithml.Algorithm.Benchmark();

            DijkstraTimeExecutionValueLabel.Text = result.Item1.ToString();

            graphResultDijkstra.Vertices = result.Item2;
            graphResultDijkstra.OnUpdate();
        }

        private void FloydBenchmark()
        {
            if (!bInited)
            {
                return;
            }

            FloydAlgorithml.Algorithm.Graph = graphFloyd;
            var result = FloydAlgorithml.Algorithm.Benchmark();

            FloydTimeExecutionValueLabel.Text = result.Item1.ToString();

            graphResultFloyd.Vertices = result.Item2;
            graphResultFloyd.OnUpdate();
        }

        private void DijkstraBenchButton_Click(object sender, EventArgs e)
        {
            DijkstraBenchmark();
        }

        private void FloydBenchButton_Click(object sender, EventArgs e)
        {
            FloydBenchmark();
        }

        private void BothBenchButton_Click(object sender, EventArgs e)
        {
            DijkstraBenchmark();
            FloydBenchmark();
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            IGraphReader graphRead = new GraphReadRandom();

            graphFloyd.ReadGraph(graphRead);
            graphDijkstra.ReadGraph(graphRead);

            bInited = true;
        }
    }
}
