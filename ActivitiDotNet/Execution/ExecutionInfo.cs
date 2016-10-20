using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ActivitiDotNet.Execution
{
    [DataContract]
    public class ExecutionInfo
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "parentId", EmitDefaultValue = false)]
        public string ParentId { get; set; }

        [DataMember(Name = "parentUrl", EmitDefaultValue = false)]
        public string ParentUrl { get; set; }

        [DataMember(Name = "processInstanceId", EmitDefaultValue = false)]
        public string ProcessInstanceId { get; set; }

        [DataMember(Name = "processInstanceUrl", EmitDefaultValue = false)]
        public string ProcessInstanceUrl { get; set; }

        [DataMember(Name = "suspended", EmitDefaultValue = false)]
        public string Suspended { get; set; }

        [DataMember(Name = "activityId", EmitDefaultValue = false)]
        public string ActivityId { get; set; }

        [DataMember(Name = "tenantId", EmitDefaultValue = false)]
        public string TenantId { get; set; }
    }
}
