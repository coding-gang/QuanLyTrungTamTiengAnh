namespace UI
{
    partial class frmHome
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
            this.mnuHome = new System.Windows.Forms.MenuStrip();
            this.mnuHethong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuantri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanly = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongke = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBaocao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHotro = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblName = new Krypton.Toolkit.KryptonLabel();
            this.btnKhoahoc = new FontAwesome.Sharp.IconButton();
            this.btnDangky = new FontAwesome.Sharp.IconButton();
            this.btnHocvien = new FontAwesome.Sharp.IconButton();
            this.kryptonStatusStrip1 = new Krypton.Toolkit.KryptonStatusStrip();
            this.tlbLabelTendangnhap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbTendangnhap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbLabelChinhanh = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbChinhanh = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbLabelNhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.tlbNhom = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tc1 = new System.Windows.Forms.TabControl();
            this.tpHocvien = new System.Windows.Forms.TabPage();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tpDangky = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tpKhoahoc = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.panel9 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.mnuHome.SuspendLayout();
            this.panel1.SuspendLayout();
            this.kryptonStatusStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tc1.SuspendLayout();
            this.tpHocvien.SuspendLayout();
            this.tpDangky.SuspendLayout();
            this.tpKhoahoc.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuHome
            // 
            this.mnuHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.mnuHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHethong,
            this.mnuQuantri,
            this.mnuQuanly,
            this.mnuThongke,
            this.mnuBaocao,
            this.mnuHotro});
            this.mnuHome.Location = new System.Drawing.Point(0, 0);
            this.mnuHome.Name = "mnuHome";
            this.mnuHome.Size = new System.Drawing.Size(800, 24);
            this.mnuHome.TabIndex = 0;
            this.mnuHome.Text = "menuStripHome";
            // 
            // mnuHethong
            // 
            this.mnuHethong.Name = "mnuHethong";
            this.mnuHethong.Size = new System.Drawing.Size(69, 20);
            this.mnuHethong.Text = "Hệ thống";
            // 
            // mnuQuantri
            // 
            this.mnuQuantri.Name = "mnuQuantri";
            this.mnuQuantri.Size = new System.Drawing.Size(62, 20);
            this.mnuQuantri.Text = "Quản trị";
            // 
            // mnuQuanly
            // 
            this.mnuQuanly.Name = "mnuQuanly";
            this.mnuQuanly.Size = new System.Drawing.Size(60, 20);
            this.mnuQuanly.Text = "Quản lý";
            // 
            // mnuThongke
            // 
            this.mnuThongke.Name = "mnuThongke";
            this.mnuThongke.Size = new System.Drawing.Size(68, 20);
            this.mnuThongke.Text = "Thống kê";
            // 
            // mnuBaocao
            // 
            this.mnuBaocao.Name = "mnuBaocao";
            this.mnuBaocao.Size = new System.Drawing.Size(61, 20);
            this.mnuBaocao.Text = "Báo cáo";
            // 
            // mnuHotro
            // 
            this.mnuHotro.Name = "mnuHotro";
            this.mnuHotro.Size = new System.Drawing.Size(53, 20);
            this.mnuHotro.Text = "Hỗ trợ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.btnKhoahoc);
            this.panel1.Controls.Add(this.btnDangky);
            this.panel1.Controls.Add(this.btnHocvien);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 36);
            this.panel1.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblName.Location = new System.Drawing.Point(670, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 36);
            this.lblName.TabIndex = 3;
            this.lblName.Values.Text = "Trần Đỗ Phương Nam";
            // 
            // btnKhoahoc
            // 
            this.btnKhoahoc.AutoSize = true;
            this.btnKhoahoc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnKhoahoc.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnKhoahoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKhoahoc.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            this.btnKhoahoc.IconColor = System.Drawing.Color.Black;
            this.btnKhoahoc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnKhoahoc.IconSize = 37;
            this.btnKhoahoc.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnKhoahoc.Location = new System.Drawing.Point(220, 0);
            this.btnKhoahoc.Name = "btnKhoahoc";
            this.btnKhoahoc.Size = new System.Drawing.Size(110, 36);
            this.btnKhoahoc.TabIndex = 2;
            this.btnKhoahoc.Text = "Khóa học";
            this.btnKhoahoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKhoahoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnKhoahoc.UseVisualStyleBackColor = true;
            // 
            // btnDangky
            // 
            this.btnDangky.AutoSize = true;
            this.btnDangky.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDangky.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDangky.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangky.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btnDangky.IconColor = System.Drawing.Color.Black;
            this.btnDangky.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDangky.IconSize = 37;
            this.btnDangky.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnDangky.Location = new System.Drawing.Point(110, 0);
            this.btnDangky.Name = "btnDangky";
            this.btnDangky.Size = new System.Drawing.Size(110, 36);
            this.btnDangky.TabIndex = 1;
            this.btnDangky.Text = "Đăng ký";
            this.btnDangky.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangky.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDangky.UseVisualStyleBackColor = true;
            // 
            // btnHocvien
            // 
            this.btnHocvien.AutoSize = true;
            this.btnHocvien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHocvien.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnHocvien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHocvien.IconChar = FontAwesome.Sharp.IconChar.GraduationCap;
            this.btnHocvien.IconColor = System.Drawing.Color.Black;
            this.btnHocvien.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnHocvien.IconSize = 37;
            this.btnHocvien.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnHocvien.Location = new System.Drawing.Point(0, 0);
            this.btnHocvien.Name = "btnHocvien";
            this.btnHocvien.Size = new System.Drawing.Size(110, 36);
            this.btnHocvien.TabIndex = 0;
            this.btnHocvien.Text = "Học viên";
            this.btnHocvien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHocvien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHocvien.UseVisualStyleBackColor = true;
            // 
            // kryptonStatusStrip1
            // 
            this.kryptonStatusStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.kryptonStatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlbLabelTendangnhap,
            this.tlbTendangnhap,
            this.tlbLabelChinhanh,
            this.tlbChinhanh,
            this.tlbLabelNhom,
            this.tlbNhom});
            this.kryptonStatusStrip1.Location = new System.Drawing.Point(0, 428);
            this.kryptonStatusStrip1.Name = "kryptonStatusStrip1";
            this.kryptonStatusStrip1.ProgressBars = null;
            this.kryptonStatusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.kryptonStatusStrip1.Size = new System.Drawing.Size(800, 22);
            this.kryptonStatusStrip1.TabIndex = 2;
            this.kryptonStatusStrip1.Text = "kryptonStatusStrip1";
            // 
            // tlbLabelTendangnhap
            // 
            this.tlbLabelTendangnhap.Name = "tlbLabelTendangnhap";
            this.tlbLabelTendangnhap.Size = new System.Drawing.Size(88, 17);
            this.tlbLabelTendangnhap.Text = "Tên đăng nhập:";
            // 
            // tlbTendangnhap
            // 
            this.tlbTendangnhap.Name = "tlbTendangnhap";
            this.tlbTendangnhap.Size = new System.Drawing.Size(55, 17);
            this.tlbTendangnhap.Text = "                ";
            // 
            // tlbLabelChinhanh
            // 
            this.tlbLabelChinhanh.Name = "tlbLabelChinhanh";
            this.tlbLabelChinhanh.Size = new System.Drawing.Size(65, 17);
            this.tlbLabelChinhanh.Text = "Chi nhánh:";
            // 
            // tlbChinhanh
            // 
            this.tlbChinhanh.Name = "tlbChinhanh";
            this.tlbChinhanh.Size = new System.Drawing.Size(55, 17);
            this.tlbChinhanh.Text = "                ";
            // 
            // tlbLabelNhom
            // 
            this.tlbLabelNhom.Name = "tlbLabelNhom";
            this.tlbLabelNhom.Size = new System.Drawing.Size(44, 17);
            this.tlbLabelNhom.Text = "Nhóm:";
            // 
            // tlbNhom
            // 
            this.tlbNhom.Name = "tlbNhom";
            this.tlbNhom.Size = new System.Drawing.Size(43, 17);
            this.tlbNhom.Text = "            ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tc1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 60);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 368);
            this.panel2.TabIndex = 3;
            // 
            // tc1
            // 
            this.tc1.Controls.Add(this.tpHocvien);
            this.tc1.Controls.Add(this.tpDangky);
            this.tc1.Controls.Add(this.tpKhoahoc);
            this.tc1.Controls.Add(this.tabPage4);
            this.tc1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc1.Location = new System.Drawing.Point(0, 0);
            this.tc1.Name = "tc1";
            this.tc1.SelectedIndex = 0;
            this.tc1.Size = new System.Drawing.Size(800, 368);
            this.tc1.TabIndex = 0;
            // 
            // tpHocvien
            // 
            this.tpHocvien.Controls.Add(this.panel7);
            this.tpHocvien.Controls.Add(this.panel8);
            this.tpHocvien.Location = new System.Drawing.Point(4, 22);
            this.tpHocvien.Name = "tpHocvien";
            this.tpHocvien.Padding = new System.Windows.Forms.Padding(3);
            this.tpHocvien.Size = new System.Drawing.Size(792, 342);
            this.tpHocvien.TabIndex = 0;
            this.tpHocvien.Text = "Học viên";
            this.tpHocvien.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel7.Location = new System.Drawing.Point(396, 3);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(393, 336);
            this.panel7.TabIndex = 3;
            // 
            // panel8
            // 
            this.panel8.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel8.Location = new System.Drawing.Point(3, 3);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(393, 336);
            this.panel8.TabIndex = 2;
            // 
            // tpDangky
            // 
            this.tpDangky.Controls.Add(this.panel5);
            this.tpDangky.Controls.Add(this.panel6);
            this.tpDangky.Location = new System.Drawing.Point(4, 22);
            this.tpDangky.Name = "tpDangky";
            this.tpDangky.Padding = new System.Windows.Forms.Padding(3);
            this.tpDangky.Size = new System.Drawing.Size(792, 342);
            this.tpDangky.TabIndex = 1;
            this.tpDangky.Text = "Đăng ký";
            this.tpDangky.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(396, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(393, 336);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(393, 336);
            this.panel6.TabIndex = 2;
            // 
            // tpKhoahoc
            // 
            this.tpKhoahoc.Controls.Add(this.panel4);
            this.tpKhoahoc.Controls.Add(this.panel3);
            this.tpKhoahoc.Location = new System.Drawing.Point(4, 22);
            this.tpKhoahoc.Name = "tpKhoahoc";
            this.tpKhoahoc.Padding = new System.Windows.Forms.Padding(3);
            this.tpKhoahoc.Size = new System.Drawing.Size(792, 342);
            this.tpKhoahoc.TabIndex = 2;
            this.tpKhoahoc.Text = "Khóa học";
            this.tpKhoahoc.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(396, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(393, 336);
            this.panel4.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(393, 336);
            this.panel3.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.panel9);
            this.tabPage4.Controls.Add(this.panel10);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 342);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // panel9
            // 
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(396, 3);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(393, 336);
            this.panel9.TabIndex = 3;
            // 
            // panel10
            // 
            this.panel10.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel10.Location = new System.Drawing.Point(3, 3);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(393, 336);
            this.panel10.TabIndex = 2;
            // 
            // frmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.kryptonStatusStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mnuHome);
            this.MainMenuStrip = this.mnuHome;
            this.Name = "frmHome";
            this.Text = "Form_Home";
            this.mnuHome.ResumeLayout(false);
            this.mnuHome.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.kryptonStatusStrip1.ResumeLayout(false);
            this.kryptonStatusStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tc1.ResumeLayout(false);
            this.tpHocvien.ResumeLayout(false);
            this.tpDangky.ResumeLayout(false);
            this.tpKhoahoc.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuHome;
        private System.Windows.Forms.ToolStripMenuItem mnuHethong;
        private System.Windows.Forms.ToolStripMenuItem mnuQuantri;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanly;
        private System.Windows.Forms.ToolStripMenuItem mnuThongke;
        private System.Windows.Forms.ToolStripMenuItem mnuBaocao;
        private System.Windows.Forms.ToolStripMenuItem mnuHotro;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btnHocvien;
        private Krypton.Toolkit.KryptonLabel lblName;
        private FontAwesome.Sharp.IconButton btnKhoahoc;
        private FontAwesome.Sharp.IconButton btnDangky;
        private Krypton.Toolkit.KryptonStatusStrip kryptonStatusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlbLabelTendangnhap;
        private System.Windows.Forms.ToolStripStatusLabel tlbTendangnhap;
        private System.Windows.Forms.ToolStripStatusLabel tlbLabelChinhanh;
        private System.Windows.Forms.ToolStripStatusLabel tlbChinhanh;
        private System.Windows.Forms.ToolStripStatusLabel tlbLabelNhom;
        private System.Windows.Forms.ToolStripStatusLabel tlbNhom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl tc1;
        private System.Windows.Forms.TabPage tpDangky;
        private System.Windows.Forms.TabPage tpKhoahoc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tpHocvien;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
    }
}