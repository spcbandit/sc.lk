using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

namespace SC.LK.Infrastructure.ConfiguratorDispatcher.Adaptors;

public class LayoutHtmlElementGenerator : IHtmlElementGenerator
{
    /// <summary>
    /// Базовый шаблон html
    /// </summary>
    private readonly string _htmlTemplate = HtmlTemplates.LayoutTemplate;
    /// <summary>
    /// Тег замены html значения
    /// </summary>
    private const string _tag_HtmlValue = "__Layout_Html_Value__";
    /// <summary>
    /// Тег замены классов стилей
    /// </summary>
    private const string _tag_ClassStyle = "__Layout_ClassStyle__";
    /// <summary>
    /// Тег замены ID элемента
    /// </summary>
    private const string _tag_Id = "__Layout_Id__";

    /// <summary>
    /// Получить Html шаблон элемента Layout
    /// </summary>
    /// <param name="element"></param>
    /// <param name="reqursionResult"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public string GetHtmlText(Element element, string reqursionResult, Style? style)
    {
        var out_html_template = string.Empty;
        
        var replacement_classes = $"{element.Type} " +
                                  $"{element.Alignment} " +
                                  $"{element.Grouping} " +
                                  $"{style.LayoutStyle}";
        
        var replacement_html_data = reqursionResult;
        
        out_html_template = _htmlTemplate
            .Replace(_tag_Id, element.Id)
            .Replace(_tag_ClassStyle, replacement_classes)
            .Replace(_tag_HtmlValue, replacement_html_data);
        return out_html_template;
    }
}