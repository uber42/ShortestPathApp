/********************************************************************
	@created:	2020/09/22
	@filename: 	IShortestPathPresenter.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShortestPathApp.MVP;
using ShortestPathApp.Graph.Interfaces;

namespace ShortestPathApp.Algorithms.Interfaces
{
    public interface IShortestPathPresenter : IPresenter<IShortestPathPresenter, IShortestPathView>, IShortestPathOperations
    {

        /// <summary>
        /// Установить алгоритм
        /// </summary>
        /// <param name="algorithm">Алгоритм</param>
        void SetAlgorithm(EShortestPathAlgorithm algorithm);

        /// <summary>
        /// Вычислить путь
        /// </summary>
        /// <param name="nBeginVertex">Начальная вершина</param>
        void CalculatePath(int nBeginVertex);

        /// <summary>
        /// Собрать путь
        /// </summary>
        /// <param name="paths"></param>
        void BuildPath(int nEndVertex);
    }
}
