namespace pbl3
{
    partial class DuLieu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLichChieu = new System.Windows.Forms.Button();
            this.btnDinhDang = new System.Windows.Forms.Button();
            this.btnPhim = new System.Windows.Forms.Button();
            this.btnTheLoai = new System.Windows.Forms.Button();
            this.btnPhongChieu = new System.Windows.Forms.Button();
            this.btnLoaiManHinh = new System.Windows.Forms.Button();
            this.pbDuLieu = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(212)))), ((int)(((byte)(228)))));
            this.panel1.Controls.Add(this.btnLichChieu);
            this.panel1.Controls.Add(this.btnDinhDang);
            this.panel1.Controls.Add(this.btnPhim);
            this.panel1.Controls.Add(this.btnTheLoai);
            this.panel1.Controls.Add(this.btnPhongChieu);
            this.panel1.Controls.Add(this.btnLoaiManHinh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(809, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnLichChieu
            // 
            this.btnLichChieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnLichChieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLichChieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLichChieu.Location = new System.Drawing.Point(645, 10);
            this.btnLichChieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnLichChieu.Name = "btnLichChieu";
            this.btnLichChieu.Size = new System.Drawing.Size(124, 31);
            this.btnLichChieu.TabIndex = 0;
            this.btnLichChieu.Text = "Lịch Chiếu";
            this.btnLichChieu.UseVisualStyleBackColor = false;
            this.btnLichChieu.Click += new System.EventHandler(this.btnLichChieu_Click);
            this.btnLichChieu.MouseLeave += new System.EventHandler(this.btnLichChieu_MouseLeave);
            this.btnLichChieu.MouseHover += new System.EventHandler(this.btnLichChieu_MouseHover);
            // 
            // btnDinhDang
            // 
            this.btnDinhDang.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnDinhDang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDinhDang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDinhDang.Location = new System.Drawing.Point(517, 10);
            this.btnDinhDang.Margin = new System.Windows.Forms.Padding(2);
            this.btnDinhDang.Name = "btnDinhDang";
            this.btnDinhDang.Size = new System.Drawing.Size(124, 31);
            this.btnDinhDang.TabIndex = 0;
            this.btnDinhDang.Text = "Phân loại Phim và Màn hình";
            this.btnDinhDang.UseVisualStyleBackColor = false;
            this.btnDinhDang.Click += new System.EventHandler(this.btnDinhDang_Click);
            this.btnDinhDang.MouseLeave += new System.EventHandler(this.btnDinhDang_MouseLeave);
            this.btnDinhDang.MouseHover += new System.EventHandler(this.btnDinhDang_MouseHover);
            // 
            // btnPhim
            // 
            this.btnPhim.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnPhim.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhim.Location = new System.Drawing.Point(389, 10);
            this.btnPhim.Margin = new System.Windows.Forms.Padding(2);
            this.btnPhim.Name = "btnPhim";
            this.btnPhim.Size = new System.Drawing.Size(124, 31);
            this.btnPhim.TabIndex = 0;
            this.btnPhim.Text = "Phim";
            this.btnPhim.UseVisualStyleBackColor = false;
            this.btnPhim.Click += new System.EventHandler(this.btnPhim_Click);
            this.btnPhim.MouseLeave += new System.EventHandler(this.btnPhim_MouseLeave);
            this.btnPhim.MouseHover += new System.EventHandler(this.btnPhim_MouseHover);
            // 
            // btnTheLoai
            // 
            this.btnTheLoai.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnTheLoai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoai.Location = new System.Drawing.Point(261, 10);
            this.btnTheLoai.Margin = new System.Windows.Forms.Padding(2);
            this.btnTheLoai.Name = "btnTheLoai";
            this.btnTheLoai.Size = new System.Drawing.Size(124, 31);
            this.btnTheLoai.TabIndex = 0;
            this.btnTheLoai.Text = "Thể Loại";
            this.btnTheLoai.UseVisualStyleBackColor = false;
            this.btnTheLoai.Click += new System.EventHandler(this.btnTheLoai_Click);
            this.btnTheLoai.MouseLeave += new System.EventHandler(this.btnTheLoai_MouseLeave);
            this.btnTheLoai.MouseHover += new System.EventHandler(this.btnTheLoai_MouseHover);
            // 
            // btnPhongChieu
            // 
            this.btnPhongChieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnPhongChieu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPhongChieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPhongChieu.Location = new System.Drawing.Point(133, 10);
            this.btnPhongChieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnPhongChieu.Name = "btnPhongChieu";
            this.btnPhongChieu.Size = new System.Drawing.Size(124, 31);
            this.btnPhongChieu.TabIndex = 0;
            this.btnPhongChieu.Text = "Phòng Chiếu";
            this.btnPhongChieu.UseVisualStyleBackColor = false;
            this.btnPhongChieu.Click += new System.EventHandler(this.btnPhongChieu_Click);
            this.btnPhongChieu.MouseLeave += new System.EventHandler(this.btnPhongChieu_MouseLeave);
            this.btnPhongChieu.MouseHover += new System.EventHandler(this.btnPhongChieu_MouseHover);
            // 
            // btnLoaiManHinh
            // 
            this.btnLoaiManHinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnLoaiManHinh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoaiManHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoaiManHinh.Location = new System.Drawing.Point(5, 10);
            this.btnLoaiManHinh.Margin = new System.Windows.Forms.Padding(2);
            this.btnLoaiManHinh.Name = "btnLoaiManHinh";
            this.btnLoaiManHinh.Size = new System.Drawing.Size(124, 31);
            this.btnLoaiManHinh.TabIndex = 0;
            this.btnLoaiManHinh.Text = "Loại màn hình";
            this.btnLoaiManHinh.UseVisualStyleBackColor = false;
            this.btnLoaiManHinh.Click += new System.EventHandler(this.btnLoaiManHinh_Click);
            this.btnLoaiManHinh.MouseLeave += new System.EventHandler(this.btnLoaiManHinh_MouseLeave);
            this.btnLoaiManHinh.MouseHover += new System.EventHandler(this.btnLoaiManHinh_MouseHover);
            // 
            // pbDuLieu
            // 
            this.pbDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDuLieu.Location = new System.Drawing.Point(0, 50);
            this.pbDuLieu.Margin = new System.Windows.Forms.Padding(2);
            this.pbDuLieu.Name = "pbDuLieu";
            this.pbDuLieu.Size = new System.Drawing.Size(809, 339);
            this.pbDuLieu.TabIndex = 1;
            // 
            // DuLieu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbDuLieu);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DuLieu";
            this.Size = new System.Drawing.Size(809, 389);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDinhDang;
        private System.Windows.Forms.Button btnPhim;
        private System.Windows.Forms.Button btnTheLoai;
        private System.Windows.Forms.Button btnPhongChieu;
        private System.Windows.Forms.Button btnLoaiManHinh;
        private System.Windows.Forms.Button btnLichChieu;
        private System.Windows.Forms.Panel pbDuLieu;
    }
}
