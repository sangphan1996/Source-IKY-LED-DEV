using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SLEDDatabase;

namespace SLED.Config
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void wchConfig_NextClick(object sender, DevExpress.XtraWizard.WizardCommandButtonClickEventArgs e)
        {
            switch (e.Page.Name)
            {
                case "wchTrangSled":
                    //if (!NVCheck())
                    //{
                        //e.Handled = true;
                        //wchConfig.SelectedPage = wchTrangSled;
                    //}
                    break;
                default:
                    break;
            }
        }

        internal void ReadConfig()
        {
            Database db = new Database("");

            txtDatasource.EditValue = Database.Datasource;
            txtDatabase.EditValue = Database.DatabaseName;
            txtUsername.EditValue = Database.Username;
            txtPassword.EditValue = Database.Password;
        }

        private void wchConfig_FinishClick(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void wchConfig_CancelClick(object sender, CancelEventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.ReadConfig();
        }

        //internal bool SldCheck()
        //{
            //bool b_Val = this.Check(txtNVDatabase, txtNVHost, txtNVUserLogin, txtNVPassword, txtNVSchema, txtNVPort);
            //return b_Val;
        //}

        internal bool Check(TextEdit txt_Datasource, TextEdit txt_Database, TextEdit txt_Username, TextEdit txt_Password)
        {
            this.Cursor = Cursors.WaitCursor;
        string s_NgonNgu = "vn";

        //    Messages msg = new Messages(s_NgonNgu);
        //    if (txt_NVDatabase.Text.Trim() == "")
        //    {
        //        Messages.Show(KeyMessage.ConfigTablespaceBlank);
        //        txt_NVDatabase.Focus();
        //        this.Cursor = Cursors.Default;
        //        return false;
        //    }
        //    if (txt_NVHost.Text.Trim() == "")
        //    {
        //        Messages.Show(KeyMessage.ConfigServiceNameBlank);
        //        txt_NVHost.Focus();
        //        this.Cursor = Cursors.Default;
        //        return false;
        //    }
        //    if (txt_NVUserLogin.Text.Trim() == "")
        //    {
        //        Messages.Show(KeyMessage.ConfigPasswordSystemBlank);
        //        txt_NVUserLogin.Focus();
        //        this.Cursor = Cursors.Default;
        //        return false;
        //    }
        //    if (txt_NVPassword.Text.Trim() == "")
        //    {
        //        Messages.Show(KeyMessage.ConfigUsernameBlank);
        //        txt_NVPassword.Focus();
        //        this.Cursor = Cursors.Default;
        //        return false;
        //    }
        //    if (txt_NVSchema.Text.Trim() == "")
        //    {
        //        Messages.Show(KeyMessage.ConfigPasswordBlank);
        //        txt_NVSchema.Focus();
        //        this.Cursor = Cursors.Default;
        //        return false;
        //    }
        //    if (txt_NVPort.Text.Trim() == "")
        //    {
        //        Messages.Show(KeyMessage.ConfigLoginUsernameBlank);
        //        txt_NVPort.Focus();
        //        this.Cursor = Cursors.Default;
        //        return false;
        //    }

        Database db = new Database(s_NgonNgu);

        Database.Datasource = txtDatasource.Text.Trim();
        Database.DatabaseName = txtDatabase.Text.Trim();
        Database.Username = txtUsername.Text.Trim();
        Database.Password = txtPassword.EditValue.ToString().Trim();

        //    string s_Conn = "Server=" + Database.Host + ";Port=" + Database.Port + ";User Id=" + Database.User + ";Password=" + Database.Password + ";Database=" + Database.DatabaseName + ";Encoding=UNICODE;Pooling=true;";
        //this.mdbCon = new MDBConnection(s_Conn);
        //    try
        //    {
        //        this.mdbCon.Open();
        //        string s_Sql = "";
        //        if (!db.ExistSchema(this.mdbCon, txt_NVSchema.Text.Trim()))
        //        {
        //            Messages.Show(KeyMessage.ConfigUserNotExist);
        //            txt_NVSchema.Focus();
        //            this.Cursor = Cursors.Default;
        //            return false;
        //        }
        //        s_Sql = "create table " + txt_NVSchema.Text + ".config(id numeric(2),val varchar(50),constraint pk_login primary key(id))";
        //        try
        //        {
        //            MDBCommand mdbCom = new MDBCommand(s_Sql, this.mdbCon);
        //            mdbCom = new MDBCommand(s_Sql, this.mdbCon);
        //            mdbCom.ExecuteNonQuery();
        //        }
        //        catch { }
        //    }
        //    catch (MDBException ex)
        //    {
        //        ex.LogError(ex.ToString(), "");
        //        Messages.Show(KeyMessage.TestKetNoiLoi);
        //        txt_NVHost.Focus();
        //        this.Cursor = Cursors.Default;
        //        return false;
        //    }
        //    finally
        //    {
        //        Database.Close(ref this.mdbCon);
        //    }
        //    this.Cursor = Cursors.Default;
        return true;
        }
    }
}
