using ShortestPathApp.Graph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathApp.Routing.Forms
{
    public partial class RoutingTable : Form
    {
        private GraphModel graph;
        private GraphPresenter presenter;

        public RoutingTable()
        {
            InitializeComponent();

            graph = new GraphModel();
            presenter = new GraphPresenter(graph, null);

            graphMatrixView1.AttachToPresenter(presenter, true);
        }

        private void RoutingTable_Load(object sender, EventArgs e)
        {

        }

        public void SetVertices(int size)
        {
            graph.Initialize(size);
            graphMatrixView1.Vertices = graph.Vertices;
        }

        public void DropTable()
        {
            int count = graphMatrixView1.Vertices.Count;
            for (int i = 0; i < count; i++)
            {
                graph.RemoveVertex(0);
            }
        }

        public void SetCell(int x, int y, int lifetime)
        {
            int currentValue = graph.Vertices[x][y];
            if(currentValue == 0)
            {
                currentValue = Int32.MaxValue;
            }

            graph.SetEdge(x, y, Math.Min(
                lifetime, currentValue));
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DropTable();
        }
    }
}
