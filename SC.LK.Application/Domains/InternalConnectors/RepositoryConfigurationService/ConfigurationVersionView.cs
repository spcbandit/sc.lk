namespace SC.LK.Application.Domains.RepositoryConfigurationService;

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "13.15.9.0 (NJsonSchema v10.6.8.0 (Newtonsoft.Json v13.0.0.0))")]
    public partial class ConfigurationVersionView
    {
        [Newtonsoft.Json.JsonProperty("configurationVersionId")]
        public System.Guid ConfigurationVersionId { get; set; }

        [Newtonsoft.Json.JsonProperty("configurationId")]
        public System.Guid ConfigurationId { get; set; }

        [Newtonsoft.Json.JsonProperty("configurationVersionNumber")]
        public int ConfigurationVersionNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("jsonHeader")]
        public string JsonHeader { get; set; }

        [Newtonsoft.Json.JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [Newtonsoft.Json.JsonProperty("proceses")]
        public System.Collections.Generic.List<ConfigurationsBusinessProcessView> Proceses { get; set; } = new System.Collections.Generic.List<ConfigurationsBusinessProcessView>();

        [Newtonsoft.Json.JsonProperty("updateBy")]
        public string UpdateBy { get; set; }

        [Newtonsoft.Json.JsonProperty("update")]
        public System.DateTimeOffset Update { get; set; }
    }