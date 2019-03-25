using System;
using System.Collections.Generic;
using System.Text;

namespace EkspresijaVjezba
{
    public enum PersonGender
    {
        Male,
        Female
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonGender Gender { get; set; }
        public BirthData Birth { get; set; }
        public List<Contact> Contacts { get; set; }

        public class BirthData
        {
            public DateTime? Date { get; set; }
            public string Country { get; set; }
        }

    }
    public enum ContactType
    {
        Telephone,
        Email
    }

    public class Contact
    {
        public ContactType Type { get; set; }
        public string Value { get; set; }
        public string Comments { get; set; }
    }
}
