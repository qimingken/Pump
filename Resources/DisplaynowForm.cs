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

namespace Crane
{
    public partial class DisplaynowForm : Form
    {
        public DisplaynowForm()
        {
            InitializeComponent();
        }

        public IntPtr displayForm;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        Modbus displaynow = MainForm.displaynow;
        int[] run = new int[10];
        short[] runstatus = new short[18];
        private void DisplaynowForm_Load(object sender, EventArgs e)
        {
            ModbusCom.ErrCodeEnum err;
            err = ErrCodeEnum.UDPTimeout;
            displaynow.CommMode = CommModeEnum.UDP;
            displaynow.CommDevice = CommDeviceEnum.GBOX;
            displaynow.ServerIP = "61.160.67.86";
            //displaynow.ServerIP = "127.0.0.1";
            displaynow.ServerPoint = 502;
            displaynow.InitialNetWorkPort("Display", "12345678", Global.crane_info, Global.gboxid);
            displayForm = (IntPtr)this.Handle;
            nowtime_lab.Text = DateTime.Now.ToString();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
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
            D5998_lab.Text = (runstatus[4] * 1.00F / 100).ToString() + "Mpa";//供气系统压力
            D5999_lab.Text = runstatus[5].ToString() + "℃";//排气温度
            D6000_lab.Text = (runstatus[6] * 1.00F / 100).ToString() + "Mpa";//供气系统压力
            D6001_lab.Text = runstatus[7].ToString()+"℃";//排气温度
            D6002_lab.Text = (runstatus[8] * 1.0F / 10).ToString()+"Hz";//主机输出频率
            D6003_lab.Text = runstatus[9].ToString() + "V";//主机输出电压
            D6004_lab.Text = (runstatus[10] * 1.0F / 10).ToString() + "A";//主机输出电流
            D6005_lab.Text = (runstatus[11] * 1.00F / 100).ToString() + "kW";//主机输出功率
            D6006_lab.Text = (runstatus[12] * 1.00F / 100).ToString() + "kWH";//整机使用电量
            D6007_lab.Text = (runstatus[13] * 1.00F / 100).ToString() + "m³";//整机使用排气量
            D6008_lab.Text = (runstatus[14] * 1.0F / 10).ToString() + "Hz";//冷却风机频率
            D6009_lab.Text = (runstatus[15] * 1.0F / 10).ToString() + "A";//冷却风机电流
            D6010_lab.Text = runstatus[16].ToString() + "h";//运行累计时间
            D6011_lab.Text = runstatus[17].ToString() + "h";//负载累计时间
            
            if (run[0] == 0)
            {
                run_button.Text = "停止";
            }
            else if (run[0] == 1)
            {
                run_button.Text = "运行";
            }

            if (run[1] == 0)
            {
                runstat_lab.Text = "停止中";
            }
            else if (run[1] == 1)
            {
                runstat_lab.Text = "运行中";
            }
            if (run[2] == 0)
            {
                runstat2_lab.Text = "卸载";
            }
            else if (run[2] == 1)
            {
                runstat2_lab.Text = "装载";
            }

            if (run[3] == 1 && run[4] == 0 && run[5] == 0 && run[6] == 0 && run[7] == 0)
            {
                run_lab.Text = runstatus[0] + "s后进入休眠";
            }
            else if (run[3] == 0 && run[4] == 1 && run[5] == 0 && run[6] == 0 && run[7] == 0)
            {
                run_lab.Text = runstatus[1] + "s后开始加载";
            }
            else if (run[3] == 0 && run[4] == 0 && run[5] == 1 && run[6] == 0 && run[7] == 0)
            {
                run_lab.Text = runstatus[2] + "s后允许重新启动";
            }
            else if (run[3] == 0 && run[4] == 0 && run[5] == 0 && run[6] == 1 && run[7] == 0)
            {
                run_lab.Text = runstatus[3] + "s后停止运行";
            }
            else if (run[3] == 0 && run[4] == 0 && run[5] == 0 && run[6] == 0 && run[7] == 1)
            {
                run_lab.Text = "休眠中";
            }

            if(run[8] == 1 && run[9] == 0)
            {
                run2_lab.Text = "剩余运行时间小于24小时或已停止";
            }
            else if (run[8] == 0 && run[9] == 1)
            {
                run2_lab.Text = "剩余运行时间不足，请联系维护！";
            }


        }


        public void display()
        {
            while (true)
            {
                Thread.Sleep(1000);
                if (displaynow.Open() == ModbusCom.ErrCodeEnum.OK)
                {
                    displaynow.ModbusReadMutilCoils(1, 7000, 11, out run);                    
                    displaynow.ModbusReadMultiWORD(1, 5994, 18, out runstatus);
                    SendMessage(displayForm, 0x500, 1, 1);
                }
            }
        }

        private void DisplaynowForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MainForm.displaythread.Abort();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            nowtime_lab.Text = DateTime.Now.ToString();
        }


        private void run_button_Click(object sender, EventArgs e)
        {
            int a = 0;
            if (run_button.Text == "运行")
            {
                a = 0;
            }
            else if (run_button.Text == "停止")
            {
                a = 1;
            }
            try
            {
                displaynow.ModbusWriteSingleCoil(1, 7000, a);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败！");
            }
        }
    }
}