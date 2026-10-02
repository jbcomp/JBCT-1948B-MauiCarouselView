using System;
using System.Collections.Generic;
using System.Text;

namespace MauiCarouselView;

[ContentProperty("Content")]
public partial class MyTab : BindableObject
{
    public View? Content { get; set; }

    public DataTemplate GetDataTemplate() => new(() => Content);
}
