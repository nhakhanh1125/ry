using DAL;
using DTO;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class FSuat : Form
    {
        public FSuat()
        {
            InitializeComponent();
            LoadData();
            Phongcbo();
            PopulateComboBox();
        }

        private List<DTO_IDPhong> LoadCboPhong()
        {
            List<DTO_IDPhong> listPhong = new List<DTO_IDPhong>();
            string query = "select ID_Phong from PHONG";

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_IDPhong dtoPhong = new DTO_IDPhong(reader.GetInt64(0));
                            listPhong.Add(dtoPhong);
                        }
                    }
                }
            }
            return listPhong;
        }

        private void Phongcbo()
        {
            List<DTO_IDPhong> listPhong = LoadCboPhong();
            cboID_Phong.DataSource = listPhong;
            cboID_Phong.DisplayMember = "IdPhong";  // Hiển thị ID_Phim trong ComboBox
            cboID_Phong.ValueMember = "IdPhong";    // Sử dụng ID_Phim làm giá trị thực của mỗi mục
        }
        private List<DTO_SuatPhim> LoadCboPhim()
        {
            List<DTO_SuatPhim> listID = new List<DTO_SuatPhim>();
            string query = "SELECT ID_Phim FROM PHIM";

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DTO_SuatPhim dtoPhim = new DTO_SuatPhim(reader.GetInt64(0));
                            listID.Add(dtoPhim);
                        }
                    }
                }
            }

            return listID;
        }


        // Phương thức để điền dữ liệu vào ComboBox
        private void PopulateComboBox()
        {
            List<DTO_SuatPhim> listID = LoadCboPhim();
            cboID_Phim.DataSource = listID;
            cboID_Phim.DisplayMember = "ID_Phim";  // Hiển thị ID_Phim trong ComboBox
            cboID_Phim.ValueMember = "ID_Phim";    // Sử dụng ID_Phim làm giá trị thực của mỗi mục
        }
       
        private void LoadData()
        {

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {

                string query = "select * from Suat";

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                cboID_Phim.Text = row.Cells[1].Value.ToString();
                cboID_Phong.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                txtGioChieu.Text = row.Cells[4].Value.ToString();





            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string id_phim = cboID_Phim.Text;
            string id_Phong = cboID_Phong.Text;
            string Ngaychieu = dateTimePicker1.Text;
            string GioChieu = txtGioChieu.Text;
            DateTime dateValue;
            string formattedDate = "";

            // Kiểm tra nếu bỏ trống một ô combobox hoặc textbox
            if (string.IsNullOrWhiteSpace(id_phim) || string.IsNullOrWhiteSpace(id_Phong) ||
                string.IsNullOrWhiteSpace(Ngaychieu) || string.IsNullOrWhiteSpace(GioChieu))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (DateTime.TryParseExact(Ngaychieu, "dddd, MMMM d, yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue))
            {
                formattedDate = dateValue.ToString("yyyy-MM-dd");
            }
            else
            {
                MessageBox.Show("Ngày chiếu không hợp lệ.");
                return;
            }

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "INSERT INTO SUAT (ID_Phim, ID_PHONG, NGAYCHIEU, GIOCHIEU) VALUES (@ID_PHIM, @ID_PHONG, @NGAYCHIEU, @GIOCHIEU)";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@ID_PHIM", id_phim);
                    command.Parameters.AddWithValue("@ID_PHONG", id_Phong);
                    command.Parameters.AddWithValue("@NGAYCHIEU", formattedDate);
                    command.Parameters.AddWithValue("@GIOCHIEU", GioChieu);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thêm suất thành công.");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show("Thêm suất không thành công.");
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

            if (dataGridView1.SelectedRows.Count > 0)
            {
                string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string GioChieu = txtGioChieu.Text; // Lấy giờ chiếu từ txtGoChieu
                string NgayChieu = dateTimePicker1.Value.ToString("yyyy-MM-dd"); // Lấy ngày chiếu từ dateTimePicker

                using (SqlConnection sqlConnection = Connect.GetSqlConnection())
                {
                    string query = "UPDATE SUAT SET NGAYCHIEU = @NGAYCHIEU, GIOCHIEU = @GIOCHIEU WHERE ID_SUAT = @ID_SUAT";
                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@ID_SUAT", ID);
                        command.Parameters.AddWithValue("@NGAYCHIEU", NgayChieu); // Thêm tham số ngày chiếu
                        command.Parameters.AddWithValue("@GIOCHIEU", GioChieu);   // Thêm tham số giờ chiếu

                        try
                        {
                            sqlConnection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cập nhật suất thành công.");
                                LoadData(); // Tải lại dữ liệu sau khi cập nhật
                            }
                            else
                            {
                                MessageBox.Show("Cập nhật suất không thành công.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = "DELETE FROM SUAT WHERE ID_SUAT = @ID_SUAT";
                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@ID_SUAT", ID);

                    try
                    {
                        sqlConnection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Xóa suất thành công.");
                            LoadData(); // Reload data after deleting the room
                        }
                        else
                        {
                            MessageBox.Show("Xóa suất không thành công.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void FSuat_Load(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
    }
    

