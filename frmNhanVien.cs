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

namespace QUANLIBIDA
{
    public partial class frmNhanVien : Form
    {
        public frmNhanVien(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }

        private BIDA_DatabaseDataContext db;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            db = new BIDA_DatabaseDataContext();
            ShowData();

            dgvNhanVien.Columns["PassWord"].Visible = false;//ẩn cột mật khẩu
            dgvNhanVien.Columns["UserName"].HeaderText = "Tài khoản";
            dgvNhanVien.Columns["HoVaTen"].HeaderText = "Họ và tên";
            dgvNhanVien.Columns["DienThoai"].HeaderText = "Điện thoại";
            dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";

            dgvNhanVien.Columns["UserName"].Width = 100;
            dgvNhanVien.Columns["DienThoai"].Width = 100;
            dgvNhanVien.Columns["HoVaTen"].Width = 200;
            dgvNhanVien.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void ShowData()
        {
            dgvNhanVien.DataSource = from nv in db.NhanViens.Where(x => x.isDeleted == 0)
                                     select new
                                     {
                                         nv.UserName,
                                         nv.PassWord,
                                         nv.HoVaTen,
                                         nv.DienThoai,
                                         nv.DiaChi
                                     };
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản nhân viên", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Select();
                return;
            }

            //kiểm tra sự tồn tại của tài khoản trong csdl
            var c = db.NhanViens.Where(x => x.UserName.Trim().ToLower() == txtUsername.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Tài khoản này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Select();
                return;
            }

            var nv = new NhanVien();
            nv.UserName = txtUsername.Text.Trim().ToLower();
            nv.PassWord = txtPassword.Text;
            nv.HoVaTen = txtHoVaTen.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.NguoiTao = nhanvien;
            nv.isDeleted = 0;
            nv.isAdmin = 0;
            nv.NgayTao = DateTime.Now;
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới nhân viên thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtDiaChi.Text = txtDienThoai.Text = txtHoVaTen.Text = txtPassword.Text = txtUsername.Text = null;
        }

        private DataGridViewRow r;
        private string nhanvien;
        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNhanVien.Rows[e.RowIndex];
                txtUsername.Text = r.Cells["UserName"].Value.ToString();
                txtPassword.Text = r.Cells["PassWord"].Value.ToString();
                txtHoVaTen.Text = r.Cells["HoVaTen"].Value.ToString();
                txtDienThoai.Text = r.Cells["DienThoai"].Value.ToString();
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nv = db.NhanViens.SingleOrDefault(x => x.UserName == r.Cells["username"].Value.ToString());
            nv.PassWord = txtPassword.Text;
            nv.HoVaTen = txtHoVaTen.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.NguoiCapNhat = nhanvien;
            nv.NgayCapNhat = DateTime.Now;
            db.SubmitChanges();
            MessageBox.Show("Cập nhật nhân viên thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtDiaChi.Text = txtDienThoai.Text = txtHoVaTen.Text = txtPassword.Text = txtUsername.Text = null;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (
              MessageBox.Show("Bạn thực sự muốn xóa nhân viên " + r.Cells["UserName"].Value.ToString() + " ?",
                                      "Xác nhận xóa",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) == DialogResult.Yes
              )
            {
                try
                {
                    var nv = db.NhanViens.SingleOrDefault(x => x.UserName == r.Cells["UserName"].Value.ToString());
                    nv.isDeleted = 1;
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhân viên thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Xóa nhân viên thất bại!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                finally
                {
                    ShowData();
                    txtDiaChi.Text = txtDienThoai.Text = txtHoVaTen.Text = txtPassword.Text = txtUsername.Text = null;
                    r = null;
                }
            }

        }
    }
}
