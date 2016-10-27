namespace ActivitiDotNet.Helpers
{
    internal static class UrlBuilder
    {

        public static string BuildUrl(params string[] parameters)
        {
            return string.Join("/", parameters);
        }


    }
}
