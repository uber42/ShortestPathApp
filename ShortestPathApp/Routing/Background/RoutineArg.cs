using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Routing.Background
{
    class RoutineArg
    {
        /// <summary>
        /// Начальный узел
        /// </summary>
        public int nBeginNode
        {
            get;
            set;
        }

        /// <summary>
        /// Конечный узел
        /// </summary>
        public int nEndNode
        {
            get;
            set;
        }

        /// <summary>
        /// Время жизни
        /// </summary>
        public int nLifeTime
        {
            get;
            set;
        }

        /// <summary>
        /// Количество пакетов
        /// </summary>
        public int nCountPackets
        {
            get;
            set;
        }

        public List<int> Path
        {
            get;
            set;
        }
    }
}
