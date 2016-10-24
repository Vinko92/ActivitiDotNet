using System.Collections.Generic;
using System.Runtime.Serialization;
using ActivitiDotNet.CustomModel;

namespace ActivitiDotNet.Process.Instance
{
    [DataContract]
    public class ProcessInstanceInfo
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "businessKey", EmitDefaultValue = false)]
        public string BusinessKey { get; set; }

        [DataMember(Name = "suspended", EmitDefaultValue = false)]
        public bool Suspended { get; set; }

        [DataMember(Name = "processDefinitionUrl", EmitDefaultValue = false)]
        public string ProcessDefinitionUrl { get; set; }

        [DataMember(Name = "processDefinitionId", EmitDefaultValue = false)]
        public string ProcessDefinitionId { get; set; }

        [DataMember(Name = "activityId", EmitDefaultValue = false)]
        public string ActivityId { get; set; }

        [DataMember(Name = "tenantId", EmitDefaultValue = false)]
        public string TenantId { get; set; }

        [DataMember(Name = "variables", EmitDefaultValue = false)]
        public List<VariableInfo> Variables { get; set; }

    }
}
