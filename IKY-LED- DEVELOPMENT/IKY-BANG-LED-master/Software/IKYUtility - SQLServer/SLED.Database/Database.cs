using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace IKYDatabase
{
    public class Database
    {
        static int iPhanHe = 0;
        const string APPLICATION = "IKY.Control.exe";
        const string DATASOURCETAG = "Datasource";
        const string DATABASETAG = "Database";
        const string USERNAMETAG = "User";
        const string PASSWORDTAG = "Password";
        const string SCHEMATAG = "Schema";
        const string HOSTTAG = "Host";
        const string PORTTAG = "Port";
        const string TDHUTHONGBAOTRAXETAG = "TocDoHieuUngThongBaoTraXe";
        const string SOLANHTTHONGBAOTRAXETAG = "SoLanHienThiThongBaoTraXe";
        const string MAUCHUTHONGBAOTRAXETAG = "sMauChuThongBaoTraXe";
        const string MAUCHUTHONGTINTRAXETAG = "sMauChuThongTinTraXe";              
        const string SODONGHIENTHITAG = "iSoDongHienThi";
        const string THOIGIANHIENTHITAG = "iThoiGianHienThi";
        const string TIEUDETAG = "sTieuDe";

        internal static string sFileConfig = ""; 
        internal static string sConStr = "";
        internal static string sNgonNgu = "";

        internal static string sDatasource = "IKYDB"; //SQL Server Instance name
        internal static string sDatabase = "iky";
        internal static string sUsername = "sa";
        internal static string sPassword = "123";
        internal static string sSchema = "dbo";
        internal static string sHost = "localhost";
        internal static string sPort = "1433";
        internal static Int32 iTocDoHieuUngThongBaoTraXe = 10;
        internal static Int32 iSoLanHienThiThongBaoTraXe = 3;
        internal static Color cMauChuThongBaoTraXe = System.Drawing.SystemColors.HighlightText;
        internal static Color cMauChuThongTinTraXe = Color.Lime;
        internal static Int32 iSoDongHienThi = 15;
        internal static Int32 iThoiGianHienThi = 15;        
        /// <summary>
        /// Phân hệ dựa vào database: Oracle, PostgreSQL
        /// </summary>
        public enum PhanHePhanMem
        {
            Oracle = 1,
            PostgreSQL = 2,
            SQLServer = 3,
            MySQL = 4,
        }
        /// <summary>
        /// PostgreSQL: Database; Oracle: Tablespace
        /// </summary>
        public static string DatabaseName
        {
            get { return sDatabase; }
            set
            {
                sDatabase = value.Trim();
#if SQLSERVER                   
                //sConStr = "Data Source=" + sHost + "/" + sDatasource + ";Initial Catalog=" + sDatabase + ";Persist Security Info=True;User ID=" + sUsername + ";Password=" + sPassword;
#endif
            }
        }
        /// <summary>
        /// PostgreSQL: Database; Oracle: Tablespace
        /// </summary>
        public static string Datasource
        {
            get { return sDatasource; }
            set
            {
                sDatasource = value.Trim();
#if SQLSERVER
                //chỉ có postgreSQL mới thay đổi connection, oracle, chỉ có 3 thông số: host, schema, password
                //sConStr = "Server=" + sHost + ";Port=" + sPort + ";User Id=" + sUserID + ";Password=" + sPassword + ";Database=" + sDatabase + ";Encoding=UNICODE;Pooling=true;Protocol=3;Timeout=2";//linh 20/8/15
#endif
            }
        }
        /// <summary>
        /// PostgreSQL: User; 
        /// User database, không cần phải giải mã hóa trước khi truyền vô;
        /// Oracle: không dùng thông số này
        /// </summary>
        public static string Username
        {
            get { return sUsername; }
            set
            {
                sUsername = value;

#if SQLSERVER
                //chỉ có postgreSQL mới thay đổi connection, oracle, chỉ có 3 thông số: host, schema, password
                //sConStr = "Server=" + sHost + ";Port=" + sPort + ";User Id=" + sUserID + ";Password=" + sPassword + ";Database=" + sDatabase + ";Encoding=UNICODE;Pooling=true;Protocol=3;Timeout=2";//linh 20/8/15
#endif
            }
        }
        /// <summary>
        /// PostgreSQL: Password user; Oracle: Password User
        /// </summary>
        public static string Password
        {
            get { return sPassword; }
            set
            {
                sPassword = value;
#if SQLSERVER
                //sConStr = "Server=" + sHost + ";Port=" + sPort + ";User Id=" + sUserID + ";Password=" + sPassword + ";Database=" + sDatabase + ";Encoding=UNICODE;Pooling=true;Protocol=3;Timeout=2";//linh 20/8/15
#endif
            }
        }

        /// <summary>
        /// PostgreSQL: Password user; Oracle: Password User
        /// </summary>
        public static string ConStr
        {
            get { return sConStr; }
            set
            {
                sConStr = value;                
            }
        }

        public static string Schema
        {
            get
            {
                return sSchema;
            }
            set
            {
                sSchema = value;
#if SQLSERVER
                //ConStr = "Data Source=" + sHost + "\\" + sDatasource + "," + sPort + ";Initial Catalog=" + sDatabase + ";Persist Security Info=True;User ID=" + sUsername + ";Password=" + sPassword;
#else
#endif
            }
        }

        public static string Host
        {
            get { return sHost; }
            set
            {
                sHost = value;
#if SQLSERVER
                //localhost,1433\SQLEXPRESSHAIDV
                ConStr = "Data Source=" + sHost + "," + sPort + @"\" + sDatasource + ";Initial Catalog=" + sDatabase + ";Persist Security Info=True;User ID=" + sUsername + ";Password=" + sPassword;
#else
                sConStr = "data source=" + sHost + ";User Id=" + sSchema + ";Password=" + sPassword;
#endif
            }
        }

        public static string Port
        {
            get { return sPort; }
            set
            {
                sPort = value;
#if SQLSERVER
                //ConStr = "Data Source=" + sHost + "\\" + sDatasource + "," + sPort + ";Initial Catalog=" + sDatabase + ";Persist Security Info=True;User ID=" + sUsername + ";Password=" + sPassword;
#endif
            }
        }

        public static string User
        {
            get { return sUsername; }
            set
            {
                sUsername = value;

#if SQLSERVER
                //ConStr = "Data Source=" + sHost + "\\" + sDatasource + "," + sPort + ";Initial Catalog=" + sDatabase + ";Persist Security Info=True;User ID=" + sUsername + ";Password=" + sPassword;
#endif
            }
        }

        /// <summary>
        /// Ngôn ngữ
        /// </summary>
        public string NgonNgu
        {
            get { return sNgonNgu; }
            set { sNgonNgu = value; }
        }

        /// <summary>
        /// Tốc độ chạy hiệu ứng thông báo trả xe
        /// </summary>
        public static Int32 TocDoHieuUngThongBaoTraXe
        {
            get { return iTocDoHieuUngThongBaoTraXe; }
            set { iTocDoHieuUngThongBaoTraXe = value; }
        }

        /// <summary>
        /// Số lần hiển thị thông báo trả xe
        /// </summary>
        public static Int32 SoLanHienThiThongBaoTraXe
        {
            get { return iSoLanHienThiThongBaoTraXe; }
            set { iSoLanHienThiThongBaoTraXe = value; }
        }


        /// <summary>
        /// Màu thông báo trả xe
        /// </summary>
        public static Color MauChuThongBaoTraXe
        {
            get { return cMauChuThongBaoTraXe; }
            set { cMauChuThongBaoTraXe = value; }
        }

        /// <summary>
        /// Màu thông tin trả xe
        /// </summary>
        public static Color MauChuThongTinTraXe
        {
            get { return cMauChuThongTinTraXe; }
            set { cMauChuThongTinTraXe = value; }
        }

     
        protected Database()
        {
            ReadConfig();
        }
        public Database(string s_NgonNgu)
            : this()
        {
#if POSTGRESQL
            iPhanHe = (int)PhanHePhanMem.PostgreSQL;
#elif MYSQL
                iPhanHe = (int) PhanHePhanMem.MySQL;
#elif ORACLE
                iPhanHe = (int) PhanHePhanMem.Oracle;Oracle
#else
            iPhanHe = (int)PhanHePhanMem.SQLServer;
#endif
            sNgonNgu = s_NgonNgu;
        }

        static public void SaveConfig()
        {
            InnitConfig();
        }

        static void InnitConfig()
        {
            sFileConfig = Application.ExecutablePath;
            int i_Index = sFileConfig.LastIndexOf('\\');
            sFileConfig = sFileConfig.Substring(0, i_Index).Trim('\\');
            sFileConfig = sFileConfig + "\\" + APPLICATION;
            Configuration config = ConfigurationManager.OpenExeConfiguration(sFileConfig);
            try
            {
                config.AppSettings.Settings.Remove(HOSTTAG);
                config.AppSettings.Settings.Remove(PORTTAG);
                config.AppSettings.Settings.Remove(DATASOURCETAG);
                config.AppSettings.Settings.Remove(DATABASETAG);
                config.AppSettings.Settings.Remove(SCHEMATAG);
                config.AppSettings.Settings.Remove(USERNAMETAG);
                config.AppSettings.Settings.Remove(PASSWORDTAG);
                config.AppSettings.Settings.Remove(TDHUTHONGBAOTRAXETAG);
                config.AppSettings.Settings.Remove(SOLANHTTHONGBAOTRAXETAG);
                config.AppSettings.Settings.Remove(MAUCHUTHONGBAOTRAXETAG);
                config.AppSettings.Settings.Remove(MAUCHUTHONGTINTRAXETAG);
                config.AppSettings.Settings.Remove(SODONGHIENTHITAG);
                config.AppSettings.Settings.Remove(THOIGIANHIENTHITAG);
                config.AppSettings.Settings.Remove(TIEUDETAG);
            }
            catch { }
            config.AppSettings.Settings.Add(HOSTTAG, sHost);
            config.AppSettings.Settings.Add(PORTTAG, sPort);
            config.AppSettings.Settings.Add(DATASOURCETAG, sDatasource);
            config.AppSettings.Settings.Add(DATABASETAG, sDatabase);
            config.AppSettings.Settings.Add(SCHEMATAG, sSchema);
            config.AppSettings.Settings.Add(USERNAMETAG, sUsername);
            config.AppSettings.Settings.Add(PASSWORDTAG, sPassword);
            config.AppSettings.Settings.Add(TDHUTHONGBAOTRAXETAG, iTocDoHieuUngThongBaoTraXe.ToString());
            config.AppSettings.Settings.Add(SOLANHTTHONGBAOTRAXETAG, iSoLanHienThiThongBaoTraXe.ToString());
            config.AppSettings.Settings.Add(MAUCHUTHONGBAOTRAXETAG, ColorTranslator.ToHtml(cMauChuThongBaoTraXe));
            config.AppSettings.Settings.Add(MAUCHUTHONGTINTRAXETAG, ColorTranslator.ToHtml(cMauChuThongTinTraXe));
            config.AppSettings.Settings.Add(SODONGHIENTHITAG, iSoDongHienThi.ToString());
            config.AppSettings.Settings.Add(THOIGIANHIENTHITAG, iThoiGianHienThi.ToString());
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        public static void ReadConfig()
        {
            sFileConfig = Application.ExecutablePath;
            int i_Index = sFileConfig.LastIndexOf('\\');
            sFileConfig = sFileConfig.Substring(0, i_Index).Trim('\\');
            sFileConfig = sFileConfig + "\\" + APPLICATION;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(sFileConfig);
                sHost = config.AppSettings.Settings[HOSTTAG].Value.ToString();
                sPort = config.AppSettings.Settings[PORTTAG].Value.ToString();
                sDatasource = config.AppSettings.Settings[DATASOURCETAG].Value.ToString();
                sDatabase = config.AppSettings.Settings[DATABASETAG].Value.ToString();
                sSchema = config.AppSettings.Settings[SCHEMATAG].Value.ToString();
                sUsername = config.AppSettings.Settings[USERNAMETAG].Value.ToString();
                sPassword = config.AppSettings.Settings[PASSWORDTAG].Value.ToString();
                iTocDoHieuUngThongBaoTraXe = Convert.ToInt32(config.AppSettings.Settings[TDHUTHONGBAOTRAXETAG].Value.ToString());
                iSoLanHienThiThongBaoTraXe = Convert.ToInt32(config.AppSettings.Settings[SOLANHTTHONGBAOTRAXETAG].Value.ToString());
                cMauChuThongBaoTraXe = ColorTranslator.FromHtml(config.AppSettings.Settings[MAUCHUTHONGBAOTRAXETAG].Value.ToString());
                cMauChuThongTinTraXe = ColorTranslator.FromHtml(config.AppSettings.Settings[MAUCHUTHONGTINTRAXETAG].Value.ToString());
                iSoDongHienThi = Convert.ToInt32(config.AppSettings.Settings[SODONGHIENTHITAG].Value.ToString());
                iThoiGianHienThi = Convert.ToInt32(config.AppSettings.Settings[THOIGIANHIENTHITAG].Value.ToString());
            }
            catch
            {
            }
            finally
            {
                ConStr = "Data Source=" + sHost + "," + sPort + @"\" + sDatasource + ";Initial Catalog=" + sDatabase + ";Persist Security Info=True;User ID=" + sUsername + ";Password=" + sPassword;
            }
        }

        /// <summary>
        /// Mở kết nối đến cơ sở dữ liệu
        /// </summary>
        /// <param name="mdbCon"></param>
        /// <returns></returns>
        public static bool Open(ref SqlConnection sqlCon)
        {
            try
            {
                ReadConfig();
                if (sqlCon != null && sqlCon.State == ConnectionState.Open) { return true; }
                sqlCon = new SqlConnection(sConStr);
                sqlCon.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }
       
        /// <summary>
        /// Đóng kết nối cơ sở dữ liệu
        /// </summary>
        /// <param name="mdbCon"></param>
        public static void Close(ref SqlConnection sqlCon)
        {
            try
            {
                sqlCon.Close();
            }
            catch
            { }
        }
        /// <summary>
        /// Kiểm tra xem Database được tạo hay chưa? neu otacle kiem tra tablespace
        /// </summary>
        /// <returns></returns>
        bool ExistDatabase(SqlConnection mdbCon)
        {
            try
            {
#if SQLSERVER
                string s_sql = "select name from master.dbo.sysdatabases where lower(name)='" + sDatabase.ToLower() + "'";                
#else

#endif
                SqlDataAdapter adt = new SqlDataAdapter(s_sql, mdbCon);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                if (dt.Rows.Count > 0) { return true; }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public int CreateDatabase(SqlConnection mdbCon)
        {
            int iVal = 0;
            try
            {
                if (this.ExistDatabase(mdbCon))
                {
                    iVal = this.CreateSchema(mdbCon);
                    if (iVal != (int)LoiTaoDatabase.SchemaKhongTaoDuoc)
                    {
                        CreateTable(mdbCon);
                        iVal = 0;
                    }
                }
                else
                {
                    iVal = (int)LoiTaoDatabase.DatabaseChuaTao;
                }
            }
            catch
            {
                iVal = (int)LoiTaoDatabase.DatabaseKhongTaoDuocCauTruc;
            }
            return iVal;
        }

        /// <summary>
        /// Tạo Schema, chương trình nếu chưa tạo schema
        /// </summary>
        /// <param name="_con"></param>
        public int CreateSchema(SqlConnection mdbCon)
        {
            int iVal = this.CreateSchema(mdbCon, sSchema);
            return iVal;
        }
        /// <summary>
        /// Kiểm tra xem schema đã tồn tại chưa? nếu oracle kiểm tra user
        /// </summary>
        /// <returns></returns>
        bool ExistSchema(SqlConnection mdbCon)
        {
            bool b_Val = this.ExistSchema(mdbCon, Schema);
            return b_Val;
        }

        /// <summary>
        /// Kiểm tra xem schema (trong postgre)| User (trong oracle) đã tồn tại chưa
        /// </summary>
        /// <returns></returns>
        public bool ExistSchema(SqlConnection mdbCon, string s_Schema)
        {
            try
            {
#if SQLSERVER
                string s_sql = "select name from sys.schemas where lower(name)='" + s_Schema.ToLower() + "'";                
#else                
#endif
                SqlDataAdapter adt = new SqlDataAdapter(s_sql, mdbCon);
                DataTable dt = new DataTable();
                adt.Fill(dt);
                return dt.Rows.Count > 0;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Tạo Schema, chương trình nếu chưa tạo schema
        /// </summary>
        /// <param name="_con"></param>
        public int CreateSchema(SqlConnection mdbCon, string s_Schema)
        {
            int iVal = 0;
            if (!ExistSchema(mdbCon, s_Schema))
            {
                try
                {
#if SQLSERVER
                    string s_sql = "CREATE SCHEMA " + s_Schema + " AUTHORIZATION " + sUsername + ";";
                    SqlCommand com = new SqlCommand(s_sql, mdbCon);
                    com.ExecuteNonQuery();
#else
                    
#endif

                }
                catch
                {
                    iVal = (int)LoiTaoDatabase.SchemaKhongTaoDuoc;
                }
            }

            return iVal;
        }

        public void CreateTable(SqlConnection sqlCon)
        {
            DataTable dtAllColumn = new DataTable();
            {
#if SQLSERVER
                string s_Sql = "";
                try
                {
                    string s_Exp = "";
                    for (int j = 0; j < 2; j++)
                    {
                        s_Exp += " and table_name not like '%_" + j + "%' ";
                    }
                    s_Sql = "SELECT lower(table_name) table_name,lower(column_name) column_name FROM information_schema.columns WHERE table_schema ='" + sSchema + "'" + s_Exp;
                    SqlDataAdapter mdbAdt = new SqlDataAdapter(s_Sql, sqlCon);
                    mdbAdt.Fill(dtAllColumn);
                }
                catch
                {
                    dtAllColumn = new DataTable();
                    dtAllColumn.Columns.Add("table_name", typeof(string)).DefaultValue = "";
                    dtAllColumn.Columns.Add("column_name", typeof(string)).DefaultValue = "";
                }
                s_Sql = "";
                DataRow[] r_Col = null;
                SqlCommand cmd = null;

                r_Col = dtAllColumn.Select("table_name='tshienthi'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table " + sSchema + ".tshienthi(maql numeric(20, 0) not null,header nvarchar(100), footer nvarchar(100),sodonghienthi numeric(4, 0),tghienthi numeric(4, 0),ngayud datetime default (getdate()));\n";
                }
                s_Sql += "alter TABLE " + sSchema + ".tshienthi add constraint pk_tshienthi primary key(maql);\n";

                r_Col = dtAllColumn.Select("table_name='tshethong'");
                if (r_Col == null || r_Col.Length <= 0) 
                {
                    s_Sql += "create table " + sSchema + ".tshethong(maql numeric(20, 0) not null,congcom nvarchar(10),ngayud datetime default (getdate()), tencty nvarchar(50),thongbaomacdinh nvarchar(50),thoigiantraxe numeric(18, 0));\n";                    
                }
                s_Sql += "alter TABLE " + sSchema + ".tshethong add constraint pk_tshethong primary key(maql);\n";

                r_Col = dtAllColumn.Select("table_name='dsbannang'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table " + sSchema + ".dsbannang(maql numeric(20, 0) not null,kythuatvien nvarchar(50),ngayud datetime default (getdate()),ndhienthi nvarchar(50),trangthai numeric(1, 0),thoigianbd datetime, tongthoigian numeric(18, 0),makhachhang numeric(20, 0),kichhoat numeric(1, 0));\n";                    
                }
                s_Sql += "alter table " + sSchema + ".dsbannang add constraint pk_dsbannang primary key (maql);\n";

                r_Col = dtAllColumn.Select("table_name='dskhachhang'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table " + sSchema + ".dskhachhang(maql numeric(20, 0) not null,hoten nvarchar(50), biensoxe nvarchar(50), ngayud datetime default (getdate()),trangthai numeric(1, 0));\n";                    
                }
                s_Sql += "alter table " + sSchema + ".dskhachhang add constraint pk_dskhachhang primary key (maql);\n";

                r_Col = dtAllColumn.Select("table_name='dstraxe'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table " + sSchema + ".dstraxe(maql numeric(20, 0) not null,makhachhang numeric(20, 0), ngayud datetime default (getdate()));\n";
                }
                s_Sql += "alter table " + sSchema + ".dstraxe add constraint pk_dstraxe primary key (maql);\n";

                r_Col = dtAllColumn.Select("table_name='qlbannang'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table " + sSchema + ".qlbannang(maql numeric(20,0) not null,mabannang numeric(20,0),makhachhang numeric(20,0),thoigian numeric(20,0), ngayud datetime default (getdate()));\n";
                }
                s_Sql += "alter table " + sSchema + ".qlbannang add constraint pk_qlbannang primary key (maql);\n";

                r_Col = dtAllColumn.Select("table_name='dsthongbao'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table " + sSchema + ".dsthongbao(maql numeric(20,0) not null,noidung nvarchar(50), ngayud datetime default (getdate()));\n";
                }
                s_Sql += "alter table " + sSchema + ".dsthongbao add constraint pk_dsthongbao primary key (maql);\n";

                r_Col = dtAllColumn.Select("table_name='dsthebh'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "create table " + sSchema + ".dsthebh(maql numeric(20,0) not null,idthe nvarchar(20) not null,sothe nvarchar(20) not null,hoten nvarchar(50),biensoxe nvarchar(50),sdt nvarchar(50),diachi nvarchar(100), ngayud datetime default (getdate()));\n";
                }
                s_Sql += "alter table " + sSchema + ".dsthebh add constraint pk_dsthebh primary key (idthe);\n";
                //Add column
                r_Col = dtAllColumn.Select("table_name='dstraxe' and column_name='trangthai'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "alter table " + sSchema + ".dstraxe add trangthai numeric(1, 0) default 0;\n";
                }

                r_Col = dtAllColumn.Select("table_name='dsthongbao' and column_name='trangthai'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "alter table " + sSchema + ".dsthongbao add trangthai numeric(1, 0) default 0;\n";
                }

                r_Col = dtAllColumn.Select("table_name='dstraxe' and column_name='goi'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "alter table " + sSchema + ".dstraxe add goi numeric(1, 0) default 0;\n";
                }

                r_Col = dtAllColumn.Select("table_name='tshethong' and column_name='tieude'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "alter table " + sSchema + ".tshethong add tieude nvarchar(50) not null default('');\n";
                }

                r_Col = dtAllColumn.Select("table_name='dskhachhang' and column_name='ghichu'");
                if (r_Col == null || r_Col.Length <= 0)
                {
                    s_Sql += "alter table " + sSchema + ".dskhachhang add ghichu nvarchar(500) default('');\n";
                }
                //Update later
                s_Sql += "alter TABLE " + sSchema + ".qlbannang add constraint fk_qlbannang_dskhachhang foreign key(makhachhang) references " + sSchema + ".dskhachhang(maql) ON UPDATE NO ACTION ON DELETE NO ACTION;\n";
                s_Sql += "alter TABLE " + sSchema + ".dstraxe add constraint fk_dstraxe_dskhachhang foreign key(makhachhang) references " + sSchema + ".dskhachhang(maql) ON UPDATE NO ACTION ON DELETE NO ACTION;\n";            
                cmd = null;
                foreach (string s in s_Sql.Trim(';').Split(';'))
                {
                    if (s.Trim() != "")
                    {
                        try
                        {
                            cmd = new SqlCommand(s, sqlCon);
                            cmd.CommandTimeout = 50000;
                            cmd.ExecuteNonQuery();
                            Application.DoEvents();
                        }
                        catch
                        {
                            cmd.Dispose();
                            continue;
                        }
                    }
                }
#else
#endif
            }
        }

        public enum LoiTaoDatabase
        {
            DatabaseChuaTao = 1013,
            DatabaseTaoThanhCong = 1014,
            DatabaseKhongTaoDuocCauTruc = 1015,
            SchemaKhongTaoDuoc = 1016,
            SchemaTaoThanhCong = 1017,
            TableKhongTaoDuoc = 1018,
            TableTaoThanhCong = 1019,
        }
    }
}
