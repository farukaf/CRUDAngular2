using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
namespace Examples.Charge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : BaseController
    {
        private IPersonFacade _facade;

        public PersonController(IPersonFacade facade, IMapper mapper)
        {
            _facade = facade;
        }

        [HttpGet]
        public async Task<ActionResult<PersonResponse>> Get() => Response(await _facade.FindAllAsync());

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return Response(null);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonRequest request)
        {
            return Response(0, null);
        }
    }
}
