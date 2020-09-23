/********************************************************************
	@created:	2020/09/16
	@filename: 	PresenterBase.cs
	@author:	Pavel Chursin
*********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;

namespace ShortestPathApp.MVP.Support
{
    public abstract class PresenterBase<TPresenterContract, TViewContract> :
        IPresenter<TPresenterContract, TViewContract>,
        IViewManager<TViewContract, TPresenterContract>
        where TViewContract : IView<TViewContract, TPresenterContract>
        where TPresenterContract : IPresenter<TPresenterContract, TViewContract>
    {
        private IList<TViewContract> _views;

        public PresenterBase()
        {
            _views = new List<TViewContract>();
        }

        protected abstract void RefreshView(TViewContract viewInstance);

        protected abstract TPresenterContract GetPresenterEndpoint();

        public event PresenterEvent<TViewContract, TPresenterContract> BeforeviewConnect;

        public event PresenterEvent<TViewContract, TPresenterContract> AfterviewConnect;

        public event PresenterEvent<TViewContract, TPresenterContract> BeforeviewDisconnect;

        public event PresenterEvent<TViewContract, TPresenterContract> AfterviewDisconnect;

        public void ConnectView(TViewContract viewInstance, bool requiresState)
        {
            if (viewInstance == null)
            {
                throw new ArgumentNullException("viewInstance");
            }

            lock (views)
            {
                if (views.Contains(viewInstance))
                {
                    return;
                }

                BeforeviewConnect?.Invoke(GetPresenterEndpoint(), viewInstance);

                _views.Add(viewInstance);

                if (requiresState)
                {
                    RefreshView(viewInstance);
                }

                AfterviewConnect?.Invoke(GetPresenterEndpoint(), viewInstance);
            }
        }

        public void DisconnectView(TViewContract viewInstance)
        {
            if (viewInstance == null)
            {
                throw new ArgumentNullException("viewInstance");
            }

            lock (views)
            {
                if (!views.Contains(viewInstance))
                {
                    return;
                }

                BeforeviewDisconnect?.Invoke(GetPresenterEndpoint(), viewInstance);

                _views.Remove(viewInstance);

                AfterviewDisconnect?.Invoke(GetPresenterEndpoint(), viewInstance);
            }
        }

        protected IEnumerable<TViewContract> views
        {
            get
            {
                return _views;
            }
        }
    }
}