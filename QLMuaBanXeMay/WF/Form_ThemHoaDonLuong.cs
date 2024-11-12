using QLMuaBanXeMay.Class;
using QLMuaBanXeMay.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLMuaBanXeMay.WF
{
    public partial class Form_ThemHoaDonLuong : Form
    {
        public HoaDonLuong hdl = new HoaDonLuong();
        public Form_ThemHoaDonLuong(HoaDonLuong hdl)
        {
            InitializeComponent();
            this.hdl = hdl;
        }

        private void Form_ThemHoaDonLuong_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            dgvThongTinHoaDonNV.DataSource = DAONhanVien.LoadThongTinNhanVienCaLamHoaDon(hdl.CCCDNV);
        }

        private void dgvThongTinHoaDonNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvThongTinHoaDonNV.Rows[e.RowIndex];

                txtMaNV.Text = row.Cells[0].Value.ToString();
                txtTenNV.Text = row.Cells[1].Value.ToString();
                txtChucVu.Text = row.Cells[2].Value.ToString();
                txtLuongCoBan.Text = row.Cells[3].Value.ToString();


            }


        }

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            try
            {

                if (!string.IsNullOrEmpty(txtSoGioLam.Text) && !string.IsNullOrEmpty(txtLuongCoBan.Text))
                {

                    TimeSpan soGioLam = TimeSpan.Parse(txtSoGioLam.Text);
                    double sogiolam = soGioLam.TotalHours;
                    double luongCoBan = double.Parse(txtLuongCoBan.Text);

                    // Tính lương: SoGioLam * LuongCoBan
                    double luong = sogiolam * luongCoBan;


                    txtTongTien.Text = luong.ToString();
                }
            }
            catch
            {

            }
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                TimeSpan soGioLam = TimeSpan.Parse(txtSoGioLam.Text);
                double sgl = soGioLam.TotalHours;
                hdl.NgayXuat = dtpNgayXuat.Value;
                hdl.SoGioLam = sgl;
                hdl.TongTien = int.Parse(txtTongTien.Text);
                hdl.CCCDNV = hdl.CCCDNV;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin");
            }


        }

        private void dtpNgayXuat_ValueChanged(object sender, EventArgs e)
        {
            dgvThongTinHoaDonNV.DataSource = DAOHoaDonLuong.LoadCaLamViecTheoNgayVaTongSoGio(hdl.CCCDNV, dtpNgayXuat.Value);
            //if (dgvThongTinHoaDonNV.Rows.Count > 0)
            //{
            //    decimal totalHours = 0;
            //    foreach (DataGridViewRow row in dgvThongTinHoaDonNV.Rows)
            //    {
            //        if (row.Cells["TGKetThuc"].Value != null && row.Cells["TGBatDau"].Value != null)
            //        {
            //            TimeSpan tgKetThuc = TimeSpan.Parse(row.Cells["TGKetThuc"].Value.ToString());
            //            TimeSpan tgBatDau = TimeSpan.Parse(row.Cells["TGBatDau"].Value.ToString());

            //            decimal hoursWorked = (decimal)(tgKetThuc - tgBatDau).TotalHours;
            //            totalHours += hoursWorked;
            //        }
            //    }
            //    txtSoGioLam.Text=totalHours.ToString();
            //    txtTongTien.Text = (totalHours * int.Parse(txtLuongCoBan.Text)).ToString();
            
        }
    }
}
