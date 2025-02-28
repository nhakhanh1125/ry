using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Phim : Connect
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;

        public List<DTO_Phim> getPhim()
        {
            List<DTO_Phim> phimList = new List<DTO_Phim>();

            String query = "SELECT * FROM PHIM WHERE NGAYCONGCHIEU <= CURRENT_TIMESTAMP AND CURRENT_TIMESTAMP <= NGAYNGUNGCHIEU";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    DTO_Phim dtoPhim = new DTO_Phim(reader.GetInt64(0), reader.GetString(1), reader.GetString(2),
      reader.GetString(4), reader.GetString(5), reader.GetString(11), reader.GetDateTime(12), reader.GetInt32(13)
      );

                    phimList.Add(dtoPhim);
                }
                sqlConnection.Close();
            }
            return phimList;
        }

        public DTO_Phim getPhimById(long idPhim)
        {
            DTO_Phim dtoPhim = new DTO_Phim();

            String query = "SELECT * FROM PHIM WHERE ID_PHIM = '" + idPhim + "'";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    dtoPhim = new DTO_Phim(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                        reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8),
                        reader.GetString(9), reader.GetString(10), reader.GetString(11), reader.GetDateTime(12), reader.GetInt32(13),
                        reader.GetString(14), reader.GetBoolean(15));
                }
                sqlConnection.Close();
            }
            return dtoPhim;
        }
    }
}
