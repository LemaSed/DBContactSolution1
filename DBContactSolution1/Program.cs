using System;
using DBContactSolution1;

namespace ContactDBLibrary
{
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine(SQLRepository.UpdateAddress(5, "Lalala", "blahblah", "5163"));
		}
	}
}
		
	