namespace pump
{
    partial class Alarm
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
            this.alarmgridview = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.alarmgridview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // alarmgridview
            // 
            this.alarmgridview.AllowUserToAddRows = false;
            this.alarmgridview.AllowUserToDeleteRows = false;
            this.alarmgridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alarmgridview.BackgroundColor = System.Drawing.SystemColors.Window;
            this.alarmgridview.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.alarmgridview.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.alarmgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.alarmgridview.Location = new System.Drawing.Point(6, 20);
            this.alarmgridview.Name = "alarmgridview";
            this.alarmgridview.ReadOnly = true;
            this.alarmgridview.RowHeadersVisible = false;
            this.alarmgridview.RowTemplate.Height = 23;
            this.alarmgridview.Size = new System.Drawing.Size(818, 531);
            this.alarmgridview.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.alarmgridview);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(830, 557);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "报警历史";
            // 
            // Alarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 645);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Alarm";
            this.Text = "Alarm";
            this.Load += new System.EventHandler(this.Alarm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alarmgridview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView alarmgridview;
        private System.Windows.Forms.GroupBox groupBox1;


    }
}