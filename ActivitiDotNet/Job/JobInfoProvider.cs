using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActivitiDotNet.Abstract;
using ActivitiDotNet.Constants;
using ActivitiDotNet.Helpers;

namespace ActivitiDotNet.Job
{
    public class JobInfoProvider : BaseInfoProvider<JobInfo>, IReadable<JobInfo>
    {
        public JobInfoProvider() : base(UrlConstants.JOB) { }


        public new List<JobInfo> GetAll()
        {
            return base.GetAll();
        }

        public new List<JobInfo> GetAll(params string[] queryParameters)
        {
            return base.GetAll();
        }

        public new JobInfo Get(string id)
        {
            return base.Get(id);
        }

        public new JobInfo Delete(string id)
        {
            return base.Delete(id);
        }

        public void Execute(string jobId)
        {
            string url = UrlBuilder.BuildUrl(UrlConstants.JOB, jobId);

            ExecuteOperation(url, Network.HttpMethod.POST, "kermit", "kermit");
        }

        public string GetStackTrace(string jobId)
        {
            string url = UrlBuilder.BuildUrl(UrlConstants.JOB, jobId, "exception-stacktrace");

            return BaseInfoProvider<string>.ExecuteOperation(url, Network.HttpMethod.GET, "kermit", "kermit");
        }

    }
}
