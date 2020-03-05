using System.Text;

namespace Arrowgene.Buffers
{
    internal static class Service
    {
        public static string ToHexString(byte[] data, string separator = null)
        {
            StringBuilder sb = new StringBuilder();
            int len = data.Length;
            for (int i = 0; i < len; i++)
            {
                sb.Append(data[i].ToString("X2"));
                if (separator != null && i < len - 1)
                {
                    sb.Append(separator);
                }
            }

            return sb.ToString();
        }

        public static string ToAsciiString(byte[] data, string separator = "  ")
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                char c = '.';
                if (data[i] >= 'A' && data[i] <= 'Z') c = (char) data[i];
                if (data[i] >= 'a' && data[i] <= 'z') c = (char) data[i];
                if (data[i] >= '0' && data[i] <= '9') c = (char) data[i];
                if (separator != null && i != 0)
                {
                    sb.Append(separator);
                }

                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}