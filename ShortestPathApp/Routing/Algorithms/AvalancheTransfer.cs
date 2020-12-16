using ShortestPathApp.Routing.Background;
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
    /// <summary>
    /// Структура данных о перемещении пакета
    /// </summary>
    struct NodeTransferData
    {
        /// <summary>
        /// Текущий узел
        /// </summary>
        public int currentNode;

        /// <summary>
        /// Следующий узел
        /// </summary>
        public int nextNode;

        /// <summary>
        /// Оставшееся время жизни для пакета
        /// </summary>
        public int lifeTime;

        /// <summary>
        /// Номер пакета
        /// </summary>
        public int packetNumber;

        /// <summary>
        /// Объект блокировки критической секции
        /// </summary>
        public object locker;

        /// <summary>
        /// Блокировка для работы с объектами графа
        /// </summary>
        public object graphLocker;

        /// <summary>
        /// Конечный узел доставки
        /// </summary>
        public int endNode;
    }

    class AvalancheTransfer : IRoutingAlgorithm
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

        /// <summary>
        /// Список потоков для обработки перемещения пакетов
        /// </summary>
        private List<BackgroundWorker> workers;

        public AvalancheTransfer(IRoutingViewer graph)
        {
            backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerSupportsCancellation = true;

            Packets = new List<IPacketControl>();

            Graph = graph;
            backgroundWorker.DoWork += BackgroundRoutine;
            workers = new List<BackgroundWorker>();
        }

        private List<int> GetAdjacentNodes(int prevNode, int currentNode)
        {
            var matrix = Graph.Vertices;
            List<int> possibleNext = new List<int>();

            for (int j = 0; j < matrix[currentNode].Count; j++)
            {
                if (prevNode != j && matrix[currentNode][j] > 0)
                {
                    possibleNext.Add(j);
                }
            }

            return possibleNext;
        }

        /// <summary>
        /// Обработчик потока
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void BackgroundRoutine(object sender, DoWorkEventArgs args)
        {
            RoutineArg arg = (RoutineArg)args.Argument;

            object locker = new object();
            object graphLocker = new object();

            for (int i = 0; i < arg.nCountPackets; i++)
            {
                var adjNodes = GetAdjacentNodes(-1, arg.nBeginNode);
                if(adjNodes.Count == 0)
                {
                    return;
                }

                for (int j = 0;j < adjNodes.Count;j++)
                {
                    int packetNumber = 0;
                    Graph.Parent.Invoke((MethodInvoker)delegate
                    {
                        Monitor.Enter(graphLocker);

                        Graph.AddPacket(Graph.Nodes[arg.nBeginNode].Location);
                        packetNumber = Graph.Packets.Count - 1;

                        Monitor.Exit(graphLocker);
                    });

                    NodeTransferData transferData;
                    transferData.currentNode = arg.nBeginNode;
                    transferData.endNode = arg.nEndNode;
                    transferData.locker = locker;
                    transferData.nextNode = adjNodes[j];
                    transferData.packetNumber = packetNumber;
                    transferData.lifeTime = arg.nLifeTime;
                    transferData.graphLocker = graphLocker;

                    BackgroundWorker bg = new BackgroundWorker();
                    bg.WorkerSupportsCancellation = true;
                    workers.Add(bg);
                    bg.DoWork += PacketTransferRoutine;
                    bg.RunWorkerAsync(transferData);
                }

                Thread.Sleep(200);
            }

            while (!args.Cancel)
            {
                try
                {
                    if (workers.Count != 0 &&
                        !workers[workers.Count - 1].IsBusy)
                    {
                        workers[workers.Count - 1].CancelAsync();
                    }

                    if (workers.Count == 0)
                    {
                        return;
                    }
                }
                finally
                {
                    Graph.Parent.Invoke((MethodInvoker)delegate
                    {
                        Graph.Parent.Refresh();
                    });
                    Thread.Sleep(5);
                }
            }

            for (int i = 0; i < workers.Count; i++)
            {
                workers[i].CancelAsync();
            }
        }

        private void PacketTransferRoutine(object sender, DoWorkEventArgs args)
        {
            NodeTransferData transferData = (NodeTransferData)args.Argument;
            var function = MathHelper.GetLengthFunction(
                            Graph.Nodes[transferData.currentNode].Location,
                            Graph.Nodes[transferData.nextNode].Location);

            int counter = 0;
            while (true)
            {
                int distance = Math.Abs(
                    Graph.Nodes[transferData.nextNode].
                    Location.X -
                    Graph.PacketCoords[transferData.packetNumber].X +
                    Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius);
                int distance_y = Math.Abs(
                    Graph.Nodes[transferData.nextNode].
                    Location.Y -
                    Graph.PacketCoords[transferData.packetNumber].Y +
                    Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius);
                if (distance < Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius &&
                    distance_y < Configuration.ms_nGraphNodeRadius - Configuration.ms_nPacketRadius)
                {
                    transferData.lifeTime--;

                    if (transferData.nextNode == transferData.endNode)
                    {
                        return;
                    }

                    Graph.Parent.Invoke((MethodInvoker)delegate
                    {
                        Graph.Packets[transferData.packetNumber].Hide();
                    });

                    if (transferData.lifeTime == 0)
                    {
                        return;
                    }
                    
                    var adjNodes = GetAdjacentNodes(
                        transferData.currentNode, transferData.nextNode);
                    if(adjNodes.Count == 0)
                    {
                        return;
                    }

                    transferData.currentNode = transferData.nextNode;

                    for (int i = 0;i < adjNodes.Count;i++)
                    {
                        int packetNumber = 0;
                        Graph.Parent.Invoke((MethodInvoker)delegate
                        {
                            Monitor.Enter(transferData.graphLocker);

                            Graph.AddPacket(Graph.Nodes[transferData.currentNode].Location);
                            packetNumber = Graph.Packets.Count - 1;

                            Monitor.Exit(transferData.graphLocker);
                        });

                        transferData.nextNode = adjNodes[i];
                        transferData.packetNumber = packetNumber;

                        BackgroundWorker bg = new BackgroundWorker();
                        bg.WorkerSupportsCancellation = true;

                        Monitor.Enter(transferData.locker);
                        workers.Add(bg);
                        Monitor.Exit(transferData.locker);

                        bg.DoWork += PacketTransferRoutine;
                        bg.RunWorkerAsync(transferData);
                    }

                    break;
                }

                counter += 2;
                Point p = function(counter);
                Graph.PacketCoords[transferData.packetNumber] = p;

                Thread.Sleep(5);
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
