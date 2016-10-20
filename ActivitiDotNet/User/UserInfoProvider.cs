using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitiDotNet.Abstract;
using ActivitiDotNet.Model;

namespace ActivitiDotNet.User
{
    public class UserInfoProvider : BaseInfoProvider<UserInfo>, IReadable<UserInfo>
    {
        public UserInfoProvider() : base("s")
        {

        }

        public new UserInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<UserInfo> GetAll()
        {
            return base.GetAll();
        }


    }
}
