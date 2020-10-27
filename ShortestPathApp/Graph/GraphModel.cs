/********************************************************************
	@created:	2020/09/16
	@filename: 	GraphModel.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using ShortestPathApp.Graph.Resources.Strings;
using System;
using System.Collections.Generic;

namespace ShortestPathApp.Graph
{
    internal class GraphModel : IGraphModel
    {
        /// <summary>
        /// Матрица весов графа
        /// </summary>
        public List<List<int>> Vertices
        {
            get;
            set;
        }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GraphModel() : this(0)
        {
        }

        /// <summary>
        /// Конструктор по количеству вершин
        /// </summary>
        public GraphModel(int nCount)
        {
            Initialize(nCount);
        }

        /// <summary>
        /// Событие удаления вершины из матрицы
        /// </summary>
        public event EventHandler<int> OnRemoveVertex;

        /// <summary>
        /// Событие обноления матрицы целиком
        /// </summary>
        public event EventHandler OnUpdateMatrix;

        /// <summary>
        /// Событие обновления веса между вершинами (Клетки матрицы)
        /// </summary>
        public event EventHandler<Tuple<int, int>> OnUpdateCell;

        /// <summary>
        /// Событие добавления вершины
        /// </summary>
        public event EventHandler OnAddVertex;

        /// <summary>
        /// Событие построяния пути
        /// </summary>
        public event EventHandler<List<int>> OnPathBuilt;

        #region Публичные методы

        /// <summary>
        /// Инциализировать
        /// </summary>
        /// <param name="nCount">Количество вершин</param>
        public void Initialize(int nCount)
        {
            if (nCount > Configuration.ms_nVerticesMaxCount)
            {
                throw new ArgumentException(
                    string.Format(StringProvider.InitializeArgumentError, Configuration.ms_nVerticesMaxCount));
            }

            if (Vertices != null)
            {
                Dispose();
            }

            Vertices = new List<List<int>>();
            for (int i = 0; i < nCount; i++)
            {
                var internalList = new List<int>();
                for (int j = 0; j < nCount; j++)
                {
                    internalList.Add(0);
                }

                Vertices.Add(internalList);
            }
        }

        /// <summary>
        /// Отчистить граф
        /// </summary>
        public void Dispose()
        {
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].Clear();
            }
            Vertices.Clear();
            Vertices = null;
        }

        /// <summary>
        /// Добавить новую вершину
        /// </summary>
        public void AddVertex()
        {
            if (Vertices.Count >= Configuration.ms_nVerticesMaxCount)
            {
                throw new ArgumentException(
                    string.Format(StringProvider.InitializeArgumentError, Configuration.ms_nVerticesMaxCount));
            }

            var newInternalList = new List<int>();
            for (int i = 0; i < Vertices.Count + 1; i++)
            {
                newInternalList.Add(0);
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].Add(0);
            }

            Vertices.Add(newInternalList);

            OnAddVertex?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Удалить вершину по ее номеру
        /// </summary>
        /// <param name="nvertex">Номер вершины</param>
        public void RemoveVertex(int nVertex)
        {
            Vertices.RemoveAt(nVertex);
            for (int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].RemoveAt(nVertex);
            }

            OnRemoveVertex?.Invoke(this, nVertex);
        }

        /// <summary>
        /// Установить вес ребра между вершинами
        /// </summary>
        /// <param name="nvertexFirst">Первая вершина</param>
        /// <param name="nvertexSecond">Вторая вершина</param>
        /// <param name="nWeight">Вес ребра</param>
        public void SetEdge(int nvertexFirst, int nvertexSecond, int nWeight)
        {
            if (nvertexFirst >= Vertices.Count ||
               nvertexSecond >= Vertices.Count)
            {
                throw new ArgumentException();
            }

            if (nWeight < 0)
            {
                throw new ArgumentException();
            }

            Vertices[nvertexFirst][nvertexSecond] = nWeight;

            OnUpdateCell?.Invoke(this, Tuple.Create(nvertexFirst, nvertexSecond));
        }

        #endregion Публичные методы

        /// <summary>
        /// Считать граф
        /// </summary>
        /// <param name="reader">Стратегия чтения</param>
        public void ReadGraph(IGraphReader reader)
        {
            var lMatrix = reader.ReadGraph();
            Vertices.Clear();
            Vertices.AddRange(lMatrix);

            OnUpdateMatrix?.Invoke(this, EventArgs.Empty);
        }

        public void BuildPath(List<int> lPathOrder)
        {
            OnPathBuilt?.Invoke(this, lPathOrder);
        }
    }
}