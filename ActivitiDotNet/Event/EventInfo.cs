using System.Runtime.Serialization;

namespace ActivitiDotNet.Event
{
    [DataContract]
    public class EventInfo
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "action", EmitDefaultValue = false)]
        public string Action { get; set; }

        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        [DataMember(Name = "taskUrl", EmitDefaultValue = false)]
        public string TaskUrl { get; set; }

        [DataMember(Name = "time", EmitDefaultValue = false)]
        public string Time { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "userId", EmitDefaultValue = false)]
        public string UserId { get; set; }



    }
}
