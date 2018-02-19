using KnockKnock.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KnockKnock.Api.Controllers
{
    [Route("api/[controller]")]
    public class Fibonacci : Controller
    {
        public Fibonacci(IFibonacciService service)
        {
            Service = service;
        }

        private IFibonacciService Service { get; }

        // GET api/values/5
        [HttpGet]
        public long Get(string n)
        {
            return Service.GetFibonacciNumberAtPosition(n);
        }
    }
}