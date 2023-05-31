using System.Net;
using Newtonsoft.Json;

namespace SC.LK.Application.Domains.ExternalConnectors.DaDataService;

public class OrganizatioByINNDto
{
    [JsonConstructor]
    public OrganizatioByINNDto(List<Suggestion> suggestions)
    {
        Suggestions = suggestions;
    }
    
    [JsonProperty("suggestions")]
    public List<Suggestion> Suggestions { get; set; }
    
    public HttpStatusCode StatusCode { get; set; }
}
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Management
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("post")]
        public string Post { get; set; }

        [JsonProperty("disqualified")]
        public object Disqualified { get; set; }
    }

    public class State
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("code")]
        public object Code { get; set; }

        [JsonProperty("actuality_date")]
        public object ActualityDate { get; set; }

        [JsonProperty("registration_date")]
        public long? RegistrationDate { get; set; }

        [JsonProperty("liquidation_date")]
        public object LiquidationDate { get; set; }
    }

    public class Opf
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }
    }

    public class Name
    {
        [JsonProperty("full_with_opf")]
        public string FullWithOpf { get; set; }

        [JsonProperty("short_with_opf")]
        public string ShortWithOpf { get; set; }

        [JsonProperty("latin")]
        public object Latin { get; set; }

        [JsonProperty("full")]
        public string Full { get; set; }

        [JsonProperty("short")]
        public string Short { get; set; }
    }

    public class Metro
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }
    }

    public class Data
    {
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_iso_code")]
        public string CountryIsoCode { get; set; }

        [JsonProperty("federal_district")]
        public string FederalDistrict { get; set; }

        [JsonProperty("region_fias_id")]
        public string RegionFiasId { get; set; }

        [JsonProperty("region_kladr_id")]
        public string RegionKladrId { get; set; }

        [JsonProperty("region_iso_code")]
        public string RegionIsoCode { get; set; }

        [JsonProperty("region_with_type")]
        public string RegionWithType { get; set; }

        [JsonProperty("region_type")]
        public string RegionType { get; set; }

        [JsonProperty("region_type_full")]
        public string RegionTypeFull { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("area_fias_id")]
        public string AreaFiasId { get; set; }

        [JsonProperty("area_kladr_id")]
        public string AreaKladrId { get; set; }

        [JsonProperty("area_with_type")]
        public string AreaWithType { get; set; }

        [JsonProperty("area_type")]
        public string AreaType { get; set; }

        [JsonProperty("area_type_full")]
        public string AreaTypeFull { get; set; }

        [JsonProperty("area")]
        public string Area { get; set; }

        [JsonProperty("city_fias_id")]
        public string CityFiasId { get; set; }

        [JsonProperty("city_kladr_id")]
        public string CityKladrId { get; set; }

        [JsonProperty("city_with_type")]
        public string CityWithType { get; set; }

        [JsonProperty("city_type")]
        public string CityType { get; set; }

        [JsonProperty("city_type_full")]
        public string CityTypeFull { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_area")]
        public string CityArea { get; set; }

        [JsonProperty("city_district_fias_id")]
        public object CityDistrictFiasId { get; set; }

        [JsonProperty("city_district_kladr_id")]
        public object CityDistrictKladrId { get; set; }

        [JsonProperty("city_district_with_type")]
        public string CityDistrictWithType { get; set; }

        [JsonProperty("city_district_type")]
        public string CityDistrictType { get; set; }

        [JsonProperty("city_district_type_full")]
        public string CityDistrictTypeFull { get; set; }

        [JsonProperty("city_district")]
        public string CityDistrict { get; set; }

        [JsonProperty("settlement_fias_id")]
        public string SettlementFiasId { get; set; }

        [JsonProperty("settlement_kladr_id")]
        public string SettlementKladrId { get; set; }

        [JsonProperty("settlement_with_type")]
        public string SettlementWithType { get; set; }

        [JsonProperty("settlement_type")]
        public string SettlementType { get; set; }

        [JsonProperty("settlement_type_full")]
        public string SettlementTypeFull { get; set; }

        [JsonProperty("settlement")]
        public string Settlement { get; set; }

        [JsonProperty("street_fias_id")]
        public string StreetFiasId { get; set; }

        [JsonProperty("street_kladr_id")]
        public string StreetKladrId { get; set; }

        [JsonProperty("street_with_type")]
        public string StreetWithType { get; set; }

        [JsonProperty("street_type")]
        public string StreetType { get; set; }

        [JsonProperty("street_type_full")]
        public string StreetTypeFull { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("stead_fias_id")]
        public object SteadFiasId { get; set; }

        [JsonProperty("stead_cadnum")]
        public object SteadCadnum { get; set; }

        [JsonProperty("stead_type")]
        public object SteadType { get; set; }

        [JsonProperty("stead_type_full")]
        public object SteadTypeFull { get; set; }

        [JsonProperty("stead")]
        public object Stead { get; set; }

        [JsonProperty("house_fias_id")]
        public string HouseFiasId { get; set; }

        [JsonProperty("house_kladr_id")]
        public string HouseKladrId { get; set; }

        [JsonProperty("house_cadnum")]
        public object HouseCadnum { get; set; }

        [JsonProperty("house_type")]
        public string HouseType { get; set; }

        [JsonProperty("house_type_full")]
        public string HouseTypeFull { get; set; }

        [JsonProperty("house")]
        public string House { get; set; }

        [JsonProperty("block_type")]
        public string BlockType { get; set; }

        [JsonProperty("block_type_full")]
        public string BlockTypeFull { get; set; }

        [JsonProperty("block")]
        public string Block { get; set; }

        [JsonProperty("entrance")]
        public object Entrance { get; set; }

        [JsonProperty("floor")]
        public object Floor { get; set; }

        [JsonProperty("flat_fias_id")]
        public object FlatFiasId { get; set; }

        [JsonProperty("flat_cadnum")]
        public object FlatCadnum { get; set; }

        [JsonProperty("flat_type")]
        public object FlatType { get; set; }

        [JsonProperty("flat_type_full")]
        public object FlatTypeFull { get; set; }

        [JsonProperty("flat")]
        public object Flat { get; set; }

        [JsonProperty("flat_area")]
        public object FlatArea { get; set; }

        [JsonProperty("square_meter_price")]
        public string SquareMeterPrice { get; set; }

        [JsonProperty("flat_price")]
        public object FlatPrice { get; set; }

        [JsonProperty("postal_box")]
        public object PostalBox { get; set; }

        [JsonProperty("fias_id")]
        public string FiasId { get; set; }

        [JsonProperty("fias_code")]
        public string FiasCode { get; set; }

        [JsonProperty("fias_level")]
        public string FiasLevel { get; set; }

        [JsonProperty("fias_actuality_state")]
        public string FiasActualityState { get; set; }

        [JsonProperty("kladr_id")]
        public string KladrId { get; set; }

        [JsonProperty("geoname_id")]
        public string GeonameId { get; set; }

        [JsonProperty("capital_marker")]
        public string CapitalMarker { get; set; }

        [JsonProperty("okato")]
        public string Okato { get; set; }

        [JsonProperty("oktmo")]
        public string Oktmo { get; set; }

        [JsonProperty("tax_office")]
        public string TaxOffice { get; set; }

        [JsonProperty("tax_office_legal")]
        public string TaxOfficeLegal { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }

        [JsonProperty("geo_lat")]
        public string GeoLat { get; set; }

        [JsonProperty("geo_lon")]
        public string GeoLon { get; set; }

        [JsonProperty("beltway_hit")]
        public string BeltwayHit { get; set; }

        [JsonProperty("beltway_distance")]
        public string BeltwayDistance { get; set; }

        [JsonProperty("metro")]
        public List<Metro> Metro { get; set; }

        [JsonProperty("qc_geo")]
        public string QcGeo { get; set; }

        [JsonProperty("qc_complete")]
        public object QcComplete { get; set; }

        [JsonProperty("qc_house")]
        public object QcHouse { get; set; }

        [JsonProperty("history_values")]
        public object HistoryValues { get; set; }

        [JsonProperty("unparsed_parts")]
        public object UnparsedParts { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("qc")]
        public string Qc { get; set; }

        [JsonProperty("kpp")]
        public string Kpp { get; set; }

        [JsonProperty("capital")]
        public object Capital { get; set; }

        [JsonProperty("management")]
        public Management Management { get; set; }

        [JsonProperty("founders")]
        public object Founders { get; set; }

        [JsonProperty("managers")]
        public object Managers { get; set; }

        [JsonProperty("predecessors")]
        public object Predecessors { get; set; }

        [JsonProperty("successors")]
        public object Successors { get; set; }

        [JsonProperty("branch_type")]
        public string BranchType { get; set; }

        [JsonProperty("branch_count")]
        public int BranchCount { get; set; }

        [JsonProperty("hid")]
        public string Hid { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("state")]
        public State State { get; set; }

        [JsonProperty("opf")]
        public Opf Opf { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("inn")]
        public string Inn { get; set; }

        [JsonProperty("ogrn")]
        public string Ogrn { get; set; }

        [JsonProperty("okpo")]
        public string Okpo { get; set; }

        [JsonProperty("okogu")]
        public string Okogu { get; set; }

        [JsonProperty("okfs")]
        public string Okfs { get; set; }

        [JsonProperty("okved")]
        public string Okved { get; set; }

        [JsonProperty("okveds")]
        public object Okveds { get; set; }

        [JsonProperty("authorities")]
        public object Authorities { get; set; }

        [JsonProperty("documents")]
        public object Documents { get; set; }

        [JsonProperty("licenses")]
        public object Licenses { get; set; }

        [JsonProperty("finance")]
        public object Finance { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phones")]
        public object Phones { get; set; }

        [JsonProperty("emails")]
        public object Emails { get; set; }

        [JsonProperty("ogrn_date")]
        public long? OgrnDate { get; set; }

        [JsonProperty("okved_type")]
        public string OkvedType { get; set; }

        [JsonProperty("employee_count")]
        public object EmployeeCount { get; set; }
    }

    public class Address
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unrestricted_value")]
        public string UnrestrictedValue { get; set; }
    }

    public class Suggestion
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("unrestricted_value")]
        public string UnrestrictedValue { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }