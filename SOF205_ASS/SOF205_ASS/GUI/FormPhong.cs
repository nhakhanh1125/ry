using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FormPhong : Form
    {
        public FormPhong()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "SELECT * FROM PHONG";
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        sqlConnection.Open();
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void FormPhong_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtID_Phong.Text = row.Cells[0].Value.ToString();
                txtTenPhong.Text = row.Cells[1].Value.ToString();
                txtSoLuongGhe.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //string idPhong = txtID.Text;
            string tenPhong = txtTenPhong.Text;
            string soLuongGhe = txtSoLuongGhe.Text;

            if (string.IsNullOrWhiteSpace(tenPhong) || string.IsNullOrWhiteSpace(soLuongGhe))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phòng.");
                return;
            }

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string checkQuery = "SELECT COUNT(*) FROM PHONG WHERE TENPHONG = @TENPHONG";
                using (SqlCommand checkCommand = new SqlCommand(checkQuery, sqlConnection))
                {
                    checkCommand.Parameters.AddWithValue("@TENPHONG", tenPhong);
                    sqlConnection.Open();
                    int count = (int)checkCommand.ExecuteScalar();
                    sqlConnection.Close();

                    if (count > 0)
                    {
                        MessageBox.Show("Tên phòng đã tồn tại.");
                        return;
                    }
                }

                string query = "INSERT INTO PHONG (TENPHONG, SOLUONGGHE) VALUES (@TENPHONG, @SOLUONGGHE)";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@TENPHONG", tenPhong);
                    command.Parameters.AddWithValue("@SOLUONGGHE", soLuongGhe);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm phòng thành công.");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm phòng không thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnfix_Click(object sender, EventArgs e)
        {
            string idPhong = txtID_Phong.Text;
            string tenPhong = txtTenPhong.Text;
            string soLuongGhe = txtSoLuongGhe.Text;

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "UPDATE PHONG SET TENPHONG = @TenPhong, SOLUONGGHE = @SoLuongGhe WHERE ID_PHONG = @IDPhong";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@IDPhong", idPhong);
                    command.Parameters.AddWithValue("@TenPhong", tenPhong);
                    command.Parameters.AddWithValue("@SoLuongGhe", soLuongGhe);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật phòng thành công.");
                            LoadData(); // Reload data after updating the room
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật phòng không thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string idPhong = txtID_Phong.Text;

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "DELETE FROM PHONG WHERE ID_PHONG = @IDPhong";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@IDPhong", idPhong);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa phòng thành công.");
                            LoadData(); // Reload data after deleting the room
                        }
                        else
                        {
                            MessageBox.Show("Xóa phòng không thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtID_Phong.Text = "";
            txtTenPhong.Text = "";
            txtSoLuongGhe.Text = "";
            txtID_Phong.Focus();
        }
    }
}
