using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiDotNet.Comment
{
    [DataContract]
    public class CommentInfo
    {
        [DataMember(Name ="id", EmitDefaultValue =false)]
        public string Id { get; internal set; }

        [DataMember(Name ="taskUrl", EmitDefaultValue =false)]
        public string TaskUrl { get; internal set; }

        [DataMember(Name = "processInstanceUrl", EmitDefaultValue =false)]
        public string  ProcessInstanceUrl { get; internal set; }

        [DataMember(Name ="message", EmitDefaultValue =false)]
        public string Message { get; set; }

        [DataMember(Name ="author", EmitDefaultValue =false)]
        public string Author { get; internal set; }

        [DataMember(Name ="time", EmitDefaultValue =false)]
        public string Time { get; internal set; }

        [DataMember(Name ="taskId", EmitDefaultValue =false)]
        public string TaskId { get; internal set; }

        [DataMember(Name ="processInstanceId", EmitDefaultValue =false)]
        public string  ProcessInstanceId { get; internal set; }


    }

}
