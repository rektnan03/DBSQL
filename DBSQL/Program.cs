using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EnrollmentDBEntities())
            {

                var query = from b in db.Students
                            orderby b.Firstname
                            select b;

                Console.WriteLine("All All student in the database:");

                foreach (var item in query)
                {
                    Console.WriteLine(item.Firstname + " " + item.Lastname);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();



                string ConnectionString = "Integrated Security=SSPI;" +
         "Initial Catalog=EnrollmentDB;" +
         "Data Source = DESKTOP-FUGQNF4\\SQLEXPRESS;";



                SqlConnection conn2 = new SqlConnection(ConnectionString);
                conn2.Open();
                using (SqlCommand cmd2 = new SqlCommand("insertNewStudent", conn2))
                {
                    cmd2.CommandType = CommandType.StoredProcedure;



                    cmd2.Parameters.Add("@Firstname", SqlDbType.VarChar).Value = "Jan Mr TRC!";
                    cmd2.Parameters.Add("@Lastname", SqlDbType.VarChar).Value = "Camacho";

                    cmd2.ExecuteNonQuery();
                }

            }
        }
    }
}