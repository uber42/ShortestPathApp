/********************************************************************
	@created:	2020/09/16
	@filename: 	IGraphDataView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;

namespace ShortestPathApp.Graph.Views.Interfaces
{
    public interface IGraphDataView : IGraphView, IGraphOperations { }
}