using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;

namespace ActivitiDotNet.Deployment
{
    public class ResourceInfoProvider : BaseInfoProvider<ResourceInfo>, IReadable<ResourceInfo>
    {
        public ResourceInfoProvider(string deploymentId) : base(string.Format(UrlConstants.DEPLOYMENT_RESOURCES,deploymentId))
        {
        }

        public new ResourceInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<ResourceInfo> GetAll()
        {
            return base.GetAll();
        }
    }
}
