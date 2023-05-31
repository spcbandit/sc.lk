using Newtonsoft.Json;
using SC.LK.Application.Domains.ConfiguratorDispatcher.Enums;
using SC.LK.Application.Extentions;

namespace SC.LK.Application.Domains.ConfiguratorDispatcher.Data;

public class ConfigurationElement
{
    [JsonProperty("info")]
    public Info Info { get; set; }

    [JsonProperty("style")]
    public Style Style { get; set; }

    [JsonProperty("forms")]
    public List<Form> Forms { get; } = new List<Form>();
}

public class Info
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("active")]
    public string Active { get; set; }

    [JsonProperty("erpUrl")]
    public string ErpUrl { get; set; }
}

public class Style
{
    [JsonProperty("compactFontSize")]
    public string CompactFontSize { get; set; }

    [JsonProperty("compactFontColor")]
    public string CompactFontColor { get; set; }

    [JsonProperty("regularFontSize")]
    public string RegularFontSize { get; set; }

    [JsonProperty("regularFontColor")]
    public string RegularFontColor { get; set; }

    [JsonProperty("strongFontSize")]
    public string StrongFontSize { get; set; }

    [JsonProperty("strongFontColor")]
    public string StrongFontColor { get; set; }

    [JsonProperty("cornerStyle")]
    public string CornerStyle { get; set; }

    [JsonProperty("layoutStyle")]
    public string LayoutStyle { get; set; }

    [JsonProperty("colorTheme")]
    public string ColorTheme { get; set; }

    [JsonProperty("background")]
    public string Background { get; set; }

    [JsonProperty("backgroundColor")]
    public string BackgroundColor { get; set; }
}

public class Form
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("loaded")]
    public string Loaded { get; set; }

    [JsonProperty("closed")]
    public string Closed { get; set; }

    [JsonProperty("elements")]
    public List<Element> Elements { get; } = new List<Element>();
}

public class Element
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("grouping")]
    public string Grouping { get; set; }
    
    [JsonProperty("alignment")]
    public string Alignment { get; set; }
    
    [JsonProperty("border")]
    public string Border { get; set; }
    
    [JsonProperty("sourceData")]
    public string SourceData { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("labelPosition")]
    public string LabelPosition { get; set; }

    [JsonProperty("defaultText")]
    public string DefaultText { get; set; }

    [JsonProperty("fontStyle")]
    public string FontStyle { get; set; }
    
    [JsonProperty("click")]
    public string Click { get; set; }
    
    [JsonProperty("elements")]
    public List<Element> Elements { get; } = new List<Element>();
}






    