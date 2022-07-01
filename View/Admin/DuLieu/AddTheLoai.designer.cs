namespace DoAn.Admin.DuLieu
{
    partial class AddTheLoai
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
            this.btnTheLoaiThoat = new System.Windows.Forms.Button();
            this.btnTheLoaiOK = new System.Windows.Forms.Button();
            this.txtTheLoaiTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTheLoaiMa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnTheLoaiThoat
            // 
            this.btnTheLoaiThoat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnTheLoaiThoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTheLoaiThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoaiThoat.Location = new System.Drawing.Point(251, 93);
            this.btnTheLoaiThoat.Margin = new System.Windows.Forms.Padding(2);
            this.btnTheLoaiThoat.Name = "btnTheLoaiThoat";
            this.btnTheLoaiThoat.Size = new System.Drawing.Size(73, 28);
            this.btnTheLoaiThoat.TabIndex = 15;
            this.btnTheLoaiThoat.Text = "Thoát";
            this.btnTheLoaiThoat.UseVisualStyleBackColor = false;
            this.btnTheLoaiThoat.Click += new System.EventHandler(this.btnTheLoaiThoat_Click);
            // 
            // btnTheLoaiOK
            // 
            this.btnTheLoaiOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.btnTheLoaiOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTheLoaiOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTheLoaiOK.Location = new System.Drawing.Point(66, 93);
            this.btnTheLoaiOK.Margin = new System.Windows.Forms.Padding(2);
            this.btnTheLoaiOK.Name = "btnTheLoaiOK";
            this.btnTheLoaiOK.Size = new System.Drawing.Size(73, 28);
            this.btnTheLoaiOK.TabIndex = 16;
            this.btnTheLoaiOK.Text = "OK";
            this.btnTheLoaiOK.UseVisualStyleBackColor = false;
            this.btnTheLoaiOK.Click += new System.EventHandler(this.btnTheLoaiOK_Click);
            // 
            // txtTheLoaiTen
            // 
            this.txtTheLoaiTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheLoaiTen.Location = new System.Drawing.Point(226, 43);
            this.txtTheLoaiTen.Margin = new System.Windows.Forms.Padding(2);
            this.txtTheLoaiTen.Name = "txtTheLoaiTen";
            this.txtTheLoaiTen.Size = new System.Drawing.Size(126, 23);
            this.txtTheLoaiTen.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(224, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên thể loại:";
            // 
            // txtTheLoaiMa
            // 
            this.txtTheLoaiMa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTheLoaiMa.Location = new System.Drawing.Point(40, 43);
            this.txtTheLoaiMa.Margin = new System.Windows.Forms.Padding(2);
            this.txtTheLoaiMa.Name = "txtTheLoaiMa";
            this.txtTheLoaiMa.Size = new System.Drawing.Size(126, 23);
            this.txtTheLoaiMa.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mã thể loại:";
            // 
            // AddTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(239)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(441, 161);
            this.Controls.Add(this.btnTheLoaiThoat);
            this.Controls.Add(this.btnTheLoaiOK);
            this.Controls.Add(this.txtTheLoaiTen);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTheLoaiMa);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AddTheLoai";
            this.Text = "Chi Tiết Thể Loại";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTheLoaiThoat;
        private System.Windows.Forms.Button btnTheLoaiOK;
        private System.Windows.Forms.TextBox txtTheLoaiTen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTheLoaiMa;
        private System.Windows.Forms.Label label1;
    }
}