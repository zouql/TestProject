namespace TestConsole
{
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Newtonsoft.Json.Linq;

    class Program
    {
        public static readonly HttpClient httpClient;


        static Program()
        {
            httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        }

        static void Main(string[] args)
        {
            var getResult = TestGet();

            Console.WriteLine($"`Get返回结果：{getResult}");

            var postResult = TestPost();

            Console.WriteLine($"`Post返回结果：{postResult}");

            Console.ReadKey();
        }

        public static string TestGet()
        {
            var baseUrl = "http://localhost/TestWebApi";

            var val = "123";

            var msg = httpClient.GetAsync($"{baseUrl}/api/Test/TestGet?value={val}").Result;

            var result = msg.Content.ReadAsStringAsync().Result;

            return result;
        }

        public static string TestPost()
        {
            var baseUrl = "http://localhost/TestWebApi";

            var val = new JObject
            {
                { "Value", 123 }
            };

            var msg = httpClient.PostAsync($"{baseUrl}/api/Test/TestPost", new StringContent(val.ToString(), Encoding.UTF8, "application/json")).Result;

            var result = msg.Content.ReadAsStringAsync().Result;

            return result;
        }
    }
}
