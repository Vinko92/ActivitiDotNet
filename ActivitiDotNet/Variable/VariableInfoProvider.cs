using System.Collections.Generic;
using ActivitiDotNet.Abstract;
using ActivitiDotNet.CustomModel;

namespace ActivitiDotNet.Variable
{
    public class VariableInfoProvider : BaseInfoProvider<VariableInfo>, IReadable<VariableInfo>
    {
        public VariableInfoProvider(string url) : base(url)
        {

        }

        public new VariableInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<VariableInfo> GetAll()
        {
            return base.GetAll();
        }
    }
}
