using ShortestPathApp.Dependency;
using ShortestPathApp.Graph.Views;
using ShortestPathApp.Routing.Algorithms;
using ShortestPathApp.Routing.Interfaces;
using System.Windows.Forms;

namespace ShortestPathApp.Routing.Views
{
    public partial class RoutingControl : UserControl
    {
        private IRoutingAlgorithm algorithm;

        public RoutingControl()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, System.EventArgs e)
        {
            IRoutingViewer routingViewer = (IRoutingViewer)((GraphLogicalView)DependencyContainer.
                GetDependency("matrix_logical")).GetPanel();

            if(methodList.SelectedIndex == 1)
            {
                algorithm = new VirtualChannelTransfer(routingViewer);
            }
            else
            {
                if(algorithmList.SelectedIndex == 0)
                {
                    algorithm = new RandomDatagramTransfer(routingViewer);
                }
                else if(algorithmList.SelectedIndex == 1)
                {
                    algorithm = new AvalancheTransfer(routingViewer);
                }
                else
                {
                    algorithm = new LearningTransfer(routingViewer);
                }
            }

            int begin = (int)numericUpDown2.Value - 1;
            int end = (int)numericUpDown1.Value - 1;
            int lifetime = (int)lifetimeCount.Value;
            int count = (int)countNumber.Value;

            algorithm.Start(begin, end, lifetime, count);
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            algorithm.Stop();
        }
    }
}