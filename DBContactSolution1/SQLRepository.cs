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

		public static int CreateContact(string ssn, string firstName, string lastName)
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
					sqlParameter.Value = lastName;
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
				

			return contactString;
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

        public static bool UpdateContact(int contactId, string ssn, string firstName, string lastName)
        {
            int rowsaffected = 0;
            const string commandText = "UPDATE CONTACT " +
                                       "SET SSN = @ssn, FIRSTNAME = @firstName, LASTNAME = @lastName " +
                                       "WHERE ID = @contactId";
            try
            {
                using (SqlCommand command = new SqlCommand(commandText, Connection))
                {
                    Connection.Open();

                    command.Parameters.Add("@contactId", SqlDbType.Int).Value = contactId;
                    command.Parameters.Add("@ssn", SqlDbType.Int).Value = ssn;
                    command.Parameters.Add("@firstName", SqlDbType.NVarChar).Value = firstName;
                    command.Parameters.Add("@lastName", SqlDbType.NVarChar).Value = lastName;

                    rowsaffected = command.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

            return rowsaffected == 1;
        }

		public static string ReadContactInformation(int contactId)
        {
            string contactString = null;

            string cmdText = "SELECT ContactInformation.Id, ContactInformation.Info, ContactInformation.ContactId " +
                             "FROM ContactInformation " +
                             "WHERE ContactInformation.Id = @contactId";

			//using (SqlConnection connection = new SqlConnection(connectionString)) //trenger ikke denne for vi har en felles Connection øverst. 
		
						Connection.Open();
				try
				{
					using (SqlCommand command = new SqlCommand(cmdText, Connection))
					{

						SqlParameter para = new SqlParameter("@contactId", contactId);
						command.Parameters.Add(para);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								contactString = $"contactInfo {reader[1]}, ContactId {reader[2]}";

							}
						}

					}
				}
				catch (Exception e)
				{
					string errMsg = e.Message;
					Console.WriteLine(errMsg);
                    return null;
                }
				finally
				{
					Connection.Close();

				}
			
            return contactString;
        }

       

		public static int CreateAdress(string street, string city, string zip)
		{
			int identityId = 0;
			const string cmdText = "INSERT into Address (Street, City, Zip) " +
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
        

		public static string ReadAddress(int addressId)
		{
			string addressString = null;
			string cmdText = "SELECT Address.Id, Address.Street, Address.City, Address.Zip " +
			                 "FROM Address " +
			                 "WHERE Address.Id = @addressId";

			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				try
				{
					using (SqlCommand command = new SqlCommand(cmdText, Connection))
					{
						Connection.Open();
						SqlParameter parameter = new SqlParameter("addressId", addressId);
						command.Parameters.Add(parameter);

						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								addressString =
									$"AddressId {reader[0]}, Street {reader[1]}, City {reader[2]}, Zip{reader[3]} ";
							}
						}
					}
				}

				catch (Exception e)
				{
					Console.WriteLine(e.Message);

					return null;
				}
			}

			return addressString;

		}

		public static bool DeleteAddress(int addressId)
		{
			int rowsAffected = 0;

			string cmdText = "DELETE FROM Contact_Address " +
							 "WHERE Contact_Address.AddressId = @addressId "+

							 "DELETE FROM Address " +
			                 "WHERE Address.Id = @addressId";
			
			try
			{
				using (SqlCommand command = new SqlCommand(cmdText, Connection))
				{
					Connection.Open();
					SqlParameter parameter = new SqlParameter("@addressId", addressId);
					command.Parameters.Add(parameter);
					rowsAffected = command.ExecuteNonQuery();
				}
			}

			catch (Exception e)
			{
				Console.WriteLine(e.Message);

				return false;
			}

			return (rowsAffected == 2);

		}

	}
}
//command.Parameters.Add("@name SqlDbType.NVarChar).Value = name;  <-- En lettere måte å legge til parameter til SQL command. 
//ExecuteNonQuery er det en static spørring. Du får ingenting tilbake
// ExecuteReader = Ville fått en read object som man kan få tilbake. For å få printet ut radene i tabellen: 
//while (DataTableReader.Read()){
	//osv