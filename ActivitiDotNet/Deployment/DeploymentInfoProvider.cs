using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;

namespace ActivitiDotNet.Deployment
{
    public class DeploymentInfoProvider : BaseInfoProvider<DeploymentInfo>, IReadable<DeploymentInfo>, IRemoveable<DeploymentInfo>
    {
        public DeploymentInfoProvider() : base(UrlConstants.DEPLOYMENT)
        {
        }

        public new DeploymentInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<DeploymentInfo> GetAll()
        {
            return base.GetAll();
        }

        public new DeploymentInfo Delete(string id)
        {
           return base.Delete(id);
        }

        public new bool TryDelete(string id, out DeploymentInfo value)
        {
            return base.TryDelete(id, out value);
        }
    }
}
