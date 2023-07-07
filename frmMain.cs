using System;
using QUANLIBIDA.ThongKe;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QUANLIBIDA.db;

namespace QUANLIBIDA
{
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        #region giao_dien

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private Boolean isMaximize = false;
        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptbMaximize_Click(object sender, EventArgs e)
        {
            if (!isMaximize)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                //ptbMaximize.Image = Properties.Resources.res;

            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                //ptbMaximize.Image = Properties.Resources.maxi;
            }
            isMaximize = !isMaximize;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        //khi double click lên paneltop thì gọi tới sự kiện click của picturebox maximize
        private void pnlTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ptbMaximize_Click(null, null);
        }
        #endregion

        private BIDA_DatabaseDataContext db;
        private NhanVien nv;
        private void frmMain_Load(object sender, EventArgs e)
        {
            var f = new frmDangNhap();
            f.ShowDialog();
            nv = f.nv;
            MessageBox.Show("Nhân Viên đăng nhập");

            if (nv != null)
            {
                lblNhanVien.Text = String.Format("Nhân viên: {0}", nv.HoVaTen);

                db = new BIDA_DatabaseDataContext();
                var ten = db.CauHinhs.SingleOrDefault(x => x.TuKhoa == "tencuahang").giatri;
                var diachi = db.CauHinhs.SingleOrDefault(x => x.TuKhoa == "diachi").giatri;
                var phone = db.CauHinhs.SingleOrDefault(x => x.TuKhoa == "phone").giatri;
                lblTitle.Text = String.Format("{0} - {1} - {2} ", ten, diachi, phone);
                if (nv.isAdmin == 0)//nếu k phải là admin
                {
                    //thì ẩn các mục không muốn cho nhân viên thường thao tác
                    nvToolStripMenuItem.Visible = false;
                    BanToolStripMenuItem.Visible = false;
                    nhapHangToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                Application.Exit();
            }

        }


        #region menu_item

        private void loaiBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmLoaiBan(nv.UserName);//khai bao form
            addForm(f);
        }
        private void addForm(Form f)
        {
            f.FormBorderStyle = FormBorderStyle.None;//bo vien form
            f.Dock = DockStyle.Fill;//tu dong co gian 
            f.TopLevel = false;
            f.TopMost = true;
            grbContent.Controls.Clear();//xoa cac item dang co tren groupbox
            grbContent.Controls.Add(f);
            f.Show();
        }

        private void BanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmBan(nv.UserName);
            addForm(f);
        }

        private void matHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new FrmMatHang(nv.UserName);
            addForm(f);
        }

        private void dvtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDonViTinh(nv.UserName);
            addForm(f);
        }

        private void nccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhaCungCap(nv.UserName);
            addForm(f);
        }

        private void nvToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhanVien(nv.UserName);
            addForm(f);
        }

        private void nhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhapHang(nv.UserName);
            addForm(f);
        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmBanHang(nv.UserName);
            addForm(f);
        }
        private void tonKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmTonKho();
            addForm(f);

        }

        private void congNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmCongNo();
            addForm(f);
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDoanhThu();
            addForm(f);
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDoiMatKhau(nv).ShowDialog();
        }

        #endregion

        private void pnlTop_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }
}

