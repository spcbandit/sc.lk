using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

namespace SC.LK.Application.Abstractions.ConfiguratorDispatcher;

public interface IHtmlElementGenerator
{
    /// <summary>
    /// Получить Html шаблон элемента специфично для Layout
    /// </summary>
    /// <param name="element">Проекция элемента из конфига</param>
    /// <param name="reqursionResult">Дети элемента</param>
    /// <param name="style"></param>
    /// <returns>HTML шаблон</returns>
    public string GetHtmlText(Element element, string reqursionResult, Style? style);
}