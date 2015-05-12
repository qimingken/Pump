namespace pump
{
    partial class Password
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CurrentPW_TextBox = new System.Windows.Forms.TextBox();
            this.NewPW_TextBox = new System.Windows.Forms.TextBox();
            this.ConPW_TextBox = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前密码：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "新密码确认：";
            // 
            // CurrentPW_TextBox
            // 
            this.CurrentPW_TextBox.Location = new System.Drawing.Point(100, 19);
            this.CurrentPW_TextBox.Name = "CurrentPW_TextBox";
            this.CurrentPW_TextBox.PasswordChar = '*';
            this.CurrentPW_TextBox.Size = new System.Drawing.Size(100, 21);
            this.CurrentPW_TextBox.TabIndex = 3;
            // 
            // NewPW_TextBox
            // 
            this.NewPW_TextBox.Location = new System.Drawing.Point(100, 48);
            this.NewPW_TextBox.Name = "NewPW_TextBox";
            this.NewPW_TextBox.PasswordChar = '*';
            this.NewPW_TextBox.Size = new System.Drawing.Size(100, 21);
            this.NewPW_TextBox.TabIndex = 4;
            // 
            // ConPW_TextBox
            // 
            this.ConPW_TextBox.Location = new System.Drawing.Point(100, 77);
            this.ConPW_TextBox.Name = "ConPW_TextBox";
            this.ConPW_TextBox.PasswordChar = '*';
            this.ConPW_TextBox.Size = new System.Drawing.Size(100, 21);
            this.ConPW_TextBox.TabIndex = 5;
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(38, 121);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 6;
            this.OK.Text = "确定";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(119, 121);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 7;
            this.Cancel.Text = "取消";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Password
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 162);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.ConPW_TextBox);
            this.Controls.Add(this.NewPW_TextBox);
            this.Controls.Add(this.CurrentPW_TextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Password";
            this.Text = "设置密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CurrentPW_TextBox;
        private System.Windows.Forms.TextBox NewPW_TextBox;
        private System.Windows.Forms.TextBox ConPW_TextBox;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Button Cancel;
    }
}