using Cwiczenia_03.DAL;
using Cwiczenia_03.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Cwiczenia_03.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private readonly IDbService _dbService;

        public StudentsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            string conString = "Data Source = db-mssql; Initial Catalog = s17180; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(conString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from student";
                con.Open();
                var dr = com.ExecuteReader();
                var st = new List<string>();
                while (dr.Read())
                {
                    if (dr["LastName"] == DBNull.Value)
                    {
                        //....
                    }
                    //  Console.WriteLine(dr["LastName"].ToString());
                    st.Add(dr["LastName"].ToString());
                    st.Add(dr["FirstName"].ToString());
                }
                return Ok((st));
            }
        }

        [HttpGet("{indexNum}")]
        public IActionResult GetStudent(string indexNum)
        {
            string conStrin = "Data Source=db-mssql;Initial Catalog=s17180;Integrated Security=True";
            var info = new List<string>();


            string studentsWithInfo = "select * from enrollment e join student s on e.idenrollment = s.idenrollment where s.IndexNumber = @index;";
            string[] cols = { "idenrollment", "semester", "idstudy", "startdate" };
            Dictionary<string, string> coulmnsNames = new Dictionary<string, string>();
            coulmnsNames.Add("index", indexNum);


            using (SqlConnection con = new SqlConnection(conStrin))
            using (SqlCommand com = new SqlCommand())
            {

                com.Connection = con;
                com.CommandText = (studentsWithInfo);


                if (coulmnsNames == null)
                {
                    return NotFound();
                }

               
                    foreach (KeyValuePair<string, string> param in coulmnsNames)
                        com.Parameters.AddWithValue(param.Key, param.Value);

          

                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {

                    foreach (string col in cols)
                        info.Add("'" + col + "'=" + reader[col].ToString());
                }

                if (info.Count == 0)
                    return NotFound();

                return Ok(info);

            }
        }


        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            return Ok(student);
        }
        [HttpPut("{id}")]
        public IActionResult putStudent(int id)
        {
            return Ok("Update succeed " + id);
        }
        [HttpDelete("{id}")]
        public IActionResult deleteStudent(int id)
        {
            return Ok("Delete succeed " + id);
        }
    }
}