namespace CVBascoo
{
    partial class FormMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pelangganToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.frameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lensaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pemasaranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaksiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tambahToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keluarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pembayaranToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masterToolStripMenuItem,
            this.transaksiToolStripMenuItem,
            this.keluarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(708, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pelangganToolStripMenuItem,
            this.frameToolStripMenuItem,
            this.lensaToolStripMenuItem,
            this.pemasaranToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // pelangganToolStripMenuItem
            // 
            this.pelangganToolStripMenuItem.Name = "pelangganToolStripMenuItem";
            this.pelangganToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pelangganToolStripMenuItem.Text = "Pelanggan";
            this.pelangganToolStripMenuItem.Click += new System.EventHandler(this.pelangganToolStripMenuItem_Click);
            // 
            // frameToolStripMenuItem
            // 
            this.frameToolStripMenuItem.Name = "frameToolStripMenuItem";
            this.frameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.frameToolStripMenuItem.Text = "Supplier";
            this.frameToolStripMenuItem.Click += new System.EventHandler(this.frameToolStripMenuItem_Click);
            // 
            // lensaToolStripMenuItem
            // 
            this.lensaToolStripMenuItem.Name = "lensaToolStripMenuItem";
            this.lensaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lensaToolStripMenuItem.Text = "Karyawan";
            this.lensaToolStripMenuItem.Click += new System.EventHandler(this.lensaToolStripMenuItem_Click);
            // 
            // pemasaranToolStripMenuItem
            // 
            this.pemasaranToolStripMenuItem.Name = "pemasaranToolStripMenuItem";
            this.pemasaranToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.pemasaranToolStripMenuItem.Text = "Pemasaran";
            this.pemasaranToolStripMenuItem.Click += new System.EventHandler(this.pemasaranToolStripMenuItem_Click);
            // 
            // transaksiToolStripMenuItem
            // 
            this.transaksiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tambahToolStripMenuItem,
            this.pembayaranToolStripMenuItem,
            this.reportToolStripMenuItem});
            this.transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            this.transaksiToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // tambahToolStripMenuItem
            // 
            this.tambahToolStripMenuItem.Name = "tambahToolStripMenuItem";
            this.tambahToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.tambahToolStripMenuItem.Text = "Pemesanan";
            this.tambahToolStripMenuItem.Click += new System.EventHandler(this.tambahToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.reportToolStripMenuItem.Text = "report";
            this.reportToolStripMenuItem.Click += new System.EventHandler(this.reportToolStripMenuItem_Click);
            // 
            // keluarToolStripMenuItem
            // 
            this.keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            this.keluarToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.keluarToolStripMenuItem.Text = "Keluar";
            this.keluarToolStripMenuItem.Click += new System.EventHandler(this.keluarToolStripMenuItem_Click);
            // 
            // pembayaranToolStripMenuItem
            // 
            this.pembayaranToolStripMenuItem.Name = "pembayaranToolStripMenuItem";
            this.pembayaranToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.pembayaranToolStripMenuItem.Text = "Input Data Barang";
            this.pembayaranToolStripMenuItem.Click += new System.EventHandler(this.pembayaranToolStripMenuItem_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 434);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pelangganToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem frameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lensaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transaksiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tambahToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pemasaranToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keluarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pembayaranToolStripMenuItem;

    }
}