using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_LoaiGhe : Connect
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;
        public DTO_LoaiGhe DangNhap(string username, string password)
        {
            DTO_LoaiGhe taiKhoan = null;

            String query = "select * from TAIKHOAN where TAIKHOAN ='" + username + "'and MATKHAU='" + password + "'";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    taiKhoan = new DTO_LoaiGhe(reader.GetInt64(0), reader.GetString(1), reader.GetInt64(2));
                }
                sqlConnection.Close();
            }
            return taiKhoan;
        }
    }
}
