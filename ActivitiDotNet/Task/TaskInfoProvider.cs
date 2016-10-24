using System;
using System.Collections.Generic;
using System.Linq;
using ActivitiDotNet.Abstract;
using ActivitiDotNet.Collection;
using ActivitiDotNet.Comment;
using ActivitiDotNet.Constants;
using ActivitiDotNet.CustomModel;
using ActivitiDotNet.Enums;
using ActivitiDotNet.Event;
using ActivitiDotNet.Model;
using ActivitiDotNet.Network;
using ActivitiDotNet.User;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActivitiDotNet.Task
{
    public class TaskInfoProvider : BaseInfoProvider<TaskInfo>, IWriteable<TaskInfo>, IRemoveable<TaskInfo>
    {
        private string tasksUrl = UrlConstants.TASK;

        public TaskInfoProvider() : base(UrlConstants.TASK)
        {

        }

        public new TaskInfo Get(string id)
        {
            return base.GetAll().FirstOrDefault(task => task.Id == id);
        }

        public new List<TaskInfo> GetAll()
        {
            return base.GetAll();
        }
        public TaskInfo ExecuteAction(string taskId, TaskAction action)
        {
            return ExecuteAction(taskId, action, string.Empty, null);
        }

        public TaskInfo ExecuteAction(string taskId, TaskAction action, string assignee)
        {
            return ExecuteAction(taskId, action, assignee, null);
        }

        public TaskInfo ExecuteAction(string taskId, TaskAction action, string assignee, List<VariableInfo> variables)
        {
            string url = string.Format("{0}/{1}", tasksUrl, taskId);
            JObject json = new JObject();

            json.Add("action", action.ToString().ToLower());
            if (!string.IsNullOrEmpty(assignee)) json.Add("assignee", assignee);
            if (variables != null) json.Add("variables", JsonConvert.SerializeObject(variables));

            return ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", json.ToString());
        }


        public List<VariableInfo> GetVariables(string taskId, Scope scope)
        {
            string scopeString = scope == Scope.Empty ? "" : scope.ToString();
            string url = string.Format("{0}/{1}/variables?scope={2}", tasksUrl, taskId, scopeString);

            return BaseInfoProvider<List<VariableInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public VariableInfo GetVariable(string taskId, string variableName, Scope scope)
        {
            string scopeString = scope == Scope.Empty ? "" : scope.ToString();
            string url = string.Format("{0}/{1}/variables/{2}?scope={3}", tasksUrl, taskId, variableName, scopeString);

            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public VariableInfo UpdateVariable(string taskId, VariableInfo variable)
        {
            string url = string.Format("{0}/{1}/variables/{2}", tasksUrl, taskId, variable.Name);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo CreateVariable(string taskId, VariableInfo variable)
        {
            string url = string.Format("{0}/{1}/variables/{2}", tasksUrl, taskId, variable.Name);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo DeleteVariable(string taskId, string variableName, Scope scope)
        {
            string url = string.Format("{0}/{1}/variables/{2}?scope={3}", tasksUrl, taskId, variableName, scope.ToString().ToLower());

            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.DELETE, "kermit", "kermit");
        }

        public VariableInfo DeleteLocalVariables(string taskId, string variableName)
        {
            string url = string.Format("{0}/{1}/variables/{2}", tasksUrl, taskId, variableName);

            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.DELETE, "kermit", "kermit");
        }

        public List<UserInfo> GetIdentityInfo(string taskId, string family, string identityId, string type)
        {
            string url = string.Format("{0}/{1}/identitylinks/{2}/{3}/{4}", tasksUrl, taskId, family, identityId, type);

            return BaseInfoProvider<List<UserInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit","kermit");
        }

        public new TaskInfo Create(TaskInfo value)
        {
            throw new NotImplementedException();
        }

        public new TaskInfo Update(string id, TaskInfo value)
        {
            return base.Update(id, value);
        }

        public new TaskInfo Delete(string id)
        {
            return base.Delete(id);
        }

        public new bool TryDelete(string id, out TaskInfo value)
        {
            return base.TryDelete(id, out value);
        }

        public List<UserInfo> GetIdentityLinks(string taskId)
        {
            string url = string.Format("{0}/{1}/identitylinks", tasksUrl, taskId);

            return BaseInfoProvider<List<UserInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public List<UserInfo> GetUsers(string taskId)
        {
            string url = string.Format("{0}/{1}/identitylinks/users", tasksUrl, taskId);

            return BaseInfoProvider<List<UserInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public List<UserInfo> GetGroups(string taskId)
        {
            string url = string.Format("{0}/{1}/identitylinks/groups", tasksUrl, taskId);

            return BaseInfoProvider<List<UserInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public UserInfo GetIdentityLink(string taskId, IdentityLinkFamily family, string identityId, string type)
        {
            string url = string.Format("{0}/{1}/identitylinks/{2}/{3}/{4}",
                                      tasksUrl, taskId, family.ToString().ToLower(), identityId, type);

            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }


        public UserInfo CreateIdentityLink(string taskId, UserInfo identityLink)
        {
            string url = string.Format("{0}/{1}/identitylinks", tasksUrl, taskId);

            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(identityLink));
        }

        public UserInfo DeleteIdentityLink(string taskId, string identityId, IdentityLinkFamily family, string type)
        {
            string url = string.Format("{0}/{1}/identitylinks/{2}/{3}/{4}", tasksUrl, taskId, family.ToString().ToLower(), type);

            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, HttpMethod.DELETE, "kermit", "kermit");
        }

        public CommentInfo AddComment(string taskId, string message, bool saveProcessInstanceId = true)
        {
            string url = string.Format("{0}/{1}/comments", tasksUrl, taskId);

            return BaseInfoProvider<CommentInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit");
        }

        public BaseInfoCollection<CommentInfo> GetAllComments(string taskId)
        {
            string url = string.Format("{0}/{1}/comments", tasksUrl, taskId);

            return BaseInfoProvider<BaseInfoCollection<CommentInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public CommentInfo GetComment(string taskId, string commentId)
        {
            string url = string.Format("{0}/{1}/comments/{2}", tasksUrl, taskId, commentId);

            return BaseInfoProvider<CommentInfo>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");

        }
        public CommentInfo DeleteComment(string taskId, string commentId)
        {
            string url = string.Format("{0}/{1}/comments/{2}", tasksUrl, taskId, commentId);

            return BaseInfoProvider<CommentInfo>.ExecuteOperation(url, HttpMethod.DELETE, "kermit", "kermit");
        }

        public List<EventInfo> GetAllEvents(string taskId)
        {
            string url = string.Format("{0}/{1}/events", tasksUrl, taskId);

            return BaseInfoProvider<List<EventInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public EventInfo GetEvent(string taskId, string eventId)
        {
            string url = string.Format("{0}/{1}/events/{2}", tasksUrl, taskId, eventId);

            return BaseInfoProvider<EventInfo>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        void IWriteable<TaskInfo>.Create(ref TaskInfo value)
        {
            throw new NotImplementedException();
        }
    }
}