﻿using QLMuaBanXeMay.Class;
using QLMuaBanXeMay.DAO;
using QLMuaBanXeMay.WF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLMuaBanXeMay.UC
{
    public partial class UC_HoaDonLuong : UserControl
    {
        public HoaDonLuong hdl = new HoaDonLuong();
        public NhanVien nv = new NhanVien();
        public UC_HoaDonLuong()
        {
            InitializeComponent();
            Load_GridView();
        }
        private void Load_GridView()
        {

            dgvHoaDonLuong.DataSource = DAOHoaDonLuong.Load_ViewHDLuong();
        }

        private void dgvHoaDonLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvHoaDonLuong.Rows[e.RowIndex];

                    txtMaHD.Text = row.Cells[0].Value.ToString();
                    txtMaNV.Text = row.Cells[1].Value.ToString();
                    txtTenNV.Text = row.Cells[2].Value.ToString();
                    txtChucVu.Text = row.Cells[3].Value.ToString();
                    txtTGBatDau.Text = row.Cells[4].Value.ToString();
                    txtTGKetThuc.Text = row.Cells[5].Value.ToString();
                    txtSoGioLam.Text = row.Cells[6].Value.ToString();
                    txtLuongCoBan.Text = row.Cells[7].Value.ToString();
                    txtTongTien.Text = row.Cells[8].Value.ToString();
                    dtpNgayXuat.Value = DateTime.Parse(row.Cells[9].Value.ToString());

                }
           
        }

        private void UC_HoaDonLuong_Load(object sender, EventArgs e)
        {

        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            Form_ChonNVThemLuong form = new Form_ChonNVThemLuong();

            if (form.ShowDialog() == DialogResult.OK)
            {
                this.hdl = form.hdl;

                
                Form_ThemHoaDonLuong formThemHoaDon = new Form_ThemHoaDonLuong(hdl);
                if (formThemHoaDon.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật danh sách hóa đơn sau khi thêm thành công
                    this.hdl = formThemHoaDon.hdl;
                    DAOHoaDonLuong.ThemHoaDonluong(hdl);
                    Load_GridView();
                }
            }
        }
    }
}
