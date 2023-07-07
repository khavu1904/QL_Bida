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
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau(NhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
        }
        private NhanVien nv;
        private BIDA_DatabaseDataContext db;
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            db = new BIDA_DatabaseDataContext();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click_1(object sender, EventArgs e)
        {
            #region rang_buoc
            if (string.IsNullOrEmpty(txtMatKhauHienTai.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại", "Chú ý!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauHienTai.Select();
                return;//không thực hiện các câu lệnh phía dưới
            }
            if (string.IsNullOrEmpty(txtMatKhauMoi.Text) || string.IsNullOrEmpty(txtXacNhanMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Chú ý!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Select();
                return;//không thực hiện các câu lệnh phía dưới
            }
            if (!txtMatKhauMoi.Text.Equals(txtXacNhanMatKhauMoi.Text))
            {
                MessageBox.Show("Mật khẩu mới và xác nhận không khớp", "Chú ý!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Select();
                return;//không thực hiện các câu lệnh phía dưới
            }
            #endregion

            var tk = db.NhanViens.SingleOrDefault(x => x.UserName == nv.UserName && x.PassWord == txtMatKhauHienTai.Text);
            if (tk == null)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Chú ý!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauHienTai.Select();
                return;//không thực hiện các câu lệnh phía dưới
            }
            //vì mật khẩu mới và xác nhận mật khẩu giống nhau
            //nên có thể chọn txtMatKhauMoi hoặc txtXacNhanMatKhauMoi đều đc
            tk.PassWord = txtMatKhauMoi.Text;
            tk.NguoiCapNhat = nv.UserName;
            tk.NgayCapNhat = DateTime.Now;
            db.SubmitChanges();//xác nhận lưu database
            MessageBox.Show("Đổi mật khẩu thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }
    }
}
