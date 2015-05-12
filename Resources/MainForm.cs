using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using ModbusCom;
using System.Runtime.InteropServices;

namespace Crane
{
    public partial class MainForm : Form
    {
        SQL sqlit = new SQL();
        Dictionary<string, Thread> ThreadDictonary = new Dictionary<string, Thread>();
        Monitor monitor = new Monitor();
        Loading load = new Loading();

        DisplaynowForm _displaynowform;
        CraneinfoForm _craneinfoForm;
        DisplayData _displaydata;
        Alarm _Alarm;


        public static Thread displaythread;
        public static Thread loading;
        public static Modbus displaynow = new Modbus();

        public MainForm()
        {
            InitializeComponent();
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            sqlit.Cancel();
            #region SendMessage方法实例化
            Monitor.pForm = (IntPtr)this.Handle;
            #endregion
            FillTree(null, null);
            Craneinfo_panel.Controls.Clear();
            //sqlit.Deleterecord();
        }

        private void showloading()
        {
            Thread.Sleep(50);
            load.ShowDialog();
        }
        //填充TreeView
        public void FillTree(object sender, EventArgs e)
        {
            crane_tree.Nodes.Clear();
            DataSet ds = sqlit.Filltree();
            TreeNode root = new TreeNode("空压机信息");
            root.Name = "空压机信息";
            crane_tree.Nodes.Add(root);
            TreeNode selectnode = null;
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                TreeNode node = new TreeNode(row["area"].ToString());
                TreeNode childnode = new TreeNode(row["crane_info"].ToString());
                string gboxid = row["gboxid"].ToString();

                node.Name = row["area"].ToString();
                childnode.Name = row["crane_info"].ToString();
                if (!root.Nodes.ContainsKey(node.Name))
                {
                    root.Nodes.Add(node);
                }
                foreach (TreeNode pNode in root.Nodes)
                {
                    if (pNode.Name == node.Name)
                    {
                        pNode.Nodes.Add(childnode);
                        if (childnode.Name == Global.crane_info)
                        {
                            selectnode = childnode;
                        }
                        if (ThreadDictonary.ContainsKey(childnode.Name) == false)
                        {
                            string[] par = new string[2];
                            par[0] = gboxid;
                            par[1] = childnode.Name;
                            Thread newThread = new Thread(new ParameterizedThreadStart(monitor.MonitorMethd));
                            newThread.IsBackground = true;
                            newThread.Start(par);
                            ThreadDictonary.Add(childnode.Name, newThread);
                        }
                    }
                }
            }
            this.crane_tree.Nodes[0].Expand();
            if (selectnode != null)
            {
                crane_tree.SelectedNode = selectnode;
            }
        }

        public void cancelit(object sender, EventArgs e)
        {
            sqlit.Conn.Open();
            string selectlogin = "select login from password";
            SqlCommand _selectlogin = new SqlCommand(selectlogin, sqlit.Conn);
            bool res = Convert.ToBoolean(_selectlogin.ExecuteScalar());
            sqlit.Conn.Close();
            if (res == true)
            {
                FillTree(null,null);
                //this.crane_tree.SelectedNode = null;
                管理员模式ToolStripMenuItem.Text = "注销";
            }
        }

        //配置菜单事件
        public void config_menu_Click(object sender, EventArgs e)
        {
            CraneinfoForm infoForm = new CraneinfoForm();
            infoForm.insinfo_button.Location = new Point(294, 600);
            infoForm.cancel_button.Location = new Point(439, 600);
            infoForm.FormClosed += new FormClosedEventHandler(FillTree);
            infoForm.ShowDialog();
        }

