using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CallManagement.Models.ViewModel
{
    public class DaoEmployee
    {
       
        private string sqlConnection()
        {
            return ConfigurationManager.AppSettings["sqlConnection"];
        }
        public DataTable List()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM EMPLOYEE";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public DataTable Login(String SerialNumber, String Password)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM EMPLOYEE WHERE SERIALNUMBER='" + SerialNumber + "' AND PASSWORD='"+Password+"'";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        internal object SearchEmployeeByNumber(string SerialNumber)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM EMPLOYEE WHERE SERIALNUMBER='" + SerialNumber + "'";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        internal void AlterEmployee(ModelEmployee modelEmployee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection()))
                {
                    string queryString = "UPDATE EMPLOYEE SET NAME = '" + modelEmployee.Name + "', DEPARTAMENT = '" + modelEmployee.Departament + "', SERIALNUMBER = '" + modelEmployee.SeriaNumber + "', ISTECNIC = '" + modelEmployee.IsTecnic + "', PASSWORD = '" + modelEmployee.Password +"'";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal void Delete(String SerialNumber)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection()))
                {
                    string queryString = "DELETE EMPLOYEE WHERE SERIALNUMBER = '" + SerialNumber + "'";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        internal void Save(ModelEmployee modelEmployee)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection()))
                {
                    string queryString = "INSERT INTO EMPLOYEE(NAME, DEPARTAMENT, SERIALNUMBER, ISTECNIC, PASSWORD) VALUES('" + modelEmployee.Name + "','" + modelEmployee.Departament + "','" + modelEmployee.SeriaNumber + "','" + modelEmployee.IsTecnic + "','" + modelEmployee.Password + "')";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}