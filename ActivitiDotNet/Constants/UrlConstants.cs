namespace ActivitiDotNet.Constants
{
    public class UrlConstants
    {
        public const string IDENTITY = "/service/identity/";
        public const string REPOSITORY = "/service/repository/";
        public const string RUNTIME = "/service/runtime/";

        public const string DEPLOYMENT = REPOSITORY + "deployments";
        public const string DEPLOYMENT_RESOURCES = DEPLOYMENT + "{0}/resources";

        public const string EXECUTION = RUNTIME + "executions";

        public const string GROUP = IDENTITY + "groups";

        public const string MODEL = REPOSITORY + "models";

        public const string PROCESS = REPOSITORY + "process-definitions";
        public const string PROCESS_INSTANCE =  RUNTIME + "process-instances";

        public const string TASK = RUNTIME + "tasks";

        public const string USER = IDENTITY + "users";

    }
}
