using ShortestPathApp.Routing.Background;
using ShortestPathApp.Routing.Forms;
using ShortestPathApp.Routing.Interfaces;
using ShortestPathApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathApp.Routing.Algorithms
{
    class LearningTransfer : IRoutingAlgorithm
    {
        /// <summary>
        /// Представление графа (сети)
        /// </summary>
        public IRoutingViewer Graph
        {
            get;
            set;
        }

        /// <summary>
        /// Список пакетов учавствующих в передаче
        /// </summary>
        public ICollection<IPacketControl> Packets
        {
            get;
            set;
        }

        /// <summary>
        /// Поток для выполнения передачи
        /// </summary>
        public BackgroundWorker backgroundWorker
        {
            get;
            set;
        }

        private RoutingTable routingTable;

        public LearningTransfer(IRoutingViewer graph)
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;

            Packets = new List<IPacketControl>();

            Graph = graph;
            backgroundWorker.DoWork += BackgroundRoutine;
            routingTable = new RoutingTable();
        }

        /// <summary>
        /// Обработчик потока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BackgroundRoutine(object sender, DoWorkEventArgs args)
        {
            RoutineArg arg = (RoutineArg)args.Argument;
            List<BackgroundWorker> workers = new List<BackgroundWorker>();

            List<List<int>> Path = new List<List<int>>();
            var matrix = Graph.Vertices;
            for (int i = 0; i < arg.nCountPackets; i++)
            {
                Path.Add(new List<int>());
                Path[i].Add(arg.nBeginNode);
            }

            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int i = 0; i < arg.nCountPackets; i++)
            {
                for (int k = 0; k < arg.nLifeTime; k++)
                {
                    List<int> possibleNext = new List<int>();
                    int currentNode = Path[i][k];

                    for (int j = 0; j < matrix[currentNode].Count; j++)
                    {
                        if (matrix[currentNode][j] > 0)
                        {
                            possibleNext.Add(j);
                        }
                    }

                    int voted = possibleNext[rnd.Next(possibleNext.Count)];
                    currentNode = voted;
                    Path[i].Add(voted);
                    if (voted == arg.nEndNode)
                    {
                        break;
                    }
                }
            }

            for (int i = 0; i < arg.nCountPackets; i++)
            {
                BackgroundWorker bg = new BackgroundWorker();
                bg.WorkerSupportsCancellation = true;
                workers.Add(bg);
                bg.DoWork += (obj, e) =>
                {
                    int currentLevel = (int)e.Argument;
                    for (int j = 0; j < Path[currentLevel].Count - 1; j++)
                    {
                        var function = MathHelper.GetLengthFunction(
                            Graph.Nodes[Path[currentLevel][j]].Location,
                            Graph.Nodes[Path[currentLevel][j + 1]].Location);

                        int counter = 0;
                        while (true)
                        {
                            int distance = Math.Abs(
                                Graph.Nodes[Path[currentLevel][j + 1]].
                                Location.X -
                                Graph.PacketCoords[currentLevel].X +
                                Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius);
                            int distance_y = Math.Abs(
                                Graph.Nodes[Path[currentLevel][j + 1]].
                                Location.Y -
                                Graph.PacketCoords[currentLevel].Y +
                                Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius);
                            if (distance < Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius &&
                                distance_y < Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius)
                            {
                                routingTable.Invoke((MethodInvoker)delegate
                                {
                                    routingTable.SetCell(
                                        Path[currentLevel][j],
                                        Path[currentLevel][j + 1],
                                        j + 1);
                                });
                                break;
                            }

                            counter += 2;
                            Point p = function(counter);
                            Graph.PacketCoords[currentLevel] = p;

                            Thread.Sleep(5);
                        }
                    }


                };

                bg.RunWorkerAsync(i);
                Thread.Sleep(200);
            }

            while (!args.Cancel)
            {
                if (workers.Count != 0 &&
                    !workers[workers.Count - 1].IsBusy)
                {
                    workers[workers.Count - 1].CancelAsync();
                    workers.RemoveAt(workers.Count - 1);
                }

                if (workers.Count == 0)
                {
                    return;
                }

                Graph.Parent.Invoke((MethodInvoker)delegate
                {
                    Graph.Parent.Refresh();
                });
                Thread.Sleep(5);
            }

            for (int i = 0; i < workers.Count; i++)
            {
                workers[i].CancelAsync();
            }
        }

        /// <summary>
        /// Начать маршрутизацию
        /// </summary>
        /// <param name="nBeginNode">Начальный узел</param>
        /// <param name="nEndNode">Конечный узел</param>
        /// <param name="nLifeTime">Время жизни пакетов</param>
        /// <param name="nCountPackets">Количество пакетов</param>
        public void Start(int nBeginNode, int nEndNode, int nLifeTime, int nCountPackets)
        {
            RoutineArg arg = new RoutineArg();
            arg.nBeginNode = nBeginNode;
            arg.nEndNode = nEndNode;
            arg.nLifeTime = nLifeTime;
            arg.nCountPackets = nCountPackets;

            routingTable.SetVertices(Graph.Nodes.Count);
            routingTable.Show();

            for (int i = 0; i < arg.nCountPackets; i++)
            {
                Graph.AddPacket(Graph.Nodes[arg.nBeginNode].Location);
            }

            Graph.StartSendPacket();
            backgroundWorker.RunWorkerAsync(arg);
        }


        /// <summary>
        /// Остановить маршрутизацию
        /// </summary>
        public void Stop()
        {
            backgroundWorker.CancelAsync();

            Graph.PacketCoords.Clear();
            Graph.Packets.Clear();
            routingTable.Hide();
        }
    }
}
