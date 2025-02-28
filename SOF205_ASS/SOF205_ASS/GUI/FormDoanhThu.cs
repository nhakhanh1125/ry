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
    public partial class FormDoanhThu : Form
    {
        public FormDoanhThu()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {

            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {

                string query = "SELECT \r\n    P.TENPHIM AS 'Tên phim',\r\n    COUNT(DISTINCT S.ID_SUAT) AS 'Số buổi chiếu',\r\n    COUNT(H.ID_HOADON) AS 'Số vé bán ra',\r\n    SUM(H.TONGTIEN) AS 'Tổng doanh thu (VND)'\r\nFROM \r\n    HOADON H\r\nJOIN \r\n    SUAT S ON H.ID_SUAT = S.ID_SUAT\r\nJOIN \r\n    PHIM P ON S.ID_PHIM = P.ID_PHIM\r\nWHERE \r\n    S.NGAYCHIEU BETWEEN NGAYCONGCHIEU AND NGAYNGUNGCHIEU\r\nGROUP BY \r\n    P.TENPHIM\r\nORDER BY \r\n    P.TENPHIM;";

                using (SqlDataAdapter adapter = new SqlDataAdapter(query, sqlConnection))
                {

                    DataTable dataTable = new DataTable();

                    try
                    {
                        sqlConnection.Open();


                        adapter.Fill(dataTable);


                        dtgv.DataSource = dataTable;
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = Connect.GetSqlConnection())
            {
                string query = @"
        SELECT 
            P.TENPHIM AS 'Tên phim',
            COUNT(DISTINCT S.ID_SUAT) AS 'Số buổi chiếu',
            COUNT(H.ID_HOADON) AS 'Số vé bán ra',
            SUM(H.TONGTIEN) AS 'Tổng doanh thu (VND)'
        FROM 
            HOADON H
        JOIN 
            SUAT S ON H.ID_SUAT = S.ID_SUAT
        JOIN 
            PHIM P ON S.ID_PHIM = P.ID_PHIM
        WHERE 
            S.NGAYCHIEU BETWEEN @StartDate AND @EndDate
        GROUP BY 
            P.TENPHIM
        ORDER BY 
            P.TENPHIM;";

                using (SqlCommand command = new SqlCommand(query, sqlConnection))
                {
                    command.Parameters.AddWithValue("@StartDate", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();

                        try
                        {
                            sqlConnection.Open();
                            adapter.Fill(dataTable);

                            dtgv.DataSource = dataTable;

                            // Calculate total revenue
                            decimal totalRevenue = 0;
                            foreach (DataRow row in dataTable.Rows)
                            {
                                if (row["Tổng doanh thu (VND)"] != DBNull.Value)
                                {
                                    totalRevenue += Convert.ToDecimal(row["Tổng doanh thu (VND)"]);
                                }
                            }
                            label5.Text = totalRevenue.ToString("N0") + " VND";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
        }

        private void FormDoanhThu_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FQuanLy formql= new FQuanLy();
            formql.ShowDialog();
        }
    }
}
