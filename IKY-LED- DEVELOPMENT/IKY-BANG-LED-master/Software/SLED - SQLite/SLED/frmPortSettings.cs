using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Data.SQLite;

namespace SLED
{
    public partial class frmPortSettings : Form
    {
        internal SQLiteConnection SQLiteCon = null;
        public bool b_ThayDoi = false;
        public frmPortSettings()
        {
            InitializeComponent();
        }

        public frmPortSettings(SQLiteConnection _SQLiteCon)
        {
            InitializeComponent();
            SQLiteCon = _SQLiteCon;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPortSettings_Load(object sender, EventArgs e)
        {
            var ports = SerialPort.GetPortNames();
            //cbbSerialPorts.DataSource = ports;
            foreach (var item in ports)
            {
                cbbSerialPorts.Properties.Items.Add(item.ToString());
            }
            cbbSerialPorts.SelectedIndex = 0;
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            if (cbbSerialPorts.SelectedIndex > -1)
            {
                if (SQLiteCon == null || SQLiteCon.State != ConnectionState.Open)
                {
                    SQLiteCon = new SQLiteConnection("Data Source=sled.sqlite;Version=3;");
                    SQLiteCon.Open();
                }
                if (SQLiteCon.State == ConnectionState.Open)
                {
                    string sql = "select * from port";
                    DataTable dt = ThuVien.SQLiteLoad(SQLiteCon, sql);
                    sql = "insert into port (id,name, baud) values (1,'" + cbbSerialPorts.SelectedItem.ToString() + "', 115200)";
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow[] r_Col = dt.Select("id=1");
                        if (r_Col != null && r_Col.Length > 0)
                        {
                            sql = "UPDATE port SET name = '" + cbbSerialPorts.SelectedItem.ToString() + "' WHERE ID = 1";
                        }
                    }
                    try
                    {
                        SQLiteCommand command = new SQLiteCommand(sql, SQLiteCon);
                        command.ExecuteNonQuery();
                    }
                    catch { }
                }
                b_ThayDoi = true;
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ", "Lỗi!");
            }
            this.Close();
        }

        private void frmPortSettings_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

    }
}
