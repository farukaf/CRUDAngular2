using Examples.Charge.Domain.Aggregates.PersonAggregate;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using Examples.Charge.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ExampleContext _context;

        public PersonRepository(ExampleContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Person>> FindAllAsync() =>
            await Task.Run(() => _context.Person.Include(x => x.Phones).ThenInclude(x => x.PhoneNumberType));

        public async Task<Person> GetAsync(int id) =>
            await _context.Person.Include(x => x.Phones).ThenInclude(x => x.PhoneNumberType).FirstOrDefaultAsync(x => x.BusinessEntityID == id);

        public async Task<Person> PostAsync(Person person)
        {
            person.BusinessEntityID = 0;
            foreach (var phone in person.Phones)
            {
                phone.BusinessEntityID = 0;
                phone.PhoneNumberType = null;
            }
            await _context.Person.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person> PutAsync(int id, Person person)
        {
            person.BusinessEntityID = id;
            foreach (var phone in person.Phones)
            {
                phone.BusinessEntityID = id;
                _context.Entry(phone.PhoneNumberType).State = EntityState.Detached;
                _context.Entry(phone).State = EntityState.Modified;
            }
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<IEnumerable<PhoneNumberType>> FindAllPhoneNumberTypes() =>
            await Task.Run(() => _context.PhoneNumberType);

    }
}
