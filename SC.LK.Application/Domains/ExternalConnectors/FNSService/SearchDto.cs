using Newtonsoft.Json;

namespace SC.LK.Application.Domains.ExternalConnectors.FNSService;

public class SearchDto
{
    [JsonConstructor]
    public SearchDto(List<SearchDtoItem> searchDtoItems)
    {
        Items = searchDtoItems;
    }

    [JsonProperty("items")]
    public List<SearchDtoItem> Items { get; set; }

    [JsonProperty("filter")]
    public string Filter { get; set; }

    [JsonProperty("Count")]
    public int Count { get; set; }
}
public class SearchDtoItem
{
    [JsonProperty("ИП")]
    public IndividualEntrepreneur IndividualEntrepreneur { get; set; }
}
public class IndividualEntrepreneur
{
    [JsonProperty("ИНН")]
    public string Inn { get; set; }

    [JsonProperty("ОГРН")]
    public string Ogrn { get; set; }

    [JsonProperty("ФИОПолн")]
    public string FIO { get; set; }
}