        public void crane_tree_AfterSelect(object sender, TreeViewEventArgs e)//节点信息显示
        {
            if (crane_tree.SelectedNode.Level == 2)
            {
                if (_displaynowform != null)
                {
                    _displaynowform.Close();
                }

                if (_displaydata != null)
                {
                    _displaydata.Close();
                }

                if (_craneinfoForm == null || _craneinfoForm.IsDisposed)
                {
                    _craneinfoForm = new CraneinfoForm();
                }
                Craneinfo_panel.Controls.Clear();
                _craneinfoForm.TopLevel = false;
                Craneinfo_panel.Controls.Add(_craneinfoForm);
                _craneinfoForm.cancel_button.Visible = false;
                _craneinfoForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                foreach (Control c in _craneinfoForm.Controls)
                {
                    if (c is TextBox)
                    {
                        ((TextBox)c).ReadOnly = true;
                    }
                }
                _craneinfoForm.Show();

                Craneinfo_panel.Controls.Add(displaynow_button);
                displaynow_button.BringToFront();

                Craneinfo_panel.Controls.Add(searchalarm_button);
                searchalarm_button.BringToFront();

                Craneinfo_panel.Controls.Add(displaydata_button);
                displaydata_button.BringToFront();

                Craneinfo_panel.Controls.Add(craneinfoshow_button);
                craneinfoshow_button.BringToFront();
                craneinfoshow_button.Visible = false;

                Craneinfo_panel.Controls.Add(close_button);
                close_button.BringToFront();

                _craneinfoForm.insinfo_button.Text = "编辑";
                Global.crane_info = crane_tree.SelectedNode.Name;//赋值crane_info到全局变量
                string[] craneinfo = sqlit.SelectCraneinfo();
                _craneinfoForm.area_ComboBox.Text = craneinfo[0];//赋值area到全局变量       //读取数据库到控件
                _craneinfoForm.crane_info_TextBox.Text = craneinfo[1];
                Global.gboxid = _craneinfoForm.gboxid_TextBox.Text = craneinfo[2];//赋值GboxID到全局变量
                _craneinfoForm.crane_type_TextBox.Text = craneinfo[3];
                _craneinfoForm.factory_date_picker.Text = craneinfo[4];
                _craneinfoForm.factory_num_TextBox.Text = craneinfo[5];
                _craneinfoForm.project_place_TextBox.Text = craneinfo[6];
                _craneinfoForm.project_name_TextBox.Text = craneinfo[7];
                _craneinfoForm.install_comp_TextBox.Text = craneinfo[8];
                _craneinfoForm.use_comp_TextBox.Text = craneinfo[9];
                _craneinfoForm.check_comp_TextBox.Text = craneinfo[10];
                _craneinfoForm.install_date_picker.Text = craneinfo[11];
                _craneinfoForm.install_qualified_ComboBox.Text = craneinfo[12];
                _craneinfoForm.install_checkdate_picker.Text = craneinfo[13];
                _craneinfoForm.mid_checkdate_picker.Text = craneinfo[14];
                _craneinfoForm.mid_check_qualified_Combobox.Text = craneinfo[15];
                _craneinfoForm.final_checkdate_picker.Text = craneinfo[16];
                _craneinfoForm.unstall_result_TextBox.Text = craneinfo[17];
                _craneinfoForm.remark1_TextBox.Text = craneinfo[18];
                _craneinfoForm.remark2_TextBox.Text = craneinfo[19];
                _craneinfoForm.maincharge_TextBox.Text = craneinfo[20];
                _craneinfoForm.maincharge_phone_TextBox.Text = craneinfo[21];
                _craneinfoForm.safecharge_TextBox.Text = craneinfo[22];
                _craneinfoForm.safecharge_phone_TextBox.Text = craneinfo[23];
                _craneinfoForm.driver_TextBox.Text = craneinfo[24];
                _craneinfoForm.driver_license_TextBox.Text = craneinfo[25];
                _craneinfoForm.driver_phone_TextBox.Text = craneinfo[26];

                _craneinfoForm.area_TextBox.Text = _craneinfoForm.area_ComboBox.Text;
                _craneinfoForm.area_TextBox.Visible = true;

                _craneinfoForm.factory_date_TextBox.Text = _craneinfoForm.factory_date_picker.Text;
                _craneinfoForm.factory_date_TextBox.Visible = true;

                _craneinfoForm.install_date_TextBox.Text = _craneinfoForm.install_date_picker.Text;
                _craneinfoForm.install_date_TextBox.Visible = true;

                _craneinfoForm.install_qualified_TextBox.Text = _craneinfoForm.install_qualified_ComboBox.Text;
                _craneinfoForm.install_qualified_TextBox.Visible = true;

                _craneinfoForm.mid_checkdate_TextBox.Text = _craneinfoForm.mid_checkdate_picker.Text;
                _craneinfoForm.mid_checkdate_TextBox.Visible = true;

                _craneinfoForm.mid_check_qualified_TextBox.Text = _craneinfoForm.mid_check_qualified_Combobox.Text;
                _craneinfoForm.mid_check_qualified_TextBox.Visible = true;

                _craneinfoForm.install_checkdate_TextBox.Text = _craneinfoForm.install_checkdate_picker.Text;
                _craneinfoForm.install_checkdate_TextBox.Visible = true;

                _craneinfoForm.final_checkdate_TextBox.Text = _craneinfoForm.final_checkdate_picker.Text;
                _craneinfoForm.final_checkdate_TextBox.Visible = true;
            }
            else
            {
                if (_displaynowform != null)
                {
                    _displaynowform.Close();
                }

                if (_displaydata != null)
                {
                    _displaydata.Close();
                }

                if (_craneinfoForm != null)
                {
                    _craneinfoForm.Close();
                }

                if (_Alarm != null)
                {
                    _Alarm.Close();
                }

                this.Craneinfo_panel.Controls.Clear();
            }

        }

