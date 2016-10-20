using System.Runtime.Serialization;

namespace ActivitiDotNet.Deployment
{
    [DataContract]
    public class DeploymentInfo
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "deploymentTime")]
        public string DeploymentTime { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        public string DestinationUrl { get; set; }

        public byte[] Data { get; set; }

        [DataMember(Name = "tenantId")]
        public string TenantID { get; set; }
    }
}
