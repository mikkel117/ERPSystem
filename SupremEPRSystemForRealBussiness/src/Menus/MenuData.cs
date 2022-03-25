namespace SupremEPRSystemForRealBussiness.src.Menus;
using TECHCOOL.UI;

internal class MenuData
{
    public enum TodoState { Todo, Started, Done }
    public string Title { get; set; }
    public int Priority { get; set; }
    public bool Back { get; set; }
    public TodoState State { get; set; }
    public MenuData(string title, int priority = 1)
    {
        Title = title;
        Priority = priority;
    }
}
