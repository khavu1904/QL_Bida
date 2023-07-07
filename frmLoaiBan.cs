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
    public partial class frmLoaiBan : Form
    {
        public frmLoaiBan(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }


        private BIDA_DatabaseDataContext db;

        private string nhanvien;//k thuc hien phep gan ngoai ham dc
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            db = new BIDA_DatabaseDataContext();
            ShowData();

            //tùy chỉnh lại thuộc tính hiển thị của datagridview
            dgvLoaiBan.Columns["ID"].HeaderText = "Mã loại";
            dgvLoaiBan.Columns["TenLoaiBan"].HeaderText = "Tên loại phòng";
            dgvLoaiBan.Columns["DonGia"].HeaderText = "Đơn giá";

            //căn chỉnh
            dgvLoaiBan.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//căn giữa
            dgvLoaiBan.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//căn phải

            //bề rộng cột
            dgvLoaiBan.Columns["ID"].Width = 100;
            dgvLoaiBan.Columns["DonGia"].Width = 150;
            dgvLoaiBan.Columns["TenLoaiBan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//tự động co giãn theo bề rộng form

            //định dạng phần nghìn cho cột đơn giá
            dgvLoaiBan.Columns["DonGia"].DefaultCellStyle.Format = "N0";


        }

        private void ShowData()
        {
            var rs = from l in db.LoaiBans.Where(x => x.isDeleted == 0)
                     select new
                     {
                         l.ID,
                         l.TenLoaiBan,
                         l.DonGia
                     };
            dgvLoaiBan.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiBan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại bàn", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiBan.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Select();
                return;
            }

            LoaiBan l = new LoaiBan();//khai báo 1 đối tượng mới thuộc class LoaiPhong
            l.TenLoaiBan = txtTenLoaiBan.Text;//gán tên loại
            l.DonGia = int.Parse(txtDonGia.Text);//gán đơn giá kiểu in nên cần parse
            l.NgayTao = DateTime.Now;//ngày giờ thêm mới
            l.NguoiTao = nhanvien;//người thêm mới
            l.isDeleted = 0;
            db.LoaiBans.InsertOnSubmit(l);//thêm vào csdl
            db.SubmitChanges();//lưu
            MessageBox.Show("Thêm mới loại bàn thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();//hiển thị danh sách loại phòng sau khi thêm mới thành công

            //reset lại giá trị mặc định cho các component
            txtDonGia.Text = "0";
            txtTenLoaiBan.Text = null;
        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ được nhập số tự nhiên
            {
                e.Handled = true;
            }
        }

        #region
        //để cập nhật và xóa được loại phòng, ta cần xác định được loại phòng cần cập nhật hoặc xóa
        //bằng việc click vào 1 dòng nào đó trên datagridview, chúng ta xác định được 1 dòng dữ liệu
        //1 dòng dữ liệu tương ứng sẽ có 3 thành phần: id,tenloaiphong và dongia
        //để lấy được dòng click, chúng ta sử dụng sự kiện cellclicked trên datagridview dgvLoaiPhong
        #endregion
        private DataGridViewRow r;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn loại bàn muốn cập nhật", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//khi gặp lệnh này thì chương trình sẽ không thực hiện các lệnh tiếp theo
            }

            //trường hợp r!=null tức là có 1 hàng nào đó trên datagridview dgvLoaiPhong được chọn
            //cần xác định được loại phòng nào trong csdl cần được cập nhật
            //việc này hoàn toàn được xác định dựa vào khóa chính của loại phòng 
            //vì id mỗi phòng là khóa chính - chỉ tồn tại duy nhất nên ứng với mỗi id chỉ xác định được 1 và duy nhất 1 loại phòng
            var l = db.LoaiBans.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            l.TenLoaiBan = txtTenLoaiBan.Text;
            l.DonGia = int.Parse(txtDonGia.Text);

            l.NgayCapNhat = DateTime.Now;
            l.NguoiCapNhat = nhanvien;

            db.SubmitChanges();

            MessageBox.Show("Cập nhật loại bàn thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();//hiển thị danh sách loại phòng sau khi thêm mới thành công

            //reset lại giá trị mặc định cho các component
            txtDonGia.Text = "0";
            txtTenLoaiBan.Text = null;
            r = null; // không còn hàng nào được chọn

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //tương tự như update, khi xóa loại phòng chúng ta cũng dựa vào id của loại phòng được click trên datagridview
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn loại bàn muốn xóa", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//khi gặp lệnh này thì chương trình sẽ không thực hiện các lệnh tiếp theo
            }

            if (
                    MessageBox.Show("Bạn thực sự muốn xóa loại bàn: "+r.Cells["TenLoaiBan"].Value.ToString()+" ?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var l = db.LoaiBans.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    l.isDeleted = 1;
                    db.SubmitChanges();

                    MessageBox.Show("Xóa loại bàn thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();//hiển thị danh sách loại phòng sau khi thêm mới thành công

                    //reset lại giá trị mặc định cho các component
                    txtDonGia.Text = "0";
                    txtTenLoaiBan.Text = null;
                    r = null; // không còn hàng nào được chọn

                }
                catch
                {
                    //vì phòng và loại phòng được liên kết bằng khóa ngoại
                    //trong trường hợp đã có phòng tham chiếu tới mã loại đang xóa thì sẽ không xóa được (quan hệ 1-n update/delete)
                    //vì vậy sẽ phát sinh trường hợp catch này
                    MessageBox.Show("Xóa loại bàn thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvLoaiBan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvLoaiBan.Rows[e.RowIndex];
                txtTenLoaiBan.Text = r.Cells["TenLoaiBan"].Value.ToString();
                txtDonGia.Text = r.Cells["DonGia"].Value.ToString();
            }
        }
    }
}
