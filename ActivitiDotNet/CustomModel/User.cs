using System.Runtime.Serialization;

namespace ActivitiDotNet.Model
{
    [DataContract]
    public class UserInfo
    {
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url;

        [DataMember(Name = "user", EmitDefaultValue = false)]
        public string User;

        [DataMember(Name = "group", EmitDefaultValue = false)]
        public string Group;

        [DataMember(Name = "type", EmitDefaultValue = false)]
        public string Type; 
    }
}
