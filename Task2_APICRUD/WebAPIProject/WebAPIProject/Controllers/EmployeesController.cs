﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL2;
using Microsoft.AspNet.Scaffolding.EntityFramework;


namespace WebAPIProject.Controllers
{
    public class EmployeesController : ApiController
    {
        //[HttpGet]
        public HttpResponseMessage Get(string gender = "All")
        {
            using (TestEmployeeDBEF entities = new TestEmployeeDBEF())
            {
                switch (gender.ToLower())
                {

                    case "all":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.TestEmployees.ToList());
                    case "male":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.TestEmployees.Where(e => e.Gender.ToLower() == "male").ToList());
                    case "female":
                        return Request.CreateResponse(HttpStatusCode.OK, entities.TestEmployees.Where(e => e.Gender.ToLower() == "female").ToList());
                    default:
                        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Value for gender must be All, Male or Female. " + gender + " is invallid");
                }
            }
        }

        [HttpGet]
        public HttpResponseMessage LoadEmployeeById(int id)
        {
            using (TestEmployeeDBEF entities = new TestEmployeeDBEF())
            {
                var entity = entities.TestEmployees.FirstOrDefault(e => e.ID == id);

                if (entity != null)
                {

                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id= " + id.ToString() + "not found");
                }

            }
        }

        public HttpResponseMessage Post([FromBody] TestEmployee employee)
        {
            try
            {
                using (TestEmployeeDBEF entities = new TestEmployeeDBEF())
                {
                    entities.TestEmployees.Add(employee);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, employee);
                    message.Headers.Location = new Uri(Request.RequestUri + employee.ID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (TestEmployeeDBEF entities = new TestEmployeeDBEF())
                {

                    var entity = entities.TestEmployees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id.ToString() + "not found to delete");
                    }
                    else
                    {
                        entities.TestEmployees.Remove(entity);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }



                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


        public HttpResponseMessage Put(int id, [FromBody] TestEmployee employee)
        {
            try
            {
                using (TestEmployeeDBEF entities = new TestEmployeeDBEF())
                {

                    var entity = entities.TestEmployees.FirstOrDefault(e => e.ID == id);
                    if (entity == null)
                    {

                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with Id " + id.ToString() + " not found to update");

                    }
                    else
                    {

                        entity.FirstName = employee.FirstName;
                        entity.LastName = employee.LastName;
                        entity.Gender = employee.Gender;
                        entity.Salary = employee.Salary;

                        entities.SaveChanges();

                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }
                }
            }

            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }


    }
}
