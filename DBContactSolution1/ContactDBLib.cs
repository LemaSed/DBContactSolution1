using System;
using System.Data.SqlClient;

namespace ContactDBLibrary
{
    public class Contact
    {
        

        public int Id { get; private set; }
        public string SSN { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public Contact(int id, string ssn, string firstName, string lastName)
        {
            Id = id;
            SSN = ssn;
            FirstName = firstName;
            LastName = lastName;
        }


        

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\tId: {Id}\tSSN: {SSN}\t";
        }
    }

    public class Address
    {
        public int Id { get; private set; }
        public string Street { get; private set; }
        public string City { get; set; }
        public int Zip { get; set; }


       
        public override string ToString()
        {
            return $"Address: {Id} { Street} {City} {Zip}";
        }

    }
    public class ContactInformation
    {
        public int Id { get; set; }
        public String Info { get; set; }
        public int ContactId { get; set; }

       
   
    }
    public class ContactAddress
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public int AddressId { get; set; }


       
   
    }
}
