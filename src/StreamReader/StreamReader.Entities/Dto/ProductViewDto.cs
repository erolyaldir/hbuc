using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace str.Entities.Dto
{
    public class ProductViewDto
    {       
        [JsonProperty(PropertyName = "event")]
        public string Event { get; set; }
        [JsonProperty(PropertyName = "messageid")]
        public string MessageId { get; set; }
        [JsonProperty(PropertyName ="userid")]
        public string UserId { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Properties Properties { get; set; }
        [JsonProperty(PropertyName = "context")]
        public Context Context { get; set; }
    }

    public class Properties
    {

        [JsonProperty(PropertyName = "productid")]
        public string ProductId { get; set; }
    }
    public class Context
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }
    }
}
