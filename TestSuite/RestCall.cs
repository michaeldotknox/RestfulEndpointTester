using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestSuite
{
    public static class RestCall
    {
        public async static Task<RestCallContentResult<TContentOut>> CallGetAsync<TContentOut>(Uri uri) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public async static Task<RestCallContentResult<TContentOut>> CallPostAsync<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) {Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")};
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public static async Task<RestCallContentResult<TContentOut>> CallPutAsync<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) {Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json")};
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        public async static Task<RestCallNoContentResult> CallOptionsAsync(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
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
    }
}
