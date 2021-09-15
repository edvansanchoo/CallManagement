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

        internal void AlterRequest()
        {
            new DaoRequests().AlterRequest(this);
        }
    }
}