using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Crane
{
    public partial class CraneinfoForm : Form
    {
        SQL sqlit = new SQL();
        public CraneinfoForm()
        {
            InitializeComponent();
        }

        private void CraneinfoForm_Load(object sender, EventArgs e)
        {
            DataSet ds = sqlit.FillareaComboBox();
            area_ComboBox.DataSource = ds.Tables[0];
            area_ComboBox.DisplayMember = "area";
            area_ComboBox.ValueMember = "area";
            area_ComboBox.Text = "";
            foreach (Control c in this.Controls)
            {
                if (c is TextBox || c is DateTimePicker)
                {
                    c.Text = "";
                }
                if (c is ComboBox)
                {
                    c.Text = "";
                    ((ComboBox)c).SelectedItem = null;
                }
            }

        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void insinfo_button_Click(object sender, EventArgs e)//配置添加设备信息
        {
            if (area_ComboBox.Text == "")
            {
                MessageBox.Show("请输入所在地区！");
            }
            else if (crane_info_TextBox.Text == "")
            {
                MessageBox.Show("请输入设备代码！");
            }
            else if (gboxid_TextBox.Text == "")
            {
                MessageBox.Show("请输入G-Box ID！");
            }
            else if (gboxid_TextBox.Text.Length != 16)
            {
                MessageBox.Show("G-Box ID 信息错误，请重新输入！");
            }
            else
            {
                if (insinfo_button.Text == "添加")
                {
                    string comp = "select count(*) from crane_info where gboxid = '" + gboxid_TextBox.Text + "'";
                    int selectcompresult = 0;
                    SqlCommand comp_SQL = new SqlCommand(comp, sqlit.Conn);
                    sqlit.Conn.Open();
                    selectcompresult = (int)comp_SQL.ExecuteScalar();
                    if (selectcompresult > 0)
                    {
                        sqlit.Conn.Close();
                        MessageBox.Show("设备信息已存在，请检查“设备代码”“G-BOX ID”，重新录入！");
                    }
                    else
                    {
                        string insert = "Insert Into crane_info(area,crane_type,crane_info,gboxid,factory_date,factory_num,project_place,project_name,install_comp,use_comp,check_comp,install_date,install_qualified,install_checkdate,mid_checkdate,mid_check_qualified,final_checkdate,unstall_result,remark1,remark2,maincharge,maincharge_phone,safecharge,safecharge_phone,driver,driver_license,driver_phone) values('"
                                                 + area_ComboBox.Text + "','"
                                                 + crane_type_TextBox.Text + "','"
                                                 + crane_info_TextBox.Text + "','"
                                                 + gboxid_TextBox.Text + "','"
                                                 + factory_date_picker.Value + "','"
                                                 + factory_num_TextBox.Text + "','"
                                                 + project_place_TextBox.Text + "','"
                                                 + project_name_TextBox.Text + "','"
                                                 + install_comp_TextBox.Text + "','"
                                                 + use_comp_TextBox.Text + "','"
                                                 + check_comp_TextBox.Text + "','"
                                                 + install_date_picker.Value + "','"
                                                 + install_qualified_ComboBox.Text + "','"
                                                 + install_checkdate_picker.Value + "','"
                                                 + mid_checkdate_picker.Value + "','"
                                                 + mid_check_qualified_Combobox.Text + "','"
                                                 + final_checkdate_picker.Value + "','"
                                                 + unstall_result_TextBox.Text + "','"
                                                 + remark1_TextBox.Text + "','"
                                                 + remark2_TextBox.Text + "','"
                                                 + maincharge_TextBox.Text + "','"
                                                 + maincharge_phone_TextBox.Text + "','"
                                                 + safecharge_TextBox.Text + "','"
                                                 + safecharge_phone_TextBox.Text + "','"
                                                 + driver_TextBox.Text + "','"
                                                 + driver_license_TextBox.Text + "','"
                                                 + driver_phone_TextBox.Text + "')";
                        SqlCommand insert_SQL = new SqlCommand(insert, sqlit.Conn);
                        try
                        {
                            insert_SQL.ExecuteNonQuery();
                            sqlit.Conn.Close();
                            MessageBox.Show("添加成功！");
                            Global.crane_info = crane_info_TextBox.Text;
                            CraneinfoForm_Load(null, null);
                        }
                        catch (Exception ex)
                        {
                            sqlit.Conn.Close();
                            MessageBox.Show("添加失败请重试");
                        }
                    }


                }
                else if (insinfo_button.Text == "编辑")
                {
                    foreach (Control c in this.Controls)
                    {
                        if (c is TextBox)
                        {
                            ((TextBox)c).ReadOnly = false;
                        }
                    }
                    area_TextBox.Text = area_ComboBox.Text;
                    area_TextBox.ReadOnly = true;
                    gboxid_TextBox.ReadOnly = true;
                    crane_info_TextBox.ReadOnly = true;
                    crane_type_TextBox.ReadOnly = true;

                    factory_date_TextBox.Text = factory_date_picker.Text;
                    factory_date_TextBox.Visible = false;

                    install_date_TextBox.Text = install_date_picker.Text;
                    install_date_TextBox.Visible = false;

                    install_qualified_TextBox.Text = install_qualified_ComboBox.Text;
                    install_qualified_TextBox.Visible = false;

                    mid_checkdate_TextBox.Text = mid_checkdate_picker.Text;
                    mid_checkdate_TextBox.Visible = false;

                    mid_check_qualified_TextBox.Text = mid_check_qualified_Combobox.Text;
                    mid_check_qualified_TextBox.Visible = false;

                    install_checkdate_TextBox.Text = install_checkdate_picker.Text;
                    install_checkdate_TextBox.Visible = false;

                    final_checkdate_TextBox.Text = final_checkdate_picker.Text;
                    final_checkdate_TextBox.Visible = false;
                    insinfo_button.Text = "更新";
                }

                else if (insinfo_button.Text == "更新")
                {
                    string update = "update crane_info set area ='" + area_ComboBox.Text +
                                    "',crane_info ='" + crane_info_TextBox.Text +
                                    "',gboxid ='" + gboxid_TextBox.Text +
                                    "',crane_type ='" + crane_type_TextBox.Text +
                                    "',factory_date ='" + factory_date_picker.Value +
                                    "',factory_num ='" + factory_num_TextBox.Text +
                                    "',project_place ='" + project_place_TextBox.Text +
                                    "',project_name ='" + project_name_TextBox.Text +
                                    "',install_comp ='" + install_comp_TextBox.Text +
                                    "',install_date ='" + install_date_picker.Value +
                                    "',install_qualified ='" + install_qualified_ComboBox.Text +
                                    "',install_checkdate ='" + install_checkdate_picker.Value +
                                    "',mid_checkdate ='" + mid_checkdate_picker.Value +
                                    "',mid_check_qualified ='" + mid_check_qualified_Combobox.Text +
                                    "',final_checkdate ='" + final_checkdate_picker.Value +
                                    "',unstall_result ='" + unstall_result_TextBox.Text +
                                    "',remark1 ='" + remark1_TextBox.Text +
                                    "',remark2 ='" + remark2_TextBox.Text +
                                    "',maincharge ='" + maincharge_TextBox.Text +
                                    "',maincharge_phone ='" + maincharge_phone_TextBox.Text +
                                    "',safecharge ='" + safecharge_TextBox.Text +
                                    "',safecharge_phone ='" + safecharge_phone_TextBox.Text +
                                    "',driver ='" + driver_TextBox.Text +
                                    "',driver_license ='" + driver_license_TextBox.Text +
                                    "',driver_phone ='" + driver_phone_TextBox.Text +
                                    "' where crane_info='" + Global.crane_info + "'";
                    SqlCommand update_SQL = new SqlCommand(update, sqlit.Conn);
                    if (MessageBox.Show(this, "确认更新？", "更新提示", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        sqlit.Conn.Open();
                        try
                        {

                            update_SQL.ExecuteNonQuery();
                            sqlit.Conn.Close();
                            MessageBox.Show("更新成功！");
                            area_TextBox.Text = area_ComboBox.Text;
                            area_TextBox.Visible = true;

                            factory_date_TextBox.Text = factory_date_picker.Text;
                            factory_date_TextBox.Visible = true;

                            install_date_TextBox.Text = install_date_picker.Text;
                            install_date_TextBox.Visible = true;

                            install_qualified_TextBox.Text = install_qualified_ComboBox.Text;
                            install_qualified_TextBox.Visible = true;

                            mid_checkdate_TextBox.Text = mid_checkdate_picker.Text;
                            mid_checkdate_TextBox.Visible = true;

                            mid_check_qualified_TextBox.Text = mid_check_qualified_Combobox.Text;
                            mid_check_qualified_TextBox.Visible = true;

                            install_checkdate_TextBox.Text = install_checkdate_picker.Text;
                            install_checkdate_TextBox.Visible = true;

                            final_checkdate_TextBox.Text = final_checkdate_picker.Text;
                            final_checkdate_TextBox.Visible = true;
                            foreach (Control c in this.Controls)
                            {
                                if (c is TextBox)
                                {
                                    ((TextBox)c).ReadOnly = true;
                                }
                            }
                            insinfo_button.Text = "编辑";
                        }
                        catch (Exception ex)
                        {
                            sqlit.Conn.Close();
                            MessageBox.Show("更新失败，请重试！");
                        }
                    }
                   
                }
            }
        }
    }
}