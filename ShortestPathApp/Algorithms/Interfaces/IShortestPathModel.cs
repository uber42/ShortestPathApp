/********************************************************************
	@created:	2020/09/22
	@filename: 	IShortestPathModel.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Algorithms.Interfaces
{
    public interface IShortestPathModel : IShortestPathOperations
    {
        /// <summary>
        /// Алгоритм нахождения кратчайшего пути
        /// </summary>
        IShortestPathAlgorithm Algorithm
        {
            get;
        }

        /// <summary>
        /// Порядок узлов для прохождения между двумя вершинами наименьшим путем
        /// </summary>
        List<int> NodesOrder
        {
            get;
        }

        /// <summary>
        /// Список минимальных расстояний до вершин
        /// </summary>
        List<int> NodesWeight
        {
            get;
        }

        /// <summary>
        /// Событие обновления пути
        /// </summary>
        event EventHandler OnWeightsUpdate;

        /// <summary>
        /// Событие обновления графа
        /// </summary>
        event EventHandler OnUpdateGraph;

        /// <summary>
        /// Установить алгоритм
        /// </summary>
        /// <param name="algorithm">Модель алгоритма</param>
        void SetAlgorithm(IShortestPathAlgorithm algorithm);

        /// <summary>
        /// Вычислить путь
        /// </summary>
        /// <param name="graph">Модель графа</param>
        /// <param name="nBeginVertex">Начальная вершина</param>
        void CalculatePath(IGraphModel graph, int nBeginVertex);

        /// <summary>
        /// Вычислить последовательность обхода вершин
        /// </summary>
        /// <param name="paths"></param>
        /// <param name="nEndVertex"></param>
        /// <param name="endPath"></param>
        void BuildMinPath(int nEndVertex, ref List<int> endPath);

        /// <summary>
        /// Обновить представления из презентера графа
        /// </summary>
        void UpdateFromGraph();
    }
}
