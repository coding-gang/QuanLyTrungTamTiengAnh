
namespace UI
{
    partial class FormUpdateClassStudent
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
            this.kryptonLabel1 = new Krypton.Toolkit.KryptonLabel();
            this.lbNameStudent = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel2 = new Krypton.Toolkit.KryptonLabel();
            this.cbbCourses = new Krypton.Toolkit.KryptonComboBox();
            this.lbCH = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel3 = new Krypton.Toolkit.KryptonLabel();
            this.txtDateStudy = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel4 = new Krypton.Toolkit.KryptonLabel();
            this.txtStartTime = new Krypton.Toolkit.KryptonLabel();
            this.cbbCahoc = new Krypton.Toolkit.KryptonComboBox();
            this.kryptonLabel5 = new Krypton.Toolkit.KryptonLabel();
            this.cbbExchangeCaHoc = new Krypton.Toolkit.KryptonComboBox();
            this.txtExchangeStartTime = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel7 = new Krypton.Toolkit.KryptonLabel();
            this.txtExchangeDateStudy = new Krypton.Toolkit.KryptonLabel();
            this.kryptonLabel9 = new Krypton.Toolkit.KryptonLabel();
            this.btnDoiCaHoc = new Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCahoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbExchangeCaHoc)).BeginInit();
            this.SuspendLayout();
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(36, 28);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(61, 20);
            this.kryptonLabel1.TabIndex = 0;
            this.kryptonLabel1.Values.Text = "Học sinh:";
            // 
            // lbNameStudent
            // 
            this.lbNameStudent.Location = new System.Drawing.Point(113, 27);
            this.lbNameStudent.Name = "lbNameStudent";
            this.lbNameStudent.Size = new System.Drawing.Size(88, 20);
            this.lbNameStudent.TabIndex = 1;
            this.lbNameStudent.Values.Text = "kryptonLabel2";
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(35, 54);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(62, 20);
            this.kryptonLabel2.TabIndex = 2;
            this.kryptonLabel2.Values.Text = "Môn học:";
            // 
            // cbbCourses
            // 
            this.cbbCourses.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbCourses.DropDownWidth = 267;
            this.cbbCourses.IntegralHeight = false;
            this.cbbCourses.Location = new System.Drawing.Point(113, 53);
            this.cbbCourses.Name = "cbbCourses";
            this.cbbCourses.Size = new System.Drawing.Size(267, 21);
            this.cbbCourses.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbbCourses.TabIndex = 3;
            this.cbbCourses.SelectedIndexChanged += new System.EventHandler(this.cbbCourses_SelectedIndexChanged);
            // 
            // lbCH
            // 
            this.lbCH.Location = new System.Drawing.Point(3, 88);
            this.lbCH.Name = "lbCH";
            this.lbCH.Size = new System.Drawing.Size(94, 20);
            this.lbCH.TabIndex = 4;
            this.lbCH.Values.Text = "Ca học hiện tại:";
            // 
            // kryptonLabel3
            // 
            this.kryptonLabel3.Location = new System.Drawing.Point(31, 124);
            this.kryptonLabel3.Name = "kryptonLabel3";
            this.kryptonLabel3.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel3.TabIndex = 6;
            this.kryptonLabel3.Values.Text = "Ngày học:";
            // 
            // txtDateStudy
            // 
            this.txtDateStudy.Location = new System.Drawing.Point(113, 125);
            this.txtDateStudy.Name = "txtDateStudy";
            this.txtDateStudy.Size = new System.Drawing.Size(81, 20);
            this.txtDateStudy.TabIndex = 7;
            this.txtDateStudy.Values.Text = "txtDateStudy";
            // 
            // kryptonLabel4
            // 
            this.kryptonLabel4.Location = new System.Drawing.Point(211, 124);
            this.kryptonLabel4.Name = "kryptonLabel4";
            this.kryptonLabel4.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel4.TabIndex = 8;
            this.kryptonLabel4.Values.Text = "Thời gian:";
            // 
            // txtStartTime
            // 
            this.txtStartTime.Location = new System.Drawing.Point(292, 124);
            this.txtStartTime.Name = "txtStartTime";
            this.txtStartTime.Size = new System.Drawing.Size(88, 20);
            this.txtStartTime.TabIndex = 9;
            this.txtStartTime.Values.Text = "kryptonLabel5";
            // 
            // cbbCahoc
            // 
            this.cbbCahoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbCahoc.DropDownWidth = 267;
            this.cbbCahoc.IntegralHeight = false;
            this.cbbCahoc.Location = new System.Drawing.Point(113, 88);
            this.cbbCahoc.Name = "cbbCahoc";
            this.cbbCahoc.Size = new System.Drawing.Size(267, 21);
            this.cbbCahoc.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbbCahoc.TabIndex = 10;
            this.cbbCahoc.SelectedIndexChanged += new System.EventHandler(this.cbbCahoc_SelectedIndexChanged);
            // 
            // kryptonLabel5
            // 
            this.kryptonLabel5.Location = new System.Drawing.Point(25, 175);
            this.kryptonLabel5.Name = "kryptonLabel5";
            this.kryptonLabel5.Size = new System.Drawing.Size(71, 20);
            this.kryptonLabel5.TabIndex = 11;
            this.kryptonLabel5.Values.Text = "Đổi ca học:";
            // 
            // cbbExchangeCaHoc
            // 
            this.cbbExchangeCaHoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cbbExchangeCaHoc.DropDownWidth = 267;
            this.cbbExchangeCaHoc.IntegralHeight = false;
            this.cbbExchangeCaHoc.Location = new System.Drawing.Point(113, 175);
            this.cbbExchangeCaHoc.Name = "cbbExchangeCaHoc";
            this.cbbExchangeCaHoc.Size = new System.Drawing.Size(267, 21);
            this.cbbExchangeCaHoc.StateCommon.ComboBox.Content.TextH = Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.cbbExchangeCaHoc.TabIndex = 12;
            this.cbbExchangeCaHoc.SelectedIndexChanged += new System.EventHandler(this.cbbExchangeCaHoc_SelectedIndexChanged);
            // 
            // txtExchangeStartTime
            // 
            this.txtExchangeStartTime.Location = new System.Drawing.Point(292, 214);
            this.txtExchangeStartTime.Name = "txtExchangeStartTime";
            this.txtExchangeStartTime.Size = new System.Drawing.Size(88, 20);
            this.txtExchangeStartTime.TabIndex = 16;
            this.txtExchangeStartTime.Values.Text = "kryptonLabel5";
            // 
            // kryptonLabel7
            // 
            this.kryptonLabel7.Location = new System.Drawing.Point(211, 214);
            this.kryptonLabel7.Name = "kryptonLabel7";
            this.kryptonLabel7.Size = new System.Drawing.Size(64, 20);
            this.kryptonLabel7.TabIndex = 15;
            this.kryptonLabel7.Values.Text = "Thời gian:";
            // 
            // txtExchangeDateStudy
            // 
            this.txtExchangeDateStudy.Location = new System.Drawing.Point(113, 215);
            this.txtExchangeDateStudy.Name = "txtExchangeDateStudy";
            this.txtExchangeDateStudy.Size = new System.Drawing.Size(88, 20);
            this.txtExchangeDateStudy.TabIndex = 14;
            this.txtExchangeDateStudy.Values.Text = "kryptonLabel8";
            // 
            // kryptonLabel9
            // 
            this.kryptonLabel9.Location = new System.Drawing.Point(31, 214);
            this.kryptonLabel9.Name = "kryptonLabel9";
            this.kryptonLabel9.Size = new System.Drawing.Size(65, 20);
            this.kryptonLabel9.TabIndex = 13;
            this.kryptonLabel9.Values.Text = "Ngày học:";
            // 
            // btnDoiCaHoc
            // 
            this.btnDoiCaHoc.Location = new System.Drawing.Point(290, 267);
            this.btnDoiCaHoc.Name = "btnDoiCaHoc";
            this.btnDoiCaHoc.Size = new System.Drawing.Size(90, 25);
            this.btnDoiCaHoc.TabIndex = 17;
            this.btnDoiCaHoc.Values.Text = "Đổi Ca học";
            this.btnDoiCaHoc.Click += new System.EventHandler(this.btnDoiCaHoc_Click);
            // 
            // FormUpdateClassStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 304);
            this.Controls.Add(this.btnDoiCaHoc);
            this.Controls.Add(this.txtExchangeStartTime);
            this.Controls.Add(this.kryptonLabel7);
            this.Controls.Add(this.txtExchangeDateStudy);
            this.Controls.Add(this.kryptonLabel9);
            this.Controls.Add(this.cbbExchangeCaHoc);
            this.Controls.Add(this.kryptonLabel5);
            this.Controls.Add(this.cbbCahoc);
            this.Controls.Add(this.txtStartTime);
            this.Controls.Add(this.kryptonLabel4);
            this.Controls.Add(this.txtDateStudy);
            this.Controls.Add(this.kryptonLabel3);
            this.Controls.Add(this.lbCH);
            this.Controls.Add(this.cbbCourses);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.lbNameStudent);
            this.Controls.Add(this.kryptonLabel1);
            this.Name = "FormUpdateClassStudent";
            this.Text = "FormUpdateClassStudent";
            this.Load += new System.EventHandler(this.FormUpdateClassStudent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbbCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbCahoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbbExchangeCaHoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private Krypton.Toolkit.KryptonLabel lbNameStudent;
        private Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private Krypton.Toolkit.KryptonComboBox cbbCourses;
        private Krypton.Toolkit.KryptonLabel lbCH;
        private Krypton.Toolkit.KryptonLabel kryptonLabel3;
        private Krypton.Toolkit.KryptonLabel txtDateStudy;
        private Krypton.Toolkit.KryptonLabel kryptonLabel4;
        private Krypton.Toolkit.KryptonLabel txtStartTime;
        private Krypton.Toolkit.KryptonComboBox cbbCahoc;
        private Krypton.Toolkit.KryptonLabel kryptonLabel5;
        private Krypton.Toolkit.KryptonComboBox cbbExchangeCaHoc;
        private Krypton.Toolkit.KryptonLabel txtExchangeStartTime;
        private Krypton.Toolkit.KryptonLabel kryptonLabel7;
        private Krypton.Toolkit.KryptonLabel txtExchangeDateStudy;
        private Krypton.Toolkit.KryptonLabel kryptonLabel9;
        private Krypton.Toolkit.KryptonButton btnDoiCaHoc;
    }
}