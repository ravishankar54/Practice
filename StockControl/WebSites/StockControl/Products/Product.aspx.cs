using System;
using Microsoft.Practices.ObjectBuilder;
using System.Web.UI.WebControls;

namespace StockControl.Products.Views
{
    public partial class Product : Microsoft.Practices.CompositeWeb.Web.UI.Page, IProductView
    {
        private ProductPresenter _presenter;

        public event EventHandler BtnSave_Click;

        public TextBox TxtProductName
        {
            get
            {
                return txtProductName;
            }
            set
            {
                txtProductName = value;
            }
        }

        public TextBox TxtCost
        {
            get
            {
                return txtCost;
            }
            set
            {
                txtCost = value;
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
        public ProductPresenter Presenter
        {
            get
            {
                return this._presenter;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this._presenter = value;
                this._presenter.View = this;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (BtnSave_Click != null)
            {
                BtnSave_Click(sender, e);
            }
        }
    }
}

