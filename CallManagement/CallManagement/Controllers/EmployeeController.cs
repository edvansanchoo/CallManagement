using CallManagement.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CallManagement.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Login()
        {
            var SerialNumber = Request["SerialNumber"];
            var Password = Request["Password"];

            ModelEmployee employee = new ModelEmployee();

            employee = new ModelEmployee().Login(SerialNumber, Password);
            if(employee.Name != null ) {
                return RedirectToAction("Index", "StartView");
            }
            else { 
                TempData["Erro"] = true;
                TempData["Message"] = "Login não possui perfil no sistema!";

                return View();
            }
            
        }

        public ActionResult CreateEmployee()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save()
        {
            ModelEmployee employee = new ModelEmployee();

            employee.Name = Request["Name"];
            employee.Departament = Request["Departament"];
            employee.SeriaNumber = Request["SerialNumber"];
            employee.IsTecnic = Convert.ToInt32(Request["IsTecnic"]);
            employee.Password = Request["Password"];
            
            employee.SaveEmployee();

            return RedirectToAction("CreateIncident");

        }

        public ActionResult AllEmployee()
        {

            var SerialNumber = Request["SerialNumber"];
            var SerialNumberLogado = Request["SerialNumberLogado"];


            if (SerialNumber != null && SerialNumber != "")
            {
                ViewBag.ModelEmployee = new ModelEmployee().SearchEmployeeByNumber(SerialNumber);
            }
            else
            {
                ViewBag.ModelEmployee = new ModelEmployee().ListEmployee();
            }
            return View();
        }

        public ActionResult EditEmployee(String SerialNumber)
        {

            ViewBag.ModelEmployee = new ModelEmployee().SearchEmployeeByNumber(SerialNumber);

            return View();
        }

        public object AlterEmployee()
        {
            ModelEmployee employee = new ModelEmployee();

            employee.Name = Request["Name"];
            employee.Departament = Request["Departament"];
            employee.SeriaNumber = Request["SeriaNumber"];
            employee.IsTecnic = Convert.ToInt32(Request["IsTecnic"]);
            employee.Password = Request["Password"];

            employee.AlterEmployeetByNumber();

            return RedirectToAction("AllIncident");
        }

        public ActionResult DeleteEmployee(String SerialNumber)
        {
            new ModelEmployee().DeleteEmployee(SerialNumber);

            return View();

        }
    }
}