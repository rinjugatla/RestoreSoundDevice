namespace RestoreSoundDevice
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            GetDevice_Button = new Button();
            CaptureDevice_DataGridView = new DataGridView();
            CaptureDeviceNameColumn = new DataGridViewTextBoxColumn();
            RenderDevice_DataGridView = new DataGridView();
            RenderDeviceNameColumn = new DataGridViewTextBoxColumn();
            CaptureDevice_Label = new Label();
            RenderDevice_Label = new Label();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            RestoreWatchdogInterval_TextBox = new TextBox();
            RestoreWatchdogInterval_Label = new Label();
            RestoreModeSwitch_Button = new Button();
            NotifyIcon = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)CaptureDevice_DataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)RenderDevice_DataGridView).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // GetDevice_Button
            // 
            GetDevice_Button.Location = new Point(731, 253);
            GetDevice_Button.Name = "GetDevice_Button";
            GetDevice_Button.Size = new Size(97, 23);
            GetDevice_Button.TabIndex = 0;
            GetDevice_Button.Text = "デバイスを取得";
            GetDevice_Button.UseVisualStyleBackColor = true;
            GetDevice_Button.Click += GetDevice_Button_Click;
            // 
            // CaptureDevice_DataGridView
            // 
            CaptureDevice_DataGridView.AllowUserToAddRows = false;
            CaptureDevice_DataGridView.AllowUserToDeleteRows = false;
            CaptureDevice_DataGridView.AllowUserToResizeColumns = false;
            CaptureDevice_DataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(192, 255, 255);
            CaptureDevice_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            CaptureDevice_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CaptureDevice_DataGridView.Columns.AddRange(new DataGridViewColumn[] { CaptureDeviceNameColumn });
            CaptureDevice_DataGridView.Location = new Point(6, 33);
            CaptureDevice_DataGridView.MultiSelect = false;
            CaptureDevice_DataGridView.Name = "CaptureDevice_DataGridView";
            CaptureDevice_DataGridView.RowTemplate.Height = 25;
            CaptureDevice_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            CaptureDevice_DataGridView.Size = new Size(408, 214);
            CaptureDevice_DataGridView.TabIndex = 2;
            // 
            // CaptureDeviceNameColumn
            // 
            CaptureDeviceNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CaptureDeviceNameColumn.HeaderText = "名前";
            CaptureDeviceNameColumn.Name = "CaptureDeviceNameColumn";
            CaptureDeviceNameColumn.ReadOnly = true;
            CaptureDeviceNameColumn.Resizable = DataGridViewTriState.False;
            CaptureDeviceNameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // RenderDevice_DataGridView
            // 
            RenderDevice_DataGridView.AllowUserToAddRows = false;
            RenderDevice_DataGridView.AllowUserToDeleteRows = false;
            RenderDevice_DataGridView.AllowUserToResizeColumns = false;
            RenderDevice_DataGridView.AllowUserToResizeRows = false;
            RenderDevice_DataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            RenderDevice_DataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            RenderDevice_DataGridView.Columns.AddRange(new DataGridViewColumn[] { RenderDeviceNameColumn });
            RenderDevice_DataGridView.Location = new Point(420, 33);
            RenderDevice_DataGridView.MultiSelect = false;
            RenderDevice_DataGridView.Name = "RenderDevice_DataGridView";
            RenderDevice_DataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RenderDevice_DataGridView.Size = new Size(408, 214);
            RenderDevice_DataGridView.TabIndex = 2;
            // 
            // RenderDeviceNameColumn
            // 
            RenderDeviceNameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            RenderDeviceNameColumn.HeaderText = "名前";
            RenderDeviceNameColumn.Name = "RenderDeviceNameColumn";
            RenderDeviceNameColumn.ReadOnly = true;
            RenderDeviceNameColumn.Resizable = DataGridViewTriState.False;
            RenderDeviceNameColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // CaptureDevice_Label
            // 
            CaptureDevice_Label.AutoSize = true;
            CaptureDevice_Label.Location = new Point(6, 15);
            CaptureDevice_Label.Name = "CaptureDevice_Label";
            CaptureDevice_Label.Size = new Size(68, 15);
            CaptureDevice_Label.TabIndex = 3;
            CaptureDevice_Label.Text = "入力デバイス";
            // 
            // RenderDevice_Label
            // 
            RenderDevice_Label.AutoSize = true;
            RenderDevice_Label.Location = new Point(420, 15);
            RenderDevice_Label.Name = "RenderDevice_Label";
            RenderDevice_Label.Size = new Size(68, 15);
            RenderDevice_Label.TabIndex = 4;
            RenderDevice_Label.Text = "出力デバイス";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CaptureDevice_DataGridView);
            groupBox1.Controls.Add(RenderDevice_Label);
            groupBox1.Controls.Add(GetDevice_Button);
            groupBox1.Controls.Add(CaptureDevice_Label);
            groupBox1.Controls.Add(RenderDevice_DataGridView);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(839, 286);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "デバイス";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(RestoreWatchdogInterval_TextBox);
            groupBox2.Controls.Add(RestoreWatchdogInterval_Label);
            groupBox2.Controls.Add(RestoreModeSwitch_Button);
            groupBox2.Location = new Point(12, 304);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(839, 57);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "監視";
            // 
            // RestoreWatchdogInterval_TextBox
            // 
            RestoreWatchdogInterval_TextBox.Location = new Point(625, 22);
            RestoreWatchdogInterval_TextBox.Name = "RestoreWatchdogInterval_TextBox";
            RestoreWatchdogInterval_TextBox.Size = new Size(100, 23);
            RestoreWatchdogInterval_TextBox.TabIndex = 3;
            RestoreWatchdogInterval_TextBox.Text = "30";
            RestoreWatchdogInterval_TextBox.TextAlign = HorizontalAlignment.Right;
            RestoreWatchdogInterval_TextBox.Validating += RestoreWatchdogInterval_TextBox_Validating;
            // 
            // RestoreWatchdogInterval_Label
            // 
            RestoreWatchdogInterval_Label.AutoSize = true;
            RestoreWatchdogInterval_Label.Location = new Point(544, 26);
            RestoreWatchdogInterval_Label.Name = "RestoreWatchdogInterval_Label";
            RestoreWatchdogInterval_Label.Size = new Size(75, 15);
            RestoreWatchdogInterval_Label.TabIndex = 2;
            RestoreWatchdogInterval_Label.Text = "監視間隔(秒)";
            // 
            // RestoreModeSwitch_Button
            // 
            RestoreModeSwitch_Button.BackColor = Color.FromArgb(255, 192, 192);
            RestoreModeSwitch_Button.Location = new Point(731, 22);
            RestoreModeSwitch_Button.Name = "RestoreModeSwitch_Button";
            RestoreModeSwitch_Button.Size = new Size(97, 23);
            RestoreModeSwitch_Button.TabIndex = 0;
            RestoreModeSwitch_Button.Text = "停止中";
            RestoreModeSwitch_Button.UseVisualStyleBackColor = false;
            RestoreModeSwitch_Button.Click += RestoreModeSwitch_Button_Click;
            // 
            // NotifyIcon
            // 
            NotifyIcon.Icon = (Icon)resources.GetObject("NotifyIcon.Icon");
            NotifyIcon.Text = "サウンドデバイス設定自動復元ツール";
            NotifyIcon.Visible = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 373);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            ShowInTaskbar = false;
            Text = "サウンドデバイス設定自動復元ツール";
            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            ((System.ComponentModel.ISupportInitialize)CaptureDevice_DataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)RenderDevice_DataGridView).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button GetDevice_Button;
        private DataGridView CaptureDevice_DataGridView;
        private DataGridView RenderDevice_DataGridView;
        private Label CaptureDevice_Label;
        private Label RenderDevice_Label;
        private DataGridViewTextBoxColumn CaptureDeviceNameColumn;
        private DataGridViewTextBoxColumn RenderDeviceNameColumn;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Label RestoreWatchdogInterval_Label;
        private Button RestoreModeSwitch_Button;
        private TextBox RestoreWatchdogInterval_TextBox;
        private NotifyIcon NotifyIcon;
    }
}