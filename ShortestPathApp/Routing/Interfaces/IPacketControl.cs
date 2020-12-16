using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShortestPathApp.Routing.Interfaces
{
    interface IPacketControl
    {
        /// <summary>
        /// Номер пакета
        /// </summary>
        int nPacketNumber
        {
            get;
            set;
        }

        /// <summary>
        /// Эпоха пакета
        /// </summary>
        int nPacketTerm
        {
            get;
            set;
        }

        /// <summary>
        /// Отправить контрол из
        /// </summary>
        /// <param name="pFrom"></param>
        /// <param name="pTo"></param>
        void Send(Point pFrom, Point pTo);
    }
}
