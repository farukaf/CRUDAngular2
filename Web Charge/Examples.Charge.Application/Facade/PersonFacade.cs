using AutoMapper;
using Examples.Charge.Application.Common.Messages;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Application.Interfaces;
using Examples.Charge.Application.Messages.Request;
using Examples.Charge.Application.Messages.Response;
using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Application.Facade
{
    public class PersonFacade : IPersonFacade
    {
        private readonly IPersonService _personService;
        private readonly IMapper _mapper;

        public PersonFacade(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<PersonResponse> FindAllAsync()
        {
            var result = await _personService.FindAllAsync();
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.AddRange(result.Select(x => _mapper.Map<PersonDto>(x)));
            return response;
        }

        public async Task<PersonResponse> GetAsync(int id)
        {
            var result = await _personService.GetAsync(id);
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.Add(_mapper.Map<PersonDto>(result));
            return response;
        }

        public async Task<BaseResponse> PostAsync(PersonRequest request)
        {
            var result = await _personService.PostAsync(_mapper.Map<Person>(request));
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.Add(_mapper.Map<PersonDto>(result));
            return response;
        }

        public async Task<PersonResponse> PutAsync(int id, PersonRequest request)
        {
            var result = await _personService.PutAsync(id, _mapper.Map<Person>(request));
            var response = new PersonResponse();
            response.PersonObjects = new List<PersonDto>();
            response.PersonObjects.Add(_mapper.Map<PersonDto>(result));
            return response;
        }

        public async Task<PhoneNumberTypeResponse> GetPhoneNumberTypes()
        {
            var result = await _personService.GetPhoneNumberTypes();
            var response = new PhoneNumberTypeResponse();
            response.PhoneNumberTypeObjects = new List<PhoneNumberTypeDto>();
            response.PhoneNumberTypeObjects.AddRange(result.Select(x => _mapper.Map<PhoneNumberTypeDto>(x)));
            return response;
        }

    }
}
