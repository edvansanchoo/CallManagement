using CallManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CallManagement.Models.DB
{
    public class DaoRequests
    {

        private string sqlConnection()
        {
            return ConfigurationManager.AppSettings["sqlConnection"];
        }

        public void Save(ModelRequest request)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection()))
                {
                    string queryString = "INSERT INTO REQUEST(NUMBERREQUEST, REQUESTFOR, STATUS, ITEM, WORKNOTES, SHORTDESCRIPTION, TempoResolucao) VALUES('" + request.NumberRequest + "','" + request.RequestFor + "','" + request.Status + "','" + request.Item + "','" + request.WorkNotes + "','" + request.ShortDescription + "', '" + request.TempoResolucao + "')";

                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public DataTable List()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM REQUEST";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public DataTable List(string serialNumber)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM REQUEST WHERE REQUESTFOR='" + serialNumber + "'";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public DataTable SearchByNumberRequest(string numberRequest)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM REQUEST WHERE NUMBERREQUEST='" + numberRequest + "'";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }

        public DataTable SearchByNumberRequest(string numberRequest, string serialNumber)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM REQUEST WHERE NUMBERREQUEST='" + numberRequest + "' AND REQUESTFOR='" + serialNumber + "'";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }
        public void AlterRequest(ModelRequest request)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection()))
                {
                    string queryString = "UPDATE REQUEST SET NUMBERREQUEST = '" + request.NumberRequest + "', REQUESTFOR = '" + request.RequestFor + "', STATUS = '" + request.Status + "', ITEM = '" + request.Item + "', WORKNOTES = '" + request.WorkNotes + "', SHORTDESCRIPTION = '" + request.ShortDescription + "' , Tecnico = '" + request.Tecnico + "'  WHERE NUMBERREQUEST = '" + request.NumberRequest+ "'";

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