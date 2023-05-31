using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

namespace SC.LK.Infrastructure.ConfiguratorDispatcher.Adaptors;

public class LabelHtmlElementGenerator : IHtmlElementGenerator
{
    /// <summary>
    /// Базовый шаблон html
    /// </summary>
    private readonly string _htmlTemplate = HtmlTemplates.LabelTemplate;
    /// <summary>
    /// 
    /// </summary>
    private const string _tag_ClassStyle = "__Label_ClassStyle__";
    /// <summary>
    /// 
    /// </summary>
    private const string _tag_CaptionValue = "__Label_Caption_TextValue__";
    /// <summary>
    /// 
    /// </summary>
    private const string _tag_TextValue = "__Label_Data_TextValue__";
    /// <summary>
    /// Тег замены ID элемента
    /// </summary>
    private const string _tag_Id = "__Label_Id__";

    /// <summary>
    /// Получить Html шаблон элемента label
    /// </summary>
    /// <param name="element"></param>
    /// <param name="reqursionResult"></param>
    /// <param name="style"></param>
    /// <returns></returns>
    public string GetHtmlText(Element element, string reqursionResult, Style? style)
    { 
        var out_html_template = string.Empty;
        
        var replacement_classes = $"{element.Type}" +
                                  $" {element.LabelPosition}" +
                                  $" {element.FontStyle}";
        
        out_html_template = _htmlTemplate
            .Replace(_tag_Id, element.Id)
            .Replace(_tag_ClassStyle, replacement_classes)
            .Replace(_tag_CaptionValue, element.Label)
            .Replace(_tag_TextValue, element.DefaultText);
        return out_html_template;
    }
}