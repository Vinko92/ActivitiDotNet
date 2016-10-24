using System;
using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.Model;

namespace ActivitiDotNet.User
{
    public class UserInfoProvider : BaseInfoProvider<UserInfo>, IReadable<UserInfo>, IWriteable<UserInfo>, IRemoveable<UserInfo>
    {
        public UserInfoProvider() : base(UrlConstants.USER)
        {

        }

        public UserInfoProvider(string url) : base(url) { }

        public new void Create(ref UserInfo value)
        {
            base.Create(ref value);
        }

        public new  UserInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<UserInfo> GetAll()
        {
            return base.GetAll();
        }

        public new UserInfo Update(string id, UserInfo value)
        {
            return base.Update(id, value);
        }

        public new UserInfo Delete(string id)
        {
            return base.Delete(id);
        }

        public new bool TryDelete(string id, out UserInfo value)
        {
            return base.TryDelete(id, out value);
        }
    }
}
