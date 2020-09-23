/********************************************************************
	@created:	2020/09/16
	@filename: 	PresenterEvent.cs
	@author:	Pavel Chursin
*********************************************************************/

namespace ShortestPathApp.MVP.Support
{
    public delegate void PresenterEvent<TViewContract, TPresenterContract>(TPresenterContract sender, TViewContract view);
}