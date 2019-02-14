using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IKYDatabase;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using IKY.NgonNgu;

namespace IKY.Control
{
    public partial class frmCaiDatCSDL : frmBase
    {
        private SqlConnection SqlConn = null;
        public frmCaiDatCSDL()
        {
            InitializeComponent();
        }

        private void frmCaiDatCSDL_Load(object sender, EventArgs e)
        {
            Database.ReadConfig();
            btnDongY.LinkClicked += btnDongY_LinkClicked;   
            txtHost.EditValue = Database.Host;
            txtPort.EditValue = Database.Port;
            txtDatasource.EditValue = Database.Datasource;
            txtDatabase.EditValue = Database.DatabaseName;
            txtSchema.Text = Database.Schema;
            txtUserLogin.EditValue = Database.User;
            txtPassword.EditValue = Database.Password;            
        }

        void btnDongY_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (Check(txtHost, txtPort, txtDatasource, txtDatabase, txtSchema, txtUserLogin, txtPassword))
            {
                this.Close();
            }
        }

        private void frmCaiDatCSDL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Keys)e.KeyChar == Keys.Escape)
            {
                this.Close();
            }
            else if ((Keys)e.KeyChar == Keys.Enter)
            {
                if (Check(txtHost, txtPort, txtDatasource, txtDatabase, txtSchema, txtUserLogin, txtPassword))
                {
                    this.Close();
                }
            }
        }


        internal bool Check(TextEdit txt_Host, TextEdit txt_Port, TextEdit txt_DataSource, TextEdit txt_Database, TextEdit txt_Schema, TextEdit txt_UserLogin, TextEdit txt_Password)
        {
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
            
            string s_Conn = "Data Source=" + Database.Host + "," + Database.Port + @"\" + Database.Datasource + ";Initial Catalog=" + Database.DatabaseName + ";Persist Security Info=True;User ID=" + Database.Username + ";Password=" + Database.Password;

            try
            {
                this.SqlConn = new SqlConnection(s_Conn);
                this.SqlConn.Open();
            }
            catch { }
            if(this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
            {
                
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
    }
}
