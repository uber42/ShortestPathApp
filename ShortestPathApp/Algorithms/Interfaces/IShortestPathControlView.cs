/********************************************************************
	@created:	2020/09/23
	@filename: 	IShortestPathControlView.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathApp.Algorithms.Interfaces
{
    interface IShortestPathControlView : IShortestPathView
    {
        int VertexCount
        {
            get;
            set;
        }
    }
}
