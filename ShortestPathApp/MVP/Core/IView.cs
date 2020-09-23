/********************************************************************
	@created:	2020/09/16
	@filename: 	IView.cs
	@author:	Pavel Chursin
*********************************************************************/

namespace ShortestPathApp.MVP
{
    public interface IView<TViewContract, TPresenterContract>
       where TViewContract : IView<TViewContract, TPresenterContract>
       where TPresenterContract : IPresenter<TPresenterContract, TViewContract>
    {
        void AttachToPresenter(TPresenterContract presenter, bool requiresInitialState);

        void DetatchFromPresenter();

        TPresenterContract Presenter { get; }
    }
}