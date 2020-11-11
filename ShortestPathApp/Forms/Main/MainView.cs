/********************************************************************
	@created:	2020/09/16
	@filename: 	MainView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Algorithms;
using ShortestPathApp.Algorithms.Interfaces;
using ShortestPathApp.Graph;
using ShortestPathApp.Graph.Interfaces;
using System.Windows.Forms;

namespace ShortestPathApp.Forms.Main
{
    public partial class MainView : Form
    {
        private IGraphModel graph;
        private IGraphPresenter graphPresenter;

        private IShortestPathModel shortestPath;
        private IShortestPathPresenter shortestPathPresenter;

        public MainView()
        {
            InitializeComponent();

            GraphControlView.OnMessage += (obj, message) =>
            {
                StripStatus.Text += message;
            };

            graph = new GraphModel(4);
            shortestPath = new ShortestPathModel();

            graphPresenter = new GraphPresenter(graph, shortestPath);
            shortestPathPresenter = new ShortestPathPresenter(shortestPath, graph);

            algorithmControlView1.AttachToPresenter(shortestPathPresenter, true);
            shortestPathView1.AttachToPresenter(shortestPathPresenter, true);

            GraphControlView.AttachToPresenter(graphPresenter, true);
            GraphMatrixView.AttachToPresenter(graphPresenter, true);
            graphLogicalView1.AttachToPresenter(graphPresenter, true);
        }
    }
}