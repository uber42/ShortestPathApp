/********************************************************************
	@created:	2020/09/16
	@filename: 	IGraphOperations.cs
	@author:	Pavel Chursin
*********************************************************************/

namespace ShortestPathApp.Graph.Interfaces
{
    public interface IGraphOperations
    {
        /// <summary>
        /// Добавить новую вершину
        /// </summary>
        void AddVertex();

        /// <summary>
        /// Удалить вершину по ее номеру
        /// </summary>
        /// <param name="nvertex">Номер вершины</param>
        void RemoveVertex(int nvertex);

        /// <summary>
        /// Установить вес ребра между вершинами
        /// </summary>
        /// <param name="nvertexFirst">Первая вершина</param>
        /// <param name="nvertexSecond">Вторая вершина</param>
        /// <param name="nWeight">Вес ребра</param>
        void SetEdge(int nvertexFirst, int nvertexSecond, int nWeight);
    }
}