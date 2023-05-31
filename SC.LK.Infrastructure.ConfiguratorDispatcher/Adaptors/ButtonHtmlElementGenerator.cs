using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

namespace SC.LK.Infrastructure.ConfiguratorDispatcher.Adaptors;

public class ButtonHtmlElementGenerator : IHtmlElementGenerator
{
    /// <summary>
    /// Базовый шаблон html
    /// </summary>
    private readonly string _htmlTemplate = HtmlTemplates.ButtonTemplate;

    /// <summary>
    /// Тег замены классов css
    /// </summary>
    private const string _tag_ClassStyle = "__Button_ClassStyle__";

    /// <summary>
    /// Тег замены текста в кнопке
    /// </summary>
    private const string _tag_TextValue = "__Button_TextValue__";
    
    /// <summary>
    /// Тег замены ID элемента
    /// </summary>
    private const string _tag_Id = "__Button_Id__";

    /// <summary>
    /// Получить Html шаблон элемента button
    /// </summary>
    /// <param name="element"></param>
    /// <param name="reqursionResult"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public string GetHtmlText(Element element, string reqursionResult, Style? style)
    {
        var out_html_template = string.Empty;
        
        var replacement_classes = $"{element.Type} {style.CornerStyle}";
        
        out_html_template = _htmlTemplate
            .Replace(_tag_Id, element.Id)
            .Replace(_tag_ClassStyle, replacement_classes)
            .Replace(_tag_TextValue, element.Label);
        return out_html_template;
    }
}