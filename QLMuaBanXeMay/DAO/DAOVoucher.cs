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
    internal class DAOVoucher
    {
        public static DataTable Load_ViewVC()
        {
            using (SqlCommand command = new SqlCommand("SELECT * FROM Voucher;", MY_DB.getConnection()))
            {
                try
                {
                    MY_DB.openConnection();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    MY_DB.closeConnection();

                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                    return null;
                }
            }
        }
        internal static void ThemVoucher(Voucher vc)
        {
            using (SqlCommand command = new SqlCommand("ThemVoucher", MY_DB.getConnection()))
            {
                try
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@TenVC", vc.TenVC);
                    command.Parameters.AddWithValue("@GiaTri", vc.Giatri);
                    command.Parameters.AddWithValue("@GiamGia", vc.Giamgia);
                    command.Parameters.AddWithValue("@NgayHH", vc.NgayHH);
                    command.Parameters.AddWithValue("@GiamGiaTD", vc.GgToida);

                    MY_DB.openConnection();

                    command.ExecuteNonQuery();

                    MY_DB.closeConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}
