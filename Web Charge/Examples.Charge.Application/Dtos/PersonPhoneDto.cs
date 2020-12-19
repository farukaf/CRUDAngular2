using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Dtos
{
    public class PersonPhoneDto
    {
        public int PersonID { get; set; }

        public string PhoneNumber { get; set; }

        public int PhoneNumberTypeID { get; set; }
        public PhoneNumberTypeDto PhoneNumberType { get; set; }
    }
}
