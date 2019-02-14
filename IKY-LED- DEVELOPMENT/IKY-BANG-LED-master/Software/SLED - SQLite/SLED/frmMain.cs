using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraBars.Alerter;


namespace SLED
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private string s_SerialPort = "";
        SQLiteConnection m_dbConnection;
        public string s_NewID;
        const string s_Database = "sled.sqlite";
        string s_MaQL = "";
        DataTable dt_HoatDongBanNang = new DataTable();
        string s_ThongBao = "";
        public frmMain()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            frmNewTable fcbv = new frmNewTable();
            fcbv.ShowDialog();
            if (fcbv.s_NewID != "")
            {
                this.s_NewID = fcbv.s_NewID;
                if (m_dbConnection == null || m_dbConnection.State != ConnectionState.Open)
                {
                    m_dbConnection = new SQLiteConnection("Data Source=sled.sqlite;Version=3;");
                    m_dbConnection.Open();
                }
                if (m_dbConnection.State == ConnectionState.Open)
                {
                    try
                    {
                        string sql = "insert into bannang (maql,id) values ('000000000000'," + this.s_NewID + ")";
                        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        command.ExecuteNonQuery();

                        refreshToolStripButton_Click(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Xử lý lỗi !","Lỗi");
                    }
                }
            }            
        }

        private void DeleteRepairZone(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn muốn xóa thông tin bàn nâng ?", "Cảnh báo", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (m_dbConnection == null || m_dbConnection.State != ConnectionState.Open)
                {
                    m_dbConnection = new SQLiteConnection("Data Source=sled.sqlite;Version=3;");
                    m_dbConnection.Open();
                }
                if (m_dbConnection.State == ConnectionState.Open)
                {
                    try
                    {
                        string s_ID = grvDuLieu.GetRowCellValue(grvDuLieu.FocusedRowHandle, "id").ToString();
                        string sql = "DELETE FROM bannang  WHERE id=" + s_ID + "";
                        SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                        command.ExecuteNonQuery();
                        refreshToolStripButton_Click(null, null);
                    }
                    catch
                    {

                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }


        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            try
            {
                string sFileDataBase = Application.ExecutablePath;
                int i_Index = sFileDataBase.LastIndexOf('\\');
                sFileDataBase = sFileDataBase.Substring(0, i_Index).Trim('\\');
                sFileDataBase = sFileDataBase + "\\" + s_Database;
                if (File.Exists(sFileDataBase) == false)
                {
                    CreatNewDatabase();
                }
            }
            catch
            {
            }
            if (m_dbConnection == null || m_dbConnection.State != ConnectionState.Open)
            {
                m_dbConnection = new SQLiteConnection("Data Source=sled.sqlite;Version=3;");
                m_dbConnection.Open();
            }
            if (m_dbConnection.State == ConnectionState.Open)
            {
                try
                {
                    string sql = "select * from port order by time asc";
                    DataTable dt = ThuVien.SQLiteLoad(m_dbConnection, sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[dt.Rows.Count - 1];
                        s_SerialPort = r["name"].ToString();
                    }
                }
                catch
                {

                }
            }
            txtTTCongGiaoTiep.Caption = s_SerialPort;
            refreshToolStripButton_Click(null,null);            
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPortSettings frm = new frmPortSettings(m_dbConnection);
            frm.ShowDialog();
            if(frm.b_ThayDoi)
            {
                restartToolStripMenuItem_Click(null, null);
            }
        }
    
        static public bool IsLoadForm(string frmActive, System.Windows.Forms.Form frmParent)
        {
            System.Windows.Forms.Form[] frmChildren = frmParent.MdiChildren;
            foreach (System.Windows.Forms.Form frmForm in frmChildren)
            {
                if (frmForm.Name.Trim().ToLower().Equals(frmActive.Trim().ToLower()))
                {
                    frmForm.Activate();
                    return true;
                }
            }
            return false;
        }

        static public int CountChildForm(System.Windows.Forms.Form frmParent)
        {
            System.Windows.Forms.Form[] frmChildren = frmParent.MdiChildren;
            return frmChildren.Count();
        }

        private void newDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_dbConnection == null)
            {
                SQLiteConnection.CreateFile("sled.sqlite");
            }
            if (m_dbConnection == null || m_dbConnection.State != ConnectionState.Open)
            {
                m_dbConnection = new SQLiteConnection("Data Source=sled.sqlite;Version=3;");
                m_dbConnection.Open();
            }
            InitDatabase(m_dbConnection);             
            MessageBox.Show("Tạo dữ liệu thành công!");
        }        

        private void grvDuLieu_DoubleClick(object sender, EventArgs e)
        {            
            //string s_time = DateTime.Now.ToString("yymmddhhmmssfff");
            //if (s_SerialPort == null || s_SerialPort == "")
            //{
            //    MessageBox.Show("Bạn chưa thiết lập cổng COM", "Cảnh báo");
            //}
            //else
            //{
            //    try
            //    {
            //        string s_QuangCao = "";
            //        string s_TTKhachHang = "";
            //        string s_Counter = "";
            //        string s_TTBienSoXe = "";
            //        string s_KTV = "";
            //        bool b_TaoMoi = true;
            //        Decimal d_TongTG = 0;
            //        string s_BanNang = grvDuLieu.GetRowCellValue(grvDuLieu.FocusedRowHandle, "id").ToString();
            //        string sql = "select * from bannang where  id = " + s_BanNang;
            //        DataTable dt = ThuVien.SQLiteLoad(m_dbConnection, sql);
            //        if (dt != null && dt.Rows.Count > 0)
            //        {
            //            DataRow r = dt.Rows[dt.Rows.Count - 1];
            //            if (r["maql"].ToString() == "0")
            //            {
            //                //sql = "UPDATE bannang SET maql = '" + s_time + "' WHERE id = " + s_BanNang;
            //                s_MaQL = s_time;
            //            }
            //            else
            //            {
            //                s_MaQL = r["maql"].ToString();
            //                s_TTKhachHang = r["khachhang"].ToString();
            //                s_TTBienSoXe = r["biensoxe"].ToString();                            
            //                b_TaoMoi = false;
            //            }
            //            d_TongTG = Convert.ToDecimal(r["counter"]);
            //            s_Counter = r["counter"].ToString();
            //            s_KTV = r["ktv"].ToString();
            //            s_QuangCao = r["greetings"].ToString();
            //        }
            //        //grdDuLieu.SendToBack();
                    
            //        //if (!IsLoadForm("frmTable", this))
            //        //{
            //        //    Form frm = new frmTable(m_dbConnection, s_BanNang, s_SerialPort, s_QuangCao, s_Counter, s_MaQL, b_TaoMoi, s_TTKhachHang, s_TTBienSoXe);
            //        //    frm.Name = "frmTable";
            //        //    frm.MdiParent = this;
            //        //    frm.FormClosed += new FormClosedEventHandler(validationForm_FormClosed);
            //        //    frm.Show();
            //        //    //frm.ShowDialog();
            //        //}
            //        frmDieuKhienBanNang frm = new frmDieuKhienBanNang(s_BanNang);
            //        frm.ShowDialog();
            //        if(frm.i_TuyChon > -1)
            //        {
            //            switch(frm.i_TuyChon)
            //            {
            //                case 0:
            //                    frmTiepNhanXe frmTNX = new frmTiepNhanXe(m_dbConnection, s_SerialPort, s_BanNang, b_TaoMoi, s_MaQL, s_TTKhachHang, s_TTBienSoXe, s_KTV);
            //                    frmTNX.ShowDialog();
            //                    break;
            //                case 1:
            //                    frmDCTGSuaChua frmDCTG = new frmDCTGSuaChua(m_dbConnection, s_SerialPort, s_BanNang, d_TongTG);
            //                    frmDCTG.ShowDialog();
            //                    break;
            //                case 2:
            //                    frmTraXe frmTX = new frmTraXe(m_dbConnection, s_SerialPort, s_BanNang, s_MaQL, s_TTKhachHang, s_TTBienSoXe, s_KTV, d_TongTG, b_TaoMoi);
            //                    frmTX.ShowDialog();
            //                    break;
            //                case 3:
            //                    frmTTCauHinhBN frmTTCHBN = new frmTTCauHinhBN(m_dbConnection, s_SerialPort, s_BanNang, s_QuangCao, s_KTV);
            //                    frmTTCHBN.ShowDialog();
            //                    break;
            //                default:
            //                    break;
            //            }
            //            refreshToolStripButton_Click(null, null);
            //        }
            //    }
            //    catch
            //    {
            //        validationForm_FormClosed(null, null);
            //    }
            //}
        }


        private void TuyChinhBanNang(int mode)
        {
            string s_time = DateTime.Now.ToString("yymmddhhmmssfff");
            if (s_SerialPort == null || s_SerialPort == "")
            {
                MessageBox.Show("Bạn chưa thiết lập cổng COM", "Cảnh báo");
            }
            else
            {
                try
                {
                    string s_QuangCao = "";
                    string s_TTKhachHang = "";
                    string s_Counter = "";
                    string s_TTBienSoXe = "";
                    string s_KTV = "";
                    bool b_TaoMoi = true;
                    Decimal d_TongTG = 0;
                    string s_BanNang = grvDuLieu.GetRowCellValue(grvDuLieu.FocusedRowHandle, "id").ToString();
                    string sql = "select * from bannang where  id = " + s_BanNang;
                    DataTable dt = ThuVien.SQLiteLoad(m_dbConnection, sql);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow r = dt.Rows[dt.Rows.Count - 1];
                        if (r["maql"].ToString() == "0")
                        {
                            //sql = "UPDATE bannang SET maql = '" + s_time + "' WHERE id = " + s_BanNang;
                            s_MaQL = s_time;
                        }
                        else
                        {
                            s_MaQL = r["maql"].ToString();
                            s_TTKhachHang = r["khachhang"].ToString();
                            s_TTBienSoXe = r["biensoxe"].ToString();
                            b_TaoMoi = false;
                        }
                        d_TongTG = Convert.ToDecimal(r["counter"]);
                        s_Counter = r["counter"].ToString();
                        s_KTV = r["ktv"].ToString();
                        s_QuangCao = r["greetings"].ToString();
                    }

                    if (mode > -1)
                    {
                        switch (mode)
                        {
                            case 0:
                                frmTiepNhanXe frmTNX = new frmTiepNhanXe(m_dbConnection, s_SerialPort, s_BanNang, b_TaoMoi, s_MaQL, s_TTKhachHang, s_TTBienSoXe, s_KTV, d_TongTG);
                                frmTNX.ShowDialog();
                                break;
                            case 1:
                                frmDCTGSuaChua frmDCTG = new frmDCTGSuaChua(m_dbConnection, s_SerialPort, s_BanNang, d_TongTG);
                                frmDCTG.ShowDialog();
                                break;
                            case 2:
                                frmTraXe frmTX = new frmTraXe(m_dbConnection, s_SerialPort, s_BanNang, s_MaQL, s_TTKhachHang, s_TTBienSoXe, s_KTV, d_TongTG, b_TaoMoi);
                                frmTX.ShowDialog();
                                break;
                            case 3:
                                frmTTCauHinhBN frmTTCHBN = new frmTTCauHinhBN(m_dbConnection, s_SerialPort, s_BanNang, s_QuangCao, s_KTV);
                                frmTTCHBN.ShowDialog();
                                break;
                            default:
                                break;
                        }
                        refreshToolStripButton_Click(null, null);
                    }
                }
                catch
                {
                    validationForm_FormClosed(null, null);
                }
            }
        }

        void validationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CountChildForm(this) < 2)
            {
                grdDuLieu.BringToFront();
                refreshToolStripButton_Click(null, null);
            }
        }


        private void CapNhatTG_SuaCHua()
        {
            string s_BanNangSuaChuaXong = "";
            try
            {
                if (dt_HoatDongBanNang != null && dt_HoatDongBanNang.Rows.Count > 0)
                {                    
                    foreach (DataRow r in dt_HoatDongBanNang.Rows)
                    {
                        Int32 TG = Convert.ToInt32(r["counter"]);
                        if (TG > 0)
                        {   
                            DateTime TGCapNhat = Convert.ToDateTime(r["time"]);
                            string s_IDMaQL = r["maql"].ToString();
                            string s_IDBanNang = r["id"].ToString();
                            string s_TTKhachHang = r["khachhang"].ToString();
                            string s_BienSoXe = r["biensoxe"].ToString();
                            string s_KyThuatVien = r["ktv"].ToString();
                            TimeSpan diff = DateTime.Now.Subtract(TGCapNhat);
                            double seconds = diff.TotalSeconds;                            
                            if (Convert.ToInt32(seconds) >= (TG * 60))
                            {
                                TuDong_TraXe(s_IDMaQL,s_IDBanNang, s_TTKhachHang, s_BienSoXe, TG.ToString(), s_KyThuatVien);
                                s_BanNangSuaChuaXong += String.Format("[{0}]",s_IDBanNang);
                            }
                        }
                    }
                }
            }
            catch
            {

            }
            if(s_BanNangSuaChuaXong != s_ThongBao)
            {
                s_ThongBao = s_BanNangSuaChuaXong;
                if (s_ThongBao != "")
                {
                    notifyIcon1.Visible = true;
                    notifyIcon1.Icon = SystemIcons.Exclamation;
                    notifyIcon1.BalloonTipTitle = "IKY-LED";
                    notifyIcon1.BalloonTipText = "Bàn nâng " + s_ThongBao + " đã sửa chữa xong";
                    notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                    notifyIcon1.ShowBalloonTip(10000);
                }
            }
        }

        private void TuDong_TraXe(string _s_MaQL,string _s_BanNang,string _s_TTKhachHang,string _s_BienSoXe ,string _s_TG,string _s_KyThuatVien)
        {
            string sql = "";
            if (m_dbConnection.State == ConnectionState.Open)
            {
                //try
                //{
                //    sql = "UPDATE bannang SET maql = '0',counter = 0 WHERE ID = " + _s_BanNang;
                //    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                //    command.ExecuteNonQuery();

                //    sql = "insert into  baocao (maql,id,khachhang,biensoxe,thoigian,ktv) values ('" + _s_MaQL + "','" + _s_BanNang + "','" + _s_TTKhachHang + "','" + _s_BienSoXe + "'," + _s_TG + ",'" + _s_KyThuatVien + "')";
                //    command = new SQLiteCommand(sql, m_dbConnection);
                //    command.ExecuteNonQuery();
                //}
                //catch { }

                if (taskbarAssistant1.ProgressMode == DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress)
                {
                    taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.Indeterminate;
                    
                    //notifyIcon1.Visible = true;
                    //notifyIcon1.Icon = SystemIcons.Exclamation;
                    //notifyIcon1.BalloonTipTitle = "IKY-LED";
                    //notifyIcon1.BalloonTipText = "Bàn nâng [" + _s_BanNang + "] đã sửa chữa xong";
                    //notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                    //notifyIcon1.ShowBalloonTip(10000);
                }
            }
        }

        private void refreshToolStripButton_Click(object sender, EventArgs e)
        {
            int i_TongBanNang = 0;
            int i_BanNangBan = 0;
            if (m_dbConnection == null || m_dbConnection.State != ConnectionState.Open)
            {
                m_dbConnection = new SQLiteConnection("Data Source=sled.sqlite;Version=3;");
                m_dbConnection.Open();
            }
            if (m_dbConnection.State == ConnectionState.Open)
            {
                try
                {
                    string sql = "select * from bannang order by id asc";
                    dt_HoatDongBanNang = ThuVien.SQLiteLoad(m_dbConnection, sql);
                    
                    if (dt_HoatDongBanNang != null && dt_HoatDongBanNang.Rows.Count > 0)
                    {
                        dt_HoatDongBanNang.Columns.Add("thoigianconlai", typeof(decimal)).DefaultValue = 0;
                        i_TongBanNang = dt_HoatDongBanNang.Rows.Count;
                        foreach (DataRow r in dt_HoatDongBanNang.Rows)
                        {
                            if (Convert.ToInt32(r["counter"]) == 0)
                            {
                                r["trangthai"] = "Rảnh";
                                r["khachhang"] = "";
                                r["biensoxe"] = "";
                                r["thoigianconlai"] = 0;
                            }
                            else
                            {
                                DateTime TGCapNhat = Convert.ToDateTime(r["time"]);                                
                                TimeSpan diff = DateTime.Now.Subtract(TGCapNhat);
                                double minutes = diff.TotalMinutes;
                                r["thoigianconlai"] = Convert.ToInt32(minutes) >= Convert.ToInt32(r["counter"]) ? 0 : Convert.ToInt32(r["counter"]) - Convert.ToInt32(minutes);
                                r["trangthai"] = "Bận";
                                i_BanNangBan++;
                            }
                        }
                    }
                    txtTrangThaiBanNang.Caption = String.Format("Hoạt động: {0}/{1}", i_BanNangBan,i_TongBanNang);
                    grdDuLieu.DataSource = dt_HoatDongBanNang;
                    if (dt_HoatDongBanNang != null && dt_HoatDongBanNang.Rows.Count > 0)
                    {
                        grvDuLieu.FocusedRowHandle = 0;
                    }
                }
                catch
                {

                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                m_dbConnection.Dispose() ;
            }
            catch { }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void CreatNewDatabase()
        {
            SQLiteConnection sqlConn = null;
            SQLiteConnection.CreateFile("sled.sqlite");
            if (sqlConn == null || sqlConn.State != ConnectionState.Open)
            {
                sqlConn = new SQLiteConnection("Data Source=sled.sqlite;Version=3;");
                sqlConn.Open();
            }
            InitDatabase(sqlConn);
            try
            {
                sqlConn.Dispose();
            }
            catch { }
        }

        private void InitDatabase(SQLiteConnection sqlConn)
        {
            if (sqlConn.State == ConnectionState.Open)
            {
                string s_Sql = "";
                DataTable dtAllColumn = new DataTable();
                try
                {
                    s_Sql = "SELECT * from sqlite_master";
                    SQLiteDataAdapter mdbAdt = new SQLiteDataAdapter(s_Sql, sqlConn);
                    mdbAdt.Fill(dtAllColumn);
                }
                catch
                {
                    dtAllColumn = new DataTable();
                    dtAllColumn.Columns.Add("name", typeof(string)).DefaultValue = "";
                }
                s_Sql = "";
                DataRow[] r_Col = null;
                SQLiteCommand command = null;
                r_Col = dtAllColumn.Select("name='port'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql = "create table port (id INTEGER PRIMARY KEY not null,name varchar(20), baud int, time TIMESTAMP DEFAULT (datetime('now','localtime')) NOT NULL);\n";
                }
                r_Col = dtAllColumn.Select("name='bannang'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table bannang (maql number(20,0) not null,id INTEGER PRIMARY KEY not null,greetings varchar(40), trangthai varchar(10),counter int DEFAULT 0,khachhang varchar(40), biensoxe varchar(40),ktv varchar(40), time TIMESTAMP DEFAULT (datetime('now','localtime')) NOT NULL);\n";
                }
                r_Col = dtAllColumn.Select("name='baocao'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table baocao (maql number(20,0) primary key not null, id not null,ktv varchar(40),khachhang varchar(40), biensoxe varchar(40),thoigian int DEFAULT 0, time TIMESTAMP DEFAULT (datetime('now','localtime')) NOT NULL);\n";
                }
                foreach (string s in s_Sql.Trim(';').Split(';'))
                {
                    if (s.Trim() != "")
                    {
                        try
                        {
                            command = new SQLiteCommand(s, sqlConn);
                            command.CommandTimeout = 50000;
                            command.ExecuteNonQuery();
                            Application.DoEvents();
                        }
                        catch
                        {
                            command.Dispose();
                            continue;
                        }
                    }
                }                
            }
        }

        public static DataTable ConvertToDataTable<X>(IEnumerable<X> varlist)
        {
            DataTable dtReturn = new DataTable();
            PropertyInfo[] oProps = null;
            bool b_OK = false;
            if (varlist == null) return dtReturn;
            foreach (X rec in varlist)
            {
                b_OK = true;
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();
                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue
                    (rec, null);
                }
                dtReturn.Rows.Add(dr);
            }
            if (!b_OK) return null;
            if (dtReturn != null)
            {
                FormatDataTable(ref dtReturn);
            }
            return dtReturn;
        }
        public static void FormatDataTable(ref DataTable dt_Table)
        {
            if (dt_Table != null)
            {

                foreach (DataColumn dcol_Currrent in dt_Table.Columns)
                {
                    dcol_Currrent.ColumnName = dcol_Currrent.ColumnName.ToLower();
                }
            }
        }

        private void BaoCaotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCao frm = new frmBaoCao(m_dbConnection);
            frm.ShowDialog();            
        }

        private void reportToolStripButton_Click(object sender, EventArgs e)
        {
            BaoCaotoolStripMenuItem_Click(null, null);
        }

        private void configToolStripButton_Click(object sender, EventArgs e)
        {
            optionsToolStripMenuItem_Click(null, null);
        }

        private void creatDBToolStripButton_Click(object sender, EventArgs e)
        {
            newDatabaseToolStripMenuItem_Click(null, null);
        }

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://iky.vn");
        }

        private void frmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 27)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn muốn thoát ứng dụng?", "Cảnh báo", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    this.Close();
                }
                else if (dialogResult == DialogResult.No)
                {

                }                
            }
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F5)
            {
                refreshToolStripButton_Click(null,null);
            }
        }

        private void btnTaoBanNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ShowNewForm(null, null);
        }

        private void btnXoaBanNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DeleteRepairZone(null, null);
        }

        private void btnLamMoiDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            CapNhatTG_SuaCHua();
            refreshToolStripButton_Click(null, null);
        }

        private void btnXemBaoCao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            BaoCaotoolStripMenuItem_Click(null, null);
        }

        private void btnTaoSoCoDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            newDatabaseToolStripMenuItem_Click(null, null);
        }

        private void btnCongGiaoTiep_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            optionsToolStripMenuItem_Click(null, null);
        }

        private void btnTrangChu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("http://iky.vn");
        }

        private void btnGioiThieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            aboutToolStripMenuItem_Click(null, null);
        }

        private void btnTTBanNang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TuyChinhBanNang(3);
        }

        private void btnTraXe_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TuyChinhBanNang(2);
        }

        private void btnChinhThoiGian_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TuyChinhBanNang(1);
        }

        private void btnTTKhachHang_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            TuyChinhBanNang(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                btnLamMoiDuLieu_ItemClick(null, null);
            });
        }

        private void frmMain_MouseClick(object sender, MouseEventArgs e)
        {
            //if(taskbarAssistant1.ProgressMode != DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress)
            //{
            //    taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress;
            //}
        }

        private void frmMain_Activated(object sender, EventArgs e)
        {
            //if (taskbarAssistant1.ProgressMode != DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress)
            //{
            //    taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress;
            //}
        }

        private void grvDuLieu_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
            if (taskbarAssistant1.ProgressMode != DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress)
            {
                taskbarAssistant1.ProgressMode = DevExpress.Utils.Taskbar.Core.TaskbarButtonProgressMode.NoProgress;
            }
        }
    }

    public class ThuVien
    {
        public static DataTable SQLiteLoad(SQLiteConnection _mdbCon, string s_Sql)
        {
            try
            {
                SQLiteCommand oLocalCommand = new SQLiteCommand(s_Sql, _mdbCon);
                SQLiteDataAdapter SQLAdt = new SQLiteDataAdapter(oLocalCommand);
                DataTable dt = new DataTable();
                SQLAdt.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
        }
        public static string ColumnExcel(int i)
        {
            string[] strArray = new string[] 
            { 
                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", 
                "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ", 
                "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ", 
                "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ",
                "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ", 
                "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ", 
                "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI", "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR", "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ", 
                "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR", "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", 
                "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HI", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HQ", "HR", "HS", "HT", "HU", "HV", "HW", "HX", "HY", "HZ",
                "IA", "IB", "IC", "ID", "IE", "IF", "IG", "IH", "II", "IJ", "IK", "IL", "IM", "IN", "IO", "IP", "IQ", "IR", "IS", "IT", "IU", "IV", "IW", "IX", "IY", "IZ", 
                "JA", "JB", "JC", "JD", "JE", "JF", "JG", "JH", "JI", "JJ", "JK", "JL", "JM", "JN", "JO", "JP", "JQ", "JR", "JS", "JT", "JU", "JV", "JW", "JX", "JY", "JZ", 
                "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KI", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KQ", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "KZ", 
                "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LI", "LJ", "LK", "LL", "LM", "LN", "LO", "LP", "LQ", "LR", "LS", "LT", "LU", "LV", "LW", "LX", "LY", "LZ", 
                "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MI", "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ", 
                "NA", "NB", "NC", "ND", "NE", "NF", "NG", "NH", "NI", "NJ", "NK", "NL", "NM", "NN", "NO", "NP", "NQ", "NR", "NS", "NT", "NU", "NV", "NW", "NX", "NY", "NZ", 
                "OA", "OB", "OC", "OD", "OE", "OF", "OG", "OH", "OI", "OJ", "OK", "OL", "OM", "ON", "OO", "OP", "OQ", "OR", "OS", "OT", "OU", "OV", "OW", "OX", "OY", "OZ", 
                "PA", "PB", "PC", "PD", "PE", "PF", "PG", "PH", "PI", "PJ", "PK", "PL", "PM", "PN", "PO", "PP", "PQ", "PR", "PS", "PT", "PU", "PV", "PW", "PX", "PY", "PZ", 
                "QA", "QB", "QC", "QD", "QE", "QF", "QG", "QH", "QI", "QJ", "QK", "QL", "QM", "QN", "QO", "QP", "QQ", "QR", "QS", "QT", "QU", "QV", "QW", "QX", "QY", "QZ", 
                "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RI", "RJ", "RK", "RL", "RM", "RN", "RO", "RP", "RQ", "RR", "RS", "RT", "RU", "RV", "RW", "RX", "RY", "RZ", 
                "SA", "SB", "SC", "SD", "SE", "SF", "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN", "SO", "SP", "SQ", "SR", "SS", "ST", "SU", "SV", "SW", "SX", "SY", "SZ", 
                "TA", "TB", "TC", "TD", "TE", "TF", "TG", "TH", "TI", "TJ", "TK", "TL", "TM", "TN", "TO", "TP", "TQ", "TR", "TS", "TT", "TU", "TV", "TW", "TX", "TY", "TZ", 
                "UA", "UB", "UC", "UD", "UE", "UF", "UG", "UH", "UI", "UJ", "UK", "UL", "UM", "UN", "UO", "UP", "UQ", "UR", "US", "UT", "UU", "UV", "UW", "UX", "UY", "UZ", 
                "VA", "VB", "VC", "VD", "VE", "VF", "VG", "VH", "VI", "VJ", "VK", "VL", "VM", "VN", "VO", "VP", "VQ", "VR", "VS", "VT", "VU", "VV", "VW", "VX", "VY", "VZ", 
                "WA", "WB", "WC", "WD", "WE", "WF", "WG", "WH", "WI", "WJ", "WK", "WL", "WM", "WN", "WO", "WP", "WQ", "WR", "WS", "WT", "WU", "WV", "WW", "WX", "WY", "WZ", 
                "XA", "XB", "XC", "XD", "XE", "XF", "XG", "XH", "XI", "XJ", "XK", "XL", "XM", "XN", "XO", "XP", "XQ", "XR", "XS", "XT", "XU", "XV", "XW", "XX", "XY", "XZ", 
                "YA", "YB", "YC", "YD", "YE", "YF", "YG", "YH", "YI", "YJ", "YK", "YL", "YM", "YN", "YO", "YP", "YQ", "YR", "YS", "YT", "YU", "YV", "YW", "YX", "YY", "YZ", 
                "ZA", "ZB", "ZC", "ZD", "ZE", "ZF", "ZG", "ZH", "ZI", "ZJ", "ZK", "ZL", "ZM", "ZN", "ZO", "ZP", "ZQ", "ZR", "ZS", "ZT", "ZU", "ZV", "ZW", "ZX", "ZY", "ZZ"
            };
            return strArray[i];
        }
    }
}