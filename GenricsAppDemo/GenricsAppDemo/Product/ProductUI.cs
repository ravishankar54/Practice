namespace GenricsAppDemo
{
    public class ProductUI : BaseUI, IProductView
    {
        public ProductPresenter Presenter { get; set; }
        public ProductUI()
        {
            InitlizaPresenter();
            Presenter.Display("From Order UI");
        }

        private void InitlizaPresenter()
        {
            Presenter = CreatePresenter<ProductPresenter>();
            Presenter.View = this;
        }
    }
}
