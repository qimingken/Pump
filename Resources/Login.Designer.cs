namespace Crane
{
    partial class Login
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
            this.PW_TextBox = new System.Windows.Forms.TextBox();
            this.Con_button = new System.Windows.Forms.Button();
            this.Cancel_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入密码：";
            // 
            // PW_TextBox
            // 
            this.PW_TextBox.Location = new System.Drawing.Point(109, 17);
            this.PW_TextBox.Name = "PW_TextBox";
            this.PW_TextBox.PasswordChar = '*';
            this.PW_TextBox.Size = new System.Drawing.Size(121, 21);
            this.PW_TextBox.TabIndex = 1;
            // 
            // Con_button
            // 
            this.Con_button.Location = new System.Drawing.Point(55, 59);
            this.Con_button.Name = "Con_button";
            this.Con_button.Size = new System.Drawing.Size(75, 23);
            this.Con_button.TabIndex = 2;
            this.Con_button.Text = "确定";
            this.Con_button.UseVisualStyleBackColor = true;
            this.Con_button.Click += new System.EventHandler(this.Con_button_Click);
            // 
            // Cancel_button
            // 
            this.Cancel_button.Location = new System.Drawing.Point(146, 59);
            this.Cancel_button.Name = "Cancel_button";
            this.Cancel_button.Size = new System.Drawing.Size(75, 23);
            this.Cancel_button.TabIndex = 3;
            this.Cancel_button.Text = "关闭";
            this.Cancel_button.UseVisualStyleBackColor = true;
            this.Cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 94);
            this.Controls.Add(this.Cancel_button);
            this.Controls.Add(this.Con_button);
            this.Controls.Add(this.PW_TextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Login";
            this.Text = "登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PW_TextBox;
        private System.Windows.Forms.Button Con_button;
        private System.Windows.Forms.Button Cancel_button;
    }
}