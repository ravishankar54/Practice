using System;
using Microsoft.Practices.ObjectBuilder;
using System.Web.UI.WebControls;

namespace StockControl.Products.Views
{
	public partial class ProductView : Microsoft.Practices.CompositeWeb.Web.UI.Page, IProductViewView
	{
		private ProductViewPresenter _presenter;

        public Label LblProductName
        {
            get
            {
                return lblProductName;
            }

            set
            {
                lblProductName = value;
            }
        }
        
        public Label LblProductCost
        {
            get
            {
                return lblProductCost;
            }

            set
            {
                lblProductCost = value;
            }
        }
       
        public Label LblTitle
        {
            get
            {
                return lblTitle;
            }

            set
            {
                lblTitle = value;
            }
        }

		protected void Page_Load(object sender, EventArgs e)
		{
			if (!this.IsPostBack)
			{
				this._presenter.OnViewInitialized();
			}
			this._presenter.OnViewLoaded();
		}

		[CreateNew]
		public ProductViewPresenter Presenter
		{
			get
			{
				return this._presenter;
			}
			set
			{
				if(value == null)
					throw new ArgumentNullException("value");

				this._presenter = value;
				this._presenter.View = this;
			}
		}


	}
}

