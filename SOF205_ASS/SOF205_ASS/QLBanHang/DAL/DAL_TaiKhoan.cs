using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QLBanHang;
using System.Data.SqlClient;
using System.Data;
using DAL;
using DTO;
using System.Collections;
using System.Runtime.Remoting.Messaging;

namespace DAL_QLBanHang
{
    public class DAL_TaiKhoan : Connect
    {
        SqlCommand sqlCommand;//truy van
        SqlDataReader reader;
        public DTO_TaiKhoan DangNhap(string username, string password)
        {
            DTO_TaiKhoan taiKhoan = null;

            String query = "select * from TAIKHOAN where TAIKHOAN ='" + username + "'and MATKHAU='" + password + "'";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    taiKhoan = new DTO_TaiKhoan(reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8));
                }
                sqlConnection.Close();
            }
            return taiKhoan;
        }
        public List<DTO_TaiKhoan> getListNhanVien()
        {
            List<DTO_TaiKhoan> taiKhoanList = new List<DTO_TaiKhoan>();

            String query = "select * from TAIKHOAN where ID_LOAITAIKHOAN = 2";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    DTO_TaiKhoan dtoTaiKhoan = new DTO_TaiKhoan(reader.GetInt64(0), reader.GetInt64(1), reader.GetString(2),
                        reader.GetString(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetInt32(8));
                    taiKhoanList.Add(dtoTaiKhoan);
                }
                sqlConnection.Close();
            }
            return taiKhoanList;
        }

        public bool QuenMatKhau(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "QuenMatKhau";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool UpdateMatKhau(long idTaiKhoan, string passwordNew, String passwordOld)
        {
            String query = "update TAIKHOAN set MATKHAU = '" + passwordNew + "' where MATKHAU = '" + passwordOld + "' AND ID_TAIKHOAN = '" + idTaiKhoan + "'";
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                int rowsAffected = sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

                if (rowsAffected > 0)
                {
                    return true;
                }
            }
            return false;
        }
        
        public bool LayVaiTroNV(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "LayVaiTroNV";
                cmd.Parameters.AddWithValue("email", email);
                if (Convert.ToInt16(cmd.ExecuteScalar()) == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        public bool QuenMatKhau(string email, string opassword, string npassword)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "ChangePwd";
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("@oPwd", opassword);
                cmd.Parameters.AddWithValue("@nPwd", npassword);

                if (Convert.ToInt16(cmd.ExecuteScalar()) < 1)
                    return true;
                else
                    return false;
            }
            catch (Exception )
            {
               
            }
            finally
            {
                _conn.Close();
            }
            return false;
        }

        //xem danh sách nhân viên
        public DataTable danhSachNV()
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DanhSachNhanVien";
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;
            }
            finally
            {
                _conn.Close();
            }
        }



        //thêm nhân viên
        public bool insertNhanVien(DTO_TaiKhoan nhanVien)
        {

            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsertDataNhanVien";
                //cmd.Parameters.AddWithValue("email", nhanVien.EmailNV);
                //cmd.Parameters.AddWithValue("tennv", nhanVien.TenNhanVien);
                //cmd.Parameters.AddWithValue("diachi", nhanVien.DiaChi);
                //cmd.Parameters.AddWithValue("vaitro", nhanVien.VaiTro);
                //cmd.Parameters.AddWithValue("tinhtrang", nhanVien.TinhTrang);
                //cmd.Parameters.AddWithValue("matkhau", nhanVien.MatKhau);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }
            return false;
        }


        // cập nhân nhân viên 
        public bool updateNhanVien(DTO_TaiKhoan nhanVien)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateNhanVien";
                //cmd.Parameters.AddWithValue("email", nhanVien.EmailNV);
                //cmd.Parameters.AddWithValue("tenNv", nhanVien.TenNhanVien);
                //cmd.Parameters.AddWithValue("diaChi", nhanVien.DiaChi);
                //cmd.Parameters.AddWithValue("vaitro", nhanVien.VaiTro);
                //cmd.Parameters.AddWithValue("tinhtrang", nhanVien.TinhTrang);
                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        // xóa nhân viên
        public bool deleteNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteDataFromNhanVien";
                cmd.Parameters.AddWithValue("Email", email);

                if (cmd.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {

            }
            finally
            {
                _conn.Close();
            }

            return false;
        }

        // tìm nhân viên
        public DataTable searchNhanVien(string tenNV)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SearchNhanVien";
                cmd.Parameters.AddWithValue("tenNV", tenNV);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;

            }

            finally
            {
                _conn.Close();
            }

        }

        //thong tin nhan vien 
        public DataTable thongTinNhanVien(string email)
        {
            try
            {
                _conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "XemThongTinNV";
                cmd.Parameters.AddWithValue("email", email);
                DataTable data = new DataTable();
                data.Load(cmd.ExecuteReader());
                return data;

            }

            finally
            {
                _conn.Close();
            }

        }
        public bool xoaTaiKhoan(long idTaiKhoan)
        {
            bool ketQua = false;

            String query = "delete from TAIKHOAN where ID_TAIKHOAN = " + idTaiKhoan;
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                sqlCommand = new SqlCommand(query, sqlConnection);
                if (sqlCommand.ExecuteNonQuery() > 0)
                {
                    ketQua = true;

                }

            }
            return ketQua;
        }
    }
}
