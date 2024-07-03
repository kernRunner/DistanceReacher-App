using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DistanceReacher.Services
{
    internal static class ApiServiceDR
    {

        //Maintain one instance of a HttpClient to use for all requests
        private static HttpClient _client;
        private static HttpClient _clientMeilisearch;

        private static HttpClient _httpClient;

        private static string _baseUrlImg = "https://admin.api.distancereacher.de";
        private static string _baseUrl = DeviceInfo.Platform == DevicePlatform.Android? "https://admin.api.distancereacher.de/api/" : "https://admin.api.distancereacher.de/api/";

        private static string _baseMeilisearch = DeviceInfo.Platform == DevicePlatform.Android ? "https://search.api.distancereacher.de/multi-search" : "https://search.api.distancereacher.de/multi-search";
        private static string _bearerToken = "hH7p0Ob73jivfuOSHy_TKckYf73Icq6qzlbnVkt9eIhH7p0O";


        public static string BaseUrl => _baseUrlImg;

        static ApiServiceDR()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(_baseUrl);


            _clientMeilisearch = new HttpClient();
            _clientMeilisearch.BaseAddress = new Uri(_baseMeilisearch);

            _httpClient = new HttpClient();


            Console.WriteLine(_clientMeilisearch.BaseAddress);
            Console.WriteLine(_clientMeilisearch);
        }

        public static async Task<string> GetJsonFromAPI(string url)
        {
            //A HttpResponseMessage is a container containing all the response data
            HttpResponseMessage response = await _client.GetAsync(url);
            //This just checks if the response code is in the 200 range, indicating it was successful

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                //return the body content of the response as a string
                return json;
            }
            else
            {
                return "";
            }
        }

        //public static async Task<string> FetchDataFromMeiliSearch(string keyword)
        //{

        //    var content = new StringContent(JsonConvert.SerializeObject(new
        //    {
        //        queries = new[]
        //        {
        //            new { indexUid = "hotspot", q = keyword, limit = 5 },
        //            new { indexUid = "attraction", q = keyword, limit = 15 }
        //        }
        //    }), Encoding.UTF8, "application/json");

        //    _clientMeilisearch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);
            

        //    using (var response = await _clientMeilisearch.PostAsync("multi-search", content))
        //    {
        //        if (response.IsSuccessStatusCode)
        //        {
        //            string json = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(json);
        //            return json;
        //        }
        //        else
        //        {
        //            Console.WriteLine("error");
        //            return "";
        //        }
        //    }
        //}

        //public static async Task<string> FetchDataFromMeiliSearch(string keyword, bool isNewItem = false)
        //{
        //    try
        //    {
        //        var queries = new[]
        //        {
        //            new { indexUid = "hotspot", q = keyword, limit = 5 },
        //            new { indexUid = "attraction", q = keyword, limit = 15 }
        //        };
        //        Console.WriteLine("MMMMMMMMMMM");
        //        StringContent content = new StringContent("", Encoding.UTF8, "application/json");

        //        _clientMeilisearch.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

        //        HttpResponseMessage response = null;
        //        if (isNewItem)
        //            response = await _clientMeilisearch.PostAsync("", content);
        //        else
        //            response = await _clientMeilisearch.PutAsync("", content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            string jsonResponse = await response.Content.ReadAsStringAsync();
        //            Console.WriteLine(@"\tData successfully saved to MeiliSearch.");
        //            Console.WriteLine(jsonResponse);
        //            Console.WriteLine(@"\tData successfully saved to MeiliSearch.");
        //            return jsonResponse;
        //        }
        //        else
        //        {
        //            Console.WriteLine(@"\tFailed to save data to MeiliSearch. Status code: {0}", response.StatusCode);
        //            return "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(@"\tERROR: {0}", ex.Message);
        //        return "";
        //    }

        //}


        public static async Task<string> PostDataWithBearerTokenAsync(string keyword)
        {

            try
            {

                string jsonData = "{\r\n    \"queries\": [\r\n      {\r\n        \"indexUid\": \"hotspot\",\r\n        \"q\": \" " + keyword + "\",\r\n        \"limit\": 5\r\n      },\r\n      {\r\n        \"indexUid\": \"attraction\",\r\n        \"q\": \" " + keyword + "\",\r\n        \"limit\": 5\r\n      }\r\n    ]\r\n  }";


                // Prepare the HTTP request
                var request = new HttpRequestMessage(HttpMethod.Post, _baseMeilisearch);

                // Set the content of the request
                request.Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                // Add bearer token to the Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _bearerToken);

                // Send the request and get the response
                var response = await _httpClient.SendAsync(request);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    // Handle the error response
                    // For example:
                    // throw new Exception($"Error: {response.StatusCode}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // For example:
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }

        public static async Task<string> PostActivityWithBearerTokenAsync(string keyword)
        {
            try
            {

                string jsonData = "{\r\n    \"queries\": [\r\n      {\r\n        \"indexUid\": \"activity\",\r\n        \"q\": \" " + keyword + "\",\r\n        \"limit\": 20\r\n      }\r\n    ]\r\n}";

                var request = new HttpRequestMessage(HttpMethod.Post, _baseMeilisearch);

                request.Content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");

                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _bearerToken);

                var response = await _httpClient.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                // For example:
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }



    }
}
