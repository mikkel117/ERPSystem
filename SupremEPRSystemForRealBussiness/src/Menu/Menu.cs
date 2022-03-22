using TECHCOOL.UI;

namespace SupremEPRSystemForRealBussiness
{
    internal class Menu : Screen
    {
        public override string Title { get; set; } = " Enterprice Resource Planning ";
        protected override void Draw()
        {
            Clear(this);
            Console.WriteLine("Lars er sej!");
        }

    }
}
