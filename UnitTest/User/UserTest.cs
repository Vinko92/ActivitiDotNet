using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

using ActivitiDotNet.Configuration;
using ActivitiDotNet.Model;
using ActivitiDotNet.User;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest.User
{

    [TestClass]
    public class UserTest
    {
        static UserInfoProvider _provider;
        static List<UserInfo> _users;
        static UserInformations _testUserInformation;
        static UserInfo _testUser;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            ConfigurationManager config = ConfigurationManager.Instance.AddBaseUrl("http://localhost:8080/activiti-rest");
            AuthorizationManager authorizationManager = AuthorizationManager.Instance;
            authorizationManager.Login("kermit", "kermit");

            _provider = new UserInfoProvider();
            _testUser = new UserInfo
            {
                Id = "uniquetestuser",
                FirstName = "test",
                LastName = "test",
                Email = "test@test.com",
            };

            _testUserInformation = new UserInformations
            {
                Key = "dana",
                Value = "petog"
            };

        }

        [TestMethod]
        public void GetAll_Success()
        {
            Assert.IsNotNull(_provider.GetAll());
        }


        [TestMethod]
        public void AddUser_Success()
        {
            _provider.Create(ref _testUser);

            Assert.AreNotEqual(_testUser.Url, string.Empty);
            Assert.AreEqual(_users.Count + 1, _provider.GetAll().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void AddUser_UserWithIdAlreadyExist()
        {
            _provider.Create(ref _testUser);
        }

        [TestMethod]
        public void GetSingleUser_ShoulldReturnUserWithGivenId()
        {
            var user = _provider.Get(_testUser.Id);

            Assert.IsNotNull(user);
            Assert.AreEqual(user.Id, _testUser.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void GetSingleUser_IdDoesNotExist_ShouldThrowWebException()
        {
             _provider.Get(_testUser.Id + new Random(DateTime.Now.Millisecond).Next());
        }

        [TestMethod]
        public void UpdateUser_UpdateUserFirstName_ShouldPass()
        {
            string oldFirstName = _testUser.FirstName;
            string newFirstname = "newFirstNameTest";
            _testUser.FirstName = newFirstname;
            _testUser.Password = "Test";

            _provider.Update(_testUser.Id, _testUser);

            Assert.AreNotEqual(oldFirstName, _provider.Get(_testUser.Id).FirstName);
            Assert.AreEqual(newFirstname, _provider.Get(_testUser.Id).FirstName);
        }

        [TestMethod]
        public void DeleteUser_UserExists_ShouldPass()
        {
            var response = _provider.Delete(_testUser.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void DeleteUser_UserDoesNotExist_ExpectWebException()
        {
            var response = _provider.Delete(_testUser.Id);

        }

        [TestMethod]
        public void GetUserInformtions_ShouldPass()
        {
            var informations = _testUser.Informations;

            Assert.IsNotNull(informations);
        }

        [TestMethod]
        public void AddUserInformation_AddInfoToExistingUser()
        {
            _testUser.Informations.Add(new UserInformations { Key = "mesecRodjenja", Value = "jul" });
        }

        [TestMethod]
        public void GetUserPicture_UserExists_ShouldReturnByteArrayAsUserPicutre()
        {
            var data = _provider.GetUserPicture(_testUser.Id);
        }

        [TestMethod]
        public void UpdateUserPictureToExistingUser_ShouldSuccess()
        {
            _provider.UpdateUserPicutre(_testUser.Id, File.ReadAllBytes(@"C:\Users\zoric\OneDrive\Slike\800.jpg"), "avatar");
        }

        [TestMethod]
        public void CreateUserInformation_UserExists()
        {
            var userInformation = _provider.CreateUserInformation(_testUser.Id, _testUserInformation);

            Assert.IsNotNull(userInformation);
        }

        [TestMethod]
        public void GetSingleUserInformation_UserExists()
        {
            var info = _provider.GetUserInformation(_testUser.Id, _testUserInformation.Key);

            Assert.IsNotNull(info);
            Assert.AreEqual(_testUserInformation.Value, info.Value);
        }

        [TestMethod]
        public void GetAllUserInformations_UserExists()
        {
            var list = _provider.GetUserInformations(_testUser.Id);

            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void DeleteUserInfo_UserExists()
        {
            _provider.DeleteUserInformation(_testUser.Id, _testUserInformation.Key);
        }






    }
}
