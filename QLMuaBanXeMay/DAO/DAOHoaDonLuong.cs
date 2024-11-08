using QLMuaBanXeMay.Class;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLMuaBanXeMay.DAO
{
    public class DAOHoaDonLuong
    {
        public static DataTable Load_ViewHD()
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
    }
}
