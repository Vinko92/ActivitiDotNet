using System.Collections.Generic;
using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.Helpers;

namespace ActivitiDotNet.Engine
{
    public class EngineInfoProvider : BaseInfoProvider<EngineInfo>
    {

        public EngineInfoProvider() : base(UrlConstants.ENGINE)
        {

        }

        public EngineInfo Get()
        {
            string url = UrlConstants.ENGINE;

            return ExecuteOperation(url, Network.HttpMethod.GET, "kermit", "kermit");
        }
     
        public Dictionary<string,string> GetProperties()
        {
            string url = UrlConstants.ENGINE_PROPERTIES;

            return BaseInfoProvider<List<string>>.GetProperties(url, "kermit", "kermit");
        }
    }
}
