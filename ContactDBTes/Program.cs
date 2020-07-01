using System;
using ContactDBLibrary;
using DBContactSolution1;

namespace ContactDBTest
{
	class Program
	{
		static void Main(string[] args)
        {

            SQLRepository.DeleteContact(2);
        }
	}
}
