using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyFit.models;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace MyFit.helpers
{
    public class RestService
    {
        public static HttpClient client;
        public static string uri = "https://myfitappserv.herokuapp.com/";

  public RestService()
        {
            client = new HttpClient();
        }

        public async Task<bool> RegisterAsync(
            string email, string password, string username, int weight, int height, int age, string fullname
            )
        {
            var user = new RegisterViewModel
            {
                email = email,
                username = username,
                password = password,
                fullname = fullname,
                height = height,
                poids = weight,
                age = age,

            };


            var json = JsonConvert.SerializeObject(user);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri + "auth/local/register", content);
            if(response.IsSuccessStatusCode)
            {
                //Debug.WriteLine(await response.Content.ReadAsStringAsync());
                var message = await response.Content.ReadAsStringAsync();
                var o = JObject.Parse(message);
                Debug.WriteLine(JsonConvert.SerializeObject(o));

                Settings.UserToken = o.Value<string>("jwt");

                Settings.UserFullName = (string)o.SelectToken("user.fullname");
                Settings.UserHeight = (string)o.SelectToken("user.height");
                Settings.UserWeight = (string)o.SelectToken("user.poids");
                

                Debug.WriteLine(Settings.UserFullName);
            }
            

            return response.IsSuccessStatusCode;
        }


        public async Task<bool> LoginAsync(string email, string password)
        {
            var user = new LoginViewModel
            {
                identifier = email,
                password = password,

            };

            var json = JsonConvert.SerializeObject(user);
            //Debug.WriteLine(json);
            HttpContent content = new StringContent(json);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri + "auth/local", content);

            var message = await response.Content.ReadAsStringAsync();

            //Debug.WriteLine(message);
            if (response.IsSuccessStatusCode)
            {
               
                    var o = JObject.Parse(message);
                    //Debug.WriteLine(JsonConvert.SerializeObject(o));

                    Settings.UserToken = o.Value<string>("jwt");
                    Settings.UserId = (string)o.SelectToken("user._id");
                    Settings.UserFullName = (string)o.SelectToken("user.fullname");
                    Settings.UserHeight = (string)o.SelectToken("user.height");
                    Settings.UserWeight = (string)o.SelectToken("user.poids");
                    Settings.UserCoursesList = (string)o.SelectToken("user.courses").ToString();
               
                //Debug.WriteLine(await response.Content.ReadAsStringAsync());

                

                //Debug.WriteLine(Settings.UserFullName);
            }

            return response.IsSuccessStatusCode;

        }

        public async Task<bool> CourseAddAsync(double calories, int steps, string maptrack)
        {
            var tour = new Course
            {
                courseStart = DateTime.Now.ToString("yyyy-MM-dd"),
                calories = calories,
                steps = steps,
                maptrack = maptrack,
                user = Settings.UserId
            };
            //var client1 = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Settings.UserToken);
            var json1 = JsonConvert.SerializeObject(tour);
            //Debug.WriteLine($"Hada ana json {json1}");
            HttpContent content1 = new StringContent(json1);
            content1.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(
                uri + "courses", content1);

            var message = await response.Content.ReadAsStringAsync();

            Debug.WriteLine(message);
           

            return response.IsSuccessStatusCode;

        }
    }
}
