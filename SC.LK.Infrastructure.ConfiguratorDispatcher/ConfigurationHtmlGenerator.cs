using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Enums;
using SC.LK.Application.Domains.Enums;
using SC.LK.Application.Extentions;
using SC.LK.Infrastructure.ConfiguratorDispatcher.Adaptors;

namespace SC.LK.Infrastructure.ConfiguratorDispatcher;

public class ConfigurationHtmlGenerator : IHtmlGenerator
{
    /// <summary>
    /// Словарь для поиска подходящего генератора Html элементов
    /// </summary>
    private readonly Dictionary<ElementType, IHtmlElementGenerator> _generators;

    /// <summary>
    /// Конструктор сервиса
    /// </summary>
    public ConfigurationHtmlGenerator()
    {
        _generators = new Dictionary<ElementType, IHtmlElementGenerator>
        {
            {ElementType.Button, new ButtonHtmlElementGenerator()},
            {ElementType.Layout, new LayoutHtmlElementGenerator()},
            {ElementType.Label, new LabelHtmlElementGenerator()},
            {ElementType.Separator, new SeparatorHtmlElementGenerator()}
        };
    }
    
    /// <summary>
    /// Генерация Html текста из списка элементов конфигурации одной формы
    /// </summary>
    /// <param name="elements">Список элементов конфигурации одной формы</param>
    /// <returns>HTML текст</returns>
    public string GenerateHtmlElements(List<Element>? elements, Style? style)
    {
        //Выход из рекурсии
        if (elements == null || elements.Count is 0)
        { return string.Empty; }
        
        // Начальный HTML шаблон
        var html_template = string.Empty;
        
        foreach (var element in elements)
        {
            // Получаем тип элемента конфигурации см. ElementType -> EnumMember
            var element_type = element.Type.ToEnum<ElementType>();
            // Берем нужный генератор html кода
            var generator = _generators[element_type];
            // Запускаемся в рекурсии на случай наличия детей
            var reqursion_result = GenerateHtmlElements(element.Elements, style);
            // Генерируем html текст выбранного элемента с учетом результата рекурсии.
            var element_html = generator.GetHtmlText(element, reqursion_result, style);
            // Собераем и отдаем шаблон html
            html_template += element_html;
        }

        return html_template;
    }
}