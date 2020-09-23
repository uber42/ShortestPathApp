/********************************************************************
	@created:	2020/09/16
	@filename: 	IPresenter.cs
	@author:	Pavel Chursin
*********************************************************************/

namespace ShortestPathApp.MVP
{
    public interface IPresenter<TPresenterContract, TViewContract>
        where TPresenterContract : IPresenter<TPresenterContract, TViewContract>
        where TViewContract : IView<TViewContract, TPresenterContract>
    {
        void ConnectView(TViewContract viewInstance, bool requiresState);

        void DisconnectView(TViewContract viewInstance);
    }
}