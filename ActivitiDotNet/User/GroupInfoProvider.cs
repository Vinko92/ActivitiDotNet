using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.CustomModel;

namespace ActivitiDotNet.User
{
    public class GroupInfoProvider : BaseInfoProvider<GroupInfo>, IReadable<GroupInfo>, IWriteable<GroupInfo>, IRemoveable<GroupInfo>
    {
        public GroupInfoProvider() : base(UrlConstants.GROUP)
        {
        }

        public new void Create(ref GroupInfo value)
        {
            base.Create(ref value);
        }

        public new GroupInfo Delete(string id)
        {
            return base.Delete(id);
        }

        public new GroupInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<GroupInfo> GetAll()
        {
            return base.GetAll();
        }

        public new bool TryDelete(string id, out GroupInfo value)
        {
            return base.TryDelete(id, out value);
        }

        public new GroupInfo Update(string id, GroupInfo value)
        {
            return base.Update(id, value);
        }
    }
}
