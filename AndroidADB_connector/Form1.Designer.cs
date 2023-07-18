namespace AndroidADB_connector
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dgDevices = new System.Windows.Forms.DataGridView();
            this.DeviceID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.port = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isConnected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgDevices)).BeginInit();
            this.loadingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRefresh.Location = new System.Drawing.Point(732, 86);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(74, 249);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDisconnect.Location = new System.Drawing.Point(654, 12);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(152, 29);
            this.btnDisconnect.TabIndex = 3;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.Location = new System.Drawing.Point(496, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(152, 29);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(329, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 28);
            this.label2.TabIndex = 100;
            this.label2.Text = "Available devices";
            // 
            // dgDevices
            // 
            this.dgDevices.AllowUserToAddRows = false;
            this.dgDevices.AllowUserToDeleteRows = false;
            this.dgDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceID,
            this.deviceName,
            this.ip,
            this.port,
            this.isConnected});
            this.dgDevices.Location = new System.Drawing.Point(12, 86);
            this.dgDevices.Name = "dgDevices";
            this.dgDevices.ReadOnly = true;
            this.dgDevices.RowTemplate.Height = 25;
            this.dgDevices.Size = new System.Drawing.Size(714, 249);
            this.dgDevices.TabIndex = 4;
            this.dgDevices.SelectionChanged += new System.EventHandler(this.dgDevices_SelectionChanged);
            // 
            // DeviceID
            // 
            this.DeviceID.DataPropertyName = "DeviceID";
            this.DeviceID.FillWeight = 80F;
            this.DeviceID.HeaderText = "ID";
            this.DeviceID.Name = "DeviceID";
            this.DeviceID.ReadOnly = true;
            // 
            // deviceName
            // 
            this.deviceName.DataPropertyName = "DeviceName";
            this.deviceName.HeaderText = "Device name";
            this.deviceName.Name = "deviceName";
            this.deviceName.ReadOnly = true;
            this.deviceName.Width = 180;
            // 
            // ip
            // 
            this.ip.DataPropertyName = "IP";
            this.ip.HeaderText = "IP";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            this.ip.Width = 140;
            // 
            // port
            // 
            this.port.DataPropertyName = "Port";
            this.port.HeaderText = "Port";
            this.port.Name = "port";
            this.port.ReadOnly = true;
            // 
            // isConnected
            // 
            this.isConnected.DataPropertyName = "Status";
            this.isConnected.HeaderText = "Status";
            this.isConnected.Name = "isConnected";
            this.isConnected.ReadOnly = true;
            // 
            // tbPort
            // 
            this.tbPort.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tbPort.Location = new System.Drawing.Point(56, 12);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(434, 29);
            this.tbPort.TabIndex = 1;
            this.tbPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPort_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 21);
            this.label3.TabIndex = 100;
            this.label3.Text = "Port";
            // 
            // loadingPanel
            // 
            this.loadingPanel.BackColor = System.Drawing.SystemColors.Control;
            this.loadingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.loadingPanel.Controls.Add(this.pictureBox1);
            this.loadingPanel.Controls.Add(this.label1);
            this.loadingPanel.Location = new System.Drawing.Point(199, 47);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(64, 33);
            this.loadingPanel.TabIndex = 100;
            this.loadingPanel.UseWaitCursor = true;
            this.loadingPanel.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(479, 144);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(280, 147);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loading...";
            this.label1.UseWaitCursor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 349);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.dgDevices);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.btnRefresh);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(834, 388);
            this.MinimumSize = new System.Drawing.Size(834, 388);
            this.Name = "Form1";
            this.Text = "ADB Connector";
            ((System.ComponentModel.ISupportInitialize)(this.dgDevices)).EndInit();
            this.loadingPanel.ResumeLayout(false);
            this.loadingPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnRefresh;
        private Button btnDisconnect;
        private Button btnConnect;
        private Label label2;
        private DataGridView dgDevices;
        private TextBox tbPort;
        private Label label3;
        private Panel loadingPanel;
        private Label label1;
        private PictureBox pictureBox1;
        private DataGridViewTextBoxColumn DeviceID;
        private DataGridViewTextBoxColumn deviceName;
        private DataGridViewTextBoxColumn ip;
        private DataGridViewTextBoxColumn port;
        private DataGridViewTextBoxColumn isConnected;
    }
}