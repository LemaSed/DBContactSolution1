using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Data.Common;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Specialized;

namespace DBContactSolution1
{
	public static class SQLRepository
	{
		private const string connectionString = @"Server=(localdb)\MSSQLLocalDB; Database=DBscrum; Integrated Security=true";
		public static int CreateContact()
		{
			using (SqlConnection connection = new SqlConnection(connectionString))
			{

				string queryString = "SELECT contact.Firstname, contact.Lastname, Contact.SSN, Contact.id " +
				"FROM contact " +
				"ORDER BY contact.id ASC;";
			}
		
		}

		public static string ReadContact(int contactId)
		{
			// Change "Object" to correct DBModel type.
			string contactString = null;

			string cmdText = "SELECT Contact.Id, Contact.SSN, Contact.FirstName, Contact.LastName " +
							 "FROM Contact " +
							 "WHERE Contact.Id = @contactId";
			
			

			using(SqlConnection Connection = new SqlConnection(connectionString))

			try
			{
				using (SqlCommand command = new SqlCommand(cmdText, Connection))

				{
					Connection.Open();
						SqlParameter para = new SqlParameter("contactId", contactId);
						command.Parameters.Add(para);

					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
								contactString = $"ContactId {reader[0]}, SSN {reader[1]}, FirstName {reader[2]}, LastName {reader[3]}";
							
						}
					}
				}
			}
			catch (Exception e)
			{
				string errMsg = e.Message;
                    Console.WriteLine("ÆSJ {0}", e.Message);
				return null;
			}
			finally
			{
				Connection.Close();
			}

			return contactString;
		}

	}
}
