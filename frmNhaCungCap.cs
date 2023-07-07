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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private BIDA_DatabaseDataContext db;
        private string nhanvien;
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            db = new BIDA_DatabaseDataContext();
            ShowData();
            dgvNhaCungCap.Columns["ID"].Visible = false;//ẩn cột mã nhà cung cấp
            dgvNhaCungCap.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNhaCungCap.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNhaCungCap.Columns["Email"].HeaderText = "Email";
            dgvNhaCungCap.Columns["DienThoai"].HeaderText = "Điện thoại";

            dgvNhaCungCap.Columns["DiaChi"].Width = 200;
            dgvNhaCungCap.Columns["DienThoai"].Width = 100;
            dgvNhaCungCap.Columns["Email"].Width = 200;
            dgvNhaCungCap.Columns["TenNCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            txtTenNCC.Select();
        }
        private void ShowData()
        {
            var rs = from n in db.NhaCungCaps.Where(x => x.isDeleted == 0)
                     select new
                     {
                         n.ID,
                         n.TenNCC,
                         n.DienThoai,
                         n.Email,
                         n.DiaChi
                     };
            dgvNhaCungCap.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Select();
                return;
            }

            NhaCungCap ncc = new NhaCungCap();
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.Email = txtEmail.Text;
            ncc.DienThoai = txtDienThoai.Text;
            ncc.NgayTao = DateTime.Now;
            ncc.NguoiTao = nhanvien;
            ncc.isDeleted = 0;
            db.NhaCungCaps.InsertOnSubmit(ncc);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = null;
            txtTenNCC.Select();

        }

        private DataGridViewRow r;
        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNhaCungCap.Rows[e.RowIndex];
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = r.Cells["Email"].Value.ToString();
                txtTenNCC.Text = r.Cells["TenNCC"].Value.ToString();
                txtDienThoai.Text = r.Cells["DienThoai"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp muốn cập nhật", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var ncc = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            ncc.TenNCC = txtTenNCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.Email = txtEmail.Text;
            ncc.DienThoai = txtDienThoai.Text;
            ncc.NgayCapNhat = DateTime.Now;
            ncc.NguoiCapNhat = nhanvien;

            db.SubmitChanges();
            MessageBox.Show("Cập nhật nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = null;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp muốn xóa", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (
              MessageBox.Show("Bạn thực sự muốn xóa nhà cung cấp " + r.Cells["TenNCC"].Value.ToString() + " ?",
                                      "Xác nhận xóa",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) == DialogResult.Yes
              )
            {
                try
                {
                    var ncc = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    ncc.isDeleted = 1;
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch
                {
                    MessageBox.Show("Xóa nhà cung cấp thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                ShowData();
                txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = null;
                r = null;
            }
        }
    }
}