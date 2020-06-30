using System;
using System.Data.SqlClient;

namespace ContactDBLibrary
{
    public class Contact
    {
        public int Id { get; private set; }
        public int SSN { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Contact(int id, int sSN, string firstName, string lastName)
        {
            Id = id;
            SSN = sSN;
            FirstName = firstName;
            LastName = lastName;
        }

    }

    public class Address
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; set; }
        public int Zip { get; set; }


        public Address(int id, string street, string city, int zip)
        {
            Id = id;
            Street = street;
            City = city;
            Zip = zip;
        }

    }
    public class ContactInformation
    {
        public int Id { get; set; }
        public String Info { get; set; }
        public int ContactId { get; set; }

        public ContactInformation(int id, string info, int contactId)
        {
            Id = id;
            Info = info;
            ContactId = contactId;
        }
   
    }
    public class ContactAddress
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int AddressId { get; set; }


        public ContactAddress(int id, int contactId, int addressId)
        {
            Id = id;
            ContactId = contactId;
            AddressId = addressId;
        }
   
    }
}
