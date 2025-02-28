using DTO;
using DTO_QLBanHang;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_Phong : Connect
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;
        public DTO_Phong getPhong(long idPhong)
        {
            DTO_Phong dtoPhong = null;

            String query = "select * from PHONG where ID_PHONG ='" + idPhong + "'";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    dtoPhong = new DTO_Phong(reader.GetInt64(0), reader.GetString(1), reader.GetInt64(2));
                }
                sqlConnection.Close();
            }
            return dtoPhong;
        }
    }
}
