﻿using QLMuaBanXeMay.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLMuaBanXeMay.DAO
{
    public class DAOHoaDonLuong
    {
        public static DataTable Load_ViewHDLuong()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM dbo.GetAllHoaDonLuong()", MY_DB.getConnection()))
            {
                MY_DB.openConnection();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                MY_DB.closeConnection();

                return dt;
            }
        }

        public static void ThemHoaDonluong(HoaDonLuong hoaDonLuong)
        {
            using (SqlCommand command = new SqlCommand("AddHoaDonLuong", MY_DB.getConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@SoGioLam", hoaDonLuong.SoGioLam);
                    command.Parameters.AddWithValue("@NgayXuat", hoaDonLuong.NgayXuat);
                    command.Parameters.AddWithValue("@TongTien", hoaDonLuong.TongTien);
                    command.Parameters.AddWithValue("@CCCDNV", hoaDonLuong.CCCDNV);
                    command.Parameters.AddWithValue("@CCCDQL", 101);

                    MY_DB.openConnection();
                    command.ExecuteNonQuery();
                    MY_DB.closeConnection();

                    MessageBox.Show("Xuất hóa đơn lương thành công");
                }
                catch (Exception ex)
                {
                    // Thông báo lỗi nếu có
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

    }
}
