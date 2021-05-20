using CallManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CallManagement.Models.ViewModel
{
    public class ModelIncidents
    {
        public String NumberIncident { get; set; }
        public String Caller { get; set; }
        public String Status { get; set; }
        public String WorkNotes { get; set; }
        public String ResolutionInformation { get; set; }
        public String Description { get; set; }




        public List<ModelIncidents> ListIncident()
        {
            var lista = new List<ModelIncidents>();
            var daoIncident = new DaoIncidents();
            foreach (DataRow row in daoIncident.List().Rows)
            {
                var incidents = new ModelIncidents();
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

        public void Save()
        {
            new DaoIncidents().Save(this);
        }

        public List<ModelIncidents> SearchIncident(string incident)
        {
            var lista = new List<ModelIncidents>();
            var daoIncident = new DaoIncidents();
            foreach (DataRow row in daoIncident.SearchByNumberIncident(incident).Rows)
            {
                var incidents = new ModelIncidents();
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