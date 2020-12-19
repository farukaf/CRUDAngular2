using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<Person>> FindAllAsync() => (await _personRepository.FindAllAsync()).ToList();

        public async Task<Person> GetAsync(int id) => await _personRepository.GetAsync(id);

        public async Task<Person> PostAsync(Person person) => await _personRepository.PostAsync(person);

        public async Task<Person> PutAsync(int id, Person person) => await _personRepository.PutAsync(id, person);

        public async Task<List<PhoneNumberType>> GetPhoneNumberTypes() => (await _personRepository.FindAllPhoneNumberTypes()).ToList();

    }
}
