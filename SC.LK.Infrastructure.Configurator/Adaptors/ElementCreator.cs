using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.ConfiguratorDispatcher.Domains.Data;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Enums;

namespace SC.LK.Infrastructure.ElementCreator.Adaptors;

public class ElementCreator : IElementCreator
{
    public HtmlElement GetElements(List<Element> Elements)
    {
        HtmlElement res = new HtmlElement();
        res.Attributes = new List<List<string>>();
        res.Children = new List<HtmlElement>();
        res.Type = "Elem";
        res.TagName = "div";
        
        foreach (var element in Elements)
        {
            if (element.ElementTypeEnum == ElementType.Layout)
            {
                HtmlElement layout = new HtmlElement();
                layout.Attributes = new List<List<string>>()
                {
                    new List<string>()
                    {
                        "class",
                        "layout tabled "+ element.Grouping + " " + element.Alignment
                    },
                };
                layout.Children = new List<HtmlElement>();
                layout.Type = "Elem";
                layout.TagName = "div";
                foreach (var elementInElements in element.Elements)
                {
                    if (elementInElements.ElementTypeEnum == ElementType.Label)
                    {
                        layout.Children.Add(CreateElementLable(elementInElements));
                    }
                    else if (element.ElementTypeEnum == ElementType.Separator)
                    {
                        CreateElementSeparator(element);
                    }           
                    else if (element.ElementTypeEnum == ElementType.Button)
                    {
                        CreateElementButton(element);
                    }
                }
                res.Children.Add(layout);
            }
            else if (element.ElementTypeEnum == ElementType.Separator)
            {
                CreateElementSeparator(element);
            }           
            else if (element.ElementTypeEnum == ElementType.Button)
            {
                CreateElementButton(element);
            }
        }
        return res;
    }
        
    public HtmlElement CreateElementLable(Element element)
    {
        var res = new HtmlElement()
        {
            Children = new List<HtmlElement>()
            {
                new HtmlElement()
                {
                   Children = new List<HtmlElement>()
                   {
                       new HtmlElement()
                       {
                           Children = new List<HtmlElement>()
                           {
                               new HtmlElement()
                               {
                                   Type = "TextElem",
                                   TextContent = element.Label,
                               }
                           },
                           Attributes = new List<List<string>>(),
                           Type = "Elem",
                           TagName = "LABEL",
                       },
                   },
                   Attributes = new List<List<string>>(){new List<string>()
                   {
                       "id", "caption"
                   }},
                   Type = "Elem",
                   TagName = "div"
                },
                new HtmlElement()
                {
                    Children = new List<HtmlElement>()
                    {
                        new HtmlElement()
                        {
                            Children = new List<HtmlElement>()
                            {
                                new HtmlElement()
                                {
                                    Type = "TextElem",
                                    TextContent = element.DefaultText,
                                }
                            },
                            Attributes = new List<List<string>>(),
                            Type = "Elem",
                            TagName = "LABEL",
                        },
                    },
                    Attributes = new List<List<string>>(){new List<string>()
                    {
                        "id", "data"
                    }},
                    Type = "Elem",
                    TagName = "div"
                },
            },
            Attributes = new List<List<string>>()
            {
                new List<string>()
                {
                    "class", "label "+ element.LabelPosition + " " + element.FontStyle
                }
            },
            Type = "Elem",
            TagName = "div",
        };
        return res;
    }
    
    public HtmlElement CreateElementSeparator(Element element)
    {
        var res = new HtmlElement()
        {
            Children = new List<HtmlElement>(),
            Attributes = new List<List<string>>()
            {
                new List<string>()
                {
                    "class", "separator"
                }
            },
            Type = "Elem",
            TagName = "div",
        };
        return res;
    }

    public HtmlElement CreateElementButton(Element element)
    {
        var res = new HtmlElement()
        {
            Children = new List<HtmlElement>()
            {
                new HtmlElement()
                {
                    Children = new List<HtmlElement>()
                    {
                        new HtmlElement()
                        {
                            Type = "TextElem",
                            TextContent = element.Label,
                        }
                    },
                    Attributes = new List<List<string>>(),
                    Type = "Elem",
                    TagName = "LABEL",
                },
            },
            Attributes = new List<List<string>>()
            {
                new List<string>()
                {
                    "class", "button full"
                }
            },
            Type = "Elem",
            TagName = "div"
        };
        return res;
    }
}