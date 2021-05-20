﻿using CallManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CallManagement.Models.DB
{
    public class DaoIncidents
    {
        private string sqlConnection()
        {
            return ConfigurationManager.AppSettings["sqlConnection"];
        }
        public DataTable List()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM INCIDENT";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        internal void Save(ModelIncidents incident)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection()))
                {
                    string queryString = "INSERT INTO INCIDENT(NUMBERINCIDENT, CALLER, STATUS, WORKNOTES, RESOLUTIONINFORMATION) VALUES('" + incident.NumberIncident + "','" + incident.Caller + "','" + incident.Status + "','"+incident.WorkNotes+"','"+incident.ResolutionInformation+"')";
                    
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        public DataTable SearchByNumberIncident(string numberIncident)
        {
            using (SqlConnection connection = new SqlConnection(sqlConnection()))
            {
                string queryString = "SELECT * FROM INCIDENT WHERE NUMBERINCIDENT='" + numberIncident + "'";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;

                DataTable table = new DataTable();
                adapter.Fill(table);
                return table;
            }
        }


        internal void AlterIncident(ModelIncidents incident)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection()))
                {
                    string queryString = "UPDATE INCIDENT SET NUMBERINCIDENT = '" + incident.NumberIncident + "', CALLER = '" + incident.Caller + "', STATUS = '" + incident.Status + "', WORKNOTES = '" + incident.WorkNotes + "', RESOLUTIONINFORMATION = '" + incident.ResolutionInformation + "' WHERE NUMERINCIDENT = " + incident.NumberIncident;

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