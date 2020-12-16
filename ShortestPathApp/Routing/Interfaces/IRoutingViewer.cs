using ShortestPathApp.Graph.Controls;
using ShortestPathApp.Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathApp.Routing.Interfaces
{
    interface IRoutingViewer
    {
        /// <summary>
        /// Матрица инцедентности
        /// </summary>
        List<List<int>> Vertices
        {
            get;
            set;
        }

        List<NodeGraph> Nodes
        {
            get;
            set;
        }

        /// <summary>
        /// Пакеты передаваемые по сети
        /// </summary>
        List<PacketControl> Packets
        {
            get;
            set;
        }

        /// <summary>
        /// Пакеты передаваемые по сети
        /// </summary>
        List<Point> PacketCoords
        {
            get;
            set;
        }

        object Locker
        {
            get;
            set;
        }

        void AddPacket(Point p);

        void StartSendPacket();

        void StopSendPacket();

        void Invalidate();

        Control Parent
        {
            get;
            set;
        }

        void Refresh();
    }
}
