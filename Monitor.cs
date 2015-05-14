using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ModbusCom;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace pump
{
    class Monitor
    {
        #region SendMessage显示GBOX状态
        public static IntPtr pForm;
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);
        #endregion


        public void MonitorMethd(object par)
        {
            Modbus MonitorCrane = new Modbus();
            SQL sqlit = new SQL();
            string[] Par = (string[])par;
            string GboxID = Par[0];
            string craneid = Par[1];
            string DeviceType = Par[2];
            string area = sqlit.Selectarea(craneid);

            int[] Alarm = new int[14];
            short[] Checkdata = new short[282];
            short[] Alarmdata = new short[181];
            short[] Runstatus = new short[14];
            short[] Runstatus_8060 = new short[15];
            int[] Alarm_8060 = new int[32];


            ModbusCom.ErrCodeEnum err;
            err = ErrCodeEnum.UDPTimeout;
            MonitorCrane.CommMode = CommModeEnum.UDP;
            MonitorCrane.CommDevice = CommDeviceEnum.GBOX;
            //MonitorCrane.ServerIP = "127.0.0.1";
            MonitorCrane.ServerIP = "61.160.67.86";
            MonitorCrane.ServerPoint = 502;
            MonitorCrane.InitialNetWorkPort("Monitor", "12345678", craneid, GboxID);

            while (true)
            {
                if (MonitorCrane.Open() == ModbusCom.ErrCodeEnum.OK)
                {
                    switch (DeviceType)
                    {
                        case "一级空压机":
                            MonitorCrane.ModbusReadMultiWORD(1, 0, 15, out Runstatus_8060);
                            string alarm_8060_1 = Convert.ToString(Runstatus_8060[7], 2);
                            if (alarm_8060_1.Length < 16)
                            {
                                for (int i = 1; i < (32-alarm_8060_1.Length); i++)
                                {
                                    alarm_8060_1 = '0' + alarm_8060_1;
                                }
                            }
                            for (int j = 0; j < 16; j++)
                            {
                                Alarm_8060[j] = Convert.ToInt32(alarm_8060_1[j]-48);
                            }

                            string alarm_8060_2 = Convert.ToString(Runstatus_8060[8], 2);
                            if (alarm_8060_2.Length < 16)
                            {
                                for (int i = 1; i < (32 - alarm_8060_2.Length); i++)
                                {
                                    alarm_8060_2 = '0' + alarm_8060_2;
                                }
                            }
                            for (int j = 0; j < 16; j++)
                            {
                                Alarm_8060[j+16] = Convert.ToInt32(alarm_8060_2[j]-48);
                            }

                            if (Runstatus_8060[0] != 0 || Runstatus_8060[1] != 0 || Runstatus_8060[2] != 0 || Runstatus_8060[3] != 0 || Runstatus_8060[4] != 0 || Runstatus_8060[10] != 0 || Runstatus_8060[11] != 0 || Runstatus_8060[12] != 0 || Runstatus_8060[13] != 0 || Runstatus_8060[14] != 0)
                            {
                                sqlit.InsertStatus_8060(GboxID, craneid, area, Runstatus_8060);
                            }
                            if (Alarm_8060[3] == 1 || Alarm_8060[4] == 1 || Alarm_8060[5] == 1 || Alarm_8060[6] == 1 || Alarm_8060[8] == 1 || Alarm_8060[9] == 1 || Alarm_8060[14] == 1 || Alarm_8060[15] == 1 || Alarm_8060[16] == 1 || Alarm_8060[17] == 1 || Alarm_8060[19] == 1 || Alarm_8060[20] == 1 || Alarm_8060[21] == 1 || Alarm_8060[22] == 1 || Alarm_8060[23] == 1 || Alarm_8060[24] == 1 || Alarm_8060[29] == 1 || Alarm_8060[30] == 1 || Alarm_8060[31] == 1)
                            {
                                sqlit.InsertAlarm_8060(GboxID, craneid, area, Alarm_8060);
                                SendMessage(pForm, 0x400, 2, new StringBuilder(craneid));
                            }
                            else 
                            {
                                SendMessage(pForm, 0x400, 0, new StringBuilder(craneid));
                            }
                            break;

                        case "二级空压机":
                            MonitorCrane.ModbusReadMultiWORD(1, 5998, 14, out Runstatus);
                            MonitorCrane.ModbusReadMutilCoils(1, 4000, 38, out Alarm);
                            if (Runstatus[0] != 0 || Runstatus[1] != 0 || Runstatus[2] != 0 || Runstatus[3] != 0 || Runstatus[4] != 0 || Runstatus[5] != 0 || Runstatus[6] != 0 || Runstatus[7] != 0 || Runstatus[8] != 0 || Runstatus[9] != 0 || Runstatus[10] != 0 || Runstatus[11] != 0 || Runstatus[12] != 0 || Runstatus[13] != 0)
                            {
                                sqlit.InsertStatus(GboxID, craneid, area, Runstatus);
                            }
                            if (Alarm[0] == 1 || Alarm[1] == 1 || Alarm[2] == 1 || Alarm[3] == 1 || Alarm[4] == 1 || Alarm[5] == 1 || Alarm[6] == 1 || Alarm[7] == 1 || Alarm[8] == 1 || Alarm[9] == 1 || Alarm[10] == 1 || Alarm[11] == 1 || Alarm[12] == 1 || Alarm[13] == 1 || Alarm[14] == 1 || Alarm[15] == 1 || Alarm[16] == 1 || Alarm[17] == 1 || Alarm[18] == 1 || Alarm[19] == 1 || Alarm[20] == 1 || Alarm[21] == 1 || Alarm[22] == 1 || Alarm[23] == 1 || Alarm[24] == 1 || Alarm[25] == 1 || Alarm[26] == 1 || Alarm[27] == 1 || Alarm[28] == 1 || Alarm[29] == 1 || Alarm[30] == 1 || Alarm[31] == 1 || Alarm[32] == 1 || Alarm[33] == 1 || Alarm[34] == 1 || Alarm[35] == 1 || Alarm[36] == 1 || Alarm[37] == 1)
                            {
                                sqlit.InsertAlarm(GboxID, craneid, area, Alarm);
                                SendMessage(pForm, 0x400, 2, new StringBuilder(craneid));
                            }
                            else
                            {
                                SendMessage(pForm, 0x400, 0, new StringBuilder(craneid)); 
                            }
                            break;
                    }
                }
                else
                {
                    SendMessage(pForm, 0x400, 1, new StringBuilder(craneid));
                }
                Thread.Sleep(60000);
            }
        }
    }
}