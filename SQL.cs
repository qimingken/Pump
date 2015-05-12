using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace pump
{
    class SQL
    {
        #region 定义数据库字符连接串
        public SqlConnection Conn = new SqlConnection("server=;uid=sa;pwd=;database=db_crane;Connection Timeout=1;");
        #endregion

        #region 填充设备信息到TreeView
        public DataSet Filltree()
        {
            Conn.Open();
            string sql = "select * from crane_info";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Conn.Close();
            return ds;
        }
        #endregion

        #region 删除设备节点和数据库信息
        public void DelCrane()
        {
            Conn.Open();
            string delcrane_info = "delete from crane_info where crane_info ='" + Global.crane_info + "'";
            SqlCommand _delcrane_info = new SqlCommand(delcrane_info, Conn);
            _delcrane_info.ExecuteNonQuery();

            string delcrane_alarm = "delete from crane_alarm where crane_info ='" + Global.crane_info + "'";
            SqlCommand _delcrane_alarm = new SqlCommand(delcrane_alarm, Conn);
            _delcrane_alarm.ExecuteNonQuery();

            string delcrane_status = "delete from crane_status where crane_info ='" + Global.crane_info + "'";
            SqlCommand _delcrane_status = new SqlCommand(delcrane_status, Conn);
            _delcrane_status.ExecuteNonQuery();
            Conn.Close();
        }
        #endregion

        #region 填充areaComboBox
        public DataSet FillareaComboBox()
        {
            Conn.Open();
            string sql = "select distinct area from crane_info";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Conn.Close();
            return ds;
        }
        #endregion

        #region 填充craneidComboBox
        public DataSet FillcraneComboBox()
        {
            Conn.Open();
            string sql = "select distinct crane_info from crane_info";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            Conn.Close();
            return ds;
        }
        #endregion

        #region 查询设备信息
        public string[] SelectCraneinfo()
        {
            Conn.Open();
            string[] result = new string[27];
            string selectinfo = "select * from crane_info where crane_info ='" + Global.crane_info + "'";
            SqlCommand cmd = new SqlCommand(selectinfo, Conn);
            SqlDataReader _selectinfo = cmd.ExecuteReader();
            while (_selectinfo.Read())
            {
                for (int i = 0; i < 27; i++)
                {
                    result[i] = _selectinfo.IsDBNull(i) ? "" : _selectinfo.GetString(i);
                }
            }
            Conn.Close();
            return result;
        }
        #endregion
                        
        #region 插入当前运行值
        public void InsertStatus(string gboxid, string craneid, string area, short[] runstatus)
        {
            Conn.Open();
            string insertstatus = "insert into crane_status ([gboxid] ,[crane_info] ,[area], [check_time] ,[D5998] ,[D5999] ,[D6000] ,[D6001] ,[D6002] ,[D6003] ,[D6004] ,[D6005] ,[D6006] ,[D6007] ,[D6008] ,[D6009] ,[D6010] ,[D6011])   VALUES ('" + gboxid + "','" + craneid + "','" + area + "','" + DateTime.Now + "','" + (Convert.ToDouble(runstatus[0]) / 100) + "','" + Convert.ToDouble(runstatus[1]) + "','" + (Convert.ToDouble(runstatus[2]) / 100) + "','" + Convert.ToDouble(runstatus[3]) + "','" + (Convert.ToDouble(runstatus[4]) / 10) + "','" + Convert.ToDouble(runstatus[5]) + "','" + (Convert.ToDouble(runstatus[6]) / 10) + "','" + (Convert.ToDouble(runstatus[7]) / 100) + "','" + (Convert.ToDouble(runstatus[8]) / 100) + "','" + (Convert.ToDouble(runstatus[9]) / 100) + "','" + (Convert.ToDouble(runstatus[10]) / 10) + "','" + (Convert.ToDouble(runstatus[11]) / 10) + "','" + Convert.ToDouble(runstatus[12]) + "','" + Convert.ToDouble(runstatus[13]) + "')";

            SqlCommand _insertstatus = new SqlCommand(insertstatus, Conn);
            try
            {
                _insertstatus.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                Conn.Close();
            }
        }
        #endregion

        #region 插入当前运行值_8060
        public void InsertStatus_8060(string gboxid, string craneid, string area, short[] runstatus)
        {
            Conn.Open();
            string insertstatus = "insert into crane_status ([gboxid] ,[crane_info] ,[area], [check_time] ,[D6080_0] ,[D6080_1] ,[D6080_2] ,[D6080_3] ,[D6080_4] ,[D6080_10] ,[D6080_11] ,[D6080_12] ,[D6080_13] ,[D6080_14])   VALUES ('" + gboxid + "','" + craneid + "','" + area + "','" + DateTime.Now + "','" + (Convert.ToDouble(runstatus[0]) / 100) + "','" + Convert.ToDouble(runstatus[1]-50) + "','" + Convert.ToDouble(runstatus[2]) + "','" + Convert.ToDouble(runstatus[3]) + "','" + (Convert.ToDouble(runstatus[4]) / 10) + "','" + Convert.ToDouble(runstatus[10]) + "','" + Convert.ToDouble(runstatus[11]) + "','" + Convert.ToDouble(runstatus[12]) + "','" + Convert.ToDouble(runstatus[13]) + "','" + Convert.ToDouble(runstatus[14]) + "')";

            SqlCommand _insertstatus = new SqlCommand(insertstatus, Conn);
            try
            {
                _insertstatus.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                Conn.Close();
            }
        }
        #endregion

        #region 插入报警值
        public void InsertAlarm(string gboxid, string craneid, string area, int[] alarm)
        {
            Conn.Open();
            string insertalarm = "insert into crane_alarm ([gboxid] ,[crane_info] ,[area], [check_time] ,[M5000] ,[M5001] ,[M5002] ,[M5003] ,[M5004] ,[M5005] ,[M5006] ,[M5007] ,[M5008] ,[M5009] ,[M5010] ,[M5011] ,[M5012] ,[M5013],[M5014],[M5015],[M5016],[M5017],[M5018],[M5019],[M5020],[M5021],[M5022],[M5023],[M5024],[M5025],[M5026],[M5027],[M5028],[M5029],[M5030],[M5031],[M5032],[M5033],[M5034],[M5035],[M5036],[M5037])   VALUES ('" + gboxid + "','" + craneid + "','" + area + "','" + DateTime.Now + "','" + alarm[0] + "','" + alarm[1] + "','" + alarm[2] + "','" + alarm[3] + "','" + alarm[4] + "','" + alarm[5] + "','" + alarm[6] + "','" + alarm[7] + "','" + alarm[8] + "','" + alarm[9] + "','" + alarm[10] + "','" + alarm[11] + "','" + alarm[12] + "','" + alarm[13] + "','" + alarm[14] + "','" + alarm[15] + "','" + alarm[16] + "','" + alarm[17] + "','" + alarm[18] + "','" + alarm[19] + "','" + alarm[20] + "','" + alarm[21] + "','" + alarm[22] + "','" + alarm[23] + "','" + alarm[24] + "','" + alarm[25] + "','" + alarm[26] + "','" + alarm[27] + "','" + alarm[28] + "','" + alarm[29] + "','" + alarm[30] + "','" + alarm[31] + "','" + alarm[32] + "','" + alarm[33] + "','" + alarm[34] + "','" + alarm[35] + "','" + alarm[36] + "','" + alarm[37] + "')";

            SqlCommand _insertalarm = new SqlCommand(insertalarm, Conn);
            try
            {
                _insertalarm.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                Conn.Close();
            }
        }
        #endregion

        #region 插入报警值_8060
        public void InsertAlarm_8060(string gboxid, string craneid, string area, int[] alarm)
        {
            Conn.Open();
            string insertalarm = "insert into crane_alarm ([gboxid] ,[crane_info] ,[area], [check_time] ,[M7_3] ,[M7_4] ,[M7_5] ,[M7_6] ,[M7_8] ,[M7_9] ,[M7_14] ,[M7_15] ,[M8_0] ,[M8_1] ,[M8_3] ,[M8_4] ,[M8_5] ,[M8_6],[M8_7],[M8_8],[M8_13],[M8_14],[M8_15]) VALUES ('" + gboxid + "','" + craneid + "','" + area + "','" + DateTime.Now + "','" + alarm[3] + "','" + alarm[4] + "','" + alarm[5] + "','" + alarm[6] + "','" + alarm[8] + "','" + alarm[9] + "','" + alarm[14] + "','" + alarm[15] + "','" + alarm[16] + "','" + alarm[17] + "','" + alarm[19] + "','" + alarm[20] + "','" + alarm[21] + "','" + alarm[22] + "','" + alarm[23] + "','" + alarm[24] + "','" + alarm[29] + "','" + alarm[30] + "','" + alarm[31] + "')";

            SqlCommand _insertalarm = new SqlCommand(insertalarm, Conn);
            try
            {
                _insertalarm.ExecuteNonQuery();
                Conn.Close();
            }
            catch (Exception ex)
            {
                Conn.Close();
            }
        }
        #endregion
        
        #region 查询设备所在区域

        public string Selectarea(string craneid)
        {
            string result = null;
            Conn.Open();
            string selectarea = "select area from crane_info where crane_info ='" + craneid + "'";
            SqlCommand cmd = new SqlCommand(selectarea, Conn);
            SqlDataReader _selectarea = cmd.ExecuteReader();
            while (_selectarea.Read())
            {
                result = _selectarea.IsDBNull(0) ? "" : _selectarea.GetString(0);
            }
            Conn.Close();
            return result;
        }

        #endregion

        #region 查询历史记录
        public DataSet SelectRunHistroy(string area, string craneid, DateTime begindate, DateTime enddate)
        {
            Conn.Open(); 
            string sql = "select * from crane_status where area like '%" + area + "%' and crane_info like '%" + craneid + "%' and (check_time between '" + begindate + "'and '" + enddate + "') ";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet result = new DataSet();
            adp.Fill(result);
            Conn.Close();
            return result;
        }

        #endregion

        #region 查询历史报警记录
        public DataSet SelectAllAlarmHistroy()
        {
            Conn.Open();
            string sql = "select * from crane_alarm ORDER BY check_time ASC";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet result = new DataSet();
            adp.Fill(result);
            Conn.Close();
            return result;
        }
        #endregion

        #region 删除两天前的记录
        public void Deleterecord()
        {
            Conn.Open();
            DateTime tempdate = DateTime.Now - new TimeSpan(2,0,0,0);
            DateTime Enddate = new DateTime(tempdate.Year,tempdate.Month,tempdate.Day,23,59,59);
            string Deleterecord_cmd = "delete from crane_status where check_time < ='" + Enddate + "'";
            SqlCommand _Deleterecord_cmd = new SqlCommand(Deleterecord_cmd, Conn);
            _Deleterecord_cmd.ExecuteNonQuery();
            Conn.Close();
        }
        #endregion

        #region 修改密码
        public void configPW(string CruPW, string NewPW, string ComPW)
        {
            string updataPW;
            Conn.Open();
            string selectPW = "select password from password";
            SqlCommand _selectPW = new SqlCommand(selectPW, Conn);
            string res = Convert.ToString(_selectPW.ExecuteScalar());
            Conn.Close();
            if (CruPW != res)
            {
                MessageBox.Show("当前密码错误！");
            }
            else 
            {
                if (NewPW != ComPW)
                {
                    MessageBox.Show("密码不符合！");
                }
                else
                {
                    Conn.Open();
                    if (res == "")
                    {
                        updataPW = "insert into password ([password]) VALUES ('" + NewPW + "')";
                    }
                    else
                    {
                        updataPW = "update password set password ='" + NewPW + "'";
                    }
                    SqlCommand _updataPW = new SqlCommand(updataPW, Conn);
                    _updataPW.ExecuteNonQuery();
                    Conn.Close();
                    MessageBox.Show("密码更新成功！");
                }
            }
        }
        #endregion

        #region 登陆
        public void Login(string CruPW)
        {
            string login;
            Conn.Open();
            string selectPW = "select password from password";
            SqlCommand _selectPW = new SqlCommand(selectPW, Conn);
            string res = Convert.ToString(_selectPW.ExecuteScalar());
            Conn.Close();
            if (CruPW != res)
            {
                MessageBox.Show("当前密码错误！");
            }
            else
            {
                Conn.Open();
                login = "update password set login = '1'";
                SqlCommand _updataPW = new SqlCommand(login, Conn);
                _updataPW.ExecuteNonQuery();
                Conn.Close();
                MessageBox.Show("登陆成功！");
             }
        }
        #endregion

        #region 注销
        public void Cancel()
        {
            Conn.Open();
            string cancel = "update password set login = '0'";
            SqlCommand _cancel = new SqlCommand(cancel, Conn);
            _cancel.ExecuteNonQuery();
            Conn.Close();
        }
        #endregion

        #region 查询报警值
        public DataSet SelectAlarmHistroy(string gboxid)
        {
            Conn.Open();
            string sql = "select * from crane_alarm where gboxid like '%" + gboxid + "%'";
            SqlDataAdapter adp = new SqlDataAdapter(sql, Conn);
            DataSet result = new DataSet();
            adp.Fill(result);
            Conn.Close();
            return result;
        }

        #endregion

        #region 查询设备类型
        public string selecttype(string cranename)
        {
            Conn.Open();
            string selecttype = "select crane_type from crane_info where crane_info = '" + cranename + "'";
            SqlCommand _selectPW = new SqlCommand(selecttype, Conn);
            string crane_type = Convert.ToString(_selectPW.ExecuteScalar());
            Conn.Close();
            return crane_type;
        }
        #endregion
    }
}