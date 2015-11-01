using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            using (var client = new HttpClient())
                try
                {
                    var response = await client.PostAsync(uri, new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json"));

                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async static Task<HttpResponseMessage> CallPutAsync<T>(Uri uri, T content)
        {
            using (var client = new HttpClient())
                try
                {
                    var response =
                        await
                            client.PutAsync(uri,
                                new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8,
                                    "application/json"));

                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async static Task<HttpResponseMessage> CallOptionsAsync(Uri uri)
        {
            using (var client = new HttpClient())
                try
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
                    var response = await client.SendAsync(requestMessage);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async static Task<HttpResponseMessage> CallDeleteAsync(Uri uri)
        {
            using (var client = new HttpClient())
                try
                {
                    var response = await client.DeleteAsync(uri);
                    return response;
                }
                catch (Exception e)
                {
                    throw e;
                }
        }

        public async static Task<HttpResponseMessage> CallPatchAsync<T>(Uri uri, T content)
        {
            throw new NotImplementedException();
        }
    }
}
