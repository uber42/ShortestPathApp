using ShortestPathApp.Graph.Controls;
using ShortestPathApp.Routing.Background;
using ShortestPathApp.Routing.Interfaces;
using ShortestPathApp.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace ShortestPathApp.Routing.Algorithms
{
    class VirtualChannelTransfer : IRoutingAlgorithm
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

        public VirtualChannelTransfer(IRoutingViewer graph)
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;

            Packets = new List<IPacketControl>();

            Graph = graph;
            backgroundWorker.DoWork += BackgroundRoutine;
        }

        /// <summary>
        /// Обработчик потока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BackgroundRoutine(object sender, DoWorkEventArgs args)
        {
            RoutineArg arg = (RoutineArg)args.Argument;
            var Path = arg.Path;
            List<BackgroundWorker> workers = new List<BackgroundWorker>();

            for (int i = 0;i < arg.nCountPackets;i++)
            {
                BackgroundWorker bg = new BackgroundWorker();
                bg.WorkerSupportsCancellation = true;
                workers.Add(bg);
                bg.DoWork += (obj, e) =>
                {
                    int currentLevel = (int)e.Argument;
                    for (int j = 0; j < Path.Count - 1; j++)
                    {
                        var function = MathHelper.GetLengthFunction(
                            Graph.Nodes[Path[j]].Location,
                            Graph.Nodes[Path[j + 1]].Location);

                        int counter = 0;
                        while (true)
                        {
                            int distance = Math.Abs(
                                Graph.Nodes[Path[j + 1]].
                                Location.X -
                                Graph.PacketCoords[currentLevel].X + 
                                Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius);
                            int distance_y = Math.Abs(
                                Graph.Nodes[Path[j + 1]].
                                Location.Y -
                                Graph.PacketCoords[currentLevel].Y +
                                Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius);
                            if (distance < Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius &&
                                distance_y < Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius)
                            {
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

            while(!args.Cancel)
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

            List<int> Path = new List<int>();
            var matrix = Graph.Vertices;
            int currentNode = arg.nBeginNode;
            Random rnd = new Random((int)DateTime.Now.Ticks);
            Path.Add(currentNode);
            for (int i = 0; i < arg.nLifeTime; i++)
            {
                List<int> possibleNext = new List<int>();

                for (int j = 0; j < matrix[currentNode].Count; j++)
                {
                    if (matrix[currentNode][j] > 0)
                    {
                        possibleNext.Add(j);
                    }
                }

                
                int voted = possibleNext[rnd.Next(possibleNext.Count)];
                currentNode = voted;
                Path.Add(voted);
                if (voted == arg.nEndNode)
                {
                    break;
                }
            }

            arg.Path = Path;

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
        }
    }
}