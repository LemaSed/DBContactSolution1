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
	
		private static readonly SqlConnection Connection;
		static SQLRepository()  
		{
			Connection = new SqlConnection(connectionString);
		}
		public static int CreateContact(string ssn, string firstName, string LastName )
		{
			int identityId = 0;
			const string cmdText = "INSERT into Contact (SSN, FirstName, LastName)" +
				"VALUES @ssn, @firstName, @lastName " +
				"SELECT SCOPE_IDENTITY() as IdentityId ";

			List<SqlParameter> parameterList = new List<SqlParameter> {
			new SqlParameter("ssn", ssn),
			new SqlParameter ("firstName",firstName), 
			new SqlParameter("lastName", LastName)
			};

			try
			{
				using (SqlCommand command = new SqlCommand(cmdText, Connection ))
				{
					Connection.Open();
					using (SqlDataReader reader = command.ExecuteReader())
					{
						if (reader.Read())
						{
							identityId = (int)(decimal)reader["IdentityID"];
						}
					}
				}
			}
			catch (Exception e)
			{
				string errMsg = e.Message;
				return 0;
			}
			finally
			{
				Connection.Close();
			}

			return identityId;
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
