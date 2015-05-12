using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using ModbusCom;
using System.Threading;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace pump
{
    public partial class DisplayData : Form
    {
        public DisplayData()
        {
            InitializeComponent();
        }

        public IntPtr displaydataForm;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        Modbus displaynow = MainForm.displaynow;
        int[] alarm = new int[14];
        short[] runstatus = new short[14];
        SQL sqlit = new SQL();
        private void DisplayData_Load(object sender, EventArgs e)
        {
            ModbusCom.ErrCodeEnum err;
            err = ErrCodeEnum.UDPTimeout;
            displaynow.CommMode = CommModeEnum.UDP;
            displaynow.CommDevice = CommDeviceEnum.GBOX;
            displaynow.ServerIP = "61.160.67.86";
            //displaynow.ServerIP = "127.0.0.1";
            displaynow.ServerPoint = 502;
            displaynow.InitialNetWorkPort("Display", "12345678", Global.crane_info, Global.gboxid);
            displaydataForm = (IntPtr)this.Handle;
            nowtime_lab.Text = DateTime.Now.ToString();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
            findtextbox(this);
        }

        private void findtextbox(Control control)
        {
            sqlit.Conn.Open();
            string selectlogin = "select login from password";
            SqlCommand _selectlogin = new SqlCommand(selectlogin, sqlit.Conn);
            bool res = Convert.ToBoolean(_selectlogin.ExecuteScalar());
            sqlit.Conn.Close();
            foreach (Control c in control.Controls)
            {
                if (c is Panel)
                {
                    findtextbox(c);
                }
                if (c is GroupBox)
                {
                    findtextbox(c);
                }
                if (c is TextBox || c is Button)
                {
                    if (res == false)
                    {
                        c.Enabled = false;
                    }
                    else
                    {
                        c.Enabled = true;
                    }
                }
            }
        } 

        #region 接受SendMessage消息 响应改变y状态
        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x500:
                    {
                        displayit(runstatus);
                        break;
                    }
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }
        #endregion

        public void displayit(short[] runstatus)
        {
            D6012_lab.Text = (runstatus[0] * 1.00F /100).ToString()+"Mpa";//加载压力
            D6013_lab.Text = (runstatus[1] * 1.00F / 100).ToString() + "Mpa";//卸载压力
            D6014_lab.Text = (runstatus[2] * 1.00F / 100).ToString() + "Mpa";//目标压力
            D6015_lab.Text = (runstatus[3] * 1.0F / 10).ToString() + "Hz";//预运行频率
            D6016_lab.Text = (runstatus[4] * 1.0F / 10).ToString() + "Hz";//空载频率
            D6017_lab.Text = runstatus[5].ToString() + "s";//延时加载时间
            D6018_lab.Text = runstatus[6].ToString() + "s";//停机加载时间
            D6019_lab.Text = runstatus[7].ToString() + "s";//重启延时时间
            D6020_lab.Text = runstatus[8].ToString() + "s";//空载过久停机时间
            D6021_lab.Text = runstatus[9].ToString() + "s";//最小休眠时间
            D6022_lab.Text = (runstatus[10] * 1.00F / 100).ToString() + "Mpa";
            D6023_lab.Text = (runstatus[11] * 1.00F / 100).ToString() + "Mpa";
            D6024_lab.Text = runstatus[12].ToString() + "℃";
            D6025_lab.Text = runstatus[13].ToString() + "℃";
            D6026_lab.Text = "-" + (runstatus[14] * 1.00F / 100).ToString() + "Mpa";
            D6027_lab.Text = (runstatus[15] * 1.00F / 100).ToString() + "Mpa";
            D6028_lab.Text = runstatus[16].ToString() + "ms";
            D6029_lab.Text = runstatus[17].ToString() + "℃";
            D6030_lab.Text = runstatus[18].ToString() + "℃";
            D6031_lab.Text = (runstatus[19] * 1.00F / 100).ToString() + "Mpa";
            D6032_lab.Text = (runstatus[20] * 1.00F / 100).ToString() + "Mpa";
            D6033_lab.Text = runstatus[21].ToString() + "℃";
            D6034_lab.Text = (runstatus[22] * 1.00F / 100).ToString() + "Mpa";
            D6035_lab.Text = runstatus[23].ToString() + "s";
            D6036_lab.Text = runstatus[24].ToString() + "s";
            D6037_lab.Text = runstatus[25].ToString() + "℃";
            D6038_lab.Text = runstatus[26].ToString() + "℃";
            D6039_lab.Text = runstatus[27].ToString() + "%";
            D6040_lab.Text = runstatus[28].ToString();
            D6041_lab.Text = runstatus[29].ToString();
            D6042_lab.Text = runstatus[30].ToString() + "h";
            D6043_lab.Text = runstatus[31].ToString() + "℃";
            D6044_lab.Text = (runstatus[32] * 1.00F / 100).ToString() + "Mpa";

        }


        public void display()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (displaynow.Open() == ModbusCom.ErrCodeEnum.OK)
                {
                    //displaynow.ModbusReadMutilCoils(1, 100, 14, out alarm);
                    displaynow.ModbusReadMultiWORD(1, 6012, 33, out runstatus);
                    SendMessage(displaydataForm, 0x500, 1, 1);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nowtime_lab.Text = DateTime.Now.ToString();
        }

        private void DisplayData_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.displaythread.Abort();
        }

        private void D6012_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6012_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7012, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6013_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6013_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7013, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6014_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6014_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7014, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6015_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6015_textbox.Text) * 10;
                displaynow.ModbusWriteWORD(1, 7015, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6016_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6016_textbox.Text) * 10;
                displaynow.ModbusWriteWORD(1, 7016, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6017_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7017, Convert.ToInt16(D6017_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6018_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7018, Convert.ToInt16(D6018_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6019_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7019, Convert.ToInt16(D6019_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6020_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7020, Convert.ToInt16(D6020_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6021_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7021, Convert.ToInt16(D6021_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6022_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6022_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7022, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6023_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6023_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7023, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6024_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7024, Convert.ToInt16(D6024_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6025_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7025, Convert.ToInt16(D6025_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6026_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6026_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7026, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6027_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6027_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7027, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6028_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7028, Convert.ToInt16(D6028_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6029_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7029, Convert.ToInt16(D6029_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6030_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7030, Convert.ToInt16(D6030_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6031_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6031_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7031, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6032_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6032_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7032, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6033_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7033, Convert.ToInt16(D6033_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6034_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6034_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7034, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6035_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7035, Convert.ToInt16(D6035_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6036_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7036, Convert.ToInt16(D6036_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6037_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7037, Convert.ToInt16(D6037_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6038_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7038, Convert.ToInt16(D6038_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6039_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7039, Convert.ToInt16(D6039_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6040_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7040, Convert.ToInt16(D6040_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6041_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7041, Convert.ToInt16(D6041_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6042_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7042, Convert.ToInt16(D6042_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6043_button_Click(object sender, EventArgs e)
        {
            try
            {
                displaynow.ModbusWriteWORD(1, 7043, Convert.ToInt16(D6043_textbox.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }

        private void D6044_button_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(D6044_textbox.Text) * 100;
                displaynow.ModbusWriteWORD(1, 7044, (short)a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("输入格式不正确！");
            }
        }
    }
}
