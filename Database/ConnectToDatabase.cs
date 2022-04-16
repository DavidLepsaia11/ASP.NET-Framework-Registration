using System;
using System.Collections.Generic;
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
        public ConnectToDatabase()
        {
            _sqlConnection = new SqlConnection(@"server = DESKTOP-TEPR7CC; database = Users; integrated security = true");
        }

        public int Insert(string username, string email, string password)
        {
            try
            {
                SqlParameter[] parameters = { new SqlParameter("@Username", username), new SqlParameter("@Email", email), new SqlParameter("@Password", password) };
                var result = ExecuteCommand("InsertCustomer_SP", CommandType.StoredProcedure, parameters).ExecuteNonQuery();
                _sqlConnection.Close();
                return result;
            }
            catch (Exception)
            {
                return -1;
            }
        }
       
        public IDbCommand ExecuteCommand(string commandText, CommandType commandType, params IDataParameter[] parameters)
        {
           var command = _sqlConnection.CreateCommand();

            _sqlConnection.Open();
            command.CommandType = commandType;
            command.CommandText = commandText;
            foreach (var p in parameters)
                command.Parameters.Add(p);
          
            return command;
        }
    }
}
