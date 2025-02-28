using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_DayGhe : Connect
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;

        public List<DTO_DayGhe> getDayGet(long idPhong)
        {
            List<DTO_DayGhe> dayGheList = new List<DTO_DayGhe>();

            String query = "select * from DAYGHE where ID_PHONG = " + idPhong;
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    DTO_DayGhe dayGhe = new DTO_DayGhe(reader.GetInt64(0), reader.GetString(1), reader.GetInt64(2));
                    dayGheList.Add(dayGhe);
                }
                sqlConnection.Close();
            }
            return dayGheList;
        }
    }
}
