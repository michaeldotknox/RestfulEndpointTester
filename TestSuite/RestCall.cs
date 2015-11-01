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
    }
}
