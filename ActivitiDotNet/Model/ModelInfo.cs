using System.Runtime.Serialization;
using ActivitiDotNet.Abstract;

namespace ActivitiDotNet.Model
{
    [DataContract]
    public class ModelInfo : IIdentifiable
    {
        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        [DataMember(Name = "category", EmitDefaultValue = false)]
        public string Category { get; set; }

        [DataMember(Name = "version", EmitDefaultValue = false)]
        public int Version { get; set; }

        [DataMember(Name = "metaInfo", EmitDefaultValue = false)]
        public string MetaInfo { get; set; }

        [DataMember(Name = "deploymentId", EmitDefaultValue = false)]
        public string DeploymentId { get; set; }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "createTime", EmitDefaultValue = false)]
        public string CreateTime { get; set; }

        [DataMember(Name = "LastUpdateTime", EmitDefaultValue = false)]
        public string LastUpdateTime { get; set; }
        [DataMember(Name = "deploymentUrl", EmitDefaultValue = false)]
        public string DeploymentUrl { get; set; }

        [DataMember(Name = "tenantId", EmitDefaultValue = false)]
        public string TenantId { get; set; }

        string IIdentifiable.Id
        {
            get
            {
                return this.Id;
            }
            set
            {
                
            }
        }
    }
}
