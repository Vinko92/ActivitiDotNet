using System;

using ActivitiDotNet.Configuration;
using ActivitiDotNet.Model;
using ActivitiDotNet.Process;
using ActivitiDotNet.Process.Instance;
using ActivitiDotNet.Task;
using ActivitiDotNet.User;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager config = ConfigurationManager.Instance.AddBaseUrl("http://localhost:8080/activiti-rest");
            AuthorizationManager authorizationManager = AuthorizationManager.Instance;
            authorizationManager.Login("kermit", "kermit");

           // ProcessInfoProvider processProvider = new ProcessInfoProvider("S");
           // ProcessInstanceInfoProvider processInstanceProvider = new ProcessInstanceInfoProvider();

           // var allProcessDefinitions = processProvider.GetAll();

           // foreach (var processDefinition in allProcessDefinitions)
           // {
           //     Console.WriteLine(processDefinition.Id);
           // }

           //processProvider.AddUserCandidate(allProcessDefinitions[allProcessDefinitions.Count - 1].Id, "vzoric");
           // foreach (var user in processProvider.GetAllCandidateStarters("createTimersProcess:1:36"))
           // {
           //     Console.WriteLine(user.User);
            //}

            //ProcessInstanceInfo processInfo = new ProcessInstanceInfo
            //{
            //    BusinessKey = "jaVolim",
            //    ProcessDefinitionId = "reviewSaledLead:1:33"
            //};

            //processInstanceProvider.Create(ref processInfo);

            //processInfo.Variables.Add(new VariableInfo { Name = ""})
            // processInstanceProvider.GetAll().ForEach(x => Console.WriteLine(x.Id));

            // processInstanceProvider.ActivateOrSuspend("41", ActivitiDotNet.Enums.ActivateOrSuspend.Activate);


            //processInstanceProvider.ActivateOrSuspend("40", ActivitiDotNet.Enums.ActivateOrSuspend.Activate);

            //TaskInfoProvider provide = new TaskInfoProvider();
            //var task = provide.Get("50");
            //provide.GetAll().ForEach(x => Console.WriteLine(x.Id));
            //provide.ExecuteAction(task.Id, ActivitiDotNet.Enums.TaskAction.Claim, "kermit");
            //processInstanceProvider.ActivateOrSuspend("40", ActivitiDotNet.Enums.ActivateOrSuspend.Activate);
            // task.Comments.Add(new ActivitiDotNet.Comment.CommentInfo { Message = "This is test comment" });
            //task.Comments.Remove("78");
            ////provide.ExecuteAction("46", ActivitiDotNet.Enums.TaskAction.Complete);
            //task.Comments.Add(new ActivitiDotNet.Comment.CommentInfo
            //{
            //    Message = "Test message"
            //});

            UserInfoProvider userInfoProvider = new UserInfoProvider();

            //userInfoProvider.GetAll().ForEach(x => Console.WriteLine(x.FirstName));

            //UserInfo newUser = new UserInfo
            //{
            //    Id = "vzoric",
            //    FirstName = "vinko",
            //    LastName = "Zoric",
            //    Email = "vinkozoric@no-replay.com",
            //    Password = "testPass"
            //};

            userInfoProvider.Get("kermit");
            GroupInfoProvider group = new GroupInfoProvider();
            var groups = group.GetAll();
            foreach(UserInfo member in groups[0].Members)
            {
                Console.WriteLine(member.FirstName);
            }
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
