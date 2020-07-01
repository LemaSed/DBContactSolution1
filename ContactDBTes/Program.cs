using System;
using ContactDBLibrary;
using DBContactSolution1;

namespace ContactDBTest
{
	class Program
	{
		static void Main(string[] args)
		{
			SQLRepository.CreateContact("516325", "Lema", "Sediqi");
			Console.WriteLine("test");
            Console.WriteLine(	SQLRepository.ReadContact(3));
            
            Console.WriteLine(	SQLRepository.ReadContact(1));

			Console.WriteLine(SQLRepository.ReadContact(2));
		}
	}
}
