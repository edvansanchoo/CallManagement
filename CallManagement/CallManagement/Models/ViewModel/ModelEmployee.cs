using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CallManagement.Models.ViewModel
{
    public class ModelEmployee
    {
        public String Name { get; set; }
        public String Departament { get; set; }
        public String SeriaNumber { get; set; }
        public int IsTecnic { get; set; }
        public String Password { get; set; }


        public List<ModelEmployee> ListEmployee()
        {
            var lista = new List<ModelEmployee>();
            var daoEmployee = new DaoEmployee();
            foreach (DataRow row in daoEmployee.List().Rows)
            {
                var employee = new ModelEmployee();
                employee.Name = Convert.ToString(row["Name"]);
                employee.Departament = Convert.ToString(row["Departament"]);
                employee.SeriaNumber = Convert.ToString(row["SerialNumber"]);
                employee.IsTecnic = Convert.ToInt32(row["IsTecnic"]);
                
                lista.Add(employee);
            }
            return lista;
        }

        public ModelEmployee Login(String SerialNumber, String Password) {
            var employee = new ModelEmployee();
            var daoEmployee = new DaoEmployee();
            foreach (DataRow row in daoEmployee.Login(SerialNumber, Password).Rows)
            {
                employee.Name = Convert.ToString(row["Name"]);
                employee.Departament = Convert.ToString(row["Departament"]);
                employee.SeriaNumber = Convert.ToString(row["SerialNumber"]);
                employee.IsTecnic = Convert.ToInt32(row["IsTecnic"]);
  
            }
            return employee;
        }

        public ModelEmployee SearchEmployeeByNumber(String SerialNumber)
        {
            var employee = new ModelEmployee();
            var daoEmployee = new DaoEmployee();
            foreach (DataRow row in daoEmployee.SearchEmployeeByNumber(SerialNumber).Rows)
            {
                employee.Name = Convert.ToString(row["Name"]);
                employee.Departament = Convert.ToString(row["Departament"]);
                employee.SeriaNumber = Convert.ToString(row["SerialNumber"]);
                employee.IsTecnic = Convert.ToInt32(row["IsTecnic"]);
                employee.Password = Convert.ToString(row["Password"]);

            }
            return employee;
        }


        public void AlterEmployeetByNumber()
        {
            new DaoEmployee().AlterEmployee(this);
        }

        public void SaveEmployee()
        {
            new DaoEmployee().Save(this);
        }

        public void DeleteEmployee(String SerialNumber)
        {
            new DaoEmployee().Delete(SerialNumber);
        }
    }
}