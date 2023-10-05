using LuvFinder_Blazor_WASM.Helpers;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LuvFinder_Blazor_WASM.Services
{
    public interface IHttpService
    {
        Task<T> Get<T>(string uri);
        Task<string> PostBlog<T>(string uri, IBrowserFile file,int blogid, string title, string body, string username);
        Task<T> Post<T>(string uri, object value);
    }

    public class HttpService : IHttpService
    {
        private HttpClient _httpClient;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;
        private IConfiguration _configuration;

        public HttpService(
            HttpClient httpClient,
            NavigationManager navigationManager,
            ILocalStorageService localStorageService,
            IConfiguration configuration
        ) {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _configuration = configuration;
        }

        public async Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return await sendRequest<T>(request);
        }

     
        public async Task<string> PostBlog<T>(string uri, IBrowserFile file, int blogid, string title, string body, string username)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
          
            var content = new MultipartFormDataContent();
            content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data");

            content.Add(new StringContent(blogid.ToString()), "blogid");
            content.Add(new StringContent(title), "title");
            content.Add(new StringContent(body), "body");
            content.Add(new StringContent(username), "username");
            
            var resized = await file.RequestImageFileAsync(file.ContentType, maxWidth: 500, maxHeight: 800);
            using Stream fileStream = resized.OpenReadStream();
            content.Add(new StreamContent(fileStream, (int)fileStream.Length), "files", "NewFile.png");
            
            request.Content = content;
            return await sendRequestFormData<T>(request);
        }

        public async Task<T> Post<T>(string uri, object value)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, uri);
            request.Content = new StringContent(JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return await sendRequest<T>(request);
        }

        // helper methods

        private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {
            // add jwt auth header if user is logged in and request is to the api url
            var user = await _localStorageService.GetItem<LuvFinder_ViewModels.User>("user");
            //var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            //if (user != null && isApiUrl)
            //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            using var response = await _httpClient.SendAsync(request);
            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("logout");
                return default;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
               var error =  await response.Content.ReadAsStringAsync();
               throw new Exception(error);
                //var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                //throw new Exception(error["message"]);
            }
            return await response.Content.ReadFromJsonAsync<T>();
        }

        //for form-data
        private async Task<string> sendRequestFormData<T>(HttpRequestMessage request)
        {
            // add jwt auth header if user is logged in and request is to the api url
            //var user = await _localStorageService.GetItem<LuvFinder_ViewModels.User>("user");
            //var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            //if (user != null && isApiUrl)
            //    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", user.Token);
            using var response = await _httpClient.SendAsync(request);
            // auto logout on 401 response
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _navigationManager.NavigateTo("logout");
                return default;
            }

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
            return await response.Content.ReadAsStringAsync();
        }

    }
}