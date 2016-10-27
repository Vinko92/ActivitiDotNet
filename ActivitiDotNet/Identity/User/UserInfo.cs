using System.Runtime.Serialization;
using ActivitiDotNet.Collection;
using ActivitiDotNet.Constants;
using ActivitiDotNet.User;

namespace ActivitiDotNet.Model
{
    [DataContract]
    public class UserInfo
    {
        private BaseInfoCollection<UserInformations> _infos;

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        public string LastName { get; set; }

        [DataMember(Name = "password", EmitDefaultValue = false)]
        public string Password { get; set; }

        [DataMember(Name = "email", EmitDefaultValue = false)]
        public string Email { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "user", EmitDefaultValue = false)]
        public string User { get; set; }

        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string Group { get; set; }

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type { get; set; }

        public BaseInfoCollection<UserInformations> Informations
        {
            get
            {
                if(_infos == null)
                {
                    _infos = new BaseInfoCollection<UserInformations>(string.Format("{0}/{1}/info",UrlConstants.USER, Id));
                }

                return _infos;
            }
        }


    }
}
