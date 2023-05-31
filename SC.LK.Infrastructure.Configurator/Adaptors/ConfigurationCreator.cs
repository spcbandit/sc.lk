using SC.LK.Application.Abstractions.ConfiguratorDispatcher;
using SC.LK.Application.ConfiguratorDispatcher.Domains.Data;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

namespace SC.LK.Infrastructure.ElementCreator.Adaptors;

public class ConfigurationCreator: IConfigurationCreator
{
    public HtmlElement GetJson(ConfigurationElement responseData)
    {
        return new HtmlElement();
    }
}