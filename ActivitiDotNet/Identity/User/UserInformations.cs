using System.Runtime.Serialization;

namespace ActivitiDotNet.User
{
    [DataContract]
    public class UserInformations
    {
        [DataMember(Name = "key", EmitDefaultValue = false)]
        public string Key { get; set; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }
    }
}
