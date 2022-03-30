
using SupremEPRSystemForRealBussiness.Data;
using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness.src.Menus
{
    internal class StorageMenu : Screen
    {
        public override string Title { get; set; } = " Storage Menu ";
        protected override void Draw()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            listPage.Add(new MenuData("List of products"));
            listPage.Add(new MenuData("Add product"));
            listPage.Add(new MenuData("Update product"));
            listPage.Add(new MenuData("Delete product"));
            listPage.AddColumn("Todo", "Title");
            MenuData selected = listPage.Select();
            switch (selected.Title)
            {
                case "List of products":
                    ListOfProducts();
                    break;
                case "Add product":
                    Database.Instance.GetAllProducts();
                    /*Console.WriteLine("add product");*/
                    break;
                case "Update product":
                    Console.WriteLine("update product");
                    break;
                case "Delete product":
                    Console.WriteLine("delete product");
                    break;
                default:
                    break;
            }
        }

        private void ListOfProducts()
        {
            Clear(this);
            ListPage<MenuData> listPage = new ListPage<MenuData>();
            foreach (var item in Database.Instance.Products)
            {
                listPage.Add(new MenuData(item.ProductName));
            }
            listPage.AddColumn("List of products", "Title");
            MenuData selected = listPage.Select();
        }


        private void ShowOneProduct(string productName)
        {

        }
    }
}

