using System.Collections.ObjectModel;

namespace MauiCarouselView;

public partial class MyTabbedPage : ContentPage
{
    public MyTabbedPage()
    {
        InitializeComponent();

        Tabs.CollectionChanged += Tabs_CollectionChanged;

        BindingContext = this;
    }

    public ObservableCollection<object> Items { get; private set; } = [];

    public ObservableCollection<MyTab> Tabs { get; private set; } = [];

    public ObservableCollection<object> TabItems { get; private set; } = [];

    /// <summary>
    /// Keeps the bindable collection of view models for each tab synchronised with the collection of tab definitions.
    /// </summary>
    /// <param name="sender">The object sourcing the event.</param>
    /// <param name="e">The arguments of the CollectionChanged event.</param>
    private void Tabs_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                foreach (MyTab tab in e.NewItems!)
                {
                    tab.BindingContext = BindingContext;
                    TabItems.Add(tab.Content!.BindingContext);
                }
                break;
        }
    }
}
