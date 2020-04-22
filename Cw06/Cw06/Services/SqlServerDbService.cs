using Cw06.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Cw06.Services
{
    public class SqlServerDbService : IStudentsDbService
    {
        private const string connection = "Data Source=db-mssql;" +
                                          "Initial Catalog=s17180;Integrated Security=True";
        public bool CheckIfExists(string index)
        {
            bool ifExist = false;
            using (var con = new SqlConnection(connection))
            using (var com = new SqlCommand())
            {

                com.Connection = con;
                com.CommandText = "select IndexNumber from Student where IndexNumber = @IndexNumber;";
                com.Parameters.AddWithValue("IndexNumber", index);

                con.Open();

                var dr = com.ExecuteReader();

                if (dr.Read())
                {
                    ifExist = true;
                }
                
                
            }
            return ifExist;
        }
        
        public Student GetStudent(string index)
        {
            var st = new Student();

            using (var con = new SqlConnection(connection))
            using (var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = ("select IndexNumber, FirstName, LastName,BirthDate,IdEnrollment from Student where IndexNumber = @IndexNumber;");
                com.Parameters.AddWithValue("IndexNumber", index);
                con.Open();
                var dr = com.ExecuteReader();

                if (dr.Read())
                {
                    st.IdStudent = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate =DateTime.Parse(dr["BirthDate"].ToString());
                    st.IdEnrollment =(int) dr["IdEnrollment"];
                }

            }
            return st;

        }

    }
}
