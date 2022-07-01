namespace pbl3.Admin.ThongTinTaiKhoan
{
    partial class ThongTinTaiKhoan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLoaiTK = new System.Windows.Forms.TextBox();
            this.txtThongTinTKTenNV = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboThongTinTKMaNV = new System.Windows.Forms.ComboBox();
            this.txtThongTinTKUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResetMK = new System.Windows.Forms.Button();
            this.btnThongTinTKXem = new System.Windows.Forms.Button();
            this.btnThongTinTKThem = new System.Windows.Forms.Button();
            this.btnThongTinTKSua = new System.Windows.Forms.Button();
            this.btnThongTinTKXoa = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTimKiemTheoUserName = new System.Windows.Forms.TextBox();
            this.dgvListThongTinTK = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListThongTinTK)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLoaiTK);
            this.groupBox1.Controls.Add(this.txtThongTinTKTenNV);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboThongTinTKMaNV);
            this.groupBox1.Controls.Add(this.txtThongTinTKUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(458, 106);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // txtLoaiTK
            // 
            this.txtLoaiTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoaiTK.Location = new System.Drawing.Point(302, 32);
            this.txtLoaiTK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLoaiTK.Name = "txtLoaiTK";
            this.txtLoaiTK.Size = new System.Drawing.Size(145, 23);
            this.txtLoaiTK.TabIndex = 8;
            // 
            // txtThongTinTKTenNV
            // 
            this.txtThongTinTKTenNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTinTKTenNV.Location = new System.Drawing.Point(302, 62);
            this.txtThongTinTKTenNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtThongTinTKTenNV.Name = "txtThongTinTKTenNV";
            this.txtThongTinTKTenNV.Size = new System.Drawing.Size(145, 23);
            this.txtThongTinTKTenNV.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(231, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Tên NV:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(229, 32);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Loại TK:";
            // 
            // cboThongTinTKMaNV
            // 
            this.cboThongTinTKMaNV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboThongTinTKMaNV.FormattingEnabled = true;
            this.cboThongTinTKMaNV.Location = new System.Drawing.Point(93, 61);
            this.cboThongTinTKMaNV.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cboThongTinTKMaNV.Name = "cboThongTinTKMaNV";
            this.cboThongTinTKMaNV.Size = new System.Drawing.Size(121, 25);
            this.cboThongTinTKMaNV.TabIndex = 3;
            this.cboThongTinTKMaNV.SelectedIndexChanged += new System.EventHandler(this.cboThongTinTKMaNV_SelectedIndexChanged);
            // 
            // txtThongTinTKUserName
            // 
            this.txtThongTinTKUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtThongTinTKUserName.Location = new System.Drawing.Point(93, 30);
            this.txtThongTinTKUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtThongTinTKUserName.Name = "txtThongTinTKUserName";
            this.txtThongTinTKUserName.Size = new System.Drawing.Size(121, 23);
            this.txtThongTinTKUserName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã NV:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "User name:";
            // 
            // btnResetMK
            // 
            this.btnResetMK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnResetMK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetMK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetMK.Location = new System.Drawing.Point(489, 32);
            this.btnResetMK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnResetMK.Name = "btnResetMK";
            this.btnResetMK.Size = new System.Drawing.Size(140, 50);
            this.btnResetMK.TabIndex = 1;
            this.btnResetMK.Text = "Reset mật khẩu";
            this.btnResetMK.UseVisualStyleBackColor = false;
            this.btnResetMK.Click += new System.EventHandler(this.btnResetMK_Click);
            // 
            // btnThongTinTKXem
            // 
            this.btnThongTinTKXem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnThongTinTKXem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongTinTKXem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinTKXem.Location = new System.Drawing.Point(11, 131);
            this.btnThongTinTKXem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongTinTKXem.Name = "btnThongTinTKXem";
            this.btnThongTinTKXem.Size = new System.Drawing.Size(69, 34);
            this.btnThongTinTKXem.TabIndex = 2;
            this.btnThongTinTKXem.Text = "Xem";
            this.btnThongTinTKXem.UseVisualStyleBackColor = false;
            this.btnThongTinTKXem.Click += new System.EventHandler(this.btnThongTinTKXem_Click);
            // 
            // btnThongTinTKThem
            // 
            this.btnThongTinTKThem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnThongTinTKThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongTinTKThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinTKThem.Location = new System.Drawing.Point(102, 131);
            this.btnThongTinTKThem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongTinTKThem.Name = "btnThongTinTKThem";
            this.btnThongTinTKThem.Size = new System.Drawing.Size(69, 34);
            this.btnThongTinTKThem.TabIndex = 3;
            this.btnThongTinTKThem.Text = "Thêm";
            this.btnThongTinTKThem.UseVisualStyleBackColor = false;
            this.btnThongTinTKThem.Click += new System.EventHandler(this.btnThongTinTKThem_Click);
            // 
            // btnThongTinTKSua
            // 
            this.btnThongTinTKSua.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnThongTinTKSua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongTinTKSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinTKSua.Location = new System.Drawing.Point(197, 131);
            this.btnThongTinTKSua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongTinTKSua.Name = "btnThongTinTKSua";
            this.btnThongTinTKSua.Size = new System.Drawing.Size(69, 34);
            this.btnThongTinTKSua.TabIndex = 4;
            this.btnThongTinTKSua.Text = "Sửa";
            this.btnThongTinTKSua.UseVisualStyleBackColor = false;
            this.btnThongTinTKSua.Click += new System.EventHandler(this.btnThongTinTKSua_Click);
            // 
            // btnThongTinTKXoa
            // 
            this.btnThongTinTKXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnThongTinTKXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThongTinTKXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThongTinTKXoa.Location = new System.Drawing.Point(285, 131);
            this.btnThongTinTKXoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnThongTinTKXoa.Name = "btnThongTinTKXoa";
            this.btnThongTinTKXoa.Size = new System.Drawing.Size(69, 34);
            this.btnThongTinTKXoa.TabIndex = 5;
            this.btnThongTinTKXoa.Text = "Xóa";
            this.btnThongTinTKXoa.UseVisualStyleBackColor = false;
            this.btnThongTinTKXoa.Click += new System.EventHandler(this.btnThongTinTKXoa_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTimKiemTheoUserName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(381, 115);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(183, 66);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tìm theo tên";
            // 
            // txtTimKiemTheoUserName
            // 
            this.txtTimKiemTheoUserName.Location = new System.Drawing.Point(5, 22);
            this.txtTimKiemTheoUserName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTimKiemTheoUserName.Name = "txtTimKiemTheoUserName";
            this.txtTimKiemTheoUserName.Size = new System.Drawing.Size(174, 23);
            this.txtTimKiemTheoUserName.TabIndex = 0;
            // 
            // dgvListThongTinTK
            // 
            this.dgvListThongTinTK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListThongTinTK.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.dgvListThongTinTK.ColumnHeadersHeight = 29;
            this.dgvListThongTinTK.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvListThongTinTK.Location = new System.Drawing.Point(0, 196);
            this.dgvListThongTinTK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvListThongTinTK.Name = "dgvListThongTinTK";
            this.dgvListThongTinTK.RowHeadersWidth = 51;
            this.dgvListThongTinTK.Size = new System.Drawing.Size(1083, 413);
            this.dgvListThongTinTK.TabIndex = 0;
            this.dgvListThongTinTK.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListThongTinTK_RowHeaderMouseClick);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(586, 130);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 34);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // ThongTinTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.dgvListThongTinTK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnThongTinTKXoa);
            this.Controls.Add(this.btnThongTinTKSua);
            this.Controls.Add(this.btnThongTinTKThem);
            this.Controls.Add(this.btnThongTinTKXem);
            this.Controls.Add(this.btnResetMK);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ThongTinTaiKhoan";
            this.Size = new System.Drawing.Size(1083, 609);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListThongTinTK)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboThongTinTKMaNV;
        private System.Windows.Forms.TextBox txtThongTinTKUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThongTinTKTenNV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnResetMK;
        private System.Windows.Forms.Button btnThongTinTKXem;
        private System.Windows.Forms.Button btnThongTinTKThem;
        private System.Windows.Forms.Button btnThongTinTKSua;
        private System.Windows.Forms.Button btnThongTinTKXoa;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTimKiemTheoUserName;
        private System.Windows.Forms.DataGridView dgvListThongTinTK;
        private System.Windows.Forms.TextBox txtLoaiTK;
        private System.Windows.Forms.Button btnSearch;
    }
}
