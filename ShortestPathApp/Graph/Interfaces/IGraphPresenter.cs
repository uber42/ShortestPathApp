/********************************************************************
	@created:	2020/09/16
	@filename: 	IGraphPresenter.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.MVP;

namespace ShortestPathApp.Graph.Interfaces
{
    public interface IGraphPresenter : IPresenter<IGraphPresenter, IGraphView>, IGraphOperations
    {
        /// <summary>
        /// Чтение графа
        /// </summary>
        /// <param name="reader">Стратегия</param>
        void ReadGraph(IGraphReader reader);
    }
}