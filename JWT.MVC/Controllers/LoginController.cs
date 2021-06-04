using JWT.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace JWT.MVC.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult DoLogin()
        {

            return View();
        }

        private string apiURL = $"https://localhost:44319/WeatherForecast"; //API 2 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DoLogin([Bind("EmailOrName,Password")] LoginRequestModel loginRequestModel)
        {
            var apiName = $"https://localhost:44318/api/User/login";

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiName, loginRequestModel);
            var jasonString = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<IEnumerable<AccessibleDb>>
                    (jasonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach (var item in data)
            {
                item.UserName = loginRequestModel.EmailOrName;
            }

            return View("SelectDatabase" , data);
        }

      
        public async Task<IActionResult> PostLogin(string db, string user)
        {
            TokenRequestModel tokenRequestModel = new TokenRequestModel() { Database = db, UserName = user };

            var apiName = $"https://localhost:44318/api/User/tokenonly";

            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.PostAsJsonAsync(apiName, tokenRequestModel);
            var jasonString = await response.Content.ReadAsStreamAsync();

            var data = await JsonSerializer.DeserializeAsync<AuthenticationModel>
                    (jasonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            var stream = data.Token;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            var selectedDb = tokenS.Claims.First(claim => claim.Type == "Database").Value;

            ViewBag.SelectedDb = selectedDb;

            return View(data);
        }

        public async Task<IActionResult> GetTestData(string token)
        {

            var apiName = $"https://localhost:44318/api/testdata";

            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await httpClient.GetAsync(apiName);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = response.StatusCode;
                return View("Weatherdata");
            }
            var jasonString = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>
                    (jasonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            return View("Weatherdata", data);
        }

        // Following are call from Function API
        public async Task<IActionResult> GetWeatherData(string token)
        {

            var apiName = apiURL;
            try
            {
              //  var apiName = $"https://localhost:44338/WeatherForecast"; // API 1
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await httpClient.GetAsync(apiName);
                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Error = response.StatusCode;
                    return View("Weatherdata");
                }
                var jasonString = await response.Content.ReadAsStreamAsync();
                var data = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>
                      (jasonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            
                return View("Weatherdata" , data);


            }
            catch (Exception)
            {

                throw ;
                

            }

            

        }

    

        public async Task<IActionResult> GetToken(string token)
        {

            var apiName = apiURL + "/token";


            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(apiName);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = response.StatusCode;
                return View("Weatherdata");
            }
            var jasonString = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<AuthenticationModel>
                 (jasonString, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


            HttpClient httpClient2 = new HttpClient();
            httpClient2.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", data.Token);
            HttpResponseMessage response2 = await httpClient2.GetAsync(apiURL);
            if (!response2.IsSuccessStatusCode)
            {
                ViewBag.Error = response.StatusCode;
                return View("Weatherdata");
            }
            var jasonString2 = await response2.Content.ReadAsStreamAsync();
            var data2 = await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>
                  (jasonString2, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return View("Weatherdata", data2);


        }


    }
}
