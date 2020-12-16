/********************************************************************
	@created:	2020/09/16
	@filename: 	Configuration.cs
	@author:	Pavel Chursin
*********************************************************************/

namespace ShortestPathApp
{
    internal class Configuration
    {
        /// <summary>
        /// Максимальное количество вершин
        /// </summary>
        public static readonly int ms_nVerticesMaxCount = 10;

        /// <summary>
        /// Радиус отдаления узлов в графе
        /// </summary>
        public static readonly int ms_nGraphRaduis = 155;

        /// <summary>
        /// Радиус узла графа
        /// </summary>
        public static readonly int ms_nGraphNodeRadius = 15;

        /// <summary>
        /// Радиус пакета
        /// </summary>
        public static readonly int ms_nPacketRadius = 7;

        /// <summary>
        /// Скорость рассылки пакетов
        /// </summary>
        public static readonly int ms_nPacketBroadcastVelocity = 5;
    }
}