using System.Runtime.Serialization;
using ActivitiDotNet.Collection;
using ActivitiDotNet.Constants;
using ActivitiDotNet.Model;

namespace ActivitiDotNet.CustomModel
{
    [DataContract]
    public class GroupInfo
    {
        private BaseInfoCollection<UserInfo> _members;

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        //public BaseInfoCollection<UserInfo> Members
        //{
        //    get
        //    {
        //        if(_members == null)
        //        {
        //            _members = new BaseInfoCollection<UserInfo>(string.Format("{0}/{1}/members", UrlConstants.GROUP, Id));
        //        }

        //        return _members;
        //    }
        //}

    }
}
