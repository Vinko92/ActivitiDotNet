using System.IO;

namespace ActivitiDotNet.Helpers
{
    internal static class IOHelper
    {
        public static byte[] ReadFile(string path, FileMode fileMode)
        {
            byte[] content = null;

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(File.Open(path, FileMode.Open)))
                {
                    string contentString = reader.ReadToEnd();
                    content = new byte[contentString.Length * sizeof(char)];
                    System.Buffer.BlockCopy(contentString.ToCharArray(), 0, content, 0, content.Length);
                }
            }
            else
            {
                throw new IOException(string.Format("File on the path {0} does not exist."));
            }

            return content;
        }

        public static string ReadStream(Stream stream)
        {
            string data = string.Empty;

            using(StreamReader reader = new StreamReader(stream))
            {
                data = reader.ReadToEnd();
            }

            return data;
        }

        public static byte[] ReadBytes(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];

            using (MemoryStream ms = new MemoryStream())
            {
                int read;

                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }

                return ms.ToArray();
            }
        }

    }
}
