﻿using CallManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CallManagement.Models.ViewModel
{
    public class ModelIncident
    {
        public String NumberIncident { get; set; }
        public String Caller { get; set; }
        public String Status { get; set; }
        public String WorkNotes { get; set; }
        public String ResolutionInformation { get; set; }
        public String Description { get; set; }
        public int IdTecnico { get; set; }
        public int IdUsuario { get; set; }
        public String Tecnico { get; set; }
        public String TempoResolucao { get; set; }
        public String SetorProblema { get; set; }






        public List<ModelIncident> ListIncident()
        {
            var lista = new List<ModelIncident>();
            var daoIncident = new DaoIncidents();
            foreach (DataRow row in daoIncident.List().Rows)
            {
                var incidents = new ModelIncident();
                incidents.NumberIncident = Convert.ToString(row["NumberIncident"]);
                incidents.Caller = Convert.ToString(row["Caller"]);
                incidents.Status = Convert.ToString(row["Status"]);
                incidents.WorkNotes = Convert.ToString(row["WorkNotes"]);
                incidents.ResolutionInformation = Convert.ToString(row["ResolutionInformation"]);
                incidents.Description = Convert.ToString(row["Description"]);
                incidents.TempoResolucao = Convert.ToString(row["TempoResolucao"]);
                if (row["Tecnico"] != null)
                {
                    incidents.Tecnico = Convert.ToString(row["Tecnico"]);
                }
                else {
                    incidents.Tecnico = "";
                }
                

                lista.Add(incidents);
            }
            return lista;
        }

        public String generationNumberIncident()
        {
            String numberIncident = "INC";
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                numberIncident += random.Next(0, 9);
            }

            return numberIncident;

        }

        public ModelIncident SearchIncidentByNumber(string numberIncident)
        {
            var incidents = new ModelIncident();
            var daoIncident = new DaoIncidents();
            foreach (DataRow row in daoIncident.SearchByNumberIncident(numberIncident).Rows)
            {
                
                incidents.NumberIncident = Convert.ToString(row["NumberIncident"]);
                incidents.Caller = Convert.ToString(row["Caller"]);
                incidents.Status = Convert.ToString(row["Status"]);
                incidents.WorkNotes = Convert.ToString(row["WorkNotes"]);
                incidents.ResolutionInformation = Convert.ToString(row["ResolutionInformation"]);
                incidents.Description = Convert.ToString(row["Description"]);
                incidents.TempoResolucao = Convert.ToString(row["TempoResolucao"]);
                if (row["Tecnico"] != null)
                {
                    incidents.Tecnico = Convert.ToString(row["Tecnico"]);
                }
                else
                {
                    incidents.Tecnico = "";
                }

            }
            return incidents;
        }

        public void dateLimiteRequest()
        {
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Today;

            int day = 0;
            String dataLimite = dateTime.ToString();
            foreach (String S in dataLimite.Split('/'))
            {
                if (dateTime.Day.ToString() == S)
                {
                    day = 2 + int.Parse(S);
                    this.TempoResolucao += day.ToString();
                }
                else
                {
                    this.TempoResolucao += "/" + S;
                }

            }
        }

        public void AlterIncidentByNumber(ModelIncident incidents)
        {
            new DaoIncidents().AlterIncident(this);
        }

        public void Save()
        {
            new DaoIncidents().Save(this);
        }

        public List<ModelIncident> SearchIncident(string incident)
        {
            var lista = new List<ModelIncident>();
            var daoIncident = new DaoIncidents();
            foreach (DataRow row in daoIncident.SearchByNumberIncident(incident).Rows)
            {
                var incidents = new ModelIncident();
                incidents.NumberIncident = Convert.ToString(row["NumberIncident"]);
                incidents.Caller = Convert.ToString(row["Caller"]);
                incidents.Status = Convert.ToString(row["Status"]);
                incidents.WorkNotes = Convert.ToString(row["WorkNotes"]);
                incidents.ResolutionInformation = Convert.ToString(row["ResolutionInformation"]);
                incidents.Description = Convert.ToString(row["Description"]);

                lista.Add(incidents);
            }
            return lista;
        }
    }
}