using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;

namespace ActivitiDotNet.Deployment
{
    public class DeploymentResourceInfoProvider : BaseInfoProvider<DeploymentResourceInfo>, IReadable<DeploymentResourceInfo>
    {
        public DeploymentResourceInfoProvider(string deploymentId) : base(string.Format(UrlConstants.DEPLOYMENT_RESOURCES,deploymentId))
        {
        }

        public new DeploymentResourceInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<DeploymentResourceInfo> GetAll()
        {
            return base.GetAll();
        }
    }
}
