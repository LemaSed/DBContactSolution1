using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;
using DBContactSolution1;

namespace DBContactSolution1
{
    public static class Seb
    {
        private const string ConnectionString =
            @"server = (localDb)\MSSQLLocalDB; Database = DBScrum; Integrated Security = true";

        private static readonly SqlConnection Connection = new SqlConnection(ConnectionString);

        public static ContactDBLibrary.Contact CreateContact(int contactId)
        {

            string commandText = "SELECT * FROM CONTACT " +
                                 "WHERE CONTACT.ID = @contactId";
            
            SqlCommand command = new SqlCommand(commandText, Connection);
            command.Parameters.AddWithValue(@"contactId", contactId);
            int id = 0;
            string ssn = "";
            string firstName = "";
            string lastName = "";

            try
            {
                Connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        id = (int) reader["Id"];
                        ssn = reader["SSN"].ToString();
                        firstName = reader["FirstName"].ToString();
                        lastName = reader["LastName"].ToString();

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            var contact = new ContactDBLibrary.Contact(id,ssn,firstName,lastName);
            return contact;
        }
        




    }
}
