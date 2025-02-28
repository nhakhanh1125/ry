using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DAL_VeGhe
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;

        public bool checkGheDaDat(long idGhe, long idSuat)
        {
            bool result = false;
            String query = "SELECT * FROM VE_GHE where ID_GHE = '" + idGhe + "' and ID_SUAT = '" + idSuat + "'";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    result = true;
                    break;
                }
                sqlConnection.Close();
            }

            return result;
        }

        public int getGheDaDatBySuat(long idSuat)
        {
            int result = 0;
            String query = "SELECT COUNT(ID_VE_GHE) FROM VE_GHE WHERE ID_SUAT = " + idSuat;
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    result = reader.GetInt32(0);
                    break;
                }
                sqlConnection.Close();
            }

            return result;
        }

        public bool insertVeGhe(long idGhe, long idHoaDon, long idSuat)
        {
            bool result = false;
            String query = "INSERT INTO VE_GHE(ID_GHE, ID_HOADON, ID_SUAT) VALUES (" + idGhe + ", " + idHoaDon + ", " + idSuat + ")";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                sqlConnection.Close();
            }

            return result;
        }
    }
}
        


