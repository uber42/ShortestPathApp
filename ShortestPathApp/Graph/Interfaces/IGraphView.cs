/********************************************************************
	@created:	2020/09/16
	@filename: 	IGraphView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.MVP;

namespace ShortestPathApp.Graph.Interfaces
{
    public interface IGraphView : IView<IGraphView, IGraphPresenter>, IGraphData
    {
        /// <summary>
        /// Обновить предсталвние для новых данных
        /// </summary>
        void UpdateView();
    }
}