using KnockKnock.Common;
using KnockKnock.Service;
using Microsoft.AspNetCore.Mvc;

namespace KnockKnock.Api.Controllers
{
    [Route("api/[controller]")]
    public class TriangleType : Controller
    {
        public TriangleType(ITriangleTypeService service)
        {
            Service = service;
        }

        private ITriangleTypeService Service { get; }

        // GET api/values/5
        [HttpGet]
        public ShapeType Get(string a, string b, string c)
        {
            return Service.GetTriangleType(a, b, c);
        }
    }
}