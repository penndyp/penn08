using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp2
{
    public class db
    {
        const string constring = "Data Source=ISS460602002944;Initial Catalog=penndb;Integrated Security=true; ";

        public static List<quartzdemo> GetList()
        {
            using (var con=new SqlConnection(constring))
            {
                return con.Query<quartzdemo>("select * from quartzdemo").ToList();
            }
        }
        public static quartzdemo GetExt(int id)
        {
            using (var con = new SqlConnection(constring))
            {
                return con.QueryFirst<quartzdemo>("select * from quartzdemo where id=@id", new { id = id });
            }
        }
    
    }
    public class quartzdemo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Express { get; set; }
    }
}
