using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Suat : Connect
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;
        public List<DTO_Suat> getSuat(long idPhim)
        {
            List<DTO_Suat> SuatList = new List<DTO_Suat>();

            String query = "SELECT * FROM SUAT WHERE ID_PHIM = " + idPhim;
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    DTO_Suat dtoSuat = new DTO_Suat(reader.GetInt64(0), reader.GetInt64(1), reader.GetInt64(2), reader.GetDateTime(3), reader.GetTimeSpan(4));

                    SuatList.Add(dtoSuat);
                }
                sqlConnection.Close();
            }
            return SuatList;
        }
    }

}
