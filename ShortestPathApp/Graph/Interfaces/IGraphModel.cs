/********************************************************************
	@created:	2020/09/16
	@filename: 	IGraphModel.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;

namespace ShortestPathApp.Graph.Interfaces
{
    public interface IGraphModel : IGraphOperations, IGraphData
    {
        /// <summary>
        /// Событие обновления матрицы целиком
        /// </summary>
        event EventHandler OnUpdateMatrix;

        /// <summary>
        /// Событие добавления вершины
        /// </summary>
        event EventHandler OnAddVertex;

        /// <summary>
        /// Событие обновления клетки матрицы
        /// </summary>
        event EventHandler<Tuple<int, int>> OnUpdateCell;

        /// <summary>
        /// Удалить вершину
        /// </summary>
        event EventHandler<int> OnRemoveVertex;

        /// <summary>
        /// Новый минимальный путь построен
        /// </summary>
        event EventHandler<List<int>> OnPathBuilt;

        /// <summary>
        /// Инциализировать
        /// </summary>
        /// <param name="nCount">Количество вершин</param>
        void Initialize(int nCount);

        /// <summary>
        /// Отчистить граф
        /// </summary>
        void Dispose();

        /// <summary>
        /// Считать граф
        /// </summary>
        /// <param name="reader">Стратегия</param>
        void ReadGraph(IGraphReader reader);

        /// <summary>
        /// Построить путь до вершины
        /// </summary>
        /// <param name="paths">Пути</param>
        /// <param name="nEndVertex">Конечная вершина</param>
        void BuildPath(List<int> lPathOrder);
    }
}