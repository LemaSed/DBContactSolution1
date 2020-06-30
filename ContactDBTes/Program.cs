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
		}
	}
}
