﻿using QLMuaBanXeMay.Class;
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

                    DateTime tgBatDau = DateTime.Parse(row.Cells[4].Value.ToString());
                    txtTGBatDau.Text = tgBatDau.ToString("HH:mm:ss");

                    DateTime tgKetThuc = DateTime.Parse(row.Cells[5].Value.ToString());
                    txtTGKetThuc.Text = tgKetThuc.ToString("HH:mm:ss");

                try
                {
                    // Kiểm tra nếu các textbox không trống
                    if (!string.IsNullOrEmpty(txtTGBatDau.Text) && !string.IsNullOrEmpty(txtTGKetThuc.Text))
                    {
                        // Chuyển đổi giá trị thời gian từ các textbox thành DateTime
                        DateTime BatDau = DateTime.Parse(txtTGBatDau.Text);
                        DateTime KetThuc = DateTime.Parse(txtTGKetThuc.Text);

                        // Tính sự khác biệt giữa TG kết thúc và TG bắt đầu
                        TimeSpan timeDifference = KetThuc - BatDau;

                        // Hiển thị số giờ làm việc trong txtSoGioLam
                        // Bạn có thể chỉ lấy phần giờ, phút, và giây
                        txtSoGioLam.Text = timeDifference.ToString(@"hh\:mm\:ss");  // Format: HH:mm:ss
                    }
                    else
                    {
                        // Thông báo nếu thời gian bắt đầu hoặc kết thúc trống
                        MessageBox.Show("Vui lòng nhập đầy đủ thời gian bắt đầu và kết thúc.");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý lỗi (nếu có)
                    MessageBox.Show("Lỗi: " + ex.Message);
                }

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
    }
}
