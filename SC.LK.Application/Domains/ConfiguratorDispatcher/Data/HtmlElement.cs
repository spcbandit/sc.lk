using Newtonsoft.Json;

namespace SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

public class HtmlElement
{
    [JsonProperty("type")]
    public string Type { get; set; }
    
    [JsonProperty("textContent")]
    public string TextContent { get; set; }
    
    [JsonProperty("tagName")]
    public string TagName { get; set; }
    
    [JsonProperty("attributes")]
    public List<List<string>> Attributes { get; set; }
    
    [JsonProperty("children")]
    public List<HtmlElement> Children { get; set; }
}