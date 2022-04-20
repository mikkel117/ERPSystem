using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class StorageMenu : Screen
    {
        public override string Title { get; set; } = " Storage Menu ";
        protected override void Draw()
        {
            Clear(this);
            ListPage<Product> listPage = new ListPage<Product>();
            listPage.Add(Data.Database.Instance.SelectProducts());
            listPage.AddColumn("Item number", "ProductID", 15);
            listPage.AddColumn("Product Name", "ProductName", 20);
            listPage.AddColumn("Stock", "Stock", 10);
            listPage.AddColumn("Buy Price", "BuyPrice", 10);
            listPage.AddColumn("Sales Price", "SalesPrice", 15);
            listPage.AddColumn("Profit Percentage", "ProfitPercentage", 20);
            Product chosenProduct = listPage.Select();
            ProductDetails(chosenProduct);
        }

        private void ProductDetails(Product product)
        {
            //calls productDeltailsMenu and sends product with
            ProductDetailsMenu productDetails = new(product);
        }

    }
}