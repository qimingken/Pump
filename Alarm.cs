using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pump
{
    public partial class Alarm : Form
    {
        SQL sqlit = new SQL();
        public Alarm()
        {
            InitializeComponent();
        }

        private void Alarm_Load(object sender, EventArgs e)
        {
            DataSet result = sqlit.SelectAlarmHistroy(Global.gboxid);
            DataTable a = new DataTable();
            a.Columns.Add("时间");
            a.Columns.Add("报警内容");

            for (int rowslength = 0; rowslength < result.Tables[0].Rows.Count; rowslength++)
            {
                string alarminfo = "";
                for (int cellnumber = 4; cellnumber < 62; cellnumber++)
                {
                    string tmp = result.Tables[0].Rows[rowslength][cellnumber].ToString();
                    if (tmp == "True")
                    {
                        switch (cellnumber)
                        {
                            case 4:
                                {
                                    alarminfo += "风机故障过载 ";
                                    break;
                                }
                            case 5:
                                {
                                    alarminfo += "一级压缩报警停机 ";
                                    break;
                                }
                            case 6:
                                {
                                    alarminfo += "电机过热 ";
                                    break;
                                }
                            case 7:
                                {
                                    alarminfo += "排气温度超限 ";
                                    break;
                                }
                            case 8:
                                {
                                    alarminfo += "排气压力超限 ";
                                    break;
                                }
                            case 9:
                                {
                                    alarminfo += "温度变送器故障 ";
                                    break;
                                }
                            case 10:
                                {
                                    alarminfo += "压力变送器故障 ";
                                    break;
                                }
                            case 11:
                                {
                                    alarminfo += "相序保护 ";
                                    break;
                                }
                            case 12:
                                {
                                    alarminfo += "油分堵塞 ";
                                    break;
                                }
                            case 13:
                                {
                                    alarminfo += "油滤堵塞 ";
                                    break;
                                }
                            case 14:
                                {
                                    alarminfo += "润滑脂使用超时 ";
                                    break;
                                }
                            case 15:
                                {
                                    alarminfo += "润滑油使用超时 ";
                                    break;
                                }
                            case 16:
                                {
                                    alarminfo += "空滤堵塞 ";
                                    break;
                                }
                            case 17:
                                {
                                    alarminfo += "油分超时 ";
                                    break;
                                }
                            case 18:
                                {
                                    alarminfo += "油滤超时 ";
                                    break;
                                }
                            case 19:
                                {
                                    alarminfo += "空滤超时 ";
                                    break;
                                }
                            case 20:
                                {
                                    alarminfo += "排气压力偏高 ";
                                    break;
                                }
                            case 21:
                                {
                                    alarminfo += "排气温度偏高 ";
                                    break;
                                }
                            case 22:
                                {
                                    alarminfo += "电机过热警告 ";
                                    break;
                                }
                            case 23:
                                {
                                    alarminfo += "功率卡温度过高 ";
                                    break;
                                }
                            case 24:
                                {
                                    alarminfo += "接地故障 ";
                                    break;
                                }
                            case 25:
                                {
                                    alarminfo += "过电流 ";
                                    break;
                                }
                            case 26:
                                {
                                    alarminfo += "转矩极限 ";
                                    break;
                                }
                            case 27:
                                {
                                    alarminfo += "变频器过载 ";
                                    break;
                                }
                            case 28:
                                {
                                    alarminfo += "直流欠压 ";
                                    break;
                                }
                            case 29:
                                {
                                    alarminfo += "直流过压 ";
                                    break;
                                }
                            case 30:
                                {
                                    alarminfo += "输出短路 ";
                                    break;
                                }
                            case 31:
                                {
                                    alarminfo += "电源缺相 ";
                                    break;
                                }
                            case 32:
                                {
                                    alarminfo += "变频器内部故障 ";
                                    break;
                                }
                            case 33:
                                {
                                    alarminfo += "电机U相缺相 ";
                                    break;
                                }
                            case 34:
                                {
                                    alarminfo += "电机V相缺相 ";
                                    break;
                                }
                            case 35:
                                {
                                    alarminfo += "电机W相缺相 ";
                                    break;
                                }
                            case 36:
                                {
                                    alarminfo += "VDD电压过低 ";
                                    break;
                                }
                            case 37:
                                {
                                    alarminfo += "一级压缩排气压力偏高 ";
                                    break;
                                }
                            case 38:
                                {
                                    alarminfo += "一级压缩排气压力极限 ";
                                    break;
                                }
                            case 39:
                                {
                                    alarminfo += "一级压缩压力传感器故障 ";
                                    break;
                                }
                            case 40:
                                {
                                    alarminfo += "一级压缩排气温度偏高 ";
                                    break;
                                }
                            case 41:
                                {
                                    alarminfo += "一级压缩排气温度超限 ";
                                    break;
                                }
                            case 42:
                                {
                                    alarminfo += "排气温度高 ";
                                    break;
                                }
                            case 43:
                                {
                                    alarminfo += "相序错误 ";
                                    break;
                                }
                            case 44:
                                {
                                    alarminfo += "主电机电流故障 ";
                                    break;
                                }
                            case 45:
                                {
                                    alarminfo += "空滤器堵塞 ";
                                    break;
                                }
                            case 46:
                                {
                                    alarminfo += "油分器堵塞 ";
                                    break;
                                }
                            case 47:
                                {
                                    alarminfo += "油滤器堵塞 ";
                                    break;
                                }
                            case 48:
                                {
                                    alarminfo += "风机电流故障 ";
                                    break;
                                }
                            case 49:
                                {
                                    alarminfo += "供气压力高 ";
                                    break;
                                }
                            case 50:
                                {
                                    alarminfo += "空久停机 ";
                                    break;
                                }
                            case 51:
                                {
                                    alarminfo += "报警 ";
                                    break;
                                }
                            case 52:
                                {
                                    alarminfo += "预警 ";
                                    break;
                                }
                            case 53:
                                {
                                    alarminfo += "润滑脂使用时间到 ";
                                    break;
                                }
                            case 54:
                                {
                                    alarminfo += "润滑油使用时间到 ";
                                    break;
                                }
                            case 55:
                                {
                                    alarminfo += "空滤器使用时间到 ";
                                    break;
                                }
                            case 56:
                                {
                                    alarminfo += "油分器使用时间到 ";
                                    break;
                                }
                            case 57:
                                {
                                    alarminfo += "油滤器使用时间到 ";
                                    break;
                                }
                            case 58:
                                {
                                    alarminfo += "排气温度高预警 ";
                                    break;
                                }
                            case 59:
                                {
                                    alarminfo += "缺水 ";
                                    break;
                                }
                            case 60:
                                {
                                    alarminfo += "排气温度传感器失灵 ";
                                    break;
                                }
                            case 61:
                                {
                                    alarminfo += "供气压力传感器失灵 ";
                                    break;
                                }
                        }
                    }
                }
                a.Rows.Add(result.Tables[0].Rows[rowslength][3], alarminfo);
            }
            alarmgridview.DataSource = a;
            alarmgridview.Columns[0].Width = 110;
            alarmgridview.Columns[1].Width = 700;
        }
    }
}
