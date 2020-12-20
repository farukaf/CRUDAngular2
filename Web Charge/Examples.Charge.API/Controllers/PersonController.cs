using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using System.Threading.Tasks;
using Examples.Charge.Application.Common.Messages;

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
        public async Task<ActionResult<PersonResponse>> Get(int id) => Response(await _facade.GetAsync(id));

        [HttpPost]
        public async Task<ActionResult<PersonResponse>> Post([FromBody] PersonRequest request) => Response(await _facade.PostAsync(request));

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonResponse>> Put(int id, [FromBody] PersonRequest request) => Response(await _facade.PutAsync(id,request));

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse>> Delete(int id) => Response(await _facade.DeleteAsync(id));

        [HttpGet("phoneNumberTypes")]
        public async Task<ActionResult<PhoneNumberTypeResponse>> GetPhoneNumberTypes() => Response(await _facade.GetPhoneNumberTypes());
    }
}
