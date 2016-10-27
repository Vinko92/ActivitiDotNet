using System;
using ActivitiDotNet.Configuration;
using ActivitiDotNet.Engine;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.Engine
{
    [TestClass]
    public class EngineTest
    {
        static EngineInfoProvider _provider;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ConfigurationManager config = ConfigurationManager.Instance.AddBaseUrl("http://localhost:8080/activiti-rest");
            AuthorizationManager authorizationManager = AuthorizationManager.Instance;
            authorizationManager.Login("kermit", "kermit");

            _provider = new EngineInfoProvider();
        }

        [TestMethod]
        public void GetEngineProperties()
        {
            _provider.GetProperties();
        }

        [TestMethod]
        public void GetEngineInformations()
        {
            _provider.Get();
        }
    }
}
