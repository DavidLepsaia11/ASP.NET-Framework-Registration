
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ConnectToDatabase
    {
        private SqlConnection _sqlConnection;
        private string _configConnection;
        
        public ConnectToDatabase()
        {
            _configConnection = ConfigurationManager.ConnectionStrings["ConnectToDatabase"].ConnectionString;
            _sqlConnection = new SqlConnection(_configConnection);
        }

        public int Insert(string username, string email, string password)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Username", username), new SqlParameter("@Email", email), new SqlParameter("@Password", password) };
                _sqlConnection.Open();
                var result = GetCommand("InsertCustomer_SP", CommandType.StoredProcedure, parameters).ExecuteNonQuery();
                _sqlConnection.Close();
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool IsValidateUser(string email, string password)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Email", email), new SqlParameter("@Password", password) };
                var command = GetCommand("GetUser_SP", CommandType.StoredProcedure, parameters);
                _sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var testEmail = (string)reader["Email"];
                    var testPassword = (string)reader["Password"];

                    if (email == (string)reader["Email"] && password == (string)reader["Password"])
                    {
                        return true;
                    }
                }
                 _sqlConnection.Close();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        #region Helper Methods
        private SqlCommand GetCommand(string commandText, CommandType commandType, params IDataParameter[] parameters)
        {
           var command = _sqlConnection.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            foreach (var p in parameters)
                command.Parameters.Add(p);
          
            return command;
        }
        #endregion

    }
}
