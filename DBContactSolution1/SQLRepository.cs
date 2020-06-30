using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;

namespace DBContactSolution1
{
	public static class SQLRepository
	{
		private const string connectionString = @"Server = (local)\MSSQLLocalID; Database = DBscrum; Integrated Security=true";
		public static int CreateContact(string ssn, string firstName, string LastName )
		{

			const string cmdText = "INSERT into Contact (SSN, FirstName, LastName)" +
				"VALUES @ssn, @firstName, @lastName " +
				"SELECT SCOPE_IDENTITY() as IdentityId ";

		
		}

	}
}
