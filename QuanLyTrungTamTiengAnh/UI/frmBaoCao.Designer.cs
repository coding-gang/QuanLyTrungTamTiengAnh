
namespace UI
{
    partial class frmBaoCao
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
            this.txtTitleBaoCao = new Krypton.Toolkit.KryptonLabel();
            this.dtgBaoCao = new Krypton.Toolkit.KryptonDataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaoCao)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitleBaoCao
            // 
            this.txtTitleBaoCao.Location = new System.Drawing.Point(373, 27);
            this.txtTitleBaoCao.Name = "txtTitleBaoCao";
            this.txtTitleBaoCao.Size = new System.Drawing.Size(80, 20);
            this.txtTitleBaoCao.TabIndex = 0;
            this.txtTitleBaoCao.Values.Text = "Title Bao cao";
            // 
            // dtgBaoCao
            // 
            this.dtgBaoCao.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgBaoCao.Location = new System.Drawing.Point(0, 68);
            this.dtgBaoCao.Name = "dtgBaoCao";
            this.dtgBaoCao.Size = new System.Drawing.Size(849, 323);
            this.dtgBaoCao.TabIndex = 1;
            // 
            // frmBaoCao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 391);
            this.Controls.Add(this.dtgBaoCao);
            this.Controls.Add(this.txtTitleBaoCao);
            this.Name = "frmBaoCao";
            this.Text = "frmBaoCao";
            this.Load += new System.EventHandler(this.frmBaoCao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgBaoCao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Krypton.Toolkit.KryptonLabel txtTitleBaoCao;
        private Krypton.Toolkit.KryptonDataGridView dtgBaoCao;
    }
}