/********************************************************************
	@created:	2020/09/16
	@filename: 	IGraphControlView.cs
	@author:	Pavel Chursin
*********************************************************************/

using ShortestPathApp.Graph.Interfaces;
using System;

namespace ShortestPathApp.Graph.Views.Interfaces
{
    internal interface IGraphControlView : IGraphView
    {
        event EventHandler<string> OnMessage;
    }
}