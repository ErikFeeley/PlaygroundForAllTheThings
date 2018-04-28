using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AspNetCoreFirebaseTest.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private static HttpClient getHttpClient(string baseUrl) =>
            new HttpClient() { BaseAddress = new Uri(baseUrl) };

        private readonly string fireDataBaseUrl = "https://test-asp-net-core.firebaseio.com/";

        private static string getSignInUrl(string apiKey) => $"verifyPassword?key={apiKey}";

        private static string getUserDataUrl(string localId, string idToken) => $"users/{localId}/.json?auth={idToken}";

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var authClient = getHttpClient("https://www.googleapis.com/identitytoolkit/v3/relyingparty/");

            var dataClient = getHttpClient(fireDataBaseUrl);

            var wat = await authClient.PostAsync(getSignInUrl(FireBaseApiKey),
                new StringContent(JsonConvert.SerializeObject(
                    new SignInDto()
                    {
                        email = "test@admin.com",
                        password = "asdfqwer1234"
                    }
                ),
                Encoding.UTF8,
                "application/json"));

            var otherThing = JsonConvert.
                DeserializeObject<FireBaseAuthResponseDto>(await wat.Content.ReadAsStringAsync());

            var testData = await dataClient.GetAsync(getUserDataUrl(otherThing.localId, otherThing.idToken));

            var finalData = JsonConvert.DeserializeObject<UserDataResponseDto>(await testData.Content.ReadAsStringAsync());

            return Ok(finalData);
        }


        public class FireBaseAuthResponseDto
        {
            public string kind { get; set; }
            public string localId { get; set; }
            public string email { get; set; }
            public string displayName { get; set; }
            public string idToken { get; set; }
            public bool registered { get; set; }
            public string refreshToken { get; set; }
            public string expiresIn { get; set; }
        }

        public class UserDataResponseDto
        {
            public string distributor { get; set; }
            public string role { get; set; }
            public string testData { get; set; }
        }

        public class SignInDto
        {
            public string email { get; set; }

            public string password { get; set; }

            public bool returnSecureToken { get; } = true;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
