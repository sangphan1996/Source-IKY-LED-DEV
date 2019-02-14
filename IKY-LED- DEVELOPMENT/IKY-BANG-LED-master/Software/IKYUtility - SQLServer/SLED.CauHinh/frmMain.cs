using DevExpress.XtraEditors;
using Microsoft.Win32;
using IKYDatabase;
using IKY.NgonNgu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using ShellLinks;

namespace IKY.CauHinh
{
    public partial class frmMain : Form
    {
        const string APP_SLEDDISPLAY_AUTORUN_NAME = "IKY.Display.exe";
    
        private SqlConnection SqlConn = null;
        Color cMauThongBao = SystemColors.HighlightText;
        Color cMauThongTin = Color.Lime;
        string sPageName = "";

        TienIch.tshienthi ts = new TienIch.tshienthi();
        public frmMain()
        {
            InitializeComponent();
        }

        private void wchConfig_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            switch (e.Page.Name)
            {
                case "wchPageDatabase":                    
                    if (!DatabaseCheck(txtHost, txtPort, txtDatasource, txtDatabase, txtSchema, txtUser, txtPassword))
                    {
                        e.Handled = true;
                        wchConfig.SelectedPage = wchPageDatabase;
                        sPageName = "wchPageDatabase";
                    }
                    else
                    {
                        sPageName = "wchPageDisplay";
                        if (SqlConn == null || SqlConn.State != ConnectionState.Open)
                        {
                            Database.Open(ref this.SqlConn);
                        }
                        ts.LoadAll(SqlConn);
                        if (ts.Header != "") txtHeader.Text = ts.Header;
                        if (ts.Footer != "") txtFooter.Text = ts.Footer;
                        if (ts.SoDongHienThi > 0) txtSoDongHienThiDuLieu.Text = ts.SoDongHienThi.ToString();
                        if (ts.TGHienThi > 0) txtThoiGianHienThiDuLieu.Text = ts.TGHienThi.ToString();
                    }
                    break;

                case "wchPageDisplay":
                    ts.Header = txtHeader.Text;
                    ts.Footer = txtFooter.Text;
                    ts.SoDongHienThi = txtSoDongHienThiDuLieu.Text == "" ? 0 : Convert.ToInt16(txtSoDongHienThiDuLieu.Text);
                    ts.TGHienThi = txtThoiGianHienThiDuLieu.Text == "" ? 0 : Convert.ToInt16(txtThoiGianHienThiDuLieu.Text);
                    ts.Update(SqlConn);
                    //
                    Database.SoLanHienThiThongBaoTraXe = txtSoLanThongBao.Text == "" ? 0 : Convert.ToInt32(txtSoLanThongBao.Text);
                    Database.TocDoHieuUngThongBaoTraXe = txtTocDoThongBao.Text == "" ? 0 : Convert.ToInt32(txtTocDoThongBao.Text);
                    Database.MauChuThongBaoTraXe = colorThongBao.Color;
                    Database.MauChuThongTinTraXe = colorThongTin.Color;
                    Database.SaveConfig();                    
                    break;

                case "wchPageWelcome":
                    sPageName = "wchPageDatabase";
                    break;

                default:
                    break;
            }
        }

        private void wchConfig_CancelClick(object sender, CancelEventArgs e)
        {
            switch (sPageName)
            {
                case "wchPageDatabase":
                    sPageName = "wchPageDisplay";
                    wchConfig.SelectedPage = wchPageDisplay;               
                    break;

                default:
                    Application.Exit();
                    break;
            }
        }

