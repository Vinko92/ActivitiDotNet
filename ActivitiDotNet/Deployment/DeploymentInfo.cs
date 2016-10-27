using System.Runtime.Serialization;
using ActivitiDotNet.Collection;
using ActivitiDotNet.Constants;

namespace ActivitiDotNet.Deployment
{
    [DataContract]
    public class DeploymentInfo
    {
        public BaseInfoCollection<ResourceInfo> _resources;

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

        public BaseInfoCollection<ResourceInfo> Resources
        {
            get
            {
                if(_resources == null)
                {
                    _resources = new BaseInfoCollection<ResourceInfo>(string.Format(UrlConstants.DEPLOYMENT_RESOURCES, Id));
                }

                return _resources;
            }
        }
    }
}
