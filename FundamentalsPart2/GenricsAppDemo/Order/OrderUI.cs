using System;

namespace GenricsAppDemo
{
    public class OrderUI : BaseUI, IOrderView
    {
        public OrderPresenter Presenter { get; set; }
        public OrderUI()
        {
            InitlizaPresenter();
            Presenter.Display("From Order UI");
        }

        private void InitlizaPresenter()
        {
            Presenter = CreatePresenter<OrderPresenter>();
            Presenter.View = this;
        }
    }
}
