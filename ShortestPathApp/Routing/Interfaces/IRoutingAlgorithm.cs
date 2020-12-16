using System.Collections.Generic;
using System.ComponentModel;

namespace ShortestPathApp.Routing.Interfaces
{
    enum ETransferAlgorithm
    {
        /// <summary>
        /// Дэйтаграммная передача
        /// </summary>
        Datagram,

        /// <summary>
        /// Передача по виртуальному каналу
        /// </summary>
        VirtualChannel
    }

    enum ERoutingAlgorithm
    {
        /// <summary>
        /// Случайная 
        /// </summary>
        Random,

        /// <summary>
        /// Лавинная
        /// </summary>
        Avalanche,

        /// <summary>
        /// По предыдущему опыту
        /// </summary>
        Experience
    }

    interface IRoutingAlgorithm
    {
        /// <summary>
        /// Представление графа (сети)
        /// </summary>
        IRoutingViewer Graph
        {
            get;
            set;
        }

        /// <summary>
        /// Список пакетов учавствующих в передаче
        /// </summary>
        ICollection<IPacketControl> Packets
        {
            get;
            set;
        }


        /// <summary>
        /// Поток для выполнения передачи
        /// </summary>
        BackgroundWorker backgroundWorker
        {
            get;
            set;
        }

        /// <summary>
        /// Начать маршрутизацию
        /// </summary>
        /// <param name="nBeginNode">Начальный узел</param>
        /// <param name="nEndNode">Конечный узел</param>
        /// <param name="nLifeTime">Время жизни пакетов</param>
        /// <param name="nCountPackets">Количество пакетов</param>
        void Start(int nBeginNode,  int nEndNode, int nLifeTime, int nCountPackets);


        /// <summary>
        /// Остановить маршрутизацию
        /// </summary>
        void Stop();
    }
}