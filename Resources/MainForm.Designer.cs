namespace Crane
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.config_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.报警查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.管理员模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.设置密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.nodeedit_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nodeadd_MenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Craneinfo_panel = new System.Windows.Forms.Panel();
            this.displaydata_button = new System.Windows.Forms.Button();
            this.close_button = new System.Windows.Forms.Button();
            this.displaynow_button = new System.Windows.Forms.Button();
            this.craneinfoshow_button = new System.Windows.Forms.Button();
            this.crane_tree = new System.Windows.Forms.TreeView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.searchalarm_button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.nodeedit_MenuStrip.SuspendLayout();
            this.nodeadd_MenuStrip.SuspendLayout();
            this.Craneinfo_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.config_menu,
            this.报警查询ToolStripMenuItem,
            this.管理员模式ToolStripMenuItem,
            this.设置密码ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // config_menu
            // 
            this.config_menu.Checked = true;
            this.config_menu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.config_menu.Name = "config_menu";
            this.config_menu.Size = new System.Drawing.Size(68, 21);
            this.config_menu.Text = "添加设备";
            this.config_menu.Click += new System.EventHandler(this.config_menu_Click);
            // 
            // 报警查询ToolStripMenuItem
            // 
            this.报警查询ToolStripMenuItem.Name = "报警查询ToolStripMenuItem";
            this.报警查询ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.报警查询ToolStripMenuItem.Text = "查询历史记录";
            this.报警查询ToolStripMenuItem.Click += new System.EventHandler(this.报警查询ToolStripMenuItem_Click);
            // 
            // 管理员模式ToolStripMenuItem
            // 
            this.管理员模式ToolStripMenuItem.Name = "管理员模式ToolStripMenuItem";
            this.管理员模式ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.管理员模式ToolStripMenuItem.Text = "管理员模式";
            this.管理员模式ToolStripMenuItem.Click += new System.EventHandler(this.管理员模式ToolStripMenuItem_Click);
            // 
            // 设置密码ToolStripMenuItem
            // 
            this.设置密码ToolStripMenuItem.Name = "设置密码ToolStripMenuItem";
            this.设置密码ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.设置密码ToolStripMenuItem.Text = "设置密码";
            this.设置密码ToolStripMenuItem.Click += new System.EventHandler(this.设置密码ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // nodeedit_MenuStrip
            // 
            this.nodeedit_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除ToolStripMenuItem});
            this.nodeedit_MenuStrip.Name = "crane_tree_MenuStrip";
            this.nodeedit_MenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // nodeadd_MenuStrip
            // 
            this.nodeadd_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加ToolStripMenuItem});
            this.nodeadd_MenuStrip.Name = "contextMenuStrip1";
            this.nodeadd_MenuStrip.Size = new System.Drawing.Size(101, 26);
            // 
            // 添加ToolStripMenuItem
            // 
            this.添加ToolStripMenuItem.Name = "添加ToolStripMenuItem";
            this.添加ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.添加ToolStripMenuItem.Text = "添加";
            this.添加ToolStripMenuItem.Click += new System.EventHandler(this.添加ToolStripMenuItem_Click);
            // 
            // Craneinfo_panel
            // 
            this.Craneinfo_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Craneinfo_panel.Controls.Add(this.searchalarm_button);
            this.Craneinfo_panel.Controls.Add(this.displaydata_button);
            this.Craneinfo_panel.Controls.Add(this.close_button);
            this.Craneinfo_panel.Controls.Add(this.displaynow_button);
            this.Craneinfo_panel.Controls.Add(this.craneinfoshow_button);
            this.Craneinfo_panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Craneinfo_panel.Location = new System.Drawing.Point(150, 25);
            this.Craneinfo_panel.Name = "Craneinfo_panel";
            this.Craneinfo_panel.Size = new System.Drawing.Size(858, 683);
            this.Craneinfo_panel.TabIndex = 6;
            // 
            // displaydata_button
            // 
            this.displaydata_button.Location = new System.Drawing.Point(377, 600);
            this.displaydata_button.Name = "displaydata_button";
            this.displaydata_button.Size = new System.Drawing.Size(103, 32);
            this.displaydata_button.TabIndex = 5;
            this.displaydata_button.Text = "显示厂家参数";
            this.displaydata_button.UseVisualStyleBackColor = true;
            this.displaydata_button.Click += new System.EventHandler(this.displaydata_button_Click);
            // 
            // close_button
            // 
            this.close_button.Location = new System.Drawing.Point(595, 600);
            this.close_button.Name = "close_button";
            this.close_button.Size = new System.Drawing.Size(103, 32);
            this.close_button.TabIndex = 4;
            this.close_button.Text = "关闭";
            this.close_button.UseVisualStyleBackColor = true;
            this.close_button.Click += new System.EventHandler(this.close_button_Click);
            // 
            // displaynow_button
            // 
            this.displaynow_button.Location = new System.Drawing.Point(268, 600);
            this.displaynow_button.Name = "displaynow_button";
            this.displaynow_button.Size = new System.Drawing.Size(103, 32);
            this.displaynow_button.TabIndex = 1;
            this.displaynow_button.Text = "显示当前状态";
            this.displaynow_button.UseVisualStyleBackColor = true;
            this.displaynow_button.Click += new System.EventHandler(this.displaynow_button_Click);
            // 
            // craneinfoshow_button
            // 
            this.craneinfoshow_button.Location = new System.Drawing.Point(159, 600);
            this.craneinfoshow_button.Name = "craneinfoshow_button";
            this.craneinfoshow_button.Size = new System.Drawing.Size(103, 32);
            this.craneinfoshow_button.TabIndex = 0;
            this.craneinfoshow_button.Text = "显示设备参数";
            this.craneinfoshow_button.UseVisualStyleBackColor = true;
            this.craneinfoshow_button.Click += new System.EventHandler(this.craneinfoshow_button_Click);
            // 
            // crane_tree
            // 
            this.crane_tree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crane_tree.Dock = System.Windows.Forms.DockStyle.Left;
            this.crane_tree.HideSelection = false;
            this.crane_tree.Location = new System.Drawing.Point(0, 25);
            this.crane_tree.Name = "crane_tree";
            this.crane_tree.Size = new System.Drawing.Size(150, 683);
            this.crane_tree.TabIndex = 5;
            this.crane_tree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.crane_tree_AfterSelect);
            this.crane_tree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.crane_tree_MouseClick);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "空压机监控系统";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // searchalarm_button
            // 
            this.searchalarm_button.Location = new System.Drawing.Point(486, 600);
            this.searchalarm_button.Name = "searchalarm_button";
            this.searchalarm_button.Size = new System.Drawing.Size(103, 32);
            this.searchalarm_button.TabIndex = 6;
            this.searchalarm_button.Text = "查询报警";
            this.searchalarm_button.UseVisualStyleBackColor = true;
            this.searchalarm_button.Click += new System.EventHandler(this.searchalarm_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.Craneinfo_panel);
            this.Controls.Add(this.crane_tree);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "空压机监控系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.nodeedit_MenuStrip.ResumeLayout(false);
            this.nodeadd_MenuStrip.ResumeLayout(false);
            this.Craneinfo_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem config_menu;
        private System.Windows.Forms.ContextMenuStrip nodeedit_MenuStrip;
        private System.Windows.Forms.ContextMenuStrip nodeadd_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加ToolStripMenuItem;
        private System.Windows.Forms.Panel Craneinfo_panel;
        private System.Windows.Forms.TreeView crane_tree;
        private System.Windows.Forms.Button close_button;
        private System.Windows.Forms.Button displaynow_button;
        private System.Windows.Forms.Button craneinfoshow_button;
        private System.Windows.Forms.ToolStripMenuItem 报警查询ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button displaydata_button;
        private System.Windows.Forms.ToolStripMenuItem 设置密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 管理员模式ToolStripMenuItem;
        private System.Windows.Forms.Button searchalarm_button;
    }
}

