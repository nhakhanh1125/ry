using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_HoaDon
    {
        SqlCommand sqlCommand;//truy van

        public long insertHoaDon(int tongTien, long idSuat)
        {
            long result = 0;
            String query = "INSERT INTO HOADON (ID_TAIKHOAN, ID_SUAT, NGAYDATVE, GIODATVE, GIADUOCGIAM, ID_KHUYENMAI, TONGTIEN, THANHTOAN) " +
                "VALUES ('1', '" + idSuat + "', CURRENT_TIMESTAMP, CURRENT_TIMESTAMP, '0', '0', " + tongTien + ", NULL)";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                object resultQuery = sqlCommand.ExecuteScalar();
                if (resultQuery != null)
                {
                    result = Convert.ToInt64(resultQuery);
                }
                sqlConnection.Close();
            }

            return result;
        }

        public long GetLatestHoaDonId()
        {
            long result = 0;
            String query = "SELECT TOP 1 ID_HOADON FROM HOADON ORDER BY ID_HOADON DESC";

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        result = reader.GetInt64(0); 
                    }
                }

                reader.Close();
                sqlConnection.Close();
            }

            return result;
        }


    }
}