        private void wchConfig_FinishClick(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        internal bool DatabaseCheck(TextEdit txt_Host, TextEdit txt_Port, TextEdit txt_DataSource, TextEdit txt_Database, TextEdit txt_Schema, TextEdit txt_UserLogin, TextEdit txt_Password)
        {
            bool result = false;
            string connString = "";
            this.Cursor = Cursors.WaitCursor;
            string s_NgonNgu = "vn";

            Messages msg = new Messages(s_NgonNgu);
            if (txt_Database.Text.Trim() == "")
            {
                Messages.Show(TienIch.Access.KeyMessage.ConfigTablespaceBlank);
                txt_Database.Focus();
                this.Cursor = Cursors.Default;
                return false;
            }
            if (txt_Host.Text.Trim() == "")
            {
                Messages.Show(TienIch.Access.KeyMessage.ConfigServiceNameBlank);
                txt_Host.Focus();
                this.Cursor = Cursors.Default;
                return false;
            }
            if (txt_UserLogin.Text.Trim() == "")
            {
                Messages.Show(TienIch.Access.KeyMessage.ConfigPasswordSystemBlank);
                txt_UserLogin.Focus();
                this.Cursor = Cursors.Default;
                return false;
            }
            if (txt_Password.Text.Trim() == "")
            {
                Messages.Show(TienIch.Access.KeyMessage.ConfigUsernameBlank);
                txt_Password.Focus();
                this.Cursor = Cursors.Default;
                return false;
            }
            if (txt_Schema.Text.Trim() == "")
            {
                Messages.Show(TienIch.Access.KeyMessage.ConfigPasswordBlank);
                txt_Schema.Focus();
                this.Cursor = Cursors.Default;
                return false;
            }
            if (txt_Port.Text.Trim() == "")
            {
                Messages.Show(TienIch.Access.KeyMessage.ConfigLoginUsernameBlank);
                txt_Port.Focus();
                this.Cursor = Cursors.Default;
                return false;
            }

            Database db = new Database(s_NgonNgu);

            Database.Host = txt_Host.Text.Trim();
            Database.Port = txt_Port.EditValue.ToString().Trim();
            Database.Datasource = txt_DataSource.EditValue.ToString().Trim();
            Database.DatabaseName = txt_Database.EditValue.ToString().Trim();
            Database.Schema = txt_Schema.Text.Trim();
            Database.User = txt_UserLogin.EditValue.ToString().Trim();
            Database.Password = txt_Password.Text.Trim();

            try
            {
                this.Cursor = Cursors.WaitCursor;
                string sRegistryKey = @"SOFTWARE\Microsoft\Microsoft SQL Server\MSSQL10_50." + Database.Datasource + @"\MSSQLServer\SuperSocketNetLib\Tcp\IPAll";
                RegistryKey registryKey;
                if (Environment.Is64BitOperatingSystem)
                {
                    registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
                }
                else
                {
                    registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                }
                using (var key = registryKey.OpenSubKey(sRegistryKey, true))
                {
                    string sTCPPort = key.GetValue("TcpPort").ToString();
                    if (sTCPPort == null || sTCPPort != Database.Port)
                    {
                        key.SetValue("TcpPort", "1433");
                        System.Diagnostics.Process process = new System.Diagnostics.Process();
                        System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                        startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        startInfo.FileName = "cmd.exe";
                        startInfo.Arguments = "/c net stop \"SQL Server (" + Database.Datasource + ")\" & net start \"SQL Server (" + Database.Datasource + ")\"";
                        startInfo.UseShellExecute = false;
                        startInfo.CreateNoWindow = true;
                        process.StartInfo = startInfo;
                        process.Start();
                        process.WaitForExit();
                    }
                }
                registryKey.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                Messages.Show(TienIch.Access.KeyMessage.CauHinhSQLServerKhongThanhCong);
                txt_Host.Focus();
                this.Cursor = Cursors.Default;
                return false;

            }

            if(chkTaoMoi.Checked)
            {
                //@"Data Source=.\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=123";
                connString = @"Data Source=.\" + Database.Datasource + ";Initial Catalog=master;User ID=" + Database.Username + ";Password=" + Database.Password;
                this.Cursor = Cursors.WaitCursor;
                result = runCreateDatabase(connString, Database.DatabaseName);                
                if(result == false)
                {
                    Messages.Show(TienIch.Access.KeyMessage.DatabaseTaoKhongThanhCong);
                    txt_Host.Focus();
                    this.Cursor = Cursors.Default;
                    return false;
                }
            }


            connString = "Data Source=" + Database.Host + "," + Database.Port + @"\" + Database.Datasource + ";Initial Catalog=" + Database.DatabaseName + ";Persist Security Info=True;User ID=" + Database.Username + ";Password=" + Database.Password;
            try
            {
                this.SqlConn = new SqlConnection(connString);
                this.SqlConn.Open();
            }
            catch { }
            if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
            {
                if (chkTaoMoi.Checked == true)
                {
                    this.Cursor = Cursors.WaitCursor;
                    db.CreateDatabase(SqlConn);                    
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                Messages.Show(TienIch.Access.KeyMessage.TestKetNoiLoi);
                txt_Host.Focus();
                this.Cursor = Cursors.Default;
                return false;
            }
            Database.Close(ref this.SqlConn);
            this.Cursor = Cursors.Default;
            Database.SaveConfig();
            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {            
            Database.ReadConfig();                       
            //
            radioGroupOS.SelectedIndex = 2;
            txtSchema.Enabled = false;
            txtDatabase.Enabled = false;
            txtPort.Enabled = false;
            //
            txtHost.EditValue = Database.Host;
            txtPort.EditValue = Database.Port;
            txtDatasource.EditValue = Database.Datasource;
            txtDatabase.EditValue = Database.DatabaseName;
            txtSchema.Text = Database.Schema;
            txtUser.EditValue = Database.User;
            txtPassword.EditValue = Database.Password;
            //                        
            cMauThongBao = Database.MauChuThongBaoTraXe;
            cMauThongTin = Database.MauChuThongTinTraXe;
            colorThongBao.Color = Database.MauChuThongBaoTraXe;
            colorThongTin.Color = Database.MauChuThongTinTraXe;            
            txtSoLanThongBao.Text = Database.SoLanHienThiThongBaoTraXe.ToString();
            txtTocDoThongBao.Text = Database.TocDoHieuUngThongBaoTraXe.ToString();            
        }

        private void chkAutoRun_CheckedChanged(object sender, EventArgs e)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey
                ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);

            if (chkAutoRun.Checked)
                rk.SetValue(APP_SLEDDISPLAY_AUTORUN_NAME, new FileInfo(Assembly.GetEntryAssembly().Location).Directory.ToString() + "\\" + APP_SLEDDISPLAY_AUTORUN_NAME);
            else
                rk.DeleteValue(APP_SLEDDISPLAY_AUTORUN_NAME, false);
        }

        private bool runCreateDatabase(string connString, string dbName)
        {
            bool result = false;
            //conn.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=123";
            SqlConnection conn = new SqlConnection(connString);            
            try
            {
                conn.Open();
                result = CreateDatabase(conn, dbName);

            }
            catch (System.Exception ex)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }

            return result;

        }

