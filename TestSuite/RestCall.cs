using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace TestSuite
{
    public static class RestCall
    {
        public async static Task<HttpResponseMessage> CallGetAsync(Uri uri)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(uri);

                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public async static Task<HttpResponseMessage> CallPostAsync<T>(Uri uri, T content)
        {
            throw new NotImplementedException();
        }

        public async static Task<HttpResponseMessage> CallPutAsync<T>(Uri uri, T content)
        {
            throw new NotImplementedException();
        }

        public async static Task<HttpResponseMessage> CallOptionsAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public async static Task<HttpResponseMessage> CallDeleteAsync(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
