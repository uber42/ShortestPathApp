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
        /// <returns>Время исполнения</returns>
        long Execute(int nBegin, ref List<int> Dist, ref List<int> Paths);

        /// <summary>
        /// Вычилить время
        /// </summary>
        /// <returns>Время</returns>
        long Benchmark();

        /// <summary>
        /// Вычислить последовательность обхода вершин
        /// </summary>
        /// <param name="nEndVertex"></param>
        /// <param name="endPath"></param>
        void BuildMinPath(int nEndVertex, ref List<int> endPath);

        /// <summary>
        /// Сбросить кэшированные данные
        /// </summary>
        void Invalidate();
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