        //Create Database function
        private bool CreateDatabase(SqlConnection sqlConn, string dbName)
        {
            String connString;
            if(sqlConn.State != ConnectionState.Open)
            {
                return false;
            }
            bool IsExits = CheckDatabaseExists(sqlConn, dbName); //Check database exists in sql server.
            if (!IsExits)
            {
                connString = "CREATE DATABASE " + dbName + " ; ";
                SqlCommand command = new SqlCommand(connString, sqlConn);
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Tạo Database lỗi, vui long kiểm tra lại thông tin cấu hình", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                finally
                {
                    if (sqlConn.State == ConnectionState.Open)
                    {
                        sqlConn.Close();
                    }
                }
                return true;
            }
            return true;
        }      

        //Check Database exists function below
        private bool CheckDatabaseExists(SqlConnection _conn, string databaseName)
        {
            string sqlCreateDBQuery;
            bool result = false;
            if (_conn.State != ConnectionState.Open)
            {
                return false;
            }
            try
            {
                sqlCreateDBQuery = string.Format("SELECT database_id FROM sys.databases WHERE Name = '{0}'", databaseName);
                using (SqlCommand sqlCmd = new SqlCommand(sqlCreateDBQuery, _conn))
                {
                    object resultObj = sqlCmd.ExecuteScalar();
                    int databaseID = 0;
                    if (resultObj != null)
                    {
                        int.TryParse(resultObj.ToString(), out databaseID);
                    }
                    result = (databaseID > 0);
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        private void radioGroupOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


    }
}
