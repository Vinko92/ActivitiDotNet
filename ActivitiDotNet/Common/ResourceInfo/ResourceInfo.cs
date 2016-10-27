using System.Runtime.Serialization;

namespace ActivitiDotNet.Deployment
{
    [DataContract]
    public class ResourceInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "dataUrl")]
        public string DataUrl { get; set; }

        [DataMember(Name = "mediaType")]
        public string MediaType { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}
