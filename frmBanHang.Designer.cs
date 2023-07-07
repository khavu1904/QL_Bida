namespace QUANLIBIDA
{
    partial class frmBanHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanHang));
            this.pnlControl = new System.Windows.Forms.Panel();
            this.dgvDanhSachMatHang = new System.Windows.Forms.DataGridView();
            this.lblBanDangChon = new System.Windows.Forms.Label();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.dgvChiTietBanHang = new System.Windows.Forms.DataGridView();
            this.pnlThoiGian = new System.Windows.Forms.Panel();
            this.mtbKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.mtbBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbcBanHang = new System.Windows.Forms.TabControl();
            this.tpBanHang = new System.Windows.Forms.TabPage();
            this.tbcContent = new System.Windows.Forms.TabControl();
            this.tpLSGD = new System.Windows.Forms.TabPage();
            this.dgvLSGD = new System.Windows.Forms.DataGridView();
            this.pdHoaDon = new System.Drawing.Printing.PrintDocument();
            this.pddHoaDon = new System.Windows.Forms.PrintPreviewDialog();
            this.pddHoaDon1 = new System.Windows.Forms.PrintDialog();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).BeginInit();
            this.panelOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).BeginInit();
            this.pnlThoiGian.SuspendLayout();
            this.tbcBanHang.SuspendLayout();
            this.tpBanHang.SuspendLayout();
            this.tpLSGD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.dgvDanhSachMatHang);
            this.pnlControl.Controls.Add(this.lblBanDangChon);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(784, 0);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(424, 505);
            this.pnlControl.TabIndex = 1;
            // 
            // dgvDanhSachMatHang
            // 
            this.dgvDanhSachMatHang.AllowUserToAddRows = false;
            this.dgvDanhSachMatHang.AllowUserToDeleteRows = false;
            this.dgvDanhSachMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachMatHang.Location = new System.Drawing.Point(4, 62);
            this.dgvDanhSachMatHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDanhSachMatHang.MultiSelect = false;
            this.dgvDanhSachMatHang.Name = "dgvDanhSachMatHang";
            this.dgvDanhSachMatHang.ReadOnly = true;
            this.dgvDanhSachMatHang.RowHeadersWidth = 51;
            this.dgvDanhSachMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachMatHang.Size = new System.Drawing.Size(416, 435);
            this.dgvDanhSachMatHang.TabIndex = 1;
            this.dgvDanhSachMatHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachMatHang_CellContentClick);
            this.dgvDanhSachMatHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDanhSachMatHang_CellDoubleClick);
            // 
            // lblBanDangChon
            // 
            this.lblBanDangChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBanDangChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanDangChon.ForeColor = System.Drawing.Color.PeachPuff;
            this.lblBanDangChon.Location = new System.Drawing.Point(4, 5);
            this.lblBanDangChon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanDangChon.Name = "lblBanDangChon";
            this.lblBanDangChon.Size = new System.Drawing.Size(416, 47);
            this.lblBanDangChon.TabIndex = 3;
            this.lblBanDangChon.Text = ".";
            this.lblBanDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.dgvChiTietBanHang);
            this.panelOrder.Controls.Add(this.pnlThoiGian);
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrder.Location = new System.Drawing.Point(0, 333);
            this.panelOrder.Margin = new System.Windows.Forms.Padding(4);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(784, 172);
            this.panelOrder.TabIndex = 2;
            // 
            // dgvChiTietBanHang
            // 
            this.dgvChiTietBanHang.AllowUserToAddRows = false;
            this.dgvChiTietBanHang.AllowUserToDeleteRows = false;
            this.dgvChiTietBanHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietBanHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietBanHang.Location = new System.Drawing.Point(284, 4);
            this.dgvChiTietBanHang.Margin = new System.Windows.Forms.Padding(4);
            this.dgvChiTietBanHang.MultiSelect = false;
            this.dgvChiTietBanHang.Name = "dgvChiTietBanHang";
            this.dgvChiTietBanHang.ReadOnly = true;
            this.dgvChiTietBanHang.RowHeadersWidth = 51;
            this.dgvChiTietBanHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietBanHang.Size = new System.Drawing.Size(500, 169);
            this.dgvChiTietBanHang.TabIndex = 4;
            this.dgvChiTietBanHang.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvChiTietBanHang_CellContentClick);
            // 
            // pnlThoiGian
            // 
            this.pnlThoiGian.Controls.Add(this.mtbKetThuc);
            this.pnlThoiGian.Controls.Add(this.label4);
            this.pnlThoiGian.Controls.Add(this.btnBatDau);
            this.pnlThoiGian.Controls.Add(this.btnKetThuc);
            this.pnlThoiGian.Controls.Add(this.mtbBatDau);
            this.pnlThoiGian.Controls.Add(this.label3);
            this.pnlThoiGian.Location = new System.Drawing.Point(9, 4);
            this.pnlThoiGian.Margin = new System.Windows.Forms.Padding(4);
            this.pnlThoiGian.Name = "pnlThoiGian";
            this.pnlThoiGian.Size = new System.Drawing.Size(267, 164);
            this.pnlThoiGian.TabIndex = 2;
            // 
            // mtbKetThuc
            // 
            this.mtbKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbKetThuc.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbKetThuc.Location = new System.Drawing.Point(92, 50);
            this.mtbKetThuc.Margin = new System.Windows.Forms.Padding(4);
            this.mtbKetThuc.Mask = "00/00/0000 90:00";
            this.mtbKetThuc.Name = "mtbKetThuc";
            this.mtbKetThuc.Size = new System.Drawing.Size(149, 23);
            this.mtbKetThuc.TabIndex = 4;
            this.mtbKetThuc.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(4, 52);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 3;
            this.label4.Text = "Kết thúc";
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.CadetBlue;
            this.btnBatDau.Enabled = false;
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(21, 81);
            this.btnBatDau.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(107, 38);
            this.btnBatDau.TabIndex = 2;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.BtnBatDau_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.BackColor = System.Drawing.Color.CadetBlue;
            this.btnKetThuc.Enabled = false;
            this.btnKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKetThuc.ForeColor = System.Drawing.Color.White;
            this.btnKetThuc.Location = new System.Drawing.Point(136, 82);
            this.btnKetThuc.Margin = new System.Windows.Forms.Padding(4);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(107, 38);
            this.btnKetThuc.TabIndex = 2;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = false;
            this.btnKetThuc.Click += new System.EventHandler(this.BtnKetThuc_Click);
            // 
            // mtbBatDau
            // 
            this.mtbBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbBatDau.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbBatDau.Location = new System.Drawing.Point(92, 18);
            this.mtbBatDau.Margin = new System.Windows.Forms.Padding(4);
            this.mtbBatDau.Mask = "00/00/0000 90:00";
            this.mtbBatDau.Name = "mtbBatDau";
            this.mtbBatDau.Size = new System.Drawing.Size(149, 23);
            this.mtbBatDau.TabIndex = 1;
            this.mtbBatDau.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(4, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bắt đầu:";
            // 
            // tbcBanHang
            // 
            this.tbcBanHang.Controls.Add(this.tpBanHang);
            this.tbcBanHang.Controls.Add(this.tpLSGD);
            this.tbcBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcBanHang.Location = new System.Drawing.Point(0, 0);
            this.tbcBanHang.Margin = new System.Windows.Forms.Padding(4);
            this.tbcBanHang.Name = "tbcBanHang";
            this.tbcBanHang.SelectedIndex = 0;
            this.tbcBanHang.Size = new System.Drawing.Size(784, 333);
            this.tbcBanHang.TabIndex = 3;
            // 
            // tpBanHang
            // 
            this.tpBanHang.Controls.Add(this.tbcContent);
            this.tpBanHang.Location = new System.Drawing.Point(4, 25);
            this.tpBanHang.Margin = new System.Windows.Forms.Padding(4);
            this.tpBanHang.Name = "tpBanHang";
            this.tpBanHang.Padding = new System.Windows.Forms.Padding(4);
            this.tpBanHang.Size = new System.Drawing.Size(776, 304);
            this.tpBanHang.TabIndex = 0;
            this.tpBanHang.Text = "Bán hàng";
            this.tpBanHang.UseVisualStyleBackColor = true;
            // 
            // tbcContent
            // 
            this.tbcContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcContent.Location = new System.Drawing.Point(4, 4);
            this.tbcContent.Margin = new System.Windows.Forms.Padding(4);
            this.tbcContent.Name = "tbcContent";
            this.tbcContent.SelectedIndex = 0;
            this.tbcContent.Size = new System.Drawing.Size(768, 296);
            this.tbcContent.TabIndex = 1;
            this.tbcContent.SelectedIndexChanged += new System.EventHandler(this.tbcContent_SelectedIndexChanged);
            // 
            // tpLSGD
            // 
            this.tpLSGD.Controls.Add(this.dgvLSGD);
            this.tpLSGD.Location = new System.Drawing.Point(4, 25);
            this.tpLSGD.Margin = new System.Windows.Forms.Padding(4);
            this.tpLSGD.Name = "tpLSGD";
            this.tpLSGD.Padding = new System.Windows.Forms.Padding(4);
            this.tpLSGD.Size = new System.Drawing.Size(776, 304);
            this.tpLSGD.TabIndex = 1;
            this.tpLSGD.Text = "Lịch sử giao dịch";
            this.tpLSGD.UseVisualStyleBackColor = true;
            // 
            // dgvLSGD
            // 
            this.dgvLSGD.AllowUserToAddRows = false;
            this.dgvLSGD.AllowUserToDeleteRows = false;
            this.dgvLSGD.BackgroundColor = System.Drawing.Color.White;
            this.dgvLSGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLSGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLSGD.Location = new System.Drawing.Point(4, 4);
            this.dgvLSGD.Margin = new System.Windows.Forms.Padding(4);
            this.dgvLSGD.Name = "dgvLSGD";
            this.dgvLSGD.ReadOnly = true;
            this.dgvLSGD.RowHeadersWidth = 51;
            this.dgvLSGD.Size = new System.Drawing.Size(768, 296);
            this.dgvLSGD.TabIndex = 0;
            this.dgvLSGD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvLSGD_CellDoubleClick);
            // 
            // pdHoaDon
            // 
            this.pdHoaDon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PdHoaDon_PrintPage);
            // 
            // pddHoaDon
            // 
            this.pddHoaDon.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pddHoaDon.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pddHoaDon.ClientSize = new System.Drawing.Size(400, 300);
            this.pddHoaDon.Enabled = true;
            this.pddHoaDon.Icon = ((System.Drawing.Icon)(resources.GetObject("pddHoaDon.Icon")));
            this.pddHoaDon.Name = "pddHoaDon";
            this.pddHoaDon.Visible = false;
            // 
            // pddHoaDon1
            // 
            this.pddHoaDon1.UseEXDialog = true;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1208, 505);
            this.Controls.Add(this.tbcBanHang);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.pnlControl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBanHang";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).EndInit();
            this.panelOrder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).EndInit();
            this.pnlThoiGian.ResumeLayout(false);
            this.pnlThoiGian.PerformLayout();
            this.tbcBanHang.ResumeLayout(false);
            this.tpBanHang.ResumeLayout(false);
            this.tpLSGD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.DataGridView dgvDanhSachMatHang;
        private System.Windows.Forms.Panel pnlThoiGian;
        private System.Windows.Forms.MaskedTextBox mtbBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbKetThuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Label lblBanDangChon;
        private System.Windows.Forms.DataGridView dgvChiTietBanHang;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.TabControl tbcBanHang;
        private System.Windows.Forms.TabPage tpBanHang;
        private System.Windows.Forms.TabControl tbcContent;
        private System.Windows.Forms.TabPage tpLSGD;
        private System.Windows.Forms.DataGridView dgvLSGD;
        private System.Drawing.Printing.PrintDocument pdHoaDon;
        private System.Windows.Forms.PrintPreviewDialog pddHoaDon;
        private System.Windows.Forms.PrintDialog pddHoaDon1;
    }
}