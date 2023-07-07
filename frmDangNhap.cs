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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public NhanVien nv;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_TaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TaiKhoan.Select();
                return;
            }

            BIDA_DatabaseDataContext db = new BIDA_DatabaseDataContext();
            var tk = db.NhanViens.SingleOrDefault(x => x.UserName == txt_TaiKhoan.Text && x.PassWord == txtMatKhau.Text && x.isDeleted == 0);
            if (tk != null)
            {
                nv = tk;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_TaiKhoan.Select();
                return;
            }
        }
        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
