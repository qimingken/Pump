using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace pump
{
    public partial class SearchAlarmData : Form
    {
        SQL sqlit = new SQL();
        public SearchAlarmData()
        {
            InitializeComponent();
        }

        private void SearchAlarmData_Load(object sender, EventArgs e)
        {
            DataSet ds = sqlit.FillcraneComboBox();
            craneidComBox.DataSource = ds.Tables[0];
            craneidComBox.DisplayMember = "crane_info";
            craneidComBox.ValueMember = "crane_info";
            craneidComBox.Text = "";
        }

        private void selectinfoCombox(object sender, EventArgs e)
        {
            if (checkTable.Checked == true)
            {
                infoComBox.Enabled = false;
            }
            else
            {
                infoComBox.Enabled = true;
            }
        }

        private void Search_Button_Click(object sender, EventArgs e)
        {
            //sqlit.Deleterecord();
            this.Begin_TimePicker.Value = new DateTime(this.Begin_TimePicker.Value.Year, this.Begin_TimePicker.Value.Month, this.Begin_TimePicker.Value.Day, 00, 00, 00);
            this.End_TimePicker.Value = new DateTime(this.End_TimePicker.Value.Year, this.End_TimePicker.Value.Month, this.End_TimePicker.Value.Day, 23, 59, 59);
            DateTime begin = Begin_TimePicker.Value;
            DateTime end = End_TimePicker.Value;

            if (Begin_TextBox.Text == "")
            {
                begin = new DateTime(1900, 1, 1, 00, 00, 00);
            }
            if (End_TextBox.Text == "")
            {
                end = new DateTime(9999, 12, 12, 00, 00, 00);
            }
            if ( craneidComBox.Text != "")
            {
                if (checkTable.Checked == false)
                {
                    DataView.Visible = false;
                    if (infoComBox.Text == "")
                    {
                        MessageBox.Show("请选择具体项目！");
                    }
                    else
                    {
                        DataSet result = sqlit.SelectRunHistroy(null, craneidComBox.Text, begin, end);
                        switch (infoComBox.Text)
                        {
                            case "一级压力":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D5998";
                                DataChart.Series[0].Name = "一级压力";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "Mpa(兆帕)";
                                break;
                            case "一级温度":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D5999";
                                DataChart.Series[0].Name = "一级温度";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "℃(摄氏度)";
                                break;
                            case "二级压力":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6000";
                                DataChart.Series[0].Name = "二级压力";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "Mpa(兆帕)";
                                break;
                            case "二级温度":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6001";
                                DataChart.Series[0].Name = "二级温度";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "℃(摄氏度)";
                                break;
                            case "主机输出频率":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6002";
                                DataChart.Series[0].Name = "主机输出频率";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "Hz(赫兹)";
                                break;
                            case "主机输出电压":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6003";
                                DataChart.Series[0].Name = "主机输出电压";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "V(伏特)";
                                break;
                            case "主机输出电流":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6004";
                                DataChart.Series[0].Name = "主机输出电流";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "A(安培)";
                                break;
                            case "主机输出功率":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6005";
                                DataChart.Series[0].Name = "主机输出功率";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "kW(千瓦)";
                                break;
                            case "整机使用电量":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6006";
                                DataChart.Series[0].Name = "整机使用电量";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "kWH(千瓦时)";
                                break;
                            case "整机使用排气量":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6007";
                                DataChart.Series[0].Name = "整机使用排气量";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "m³(立方)";
                                break;
                            case "冷却风机频率":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6008";
                                DataChart.Series[0].Name = "冷却风机频率";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "Hz(赫兹)";
                                break;
                            case "冷却风机电流":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6009";
                                DataChart.Series[0].Name = "冷却风机电流";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "A(安培)";
                                break;
                            case "运行累计时间":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6010";
                                DataChart.Series[0].Name = "运行累计时间";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "H(小时)";
                                break;
                            case "负载累计时间":
                                DataChart.DataSource = result.Tables[0];
                                DataChart.Series[0].XValueMember = "check_time";
                                DataChart.Series[0].YValueMembers = "D6011";
                                DataChart.Series[0].Name = "负载累计时间";
                                DataChart.DataBind();
                                DataChart.ChartAreas[0].AxisY.Title = "H(小时)";
                                break;
                        }
                    }
                }
                else 
                {
                    DataView.Visible = true;
                    DataSet result = sqlit.SelectRunHistroy(null, craneidComBox.Text, begin, end);
                    DataView.DataSource = result.Tables[0];
                }

            }
            else
            {
                MessageBox.Show("请填写设备信息！");
            }

            
        }

        private void Begin_TimePicker_CloseUp(object sender, EventArgs e)
        {
            Begin_TextBox.Text = Begin_TimePicker.Text;
        }

        private void End_TimePicker_CloseUp(object sender, EventArgs e)
        {
            End_TextBox.Text = End_TimePicker.Text;
        }

        private void Begin_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Back)
            {
                Begin_TextBox.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        private void End_TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back)
            {
                End_TextBox.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }

        #region 导出按钮
        private void GetTable_button_Click(object sender, EventArgs e)
        {
            saveexcel.Filter = "csv文件|*.csv|文本文件|*.txt";
            saveexcel.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            DateTime begin = Begin_TimePicker.Value;
            DateTime end = End_TimePicker.Value;
            if (Begin_TextBox.Text == "")
            {
                begin = new DateTime(1900, 1, 1, 00, 00, 00);
            }
            if (End_TextBox.Text == "")
            {
                end = new DateTime(9999, 12, 12, 00, 00, 00);
            }
            DataSet result = sqlit.SelectRunHistroy(null, craneidComBox.Text, begin, end);
            DataTable dt = result.Tables[0];

            if (saveexcel.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                string filename = saveexcel.FileName;
                savecsv(dt, filename);
            }
        }
        #endregion

        #region 保存成CSV
        public void savecsv(DataTable dt, string filename)
        {
            FileStream fs = new FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            string data = "";
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    data += dt.Columns[i].ColumnName.ToString();
            //    if (i < dt.Columns.Count - 1)
            //    {
            //        data += ",";
            //    }
            //}
            data += "GBOX ID,设备名称,所在区域,采集时间,一级压力,一级温度,二级压力,二级温度,主机输出频率,主机输出电压,主机输出电流,主机输出功率,整机使用电量,整机使用排气量,冷却风机频率,冷却风机电流,运行累计时间,负载累计时间";
            sw.WriteLine(data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    data += dt.Rows[i][j].ToString();
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);

            }
            sw.Close();
            fs.Close();
            MessageBox.Show("保存成功");
        }
        #endregion

        private void savechart_button_Click(object sender, EventArgs e)
        {
            savechart.Filter = "JPEG文件|*.jpg|BMP文件|*.bmp";
            savechart.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            savechart.FileName = craneidComBox.Text + " " + infoComBox.Text;
            if (savechart.ShowDialog() == DialogResult.OK)
            {
                if (savechart.FilterIndex == 1)
                {
                    DataChart.SaveImage(savechart.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    DataChart.SaveImage(savechart.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                MessageBox.Show("保存成功！");
                    
            } 
        }

        private void getalarmdata_Click(object sender, EventArgs e)
        {
            saveexcel.Filter = "csv文件|*.csv|文本文件|*.txt";
            saveexcel.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            DataSet result = sqlit.SelectAllAlarmHistroy();
            DataTable dt = new DataTable();
            dt.Columns.Add("GBox-ID");
            dt.Columns.Add("设备名称");
            dt.Columns.Add("所在区域");
            dt.Columns.Add("时间");
            dt.Columns.Add("报警内容");

            for (int rowslength = 0; rowslength < result.Tables[0].Rows.Count; rowslength++)
            {
                string alarminfo = "";
                for (int cellnumber = 4; cellnumber < 41; cellnumber++)
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
                        }
                    }
                }
                dt.Rows.Add(result.Tables[0].Rows[rowslength][0], result.Tables[0].Rows[rowslength][1], result.Tables[0].Rows[rowslength][2], result.Tables[0].Rows[rowslength][3], alarminfo);
            }

            if (saveexcel.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                string filename = saveexcel.FileName;
                savealarmcsv(dt, filename);
            }
        }

        #region 保存成CSV
        public void savealarmcsv(DataTable dt, string filename)
        {
            FileStream fs = new FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default);
            string data = "";
            //for (int i = 0; i < dt.Columns.Count; i++)
            //{
            //    data += dt.Columns[i].ColumnName.ToString();
            //    if (i < dt.Columns.Count - 1)
            //    {
            //        data += ",";
            //    }
            //}
            data += "GBOX ID,设备名称,所在区域,采集时间,报警内容";
            sw.WriteLine(data);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    data += dt.Rows[i][j].ToString();
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);

            }
            sw.Close();
            fs.Close();
            MessageBox.Show("保存成功");
        }
        #endregion

        private void craneidComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a = craneidComBox.SelectedIndex;
            if (a != 0)//Todo：
            {
                sqlit.selecttype(craneidComBox.Text);
            }
        }
      }
}