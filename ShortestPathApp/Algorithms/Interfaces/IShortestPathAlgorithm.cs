/********************************************************************
	@created:	2020/09/16
	@filename: 	IShortestPathAlgorithm.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using System.Collections.Generic;

namespace ShortestPathApp.Algorithms.Interfaces
{
    public interface IShortestPathAlgorithm
    {
        /// <summary>
        /// Граф
        /// </summary>
        IGraphModel Graph
        {
            get;
            set;
        }

        /// <summary>
        /// Выполнить алгоритм
        /// </summary>
        /// <param name="nBegin">Начальная вершина</param>
        /// <param name="Dist">Список расстояний до каждой из вершин</param>
        /// <param name="Paths">Список путей</param>
        void Execute(int nBegin, ref List<int> Dist, ref List<int> Paths);
    }

    /// <summary>
    /// Перечисление алгоритмов
    /// </summary>
    public enum EShortestPathAlgorithm
    {
        /// <summary>
        /// Алгоритм Дейкстры
        /// </summary>
        Dijkstra,

        /// <summary>
        /// Алгоритм Флойда
        /// </summary>
        Floyd
    }
}