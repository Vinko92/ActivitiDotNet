using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;

namespace ActivitiDotNet.Model
{
    public class ModelInfoProvider : BaseInfoProvider<ModelInfo>, IReadable<ModelInfo>, IWriteable<ModelInfo>, IRemoveable<ModelInfo>
    {
        public ModelInfoProvider() : base(UrlConstants.MODEL) { }

        public new ModelInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<ModelInfo> GetAll()
        {
            return base.GetAll();
        }

        public new ModelInfo Create(ModelInfo value)
        {
            return base.Create(value);
        }

        public new ModelInfo Update(string id, ModelInfo value)
        {
            return base.Update(id,value);
        }

        public new ModelInfo Delete(string id)
        {
            return base.Delete(id);
        }

        public new bool TryDelete(string id, out ModelInfo value)
        {
            return base.TryDelete(id, out value);
        }
    }
}
