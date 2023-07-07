using QUANLIBIDA.db;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QUANLIBIDA
{
    public partial class frmDonViTinh : Form
    {
        public frmDonViTinh(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private BIDA_DatabaseDataContext db;
        private string nhanvien;
        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            db = new BIDA_DatabaseDataContext();//khoi tao doi tuong datacontext
            ShowData();
            dgvDVT.Columns["ID"].HeaderText = "Mã ĐVT";
            dgvDVT.Columns["ID"].Width = 100;//bề rộng cột
            dgvDVT.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//căn giữa cột

            dgvDVT.Columns["TenDVT"].HeaderText = "Tên ĐVT";
            dgvDVT.Columns["TenDVT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//bề rộng tự động co giãn

            //focus cho textbox khi form đc load --> đỡ click chuột
            txtDVT.Select();
        }
        private void ShowData()
        {
            var rs = (from d in db.DonViTinhs.Where(x => x.isDeleted == 0)
                      select new
                      {
                          d.ID,
                          d.TenDVT
                      }).ToList();
            dgvDVT.DataSource = rs;//do danh sach don vi tinh len datagridview co ten dgvDVT
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDVT.Text))//neu textbox txtDVT khong null
            {
                DonViTinh dvt = new DonViTinh();// khai báo 1 đối tượng thuộc class DonViTinh
                dvt.TenDVT = txtDVT.Text;//gán tên
                dvt.NguoiTao = nhanvien;//gán nhân viên tạo
                dvt.NgayTao = DateTime.Now;//gán ngày giờ tạo
                dvt.isDeleted = 0;
                db.DonViTinhs.InsertOnSubmit(dvt);// lưu vào csdl
                db.SubmitChanges();
                MessageBox.Show("Thêm mới đơn vị tính thành công", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();//gọi hàm showdata để cập nhật lại danh sách hiển thị
                txtDVT.Text = null;//sau khi thêm thành công thì reset lại giá trị của textbox thành null
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtDVT.Select();//focus trở lại textbox sau khi thêm
        }

        private DataGridViewRow r;
        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());//e.RowIndex chỉ số hàng
            //chỉ số hàng được tính như sau: hàng đầu tiên có chỉ số là 0, hàng thứ 2 có chỉ số là 1,...
            //từ sự kiện click vào hàng, ta sẽ lấy được giá trị của hàng được chọn để tiến hành cập nhật
            r = dgvDVT.Rows[e.RowIndex];//hàng được chọn dựa vào sự kiện click chuột
            //MessageBox.Show(r.Cells["TenDVT"].Value.ToString());//tên của đơn vị tính
            txtDVT.Text = r.Cells["TenDVT"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)//nếu không có hàng nào của datagridview được chọn
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần cập nhật", "Chú ý!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng lại ngang đây mà không thực hiện các câu lệnh phía dưới
            }
            if (!string.IsNullOrEmpty(txtDVT.Text))
            {
                //mỗi đối tượng r là 1 hàng thuộc datagridview dgvDVT
                //mỗi hàng gồm có 2 cột id và TenDVT 
                //muốn cập nhật đơn vị tính ta cần dựa vào id của đvt - khóa chính mà ta đã thiết kế trong csdl
                //vì vậy, việc đầu tiên cần tìm ra dvt nào cần được cập nhật

                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));//vì r.Cells["TenDVT"].Value.ToString() là string, mà id trong csdl lại là int => ép kiểu qua int
                //đã xác định được dvt cần được cập nhật trong csdl
                dvt.TenDVT = txtDVT.Text;//cập nhật lại tên của đơn vị tính dựa vào giá trị của textbox txtDVT
                dvt.NgayCapNhat = DateTime.Now;
                dvt.NguoiCapNhat = nhanvien;
                db.SubmitChanges();//lưu vào csdl
                MessageBox.Show("Cập nhật đơn vị tính thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();//gọi lại hàm hiển thị danh sách đơn vị tính sau khi cập nhật xong
                r = null;//sau khi cập nhật xong thì set r = null <=> không hàng nào được chọn trên datagridview
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị tính", "Chú ý!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng lại ngang đây mà không thực hiện các câu lệnh phía dưới
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r==null)//nếu chưa có hàng nào được chọn trên datagridview dgvDVT
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng chương trình ngang đây, không thực hiện các câu lệnh phía dưới
            }

            if (
                MessageBox.Show("Bạn thực sự muốn xóa đơn vị tính "+ r.Cells["TenDVT"].Value.ToString()+" ?",
                                        "Xác nhận xóa",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));//vì r.Cells["TenDVT"].Value.ToString() là string, mà id trong csdl lại là int => ép kiểu qua int
                dvt.isDeleted = 1;
                db.SubmitChanges();
                MessageBox.Show("Xóa đơn vị tính thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();//gọi lại hàm hiển thị danh sách đơn vị tính sau khi cập nhật xong
                r = null;//sau khi cập nhật xong thì set r = null <=> không hàng nào được chọn trên datagridview

            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

