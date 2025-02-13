using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace MyProjectNamespace
{
    public partial class DashboardBatches : Form
    {
        private readonly string connectionString =
                 @"Data Source=th-bp-db\mssql2017;" +
                 "User ID=dvl;" +
                 "Password=Pr0gr@mm1ng;" +
                 "Database=TFCPILOT;" +
                 "Application Name=DashboardBatches";
        private Timer refreshTimer;

        public DashboardBatches()
        {
            InitializeComponent();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 10000;
            refreshTimer.Tick += new EventHandler(RefreshTimer_Tick);
            refreshTimer.Start();
        }
        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadBatchData();
        }

        private void DashboardBatches_Load(object sender, EventArgs e)
        {
            LoadCompanyLogo();
            LoadLineMachines();

            if (comboBoxLine.Items.Count > 0)
            {
                comboBoxLine.SelectedIndex = 0;
            }

            LoadBatchData();
        }

        private void ComboBoxLine_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBatchData();
        }

        private void LoadCompanyLogo()
        {
            string imageUrl = "https://img2.pic.in.th/pic/logo1.jpg";

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageBytes = webClient.DownloadData(imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        logoPictureBox.Image = Image.FromStream(ms);
                    }
                }
            }
            catch
            {
                MessageBox.Show("โหลดโลโก้ไม่สำเร็จ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadLineMachines()
        {
            comboBoxLine.Items.Clear();

            comboBoxLine.Items.Add("All");
            comboBoxLine.Items.Add("Aussie");
            comboBoxLine.Items.Add("Yankee");
            comboBoxLine.Items.Add("Seasoning");

            comboBoxLine.SelectedIndex = 0;
        }

        private void LoadBatchData()
        {
            string selectedLine = comboBoxLine.SelectedItem?.ToString() ?? "All";

            string sql = @"
SELECT 
    T.BatchNo,
P.FormulaId As ProductNo,
    T.StartSieve,
    T.FinishSieve,
    T.RMSieveBinID,
    T.SieveComplete,
    T.RMTipBinID,
    T.StartTip,
    T.FinishTip,
    T.StartBlend,
    T.FinishBlend,
    T.FGTipBinID,
    T.FGPackBinID,
    T.StartPack,
    T.FinishPack,
    T.IBCKG,
    T.BagSize,
    T.FullBags,
    T.PartBags,
    T.PackComplete,
    T.StartSieve2,
    T.FinishSieve2,
    T.FGItemkey,
    T.IBCFinished,
    T.Clean1start,
    T.Clean1finish,
    T.Clean2start,
    T.Clean2finish,
    T.Clean3start,
    T.Clean3finish
FROM TFC_PTiming2 T
LEFT JOIN PNMAST P
    ON T.BatchNo = P.BatchNo";

            if (selectedLine != "All")
            {
                sql += " WHERE T.ProcessCell = @line";
            }

            
            sql += " ORDER BY T.Sequence DESC";


            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (selectedLine != "All")
                {
                    cmd.Parameters.AddWithValue("@line", selectedLine);
                }

                conn.Open();
                dt.Load(cmd.ExecuteReader());
            }

            dataGridViewBatches.DataSource = dt;
            CustomizeDataGridView();
        }
        private void CustomizeDataGridView()
        {
            var grid = dataGridViewBatches;

            
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30); 
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.Gold; 
            grid.ColumnHeadersHeight = 50; 

            
            grid.RowsDefaultCellStyle.BackColor = Color.White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(220, 230, 240); 

            
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 14);
            grid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            grid.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5); 
            grid.RowTemplate.Height = 60; 

            
            grid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grid.GridColor = Color.LightGray;

            
            grid.RowHeadersVisible = false;

            
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 171, 64); 
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;

            
            foreach (DataGridViewColumn column in grid.Columns)
            {
                column.Width = 200; 
            }

            grid.ClearSelection();
        }

        private void DataGridViewBatches_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGridViewBatches.Rows[e.RowIndex].DataBoundItem == null)
                return;

            object batchNoValue = dataGridViewBatches.Rows[e.RowIndex].Cells["BatchNo"].Value;

            
            e.CellStyle.BackColor = e.RowIndex % 2 == 0 ? Color.White : Color.FromArgb(220, 230, 240);

            
            if (batchNoValue != null && batchNoValue.ToString() == "999999")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 200, 100); // Light Orange
                e.CellStyle.ForeColor = Color.Black;
                e.CellStyle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            }
        }

    }
}
