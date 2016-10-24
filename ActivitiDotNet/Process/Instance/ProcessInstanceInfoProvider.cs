using System;
using System.Collections.Generic;
using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.CustomModel;
using ActivitiDotNet.Enums;
using ActivitiDotNet.Helpers;
using ActivitiDotNet.Model;
using ActivitiDotNet.Network;
using ActivitiDotNet.Network.Model;
using ActivitiDotNet.Variable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActivitiDotNet.Process.Instance
{
    public class ProcessInstanceInfoProvider : BaseInfoProvider<ProcessInstanceInfo>, IReadable<ProcessInstanceInfo>, IRemoveable<ProcessInstanceInfo>
    {
        private string baseUrl;
        public ProcessInstanceInfoProvider() : base(UrlConstants.PROCESS_INSTANCE) { }

        public new ProcessInstanceInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<ProcessInstanceInfo> GetAll()
        {
            return base.GetAll();
        }

        public new ProcessInstanceInfo Delete(string id)
        {
            return base.Delete(id);
        }

        public new bool TryDelete(string id, out ProcessInstanceInfo value)
        {
            return base.TryDelete(id, out value);
        }

        public ProcessInstanceInfo ActivateOrSuspend(string processId, ActivateOrSuspend activateOrSuspend)
        {
            JObject body = new JObject();
            body.Add("action", activateOrSuspend.ToString().ToLower());

            string url = string.Concat(UrlConstants.PROCESS_INSTANCE, "/", processId);
            return ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", body.ToString());
        }

        public ProcessInstanceInfo Start(ProcessInstanceInfo process)
        {
            return ExecuteOperation(UrlConstants.PROCESS_INSTANCE, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(process));
        }

        public UserInfo AddInvolvedUser(string processInstanceId, UserInfo user)
        {
            string url = string.Format("{0}/{1}/identitylinks", UrlConstants.PROCESS_INSTANCE, processInstanceId);
            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(user));
        }

        public UserInfo RemoveInvolvedUser(string processInstanceId, string userId, string userType)
        {
            string url = string.Format("{0}/{1}/identitylinks/users/{2}/{3}", UrlConstants.PROCESS_INSTANCE, processInstanceId, userId, userType);
            return BaseInfoProvider<UserInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit");
        }

        public List<VariableInfo> GetVariables(string processInstanceId)
        {
            string url = string.Format("{0}/{1}/variables", UrlConstants.PROCESS_INSTANCE, processInstanceId);
            return BaseInfoProvider<List<VariableInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public VariableInfo GetVariable(string processInstanceId, string variableName)
        {
            string url = string.Format("{0}/{1}/variables", UrlConstants.PROCESS_INSTANCE, processInstanceId);
            VariableInfoProvider variableProvider = new VariableInfoProvider(url);

            return variableProvider.Get(variableName);
        }

        public VariableInfo UpdateVariable(string processInstance, VariableInfo variable)
        {
            string url = string.Format("{0}/{1}/variables/{2}", UrlConstants.PROCESS_INSTANCE, processInstance, variable.Name);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo CreateVariable(string processInstance, VariableInfo variable)
        {
            string url = string.Format("{0}/{1}/variables/{2}", UrlConstants.PROCESS_INSTANCE, processInstance, variable.Name);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo UpdateVariables(string processInstance, List<VariableInfo> variable)
        {
            string url = string.Format("{0}/{1}/variables", UrlConstants.PROCESS_INSTANCE, processInstance);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo CreateVariables(string processInstanceId, List<VariableInfo> variable)
        {
            string url = string.Format("{0}/{1}/variables", UrlConstants.PROCESS_INSTANCE, processInstanceId);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public ProcessInstanceInfo GetDiagram(string processId)
        {
            string url = string.Format("{0}/{1}/diagram", UrlConstants.PROCESS_INSTANCE, processId);

            return ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public List<UserInfo> GetInvolvedUsers(string processId)
        {
            string url = string.Format("{0}/{1}/{2}/identitylinks", UrlConstants.PROCESS_INSTANCE, processId);

            return BaseInfoProvider<List<UserInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }


    }
}
