using System.Collections.Generic;

using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.CustomModel;
using ActivitiDotNet.Enums;
using ActivitiDotNet.Network;

namespace ActivitiDotNet.Execution
{
    public class ExecutionInfoProvider : BaseInfoProvider<ExecutionInfo>, IReadable<ExecutionInfo>
    {
        public ExecutionInfoProvider() : base(UrlConstants.EXECUTION) { }

        public new ExecutionInfo Get(string id)
        {
            return base.Get(id);
        }

        public new List<ExecutionInfo> GetAll()
        {
            return base.GetAll();
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
