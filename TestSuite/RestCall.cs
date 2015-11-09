using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestSuite
{
    public static class RestCall
    {
        public static async Task<RestCallContentResult<TContentOut>> CallGetAsync<TContentOut>(Uri uri, string username,
            string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public async static Task<RestCallContentResult<TContentOut>> CallGetAsync<TContentOut>(Uri uri) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public async static Task<RestCallContentResult<TContentOut>> CallPostAsync<TContentOut, TContentIn>(Uri uri, TContentIn content, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public async static Task<RestCallContentResult<TContentOut>> CallPostAsync<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public static async Task<RestCallContentResult<TContentOut>> CallPutAsync<TContentOut, TContentIn>(Uri uri, TContentIn content, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public static async Task<RestCallContentResult<TContentOut>> CallPutAsync<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public async static Task<RestCallNoContentResult> CallOptionsAsync(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallWithoutContentAsync(requestMessage);
        }

        public async static Task<RestCallNoContentResult> CallOptionsAsync(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
            return await MakeRestCallWithoutContentAsync(requestMessage);
        }

        public async static Task<RestCallNoContentResult> CallDeleteAsync(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallWithoutContentAsync(requestMessage);
        }

        public async static Task<RestCallNoContentResult> CallDeleteAsync(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            return await MakeRestCallWithoutContentAsync(requestMessage);
        }

        public static async Task<RestCallContentResult<TContentOut>> CallPatchAsync<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            throw new NotImplementedException();
        }

        private async static Task<RestCallContentResult<TContent>> MakeRestCallAsync<TContent>(HttpRequestMessage request) where TContent : class
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var callResult = await client.SendAsync(request);
                    var result = new RestCallContentResult<TContent>
                    {
                        Headers = callResult.Headers,
                        Status = callResult.StatusCode,
                        Content = JsonConvert.DeserializeObject<TContent>(await callResult.Content.ReadAsStringAsync()),
                        HttpResponseMessage = callResult
                    };

                    return result;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        private async static Task<RestCallNoContentResult> MakeRestCallWithoutContentAsync(HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                var callResult = await client.SendAsync(request);
                var result = new RestCallNoContentResult
                {
                    Headers = callResult.Headers,
                    Status = callResult.StatusCode,
                    HttpResponseMessage = callResult
                };

                return result;
            }
        }

        private static string Encode(string username, string password)
        {
            var encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            return encodedString;
        }
    }
}
