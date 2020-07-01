using System;
using DBContactSolution1;

namespace ContactDBLibrary
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine(SQLRepository.ReadContactInformation(2));

            Console.WriteLine("test");
		}
	}
}
	