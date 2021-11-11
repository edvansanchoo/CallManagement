using CallManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CallManagement.Models.ViewModel
{
    public class ModelRequest
    {
        public String NumberRequest { get; set; }
        public String RequestFor { get; set; }
        public String Status { get; set; }
        public String Item { get; set; }
        public String WorkNotes { get; set; }
        public String ShortDescription { get; set; }
        public int IdTecnico { get; set; }
        public int IdUsuario { get; set; }
        public String Tecnico { get; set; }
        public String TempoResolucao { get; set; }

        public string generationNumberRequest()
        {
            String numberRequest = "REQ";
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                numberRequest += random.Next(0, 9);
            }

            return numberRequest;
        }

        internal void Save()
        {
            new DaoRequests().Save(this);
        }

        public List<ModelRequest> ListRequest()
        {
            var lista = new List<ModelRequest>();
            var daoRequest = new DaoRequests();
            foreach (DataRow row in daoRequest.List().Rows)
            {
                var request = new ModelRequest();
                request.NumberRequest = Convert.ToString(row["NumberRequest"]);
                request.RequestFor = Convert.ToString(row["RequestFor"]);
                request.Item = Convert.ToString(row["Item"]);
                request.Status = Convert.ToString(row["Status"]);
                request.WorkNotes = Convert.ToString(row["WorkNotes"]);
                request.ShortDescription = Convert.ToString(row["ShortDescription"]);
                request.TempoResolucao = Convert.ToString(row["TempoResolucao"]);
                if (row["Tecnico"] != null)
                {
                    request.Tecnico = Convert.ToString(row["Tecnico"]);
                }
                else
                {
                    request.Tecnico = "";
                }
                lista.Add(request);
            }
            return lista;
        }

        public List<ModelRequest> ListRequest(string serialNumber)
        {
            var lista = new List<ModelRequest>();
            var daoRequest = new DaoRequests();
            foreach (DataRow row in daoRequest.List(serialNumber).Rows)
            {
                var request = new ModelRequest();
                request.NumberRequest = Convert.ToString(row["NumberRequest"]);
                request.RequestFor = Convert.ToString(row["RequestFor"]);
                request.Item = Convert.ToString(row["Item"]);
                request.Status = Convert.ToString(row["Status"]);
                request.WorkNotes = Convert.ToString(row["WorkNotes"]);
                request.ShortDescription = Convert.ToString(row["ShortDescription"]);
                request.TempoResolucao = Convert.ToString(row["TempoResolucao"]);
                if (row["Tecnico"] != null)
                {
                    request.Tecnico = Convert.ToString(row["Tecnico"]);
                }
                else
                {
                    request.Tecnico = "";
                }
                lista.Add(request);
            }
            return lista;
        }

        public List<ModelRequest> SearchRequestByNumber(string numberRequest)
        {
            
            var request = new ModelRequest();
            var lista = new List<ModelRequest>();
            var daoRequest = new DaoRequests();
            foreach (DataRow row in daoRequest.SearchByNumberRequest(numberRequest).Rows)
            {
                    
                request.NumberRequest = Convert.ToString(row["NumberRequest"]);
                request.RequestFor = Convert.ToString(row["RequestFor"]);
                request.Item = Convert.ToString(row["Item"]);
                request.Status = Convert.ToString(row["Status"]);
                request.WorkNotes = Convert.ToString(row["WorkNotes"]);
                request.ShortDescription = Convert.ToString(row["ShortDescription"]);
                request.TempoResolucao = Convert.ToString(row["TempoResolucao"]);
                if (row["Tecnico"] != null)
                {
                    request.Tecnico = Convert.ToString(row["Tecnico"]);
                }
                else
                {
                    request.Tecnico = "";
                }
                lista.Add(request);     
            }
            return lista;
        }

        public List<ModelRequest> SearchRequestByNumber(string numberRequest, string serialNumber)
        {

            var request = new ModelRequest();
            var lista = new List<ModelRequest>();
            var daoRequest = new DaoRequests();
            foreach (DataRow row in daoRequest.SearchByNumberRequest(numberRequest, serialNumber).Rows)
            {

                request.NumberRequest = Convert.ToString(row["NumberRequest"]);
                request.RequestFor = Convert.ToString(row["RequestFor"]);
                request.Item = Convert.ToString(row["Item"]);
                request.Status = Convert.ToString(row["Status"]);
                request.WorkNotes = Convert.ToString(row["WorkNotes"]);
                request.ShortDescription = Convert.ToString(row["ShortDescription"]);
                request.TempoResolucao = Convert.ToString(row["TempoResolucao"]);
                if (row["Tecnico"] != null)
                {
                    request.Tecnico = Convert.ToString(row["Tecnico"]);
                }
                else
                {
                    request.Tecnico = "";
                }
                lista.Add(request);
            }
            return lista;
        }

        public List<ModelRequest> SearchRequest(string numberRequest)
        {
            var lista = new List<ModelRequest>();
            var daoRequest = new DaoRequests();
            foreach (DataRow row in daoRequest.SearchByNumberRequest(numberRequest).Rows)
            {
                var request = new ModelRequest();
                request.NumberRequest = Convert.ToString(row["NumberRequest"]);
                request.RequestFor = Convert.ToString(row["RequestFor"]);
                request.Item = Convert.ToString(row["Item"]);
                request.Status = Convert.ToString(row["Status"]);
                request.WorkNotes = Convert.ToString(row["WorkNotes"]);
                request.ShortDescription = Convert.ToString(row["ShortDescription"]);

                lista.Add(request);
            }
            return lista;
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
                    day = 7 + int.Parse(S);
                    this.TempoResolucao += day.ToString();
                }
                else
                {
                    this.TempoResolucao += "/" + S;
                }

            }
        }

        internal void AlterRequest()
        {
            new DaoRequests().AlterRequest(this);
        }
    }
}