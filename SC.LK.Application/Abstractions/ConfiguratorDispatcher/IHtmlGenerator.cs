using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

namespace SC.LK.Application.Abstractions.ConfiguratorDispatcher;

public interface IHtmlGenerator
{
    /// <summary>
    /// Генерация Html текста из списка элементов конфигурации одной формы
    /// </summary>
    /// <param name="elements">Список элементов конфигурации одной формы</param>
    /// <returns>HTML текст</returns>
    public string GenerateHtmlElements(List<Element>? elements, Style? style);
}