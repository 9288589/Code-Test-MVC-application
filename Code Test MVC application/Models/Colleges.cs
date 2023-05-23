using Newtonsoft.Json;

namespace Code_Test_MVC_application.Models
{
    public class Colleges
    {
      public string? country { get; set; }
        
      [JsonProperty(PropertyName = "alpha_two_code")]
      public string? alphatwocode { get; set; }


      [JsonProperty(PropertyName = "web_pages")]
        public List<string>? webpages { get; set; }
        [JsonProperty(PropertyName = "state-province")]
        public string? stateprovince { get; set; }

      public List<string>? domains { get; set; }
      
      public string? name { get; set; }
    }
    public class WebPages
    {
        //public int Id {get;set;}
        public string? name { get; set; }
    }
    public class Domains
    {
        //public int Id { get; set; }
        public string? name { get; set; }
    }

}
