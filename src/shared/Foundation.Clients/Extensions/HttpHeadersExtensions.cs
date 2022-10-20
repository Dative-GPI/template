using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Foundation.Clients.Extensions
{
    public static class HttpHeadersExtensions
    {
        public static void Set(this HttpHeaders headers, string name, string value)
        {
            if (headers.Contains(name))
            {
                headers.Remove(name);
            }

            headers.Add(name, value);
        }

        public static void Set(this HttpHeaders headers, string name, IEnumerable<string> value)
        {
            if (headers.Contains(name))
            {
                headers.Remove(name);
            }

            headers.Add(name, value);
        }
    }
}