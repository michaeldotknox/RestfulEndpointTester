using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestfulEndpoints
{
    public static class RestCall
    {
        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallGet(string uri, string username, string password)
        {
            return CallGet(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallGet(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCall(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallGet(string uri)
        {
            return CallGet(CreateUri(uri));
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallGet(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return MakeRestCall(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallGet<TContentOut>(string uri, string username, string password) where TContentOut : class
        {
            return CallGet<TContentOut>(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallGet<TContentOut>(Uri uri, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCall<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallGet<TContentOut>(string uri)
            where TContentOut : class
        {
            return CallGet<TContentOut>(CreateUri(uri));
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallGet<TContentOut>(Uri uri) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return MakeRestCall<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult> CallGetAsync(string uri, string username, string password)
        {
            return await CallGetAsync(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult> CallGetAsync(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET call to an endpoint returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult> CallGetAsync(string uri)
        {
            return await CallGetAsync(CreateUri(uri));
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET call to an endpoint returning an object as the resulting content
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult> CallGetAsync(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return await MakeRestCallAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult<TContentOut>> CallGetAsync<TContentOut>(string uri, string username, string password) where TContentOut : class
        {
            return await CallGetAsync<TContentOut>(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult<TContentOut>> CallGetAsync<TContentOut>(Uri uri, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET call to an endpoint returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult<TContentOut>> CallGetAsync<TContentOut>(string uri)
            where TContentOut : class
        {
            return await CallGetAsync<TContentOut>(CreateUri(uri));
        }

        /// <summary>
        /// Makes a synchronous HTTP GET call to an endpoint returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult<TContentOut>> CallGetAsync<TContentOut>(Uri uri) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPost<TContentIn>(string uri, TContentIn content, string username, string password)
        {
            return CallPost(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPost<TContentIn>(Uri uri, TContentIn content, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCall(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPost<TContentIn>(string uri, TContentIn content)
        {
            return CallPost(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPost<TContentIn>(Uri uri, TContentIn content)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return MakeRestCall(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP POST call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPost<TContentOut, TContentIn>(string uri, TContentIn content, string username, string password) where TContentOut : class
        {
            return CallPost<TContentOut, TContentIn>(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP POST call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPost<TContentOut, TContentIn>(Uri uri, TContentIn content, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCall<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP POST call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPost<TContentOut, TContentIn>(string uri, TContentIn content) where TContentOut : class
        {
            return CallPost<TContentOut, TContentIn>(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes a synchronous HTTP POST call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPost<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return MakeRestCall<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult> CallPostAsync<TContentIn>(string uri, TContentIn content, string username, string password)
        {
            return await CallPostAsync(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult> CallPostAsync<TContentIn>(Uri uri, TContentIn content, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult> CallPostAsync<TContentIn>(string uri, TContentIn content)
        {
            return await CallPostAsync(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the POST</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult> CallPostAsync<TContentIn>(Uri uri, TContentIn content)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return await MakeRestCallAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP POST call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult<TContentOut>> CallPostAsync<TContentOut, TContentIn>(string uri, TContentIn content, string username, string password) where TContentOut : class
        {
            return await CallPostAsync<TContentOut, TContentIn>(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP POST call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult<TContentOut>> CallPostAsync<TContentOut, TContentIn>(Uri uri, TContentIn content, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP POST call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult<TContentOut>> CallPostAsync<TContentOut, TContentIn>(string uri, TContentIn content) where TContentOut : class
        {
            return await CallPostAsync<TContentOut, TContentIn>(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes an asynchronous HTTP POST call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the POST</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the POST</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult<TContentOut>> CallPostAsync<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPut<TContentIn>(string uri, TContentIn content, string username, string password)
        {
            return CallPut(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPut<TContentIn>(Uri uri, TContentIn content, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCall(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPut<TContentIn>(string uri, TContentIn content)
        {
            return CallPut(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes a synchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult CallPut<TContentIn>(Uri uri, TContentIn content)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return MakeRestCall(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP PUT call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPut<TContentOut, TContentIn>(string uri, TContentIn content, string username, string password) where TContentOut : class
        {
            return CallPut<TContentOut, TContentIn>(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP PUT call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPut<TContentOut, TContentIn>(Uri uri, TContentIn content, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCall<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP PUT call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPut<TContentOut, TContentIn>(string uri, TContentIn content) where TContentOut : class
        {
            return CallPut<TContentOut, TContentIn>(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes a synchronous HTTP PUT call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static RestCallContentResult<TContentOut> CallPut<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return MakeRestCall<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult> CallPutAsync<TContentIn>(string uri, TContentIn content, string username, string password)
        {
            return await CallPutAsync(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint sending a basic authentication header and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult> CallPutAsync<TContentIn>(Uri uri, TContentIn content, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult> CallPutAsync<TContentIn>(string uri, TContentIn content)
        {
            return await CallPutAsync(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes an asynchronous HTTP Post call to an endpoint and returning an object as the resulting content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content to be sent with the PUT</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to send in with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult> CallPutAsync<TContentIn>(Uri uri, TContentIn content)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return await MakeRestCallAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP PUT call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult<TContentOut>> CallPutAsync<TContentOut, TContentIn>(string uri, TContentIn content, string username, string password) where TContentOut : class
        {
            return await CallPutAsync<TContentOut, TContentIn>(CreateUri(uri), content, username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP PUT call to an endpoint sending a basic authentication header and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult<TContentOut>> CallPutAsync<TContentOut, TContentIn>(Uri uri, TContentIn content, string username, string password) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP PUT call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public async static Task<RestCallContentResult<TContentOut>> CallPutAsync<TContentOut, TContentIn>(string uri, TContentIn content) where TContentOut : class
        {
            return await CallPutAsync<TContentOut, TContentIn>(CreateUri(uri), content);
        }

        /// <summary>
        /// Makes an asynchronous HTTP PUT call to an endpoint and returning a specific object type as the content
        /// </summary>
        /// <typeparam name="TContentIn">The type of the content that is sent with the PUT</typeparam>
        /// <typeparam name="TContentOut">The type of the content that is returned from the call</typeparam>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="content">The content to be sent with the PUT</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        public static async Task<RestCallContentResult<TContentOut>> CallPutAsync<TContentOut, TContentIn>(Uri uri, TContentIn content) where TContentOut : class
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri) { Content = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json") };
            return await MakeRestCallAsync<TContentOut>(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP OPTIONS call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallOptions(string uri, string username, string password)
        {
            return CallOptions(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP OPTIONS call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallOptions(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCallWithoutContent(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP GET OPTIONS to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallOptions(string uri)
        {
            return CallOptions(CreateUri(uri));
        }

        /// <summary>
        /// Makes a synchronous HTTP GET OPTIONS to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallOptions(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
            return MakeRestCallWithoutContent(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP OPTIONS call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallOptionsAsync(string uri, string username, string password)
        {
            return await CallOptionsAsync(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP OPTIONS call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallOptionsAsync(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallWithoutContentAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET OPTIONS to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallOptionsAsync(string uri)
        {
            return await CallOptionsAsync(CreateUri(uri));
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET OPTIONS to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallOptionsAsync(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Options, uri);
            return await MakeRestCallWithoutContentAsync(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP DELETE call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallDelete(string uri, string username, string password)
        {
            return CallDelete(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes a synchronous HTTP DELETE call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallDelete(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return MakeRestCallWithoutContent(requestMessage);
        }

        /// <summary>
        /// Makes a synchronous HTTP GET DELETE to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallDelete(string uri)
        {
            return CallDelete(CreateUri(uri));
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET DELETE to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public static RestCallNoContentResult CallDelete(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            return MakeRestCallWithoutContent(requestMessage);
        }
        /// <summary>
        /// Makes an asynchronous HTTP DELETE call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallDeleteAsync(string uri, string username, string password)
        {
            return await CallDeleteAsync(CreateUri(uri), username, password);
        }

        /// <summary>
        /// Makes an asynchronous HTTP DELETE call to an endpoint sending a basic authentication header
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <param name="username">The username to send in the authorization header</param>
        /// <param name="password">The password to send in the authorization header</param>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallDeleteAsync(Uri uri, string username, string password)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("basic", Encode(username, password));
            return await MakeRestCallWithoutContentAsync(requestMessage);
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET DELETE to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="string"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallDeleteAsync(string uri)
        {
            return await CallDeleteAsync(CreateUri(uri));
        }

        /// <summary>
        /// Makes an asynchronous HTTP GET DELETE to an endpoint
        /// </summary>
        /// <param name="uri">A <see cref="Uri"/> of the endpoint to call</param>
        /// <returns>A <see cref="RestCallContentResult"/> with the status and content of the response</returns>
        /// <returns>A <see cref="RestCallNoContentResult"/> with the status of the response</returns>
        public async static Task<RestCallNoContentResult> CallDeleteAsync(Uri uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);
            return await MakeRestCallWithoutContentAsync(requestMessage);
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

        private async static Task<RestCallContentResult> MakeRestCallAsync(HttpRequestMessage request)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var callResult = await client.SendAsync(request);
                    var result = new RestCallContentResult
                    {
                        Headers = callResult.Headers,
                        Status = callResult.StatusCode,
                        Content = JsonConvert.DeserializeObject<object>(await callResult.Content.ReadAsStringAsync()), // TODO:Not sure if this will work
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

        private static RestCallContentResult<TContent> MakeRestCall<TContent>(HttpRequestMessage request) where TContent : class
        {
            var task = MakeRestCallAsync<TContent>(request);
            Task.Run(() => task);

            return task.Result;
        }

        private static RestCallContentResult MakeRestCall(HttpRequestMessage request)
        {
            var task = MakeRestCallAsync(request);
            Task.Run(() => task);

            return task.Result;
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

        private static RestCallNoContentResult MakeRestCallWithoutContent(HttpRequestMessage request)
        {
            var task = MakeRestCallWithoutContentAsync(request);
            Task.Run(() => task);

            return task.Result;
        }

        private static Uri CreateUri(string uri)
        {
            var variables = Tests.GetCurentTest().Variables;

            var regex = new Regex(@"\$\{(\w+)\}");
            var matches = regex.Matches(uri);
            foreach (Match match in matches)
            {
                var replaceString = match.Groups[0].Value;
                var variableKey = match.Groups[1].Value;

                if (variables.ContainsKey(variableKey))
                {
                    uri = uri.Replace(replaceString, variables[variableKey]);
                }
                else
                {
                    throw new Exception($"Unable to find a variable named {variableKey}");
                }
            }
            return new Uri(uri);
        }

        private static string Encode(string username, string password)
        {
            var encodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
            return encodedString;
        }
    }
}
