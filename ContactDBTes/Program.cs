using System;
using ContactDBLibrary;
using DBContactSolution1;

namespace ContactDBTest
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("test");
            Console.WriteLine(	SQLRepository.ReadContact(1));
            
		}
	}
}
