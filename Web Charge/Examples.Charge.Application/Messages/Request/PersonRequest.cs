using Examples.Charge.Application.Dtos;
using System.Collections.Generic;

namespace Examples.Charge.Application.Messages.Request
{
    public class PersonRequest
    {
        public int ID { get; set; } 
        public string Name { get; set; } 
        public ICollection<PersonPhoneDto> Phones { get; set; } 

    }
}
