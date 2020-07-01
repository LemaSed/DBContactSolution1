using System;
using ContactDBLibrary;
using DBContactSolution1;

namespace ContactDBTest
{
	class Program
	{
		static void Main(string[] args)
        {
            Console.WriteLine(SQLRepository.ReadContact(7));
            Console.WriteLine(SQLRepository.ReadContact(11));
            SQLRepository.DeleteContact(11);
        }
	}
}
