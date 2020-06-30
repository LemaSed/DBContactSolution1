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
		public static int CreateContact()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				string queryString = "SELECT contact.Firstname, contact.Lastname, Contact.SSN, Contact.id " +
				"FROM contact " +
				"ORDER BY contact.id ASC;";
			}
		
		}

	}
}
