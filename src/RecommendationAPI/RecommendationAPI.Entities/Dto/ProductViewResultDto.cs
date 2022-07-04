using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RecommendationAPI.Entities.Dto
{
    [DataContract(Name = "item")]
    public  class ProductViewResultDto
    { 
        [DataMember(Name = "user-id")]
        public string UserId { get; set; }

        [DataMember(Name = "products")] 
        public List<string> ProductIds { get; set; }

        [DataMember(Name = "type")] 
        public string ListType { get; set; }
    }

    public enum ListType
    { 
        [DataMember(Name = "personalized")]
        personalized,
        [DataMember(Name = "non-personalized")] 
        nonpersonalized
    }
}
