using System;
using System.Runtime.Serialization;
using ActivitiDotNet.Collection;
using ActivitiDotNet.Comment;
using ActivitiDotNet.Constants;

namespace ActivitiDotNet.Task
{
    [DataContract]
    public class TaskInfo 
    {
        private TaskInfoProvider _provider;
        private BaseInfoCollection<CommentInfo> _comments;

        private TaskInfoProvider ProviderInstance
        {
            get
            {
                if (_provider == null)
                {
                    _provider = new TaskInfoProvider();
                }

                return _provider;
            }
        }

        [DataMember(Name = "id", EmitDefaultValue = false)]
        public string Id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "assignee", EmitDefaultValue = false)]
        public string Assignee { get; set; }

        [DataMember(Name = "createTime", EmitDefaultValue = false)]
        public string CreateTime { get; set; }

        [DataMember(Name = "delegationState", EmitDefaultValue = false)]
        public string DelegationState { get; set; }

        [DataMember(Name = "description", EmitDefaultValue = false)]
        public string Description { get; set; }

        [DataMember(Name = "dueDate", EmitDefaultValue = false)]
        public string DueDate { get; set; }

        [DataMember(Name = "execution", EmitDefaultValue = false)]
        public string Execution { get; set; }

        [DataMember(Name = "owner", EmitDefaultValue = false)]
        public string Owner { get; set; }

        [DataMember(Name = "parentTask", EmitDefaultValue = false)]
        public string ParentTask { get; set; }

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public string Priority { get; set; }

        [DataMember(Name = "processDefinition", EmitDefaultValue = false)]
        public string ProcessDefinition { get; set; }

        [DataMember(Name = "processInstance", EmitDefaultValue = false)]
        public string ProcessInstance { get; set; }

        [DataMember(Name = "suspended", EmitDefaultValue = false)]
        public string Suspended { get; set; }

        [DataMember(Name = "taskDefinitionKey", EmitDefaultValue = false)]
        public string TaskDefinitionKey { get; set; }

        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }

        [DataMember(Name = "tenantId", EmitDefaultValue = false)]
        public string TenantId { get; set; }

        public BaseInfoCollection<CommentInfo> Comments
        {
            get
            {
                if(_comments == null)
                {
                   _comments = new BaseInfoCollection<CommentInfo>(string.Format("{0}/{1}/comments", UrlConstants.TASK, Id));
                }

                return _comments;
            }

            private set
            {
                this.Comments = value;
            }
        }
    }
}
