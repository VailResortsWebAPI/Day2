using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace AdventureWorksWebAPI.Controllers
{
    public class Person
    {
        public string FirstName, LastName;
    }

    public class Student : Person
    {
        public float Grade;
    }

    public class DeserializeController : ApiController
    {
        [Route("api/Deserialize/Manual")]
        public string Manual(HttpRequestMessage req)
        {
            string content = req.Content.ReadAsStringAsync().Result;
            return "Manual: " + content;
        }

        [Route("api/Deserialize/JSON")]
        public string JSON(HttpRequestMessage req)
        {
            string content = req.Content.ReadAsStringAsync().Result;

            JavaScriptSerializer ser = new JavaScriptSerializer();
            Person person = ser.Deserialize<Person>(content);

            string results = String.Format("{0} - {1} {2}", 
                person.GetType(), person.FirstName, person.LastName);
            return "JSON: " + results;
        }

        [Route("api/Deserialize/ReadAsAsync")]
        public string ReadAsAsync(HttpRequestMessage req)
        {
            Person person = req.Content.ReadAsAsync<Person>().Result;
            string results = String.Format("{0} - {1} {2}",
                person.GetType(), person.FirstName, person.LastName);
            return "ReadAsAsync: " + results;
        }

        [Route("api/Deserialize/Binding")]
        public string Binding(Person person)
        {
            string results = String.Format("{0} - {1} {2}",
                person.GetType(), person.FirstName, person.LastName);
            return "Binding: " + results;
        }

        [Route("api/Deserialize/StudentBinding")]
        public string Binding(Student student)
        {
            string results = String.Format("{0} - {1} {2} has a {3}",
                student.GetType(), student.FirstName, student.LastName, student.Grade);
            return "Binding: " + results;
        }
    }
}
