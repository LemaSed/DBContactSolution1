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
		private const string connectionString = @"Server = (localdb)\MSSQLLocalDB; Database = DBscrum; Integrated Security=true";
		private static readonly SqlConnection Connection;
		static SQLRepository()
		{
			Connection = new SqlConnection(connectionString);
		}

		public static int CreateContact(string ssn, string firstName, string LastName)
		{
			int identityId = 0;
			const string cmdText = "INSERT into Contact (SSN, FirstName, LastName) " +
				"VALUES (@ssn, @firstName, @lastName) " +
				"SELECT SCOPE_IDENTITY() as IdentityId ";


			try
			{
				using (SqlCommand command = new SqlCommand(cmdText, Connection))
				{
					SqlParameter sqlParameter = command.CreateParameter();
					sqlParameter.ParameterName = "@ssn";
					sqlParameter.Value = ssn;
					command.Parameters.Add(sqlParameter);

					sqlParameter = command.CreateParameter();
					sqlParameter.ParameterName = "@firstName";
					sqlParameter.Value = firstName;
					command.Parameters.Add(sqlParameter);

					sqlParameter = command.CreateParameter();
					sqlParameter.ParameterName = "@LastName";
					sqlParameter.Value = LastName;
					command.Parameters.Add(sqlParameter);

					//command.Parameters.Add(parameterList);
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
				Console.WriteLine(errMsg);
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



			using (SqlConnection Connection = new SqlConnection(connectionString))

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
								contactString = $"ContactId {reader[0]}, SSN {reader[1]}, Name {reader[2]} {reader[3]}";

							}
						}
					}
				}
				catch (Exception e)
				{
					
					Console.WriteLine("ÆSJ {0}", e.Message);
					return null;
				}
				/*finally
				{
					Connection.Close();
				}*/

			return contactString;
		}

		public static int CreateAdress(string street, string city, string zip)
		{
			int identityId = 0;
			const string cmdText = "INSERT into Adress (Street, City, Zip) " +
				"VALUES (@street, @city, @zip) " +
				"SELECT SCOPE_IDENTITY() as IdentityId ";


			try
			{
				using (SqlCommand command = new SqlCommand(cmdText, Connection))
				{
					SqlParameter sqlParameter = command.CreateParameter();
					sqlParameter.ParameterName = "@street";
					sqlParameter.Value = street;
					command.Parameters.Add(sqlParameter);

					sqlParameter = command.CreateParameter();
					sqlParameter.ParameterName = "@city";
					sqlParameter.Value = city;
					command.Parameters.Add(sqlParameter);

					sqlParameter = command.CreateParameter();
					sqlParameter.ParameterName = "@zip";
					sqlParameter.Value = zip;
					command.Parameters.Add(sqlParameter);

					//command.Parameters.Add(parameterList);
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
				Console.WriteLine(errMsg);
				return 0;
			}
			finally
			{
				Connection.Close();
			}

			return identityId;
		}
        public static bool DeleteContact(int contactId)
        {
            

            int rowsAffected = 0;

            const string commandText = "DELETE FROM CONTACT " +
                                 "WHERE CONTACT.ID = @contactId";

			

            try
            {
                using (SqlCommand command = new SqlCommand(commandText, Connection))
                {
                    
					Connection.Open();
                    SqlParameter para = new SqlParameter("contactId", contactId);
                    command.Parameters.Add(para);
                    rowsAffected = command.ExecuteNonQuery();
                }

            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                return false;
            }
            return (rowsAffected == 1);
        }

	}
}
