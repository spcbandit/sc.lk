using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

namespace SC.LK.Infrastructure.ConfiguratorDispatcher.Adaptors;

public class SeparatorHtmlElementGenerator : IHtmlElementGenerator
{   
    
    /// <summary>
    /// Базовый шаблон html
    /// </summary>
    private readonly string _htmlTemplate = HtmlTemplates.SeparatorTemplate;    
    /// <summary>
    /// 
    /// </summary>
    private const string _tag_ClassStyle = "__Separator_ClassStyle__";
    
    /// <summary>
    /// Тег замены ID элемента
    /// </summary>
    private const string _tag_Id = "__Separator_Id__";

    /// <summary>
    /// Получить Html шаблон элемента separator
    /// </summary>
    /// <param name="element"></param>
    /// <param name="reqursionResult"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public string GetHtmlText(Element element, string reqursionResult, Style? style)
    {
        var out_html_template = string.Empty;
        
        var replacement_classes = $"{element.Type}";

        out_html_template = _htmlTemplate
            .Replace(_tag_Id, element.Id)
            .Replace(_tag_ClassStyle, replacement_classes);
        return out_html_template;
    }
}