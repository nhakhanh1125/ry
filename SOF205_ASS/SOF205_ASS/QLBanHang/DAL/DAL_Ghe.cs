using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Ghe : Connect
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;
        public List<DTO_Ghe> getGhe(long idDayGhe)
        {
            List<DTO_Ghe> dtoGheList = new List<DTO_Ghe>();

            String query = "select * from GHE where ID_DAYGHE = " + idDayGhe;
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    dtoGheList.Add(new DTO_Ghe(reader.GetInt64(0), reader.GetInt32(1), reader.GetInt64(2), reader.GetInt64(3)));
                }
                sqlConnection.Close();
            }
            return dtoGheList;
        }
    }
}
