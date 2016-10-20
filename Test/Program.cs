using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitiDotNet.Configuration;
using ActivitiDotNet.Deployment;
using ActivitiDotNet.Model;
using ActivitiDotNet.Process;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager config = ConfigurationManager.Instance.AddBaseUrl("http://localhost:8080/activiti-rest");
            AuthorizationManager authorizationManager = AuthorizationManager.Instance;
            authorizationManager.Login("kermit", "kermit");

            ProcessInfoProvider processProvider = new ProcessInfoProvider("S");

            var allDeployments = processProvider.

            foreach (var deployment in allDeployments)
            {
                Console.WriteLine(deployment.Id);
            }

            Console.WriteLine(processProvider.Suspend("createTimersProcess:1:36").Name);

            //ModelInfo model = new ModelInfo
            //{
            //    TenantId = "tenant updated"
            //};

            //ModelInfoProvider prov = new ModelInfoProvider();
            //prov.Update("40",model);

            //Console.WriteLine(prov.Get("40").TenantId);

            Console.ReadLine();
        }

    }
}