        //选中节点弹出菜单
        public void crane_tree_MouseClick(object sender, MouseEventArgs e)
        {
            crane_tree.SelectedNode = crane_tree.GetNodeAt(e.Location);
            if (e.Button == MouseButtons.Right)
            {
                if (crane_tree.SelectedNode.Level == 2)
                {
                    Global.crane_info = crane_tree.SelectedNode.Name;
                    nodeedit_MenuStrip.Show(crane_tree, e.Location);
                }
                else if (crane_tree.SelectedNode.Level == 1)
                {
                    nodeadd_MenuStrip.Show(crane_tree, e.Location);
                }
            }
        }

        //菜单功能
        public void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            config_menu_Click(null, null);
        }

        public void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "此操作将删除与该空压机相关的报警设定值、自检值、报警历史记录，确认删除？", "删除提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ThreadDictonary[crane_tree.SelectedNode.Name].Abort();
                while (ThreadDictonary[crane_tree.SelectedNode.Name].IsAlive || ThreadDictonary[crane_tree.SelectedNode.Name] != null)
                {
                    if (!ThreadDictonary[crane_tree.SelectedNode.Name].IsAlive || ThreadDictonary[crane_tree.SelectedNode.Name] == null)
                    {
                        sqlit.DelCrane();
                        ThreadDictonary.Remove(crane_tree.SelectedNode.Name);
                        crane_tree.SelectedNode.Remove();
                        break;
                    }
                }
            }
        }



        private void craneinfoshow_button_Click(object sender, EventArgs e)
        {
            crane_tree_AfterSelect(null, null);
        }

        private void displaynow_button_Click(object sender, EventArgs e)
        {

            if (_displaydata != null)
            {
                _displaydata.Close();
            }

            if (_craneinfoForm != null)
            {
                _craneinfoForm.Close();
            }

            if (_Alarm != null)
            {
                _Alarm.Close();
            }

            if (_displaynowform == null || _displaynowform.IsDisposed)
            {
                _displaynowform = new DisplaynowForm();
                Craneinfo_panel.Controls.Clear();
                _displaynowform.TopLevel = false;
                Craneinfo_panel.Controls.Add(_displaynowform);
                _displaynowform.Show();

                while (true)
                {

                    if (displaythread == null || !(displaythread.IsAlive))
                    {
                        displaythread = new Thread(_displaynowform.display);
                        displaythread.IsBackground = true;
                        displaythread.Start();
                        break;
                    }
                }


                Craneinfo_panel.Controls.Add(displaynow_button);
                displaynow_button.BringToFront();

                Craneinfo_panel.Controls.Add(searchalarm_button);
                searchalarm_button.BringToFront();

                Craneinfo_panel.Controls.Add(craneinfoshow_button);
                craneinfoshow_button.BringToFront();
                craneinfoshow_button.Visible = true;

                Craneinfo_panel.Controls.Add(displaydata_button);
                displaydata_button.BringToFront();

                Craneinfo_panel.Controls.Add(close_button);
                close_button.BringToFront();
            }

        }

        private void displaydata_button_Click(object sender, EventArgs e)
        {
            if (_displaynowform != null)
            {
                _displaynowform.Close();
            }

            if (_craneinfoForm != null)
            {
                _craneinfoForm.Close();
            }

            if (_Alarm != null)
            {
                _Alarm.Close();
            }

            if (_displaydata == null || _displaydata.IsDisposed)
            {
                _displaydata = new DisplayData();
                Craneinfo_panel.Controls.Clear();
                _displaydata.TopLevel = false;
                Craneinfo_panel.Controls.Add(_displaydata);
                _displaydata.Show();

                while (true)
                {
                    if (displaythread == null || !(displaythread.IsAlive))
                    {
                        displaythread = new Thread(_displaydata.display);
                        displaythread.IsBackground = true;
                        displaythread.Start();
                        break;
                    }
                }


                Craneinfo_panel.Controls.Add(displaynow_button);
                displaynow_button.BringToFront();

                Craneinfo_panel.Controls.Add(searchalarm_button);
                searchalarm_button.BringToFront();

                Craneinfo_panel.Controls.Add(craneinfoshow_button);
                craneinfoshow_button.BringToFront();
                craneinfoshow_button.Visible = true;

                Craneinfo_panel.Controls.Add(displaydata_button);
                displaydata_button.BringToFront();
                displaydata_button.Visible = true;

                Craneinfo_panel.Controls.Add(close_button);
                close_button.BringToFront();
            }
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            if (_displaynowform != null)
            {
                _displaynowform.Close();
            }

            if (_craneinfoForm != null)
            {
                _craneinfoForm.Close();
            }

            if (_Alarm != null)
            {
                _Alarm.Close();
            }

            this.Craneinfo_panel.Controls.Clear();
            crane_tree.SelectedNode = null;
        }

        private void nodecolor(string compnode, int b, TreeNodeCollection TreeNodes)//改变节点颜色
        {
            foreach (TreeNode Tnode in TreeNodes)
            {
                if (Tnode.Name == compnode)
                {
                    switch (b)
                    {

                        case 0:
                            {
                                Tnode.ForeColor = System.Drawing.Color.Black;
                                Tnode.Parent.ForeColor = System.Drawing.Color.Black;
                                break;
                            }
                        case 1:
                            {
                                Tnode.ForeColor = System.Drawing.Color.LightGray;
                                break;
                            }
                        case 2:
                            {
                                Tnode.ForeColor = System.Drawing.Color.Red;
                                Tnode.Parent.ForeColor = System.Drawing.Color.Red;
                                break;
                            }
                    }
                }

                if (Tnode.Nodes.Count > 0)
                {
                    nodecolor(compnode, b, Tnode.Nodes);
                }

            }
        }

        #region 接受SendMessage消息 响应改变TreeView状态
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x400:
                    {
                        string a = Marshal.PtrToStringAnsi(m.LParam);
                        int b = (int)m.WParam;
                        nodecolor(a, b, crane_tree.Nodes);
                        break;
                    }
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
        #endregion

        private void 报警查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchAlarmData searchAlarmdata = new SearchAlarmData();
            searchAlarmdata.Show();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }

        private void 设置密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Password password = new Password();
            password.Show();
        }

        private void 管理员模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (管理员模式ToolStripMenuItem.Text == "管理员模式")
            {
                Login login = new Login();
                login.Show();
                login.FormClosed += new FormClosedEventHandler(cancelit);
            }
            else if (管理员模式ToolStripMenuItem.Text == "注销")
            {
                sqlit.Cancel();
                sqlit.Conn.Open();
                string selectlogin = "select login from password";
                SqlCommand _selectlogin = new SqlCommand(selectlogin, sqlit.Conn);
                bool res = Convert.ToBoolean(_selectlogin.ExecuteScalar());
                sqlit.Conn.Close();
                if (res == false)
                {
                    MessageBox.Show("注销成功！");
                    FillTree(null,null);
                    //this.crane_tree.SelectedNode = null;
                    管理员模式ToolStripMenuItem.Text = "管理员模式";
                }
            }
            
        }

        private void searchalarm_button_Click(object sender, EventArgs e)
        {
            if (_displaydata != null)
            {
                _displaydata.Close();
            }

            if (_craneinfoForm != null)
            {
                _craneinfoForm.Close();
            }

            if (_displaynowform != null)
            {
                _displaynowform.Close();
            }

            if (_Alarm != null)
            {
                _Alarm.Close();
            }

            if (_Alarm == null || _Alarm.IsDisposed)
            {
                _Alarm = new Alarm();
                Craneinfo_panel.Controls.Clear();
                _Alarm.TopLevel = false;
                Craneinfo_panel.Controls.Add(_Alarm);
                _Alarm.Show();
                
                Craneinfo_panel.Controls.Add(displaynow_button);
                displaynow_button.BringToFront();

                Craneinfo_panel.Controls.Add(searchalarm_button);
                searchalarm_button.BringToFront();

                Craneinfo_panel.Controls.Add(craneinfoshow_button);
                craneinfoshow_button.BringToFront();
                craneinfoshow_button.Visible = true;

                Craneinfo_panel.Controls.Add(displaydata_button);
                displaydata_button.BringToFront();
                displaydata_button.Visible = true;

                Craneinfo_panel.Controls.Add(close_button);
                close_button.BringToFront();
            }
        }
    }
}