namespace MyProjectNamespace
{
    partial class DashboardBatches
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.ComboBox comboBoxLine;
        private System.Windows.Forms.DataGridView dataGridViewBatches;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new System.Windows.Forms.Panel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.comboBoxLine = new System.Windows.Forms.ComboBox();
            this.dataGridViewBatches = new System.Windows.Forms.DataGridView();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatches)).BeginInit();
            this.SuspendLayout();
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.headerPanel.Controls.Add(this.logoPictureBox);
            this.headerPanel.Controls.Add(this.comboBoxLine);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1500, 137);
            this.headerPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Location = new System.Drawing.Point(20, 10);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(229, 108);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // comboBoxLine
            // 
            this.comboBoxLine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLine.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxLine.Location = new System.Drawing.Point(300, 25);
            this.comboBoxLine.Name = "comboBoxLine";
            this.comboBoxLine.Size = new System.Drawing.Size(250, 40);
            this.comboBoxLine.TabIndex = 1;
            this.comboBoxLine.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLine_SelectedIndexChanged);
            // 
            // dataGridViewBatches
            // 
            this.dataGridViewBatches.AllowUserToAddRows = false;
            this.dataGridViewBatches.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBatches.ColumnHeadersHeight = 50;
            this.dataGridViewBatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewBatches.Location = new System.Drawing.Point(0, 137);
            this.dataGridViewBatches.Name = "dataGridViewBatches";
            this.dataGridViewBatches.ReadOnly = true;
            this.dataGridViewBatches.RowHeadersWidth = 62;
            this.dataGridViewBatches.RowTemplate.Height = 50;
            this.dataGridViewBatches.Size = new System.Drawing.Size(1500, 663);
            this.dataGridViewBatches.TabIndex = 0;
            this.dataGridViewBatches.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DataGridViewBatches_CellFormatting);
            // 
            // DashboardBatches
            // 
            this.ClientSize = new System.Drawing.Size(1500, 800);
            this.Controls.Add(this.dataGridViewBatches);
            this.Controls.Add(this.headerPanel);
            this.Name = "DashboardBatches";
            this.Load += new System.EventHandler(this.DashboardBatches_Load);
            this.headerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBatches)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
