namespace MauiCarouselView;

public class ItemTemplateSelector : DataTemplateSelector
{
    public MyTabbedPage? TabbedPage { get; set; }

    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        var tab = default(MyTab);
        for (int i = 0; i < TabbedPage?.TabItems.Count; i++)
        {
            if (TabbedPage?.TabItems[i] == item)
            {
                tab = TabbedPage.Tabs[i];
                break;
            }
        }
        return tab?.GetDataTemplate() ?? throw new Exception("Tab cannot be determined from bound item");
    }
}
