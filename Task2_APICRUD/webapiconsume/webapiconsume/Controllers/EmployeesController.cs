using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webapiconsume.Models;


namespace webapiconsume.Controllers
{
    public class EmployeesController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:65432/api");
        HttpClient client;

        public EmployeesController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        // GET: Employees
        public ActionResult Index()
        {
            List<Employee> modelList = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/employees").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return View(modelList);
        }


         public ActionResult Create() {

        
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            string data = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            HttpResponseMessage response = client.PostAsync(client.BaseAddress + "/employees", content).Result;
            if (response.IsSuccessStatusCode) { 
                return RedirectToAction("Index");
            }

            return View();
        }

        

        public ActionResult update()
        {
            List<Employee> modelList = new List<Employee>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/employees/id").Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                modelList = JsonConvert.DeserializeObject<List<Employee>>(data);
            }
            return View(modelList);
        }



        public ActionResult Edit(int id)
        {
            Employee model = new Employee();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/employees?id=" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Employee>(data);
            }
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            string data = JsonConvert.SerializeObject(employee);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(client.BaseAddress + "/employees/" + employee.ID, content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }




        public ActionResult Delete(int id)
        {

            Employee model = new Employee();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/employees?id=" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                model = JsonConvert.DeserializeObject<Employee>(data);
            }

            return View(model);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult ConfirmDeleteDelete(int id)
        {

            HttpResponseMessage response = client.DeleteAsync(client.BaseAddress + "/employees/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }



    }
}