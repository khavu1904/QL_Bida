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
    public partial class frmBan : Form
    {
        public frmBan(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }

        private BIDA_DatabaseDataContext db;
        private string nhanvien;
        private void frmBan_Load(object sender, EventArgs e)
        {
            db = new BIDA_DatabaseDataContext();
            ShowData();//gọi hàm hiển thị danh sách bàn khi form đc load

            //đổ dữ liệu cho combobox cbbLoaiBan
            cbbLoaiBan.DataSource = db.LoaiBans.Where(x => x.isDeleted == 0);
            cbbLoaiBan.DisplayMember = "tenloaiban";//thuộc tính hiển thị: tên loại bàn
            cbbLoaiBan.ValueMember = "id";//thuộc tính giá trị: id - mã của loại bàn
            cbbLoaiBan.SelectedIndex = -1;//mặc định không chọn loại bàn nào cả

            //tùy chỉnh lại thuộc tính hiển thị của các cột trên datagridview dgvBan
            //tương tự các phần trước nên mình không giải thích nữa
            dgvBan.Columns["ID"].HeaderText = "Mã bàn ";
            dgvBan.Columns["TenLoaiBan"].HeaderText = "Loại bàn";
            dgvBan.Columns["TenBan"].HeaderText = "Tên bàn";
            dgvBan.Columns["DonGia"].HeaderText = "Đơn giá";
            dgvBan.Columns["SucChua"].HeaderText = "Sức chứa";

            dgvBan.Columns["ID"].Width = 100;
            dgvBan.Columns["TenLoaiBan"].Width = 200;
            dgvBan.Columns["SucChua"].Width = 100;
            dgvBan.Columns["TenBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvBan.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBan.Columns["SucChua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBan.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvBan.Columns["DonGia"].DefaultCellStyle.Format = "N0";
        }

        private void ShowData()
        {
            //theo thiết kế thì 2 bảng Bàn và loại bàn quan hệ với nhau 1-n
            //dựa vào khóa ngoại [IDLoaiBan]
            //nên để lấy dữ liệu từ 2 bảng này, chúng ta sử dụng join trong linq
            var rs = from p in db.BANs.Where(x => x.isDeleted == 0)//chi lay cac  chua bi xoa & thuoc nhung loai ban chua bi xoa
                     join l in db.LoaiBans.Where(x => x.isDeleted == 0)//chi lay nhung loai ban chua bi xoa
                     on p.IDLoaiBan equals l.ID
                     select new
                     {
                         p.ID,
                         l.TenLoaiBan,
                         p.TenBan,
                         l.DonGia,
                         p.SucChua
                     };
            dgvBan.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            

            var p = new BAN();//khai báo 1 đối tượng mới thuộc class Phong
            try
            {
                if (string.IsNullOrEmpty(txtTenBan.Text))
                {
                    MessageBox.Show("Vui lòng nhập tên bàn", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTenBan.Select();
                    return;
                }
                if (cbbLoaiBan.SelectedIndex < 0)
                {
                    MessageBox.Show("Vui lòng chọn loại bàn", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text)<=0)
                {
                    MessageBox.Show("Sức chứa của bàn phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSucChua.Select();
                    return;
                }

                p.TenBan = txtTenBan.Text;
                p.IDLoaiBan = int.Parse(cbbLoaiBan.SelectedValue.ToString());// vì SelectedValue.ToString() trả về string nên cần convert qua int để cùng kiểu với ban trong csdl
                p.SucChua = int.Parse(txtSucChua.Text);//tương tự như trên

                p.NgayTao = DateTime.Now;
                p.NguoiTao = nhanvien;
                p.isDeleted = 0;
                db.BANs.InsertOnSubmit(p);
                db.SubmitChanges();
            }
            catch (Exception)
            {

                MessageBox.Show(p.TenBan.ToString()+p.LoaiBan.ToString());
            }
            //lỗi vừa nhận được là do id trong bảng bàn chưa được thiết lập tăng tự động
            //sau khi chỉnh sửa lại xong csdl ta cũng cần cập nhật lại datacontext

            MessageBox.Show("Thêm mới bàn thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();//gọi lại hàm hiển thị danh sách bàn

            //thiết lập lại giá trị mặc định cho các component
            txtSucChua.Text = txtTenBan.Text = null;
            cbbLoaiBan.SelectedIndex = -1;

            txtTenBan.Select();//focus lại textbox tên bàn sau khi thêm xong -> thuận tiện hơn trong trường hợp muốn thêm tiếp, đỡ click chuột
        }

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ được nhập số tự nhiên
            {
                e.Handled = true;
            }
        }

        #region
        //phần cập nhật và phần xóa bàn tương tự như bên loại bàn
        //nên mình sẽ không giải thích nhiều
        //các bạn nếu không hiểu thì xem lại đoạn loại bàn nhé
        #endregion
        private DataGridViewRow r;
        private void dgvBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvBan.Rows[e.RowIndex];
                txtTenBan.Text = r.Cells["TenBan"].Value.ToString();
                txtSucChua.Text = r.Cells["SucChua"].Value.ToString();
                cbbLoaiBan.Text = r.Cells["TenLoaiBan"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenBan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên bàn", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenBan.Select();
                return;
            }
            if (cbbLoaiBan.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại bàn", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text) <= 0)
            {
                MessageBox.Show("Sức chứa của bàn phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSucChua.Select();
                return;
            }
            var p = db.BANs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            p.TenBan = txtTenBan.Text;
            p.IDLoaiBan = int.Parse(cbbLoaiBan.SelectedValue.ToString());// vì SelectedValue.ToString() trả về string nên cần convert qua int để cùng kiểu với idloaiban trong csdl
            p.SucChua = int.Parse(txtSucChua.Text);//tương tự như trên

            p.NgayCapNhat = DateTime.Now;
            p.NguoiCapNhat = nhanvien;
            db.SubmitChanges();
            MessageBox.Show("Cập nhật bàn thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();//gọi lại hàm hiển thị danh sách bàn

            //thiết lập lại giá trị mặc định cho các component
            txtSucChua.Text = txtTenBan.Text = null;
            cbbLoaiBan.SelectedIndex = -1;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //tương tự như update, khi xóa loại bàn chúng ta cũng dựa vào id của loại bàn được click trên datagridview
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn bàn muốn xóa", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//khi gặp lệnh này thì chương trình sẽ không thực hiện các lệnh tiếp theo
            }

            if (
                    MessageBox.Show("Bạn thực sự muốn xóa bàn: " + r.Cells["TenBan"].Value.ToString() + " ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var p = db.BANs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    p.isDeleted = 1;//1 = da delete <=> soft delete
                    db.SubmitChanges();

                    MessageBox.Show("Xóa bàn thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();//hiển thị danh sách loại bàn sau khi thêm mới thành công

                    //reset lại giá trị mặc định cho các component
                    txtSucChua.Text = "0";
                    txtTenBan.Text = null;
                    cbbLoaiBan.SelectedIndex = -1;
                    r = null; // không còn hàng nào được chọn

                }
                catch
                {
                    //vì bàn và loại bàn được liên kết bằng khóa ngoại
                    //trong trường hợp đã có bàn tham chiếu tới mã loại đang xóa thì sẽ không xóa được (quan hệ 1-n update/delete)
                    //vì vậy sẽ phát sinh trường hợp catch này
                    MessageBox.Show("Xóa loại bàn thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
