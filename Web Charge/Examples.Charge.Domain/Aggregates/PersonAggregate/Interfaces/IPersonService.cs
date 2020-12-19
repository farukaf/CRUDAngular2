using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonService
    {
        Task<List<Person>> FindAllAsync();
        Task<Person> GetAsync(int id);
        Task<Person> PostAsync(Person person);
        Task<Person> PutAsync(int id, Person person);
        Task<List<PhoneNumberType>> GetPhoneNumberTypes();
    }
}
