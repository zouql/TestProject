namespace TestWebApi.Controllers
{
    using System.Web.Http;

    public class TestController : ApiController
    {
        [HttpGet]
        public string TestGet(int value)
        {
            return $"value:{value}";
        }

        [HttpPost]
        public string TestPost(Model model)
        {
            return $"value:{model?.Value}";
        }

        public class Model
        {
            public int Value { get; set; }
        }
    }
}
