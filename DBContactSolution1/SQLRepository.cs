﻿using System;
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
		private const string connectionString = @"Server = (local)\MSSQLLocalID; Database = DBscrum; Integrated Security=true";
		private static readonly SqlConnection Connection;
		static SQLRepository()  
		{
			Connection = new SqlConnection(connectionString);
		}
		public static int CreateContact(string ssn, string firstName, string LastName )
		{
			int identityId = 0;
			const string cmdText = "INSERT into Contact (SSN, FirstName, LastName) " +
				"VALUES (@ssn, @firstName, @lastName) " +
				"SELECT SCOPE_IDENTITY() as IdentityId ";

			/*List<SqlParameter> parameterList = new List<SqlParameter> {
			new SqlParameter("ssn", ssn),
			new SqlParameter ("firstName",firstName), 
			new SqlParameter("lastName", LastName)
			};*/
	


			try
			{
				using (SqlCommand command = new SqlCommand(cmdText, Connection ))
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

	}
}
