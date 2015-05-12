namespace pump
{
    partial class SearchAlarmData
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.SearchPanel = new System.Windows.Forms.Panel();
            this.getalarmdata = new System.Windows.Forms.Button();
            this.savechart_button = new System.Windows.Forms.Button();
            this.checkTable = new System.Windows.Forms.CheckBox();
            this.infoComBox = new System.Windows.Forms.ComboBox();
            this.info = new System.Windows.Forms.Label();
            this.craneidComBox = new System.Windows.Forms.ComboBox();
            this.GetTable_button = new System.Windows.Forms.Button();
            this.End_TextBox = new System.Windows.Forms.TextBox();
            this.Begin_TextBox = new System.Windows.Forms.TextBox();
            this.Search_Button = new System.Windows.Forms.Button();
            this.End_TimePicker = new System.Windows.Forms.DateTimePicker();
            this.Begin_TimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.DataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveexcel = new System.Windows.Forms.SaveFileDialog();
            this.DataView = new System.Windows.Forms.DataGridView();
            this.gboxid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.crane_info = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.area = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.check_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D5998 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D5999 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6000 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6001 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6002 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6003 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6004 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6005 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6006 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6007 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6008 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6009 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6010 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D6011 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.savechart = new System.Windows.Forms.SaveFileDialog();
            this.SearchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).BeginInit();
            this.SuspendLayout();
            // 
            // SearchPanel
            // 
            this.SearchPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchPanel.BackColor = System.Drawing.Color.White;
            this.SearchPanel.Controls.Add(this.getalarmdata);
            this.SearchPanel.Controls.Add(this.savechart_button);
            this.SearchPanel.Controls.Add(this.checkTable);
            this.SearchPanel.Controls.Add(this.infoComBox);
            this.SearchPanel.Controls.Add(this.info);
            this.SearchPanel.Controls.Add(this.craneidComBox);
            this.SearchPanel.Controls.Add(this.GetTable_button);
            this.SearchPanel.Controls.Add(this.End_TextBox);
            this.SearchPanel.Controls.Add(this.Begin_TextBox);
            this.SearchPanel.Controls.Add(this.Search_Button);
            this.SearchPanel.Controls.Add(this.End_TimePicker);
            this.SearchPanel.Controls.Add(this.Begin_TimePicker);
            this.SearchPanel.Controls.Add(this.label5);
            this.SearchPanel.Controls.Add(this.label4);
            this.SearchPanel.Controls.Add(this.label3);
            this.SearchPanel.Location = new System.Drawing.Point(0, 0);
            this.SearchPanel.Name = "SearchPanel";
            this.SearchPanel.Size = new System.Drawing.Size(1166, 49);
            this.SearchPanel.TabIndex = 1;
            // 
            // getalarmdata
            // 
            this.getalarmdata.Location = new System.Drawing.Point(1072, 10);
            this.getalarmdata.Name = "getalarmdata";
            this.getalarmdata.Size = new System.Drawing.Size(75, 23);
            this.getalarmdata.TabIndex = 16;
            this.getalarmdata.Text = "报警导出";
            this.getalarmdata.UseVisualStyleBackColor = true;
            this.getalarmdata.Click += new System.EventHandler(this.getalarmdata_Click);
            // 
            // savechart_button
            // 
            this.savechart_button.Location = new System.Drawing.Point(991, 10);
            this.savechart_button.Name = "savechart_button";
            this.savechart_button.Size = new System.Drawing.Size(75, 23);
            this.savechart_button.TabIndex = 15;
            this.savechart_button.Text = "保存曲线图";
            this.savechart_button.UseVisualStyleBackColor = true;
            this.savechart_button.Click += new System.EventHandler(this.savechart_button_Click);
            // 
            // checkTable
            // 
            this.checkTable.AutoSize = true;
            this.checkTable.Location = new System.Drawing.Point(745, 15);
            this.checkTable.Name = "checkTable";
            this.checkTable.Size = new System.Drawing.Size(72, 16);
            this.checkTable.TabIndex = 14;
            this.checkTable.Text = "显示表格";
            this.checkTable.UseVisualStyleBackColor = true;
            this.checkTable.CheckedChanged += new System.EventHandler(this.selectinfoCombox);
            // 
            // infoComBox
            // 
            this.infoComBox.FormattingEnabled = true;
            this.infoComBox.Items.AddRange(new object[] {
            "一级压力",
            "一级温度",
            "二级压力",
            "二级温度",
            "主机输出频率",
            "主机输出电压",
            "主机输出电流",
            "主机输出功率",
            "整机使用电量",
            "整机使用排气量",
            "冷却风机频率",
            "冷却风机电流",
            "运行累计时间",
            "负载累计时间"});
            this.infoComBox.Location = new System.Drawing.Point(224, 12);
            this.infoComBox.Name = "infoComBox";
            this.infoComBox.Size = new System.Drawing.Size(125, 20);
            this.infoComBox.TabIndex = 13;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(186, 15);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(41, 12);
            this.info.TabIndex = 12;
            this.info.Text = "项目：";
            // 
            // craneidComBox
            // 
            this.craneidComBox.FormattingEnabled = true;
            this.craneidComBox.Location = new System.Drawing.Point(83, 12);
            this.craneidComBox.Name = "craneidComBox";
            this.craneidComBox.Size = new System.Drawing.Size(97, 20);
            this.craneidComBox.TabIndex = 11;
            this.craneidComBox.SelectedIndexChanged += new System.EventHandler(this.craneidComBox_SelectedIndexChanged);
            // 
            // GetTable_button
            // 
            this.GetTable_button.Location = new System.Drawing.Point(910, 10);
            this.GetTable_button.Name = "GetTable_button";
            this.GetTable_button.Size = new System.Drawing.Size(75, 23);
            this.GetTable_button.TabIndex = 10;
            this.GetTable_button.Text = "导出";
            this.GetTable_button.UseVisualStyleBackColor = true;
            this.GetTable_button.Click += new System.EventHandler(this.GetTable_button_Click);
            // 
            // End_TextBox
            // 
            this.End_TextBox.Location = new System.Drawing.Point(612, 12);
            this.End_TextBox.Name = "End_TextBox";
            this.End_TextBox.Size = new System.Drawing.Size(109, 21);
            this.End_TextBox.TabIndex = 3;
            this.End_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.End_TextBox_KeyPress);
            // 
            // Begin_TextBox
            // 
            this.Begin_TextBox.Location = new System.Drawing.Point(421, 12);
            this.Begin_TextBox.Name = "Begin_TextBox";
            this.Begin_TextBox.Size = new System.Drawing.Size(109, 21);
            this.Begin_TextBox.TabIndex = 2;
            this.Begin_TextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Begin_TextBox_KeyPress);
            // 
            // Search_Button
            // 
            this.Search_Button.Location = new System.Drawing.Point(829, 10);
            this.Search_Button.Name = "Search_Button";
            this.Search_Button.Size = new System.Drawing.Size(75, 23);
            this.Search_Button.TabIndex = 4;
            this.Search_Button.Text = "查询";
            this.Search_Button.UseVisualStyleBackColor = true;
            this.Search_Button.Click += new System.EventHandler(this.Search_Button_Click);
            // 
            // End_TimePicker
            // 
            this.End_TimePicker.Location = new System.Drawing.Point(612, 12);
            this.End_TimePicker.Name = "End_TimePicker";
            this.End_TimePicker.Size = new System.Drawing.Size(124, 21);
            this.End_TimePicker.TabIndex = 9;
            this.End_TimePicker.CloseUp += new System.EventHandler(this.End_TimePicker_CloseUp);
            // 
            // Begin_TimePicker
            // 
            this.Begin_TimePicker.Location = new System.Drawing.Point(421, 12);
            this.Begin_TimePicker.Name = "Begin_TimePicker";
            this.Begin_TimePicker.Size = new System.Drawing.Size(124, 21);
            this.Begin_TimePicker.TabIndex = 8;
            this.Begin_TimePicker.CloseUp += new System.EventHandler(this.Begin_TimePicker_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(551, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "结束时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "起始时间：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "设备名称：";
            // 
            // DataChart
            // 
            this.DataChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.DataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.DataChart.Legends.Add(legend1);
            this.DataChart.Location = new System.Drawing.Point(0, 46);
            this.DataChart.Name = "DataChart";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.DataChart.Series.Add(series1);
            this.DataChart.Size = new System.Drawing.Size(1166, 684);
            this.DataChart.TabIndex = 2;
            this.DataChart.Text = "chart1";
            // 
            // DataView
            // 
            this.DataView.AllowUserToAddRows = false;
            this.DataView.AllowUserToDeleteRows = false;
            this.DataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gboxid,
            this.crane_info,
            this.area,
            this.check_time,
            this.D5998,
            this.D5999,
            this.D6000,
            this.D6001,
            this.D6002,
            this.D6003,
            this.D6004,
            this.D6005,
            this.D6006,
            this.D6007,
            this.D6008,
            this.D6009,
            this.D6010,
            this.D6011});
            this.DataView.Location = new System.Drawing.Point(0, 46);
            this.DataView.Name = "DataView";
            this.DataView.ReadOnly = true;
            this.DataView.RowHeadersVisible = false;
            this.DataView.RowTemplate.Height = 23;
            this.DataView.Size = new System.Drawing.Size(1166, 684);
            this.DataView.TabIndex = 3;
            this.DataView.Visible = false;
            // 
            // gboxid
            // 
            this.gboxid.DataPropertyName = "gboxid";
            this.gboxid.HeaderText = "GboxID";
            this.gboxid.Name = "gboxid";
            this.gboxid.ReadOnly = true;
            // 
            // crane_info
            // 
            this.crane_info.DataPropertyName = "crane_info";
            this.crane_info.HeaderText = "设备名称";
            this.crane_info.Name = "crane_info";
            this.crane_info.ReadOnly = true;
            // 
            // area
            // 
            this.area.DataPropertyName = "area";
            this.area.HeaderText = "所在区域";
            this.area.Name = "area";
            this.area.ReadOnly = true;
            // 
            // check_time
            // 
            this.check_time.DataPropertyName = "check_time";
            this.check_time.HeaderText = "采集时间";
            this.check_time.Name = "check_time";
            this.check_time.ReadOnly = true;
            // 
            // D5998
            // 
            this.D5998.DataPropertyName = "D5998";
            this.D5998.HeaderText = "一级压力";
            this.D5998.Name = "D5998";
            this.D5998.ReadOnly = true;
            // 
            // D5999
            // 
            this.D5999.DataPropertyName = "D5999";
            this.D5999.HeaderText = "一级温度";
            this.D5999.Name = "D5999";
            this.D5999.ReadOnly = true;
            // 
            // D6000
            // 
            this.D6000.DataPropertyName = "D6000";
            this.D6000.HeaderText = "二级压力";
            this.D6000.Name = "D6000";
            this.D6000.ReadOnly = true;
            // 
            // D6001
            // 
            this.D6001.DataPropertyName = "D6001";
            this.D6001.HeaderText = "二级温度";
            this.D6001.Name = "D6001";
            this.D6001.ReadOnly = true;
            // 
            // D6002
            // 
            this.D6002.DataPropertyName = "D6002";
            this.D6002.HeaderText = "主机输出频率";
            this.D6002.Name = "D6002";
            this.D6002.ReadOnly = true;
            this.D6002.Width = 120;
            // 
            // D6003
            // 
            this.D6003.DataPropertyName = "D6003";
            this.D6003.HeaderText = "主机输出电压";
            this.D6003.Name = "D6003";
            this.D6003.ReadOnly = true;
            this.D6003.Width = 120;
            // 
            // D6004
            // 
            this.D6004.DataPropertyName = "D6004";
            this.D6004.HeaderText = "主机输出电流";
            this.D6004.Name = "D6004";
            this.D6004.ReadOnly = true;
            this.D6004.Width = 120;
            // 
            // D6005
            // 
            this.D6005.DataPropertyName = "D6005";
            this.D6005.HeaderText = "主机输出功率";
            this.D6005.Name = "D6005";
            this.D6005.ReadOnly = true;
            this.D6005.Width = 120;
            // 
            // D6006
            // 
            this.D6006.DataPropertyName = "D6006";
            this.D6006.HeaderText = "整机使用电量";
            this.D6006.Name = "D6006";
            this.D6006.ReadOnly = true;
            this.D6006.Width = 120;
            // 
            // D6007
            // 
            this.D6007.DataPropertyName = "D6007";
            this.D6007.HeaderText = "整机使用排气量";
            this.D6007.Name = "D6007";
            this.D6007.ReadOnly = true;
            this.D6007.Width = 130;
            // 
            // D6008
            // 
            this.D6008.DataPropertyName = "D6008";
            this.D6008.HeaderText = "冷却风机频率";
            this.D6008.Name = "D6008";
            this.D6008.ReadOnly = true;
            this.D6008.Width = 120;
            // 
            // D6009
            // 
            this.D6009.DataPropertyName = "D6009";
            this.D6009.HeaderText = "冷却风机电流";
            this.D6009.Name = "D6009";
            this.D6009.ReadOnly = true;
            this.D6009.Width = 120;
            // 
            // D6010
            // 
            this.D6010.DataPropertyName = "D6010";
            this.D6010.HeaderText = "运行累计时间";
            this.D6010.Name = "D6010";
            this.D6010.ReadOnly = true;
            this.D6010.Width = 120;
            // 
            // D6011
            // 
            this.D6011.DataPropertyName = "D6011";
            this.D6011.HeaderText = "负载累计时间";
            this.D6011.Name = "D6011";
            this.D6011.ReadOnly = true;
            this.D6011.Width = 120;
            // 
            // SearchAlarmData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 730);
            this.Controls.Add(this.DataView);
            this.Controls.Add(this.SearchPanel);
            this.Controls.Add(this.DataChart);
            this.Name = "SearchAlarmData";
            this.Text = "查询历史数据";
            this.Load += new System.EventHandler(this.SearchAlarmData_Load);
            this.SearchPanel.ResumeLayout(false);
            this.SearchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel SearchPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker Begin_TimePicker;
        private System.Windows.Forms.DateTimePicker End_TimePicker;
        private System.Windows.Forms.Button Search_Button;
        private System.Windows.Forms.TextBox Begin_TextBox;
        private System.Windows.Forms.TextBox End_TextBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart DataChart;
        private System.Windows.Forms.Button GetTable_button;
        private System.Windows.Forms.SaveFileDialog saveexcel;
        private System.Windows.Forms.ComboBox craneidComBox;
        private System.Windows.Forms.ComboBox infoComBox;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.DataGridView DataView;
        private System.Windows.Forms.CheckBox checkTable;
        private System.Windows.Forms.Button savechart_button;
        private System.Windows.Forms.SaveFileDialog savechart;
        private System.Windows.Forms.DataGridViewTextBoxColumn gboxid;
        private System.Windows.Forms.DataGridViewTextBoxColumn crane_info;
        private System.Windows.Forms.DataGridViewTextBoxColumn area;
        private System.Windows.Forms.DataGridViewTextBoxColumn check_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn D5998;
        private System.Windows.Forms.DataGridViewTextBoxColumn D5999;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6000;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6001;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6002;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6003;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6004;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6005;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6006;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6007;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6008;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6009;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6010;
        private System.Windows.Forms.DataGridViewTextBoxColumn D6011;
        private System.Windows.Forms.Button getalarmdata;
    }
}