using System.Text;

namespace ActivitiDotNet.Helpers
{
    internal static class StringExtensions
    {
        public static string ToBase64(this string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            return System.Convert.ToBase64String(inputBytes); 
        }

    }
}
