using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connect
    {
        protected SqlConnection _conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=QLDatVePhim;Integrated Security=True");
        private static string stringconnection = @"Data Source=localhost;Initial Catalog=QLDatVePhim;Integrated Security=True";
        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(stringconnection);
        
        }
    }
}
