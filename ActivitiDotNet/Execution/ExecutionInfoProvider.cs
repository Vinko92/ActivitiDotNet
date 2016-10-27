using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.CustomModel;
using ActivitiDotNet.Enums;
using ActivitiDotNet.Network;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActivitiDotNet.Execution
{
    public class ExecutionInfoProvider : BaseInfoProvider<ExecutionInfo>, IReadable<ExecutionInfo>
    {
        public ExecutionInfoProvider() : base(UrlConstants.EXECUTION) { }

        public new ExecutionInfo Get(string id)
        {
            return base.Get(id);
        }

        //TODO: Query

        public new List<ExecutionInfo> GetAll()
        {
            return base.GetAll();
        }

        public ExecutionInfo ExecuteAction(string executionId,ExecutionAction action, string name, List<VariableInfo> variables = null)
        {
            string url = string.Format("{0}/{1}", UrlConstants.EXECUTION, executionId);

            JObject json = new JObject();

            switch (action)
            {
                case ExecutionAction.Signal:
                    json.Add("action", "signal");
                    break;
                case ExecutionAction.SignalEventReceived:
                    json.Add("action", "signalEventReceived");
                    json.Add("signalName", name);
                    if(variables != null) json.Add("variables", JsonConvert.SerializeObject(variables));
                    break;
                case ExecutionAction.MessageEventReceived:
                    json.Add("action", "messageEventReceived");
                    json.Add("messageName", name);
                    if (variables != null) json.Add("variables", JsonConvert.SerializeObject(variables));
                    break;
            }

            return ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", json.ToString());
        }

        public List<string> GetActiveActivities(string executionId)
        {
            string url = string.Format("{0}/{1}/activities", UrlConstants.EXECUTION, executionId);

            return BaseInfoProvider<List<string>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public VariableInfo UpdateVariable(string executionId, VariableInfo variable)
        {
            string url = string.Format("{0}/{1}/variables/{2}", UrlConstants.EXECUTION, executionId, variable.Name);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo CreateVariable(string executionId, VariableInfo variable)
        {
            string url = string.Format("{0}/{1}/variables/{2}", UrlConstants.EXECUTION, executionId, variable.Name);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo UpdateVariables(string executionId, List<VariableInfo> variable)
        {
            string url = string.Format("{0}/{1}/variables", UrlConstants.EXECUTION, executionId);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.POST, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }

        public VariableInfo CreateVariables(string executionId, List<VariableInfo> variable)
        {
            string url = string.Format("{0}/{1}/variables", UrlConstants.EXECUTION, executionId);
            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.PUT, "kermit", "kermit", JsonConvert.SerializeObject(variable));
        }


        public List<VariableInfo> GetVariables(string executionId, Scope scope)
        {
            string scopeString = scope == Scope.Empty ? "" : scope.ToString();
            string url = string.Format("{0}/{1}/variables?scope={2}", UrlConstants.EXECUTION, executionId, scopeString);

            return BaseInfoProvider<List<VariableInfo>>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }

        public VariableInfo GetVariable(string executionId, string variableName, Scope scope)
        {
            string scopeString = scope == Scope.Empty ? "" : scope.ToString();
            string url = string.Format("{0}/{1}/variables/{2}?scope={3}", UrlConstants.EXECUTION, executionId, variableName, scopeString);

            return BaseInfoProvider<VariableInfo>.ExecuteOperation(url, HttpMethod.GET, "kermit", "kermit");
        }
    }
}
