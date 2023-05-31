using Newtonsoft.Json;

namespace SC.LK.Application.Domains.ExternalConnectors.FNSService;

public class EGRDto
{
    [JsonConstructor]
    public EGRDto(List<Items> itemsList)
    {
        ItemsList = itemsList;
    }
    
    [JsonProperty("items")]
    public List<Items> ItemsList { get; set; }
}

public class Items
{
    [JsonProperty("ЮЛ")]
    public LegalEntity LegalEntity { get; set; }
}

public class LegalEntity
{
    [JsonProperty("ИНН")]
    public string INN { get; set; }
    
    [JsonProperty("КПП")]
    public string KPP { get; set; }
    
    [JsonProperty("ДатаРег")]
    public DateTime DataReg { get; set; }
    
    [JsonProperty("НаимСокрЮЛ")]
    public string OrganizationName { get; set; }
    
    [JsonProperty("Адрес")]
    public Adress Adress { get; set; }
}

public class Adress
{
    [JsonProperty("АдресПолн")]
    public string FullAdress { get; set; }
}