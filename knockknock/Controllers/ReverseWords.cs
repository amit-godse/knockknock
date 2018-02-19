using KnockKnock.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KnockKnock.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReverseWords : Controller
    {
        public ReverseWords(IReverseWordsService service)
        {
            Service = service;
        }

        private IReverseWordsService Service { get; }

        // GET api/values/5
        [HttpGet]
        public string Get(string sentence)
        {
            return Service.ReverseWord(sentence);
        }
    }
}