using System;
using KnockKnock.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KnockKnock.Api.Controllers
{
    [Route("api/[controller]")]
    public class Token : Controller
    {
        public Token(ITokenService service)
        {
            Service = service;
        }

        private ITokenService Service { get; }

        [HttpGet]
        public Guid Get()
        {
            return Service.GetToken();
        }
    }
}