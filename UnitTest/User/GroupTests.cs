using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitiDotNet.Configuration;
using ActivitiDotNet.CustomModel;
using ActivitiDotNet.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.User
{
    [TestClass]
    public class GroupTests
    {
        static GroupInfoProvider _provider;
        static GroupInfo _testGroup;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ConfigurationManager config = ConfigurationManager.Instance.AddBaseUrl("http://localhost:8080/activiti-rest");
            AuthorizationManager authorizationManager = AuthorizationManager.Instance;
            authorizationManager.Login("kermit", "kermit");

            _provider = new GroupInfoProvider();
            _testGroup = new GroupInfo
            {
                Id = "uniquetestgroup",
                Name= "direktor",
                Type = "teski direktor"
            };
        }

        [TestMethod]
        public void CreateNewGroup()
        {
            _provider.Create(ref _testGroup);

            Assert.AreNotEqual(string.Empty, _testGroup.Id);
        }

        [TestMethod]
        public void GetGroup_GroupExists()
        {
            var group = _provider.Get(_testGroup.Id);

            Assert.IsNotNull(group);
            Assert.AreEqual(_testGroup.Id, group.Id);
        }

        [TestMethod]
        public void GetAllGroups()
        {
            var groups = _provider.GetAll();

            Assert.IsNotNull(groups);
        }

        [TestMethod]
        public void UpdateGroup_GroupExists()
        {
            _testGroup.Name = "new group name";

            var group = _provider.Update(_testGroup.Id, _testGroup);
        }

        [TestMethod]
        public void DeleteGroup_GroupExists()
        {
            _provider.Delete(_testGroup.Id);
        }

        [TestMethod]
        public void GetMembers_GroupExists()
        {
            var list = _provider.GetMembers(_testGroup.Id);

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void AddMemberToExistsingGroup()
        {
            _provider.AddMember(_testGroup.Id,"kermit");
        }

        [TestMethod]
        public void RemoveMemeberFromExistingGroup()
        {
            _provider.DeleteMember(_testGroup.Id, "kermit");
        }
    }
    }
