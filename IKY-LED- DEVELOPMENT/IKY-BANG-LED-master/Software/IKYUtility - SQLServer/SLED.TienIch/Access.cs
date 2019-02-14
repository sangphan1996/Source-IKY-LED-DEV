using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Xml;

namespace TienIch
{
    public class Access
    {
        const string FOLDERXML = "..//..//IKYxml";

        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        /// <summary>
        /// Kiểm tra xem form đã được mở hay chưa, nếu mở rồi thì active form, ngược lại thì open form
        /// </summary>
        /// <param name="frmActive"></param>
        /// <param name="frmParent"></param>
        /// <returns></returns>
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

        public static string PATHXML
        {
            get
            {
                string s_Temp = FOLDERXML.Replace("/", "");
                s_Temp = s_Temp.Trim('.');
                string s_Path = System.IO.Directory.GetParent(FOLDERXML).ToString() + "\\" + s_Temp;
                if (!System.IO.Directory.Exists(s_Path)) { System.IO.Directory.CreateDirectory(s_Path); }
                return s_Path;
            }
        }

        static string sPathOptionFile
        {
            get
            {
                string s_Val = "option.xml";
                return s_Val;
            }
        }

        public static void WriteOption(string s_TenCot, string s_GiaTri)
        {
            SaveXml(sPathOptionFile, s_TenCot, s_GiaTri);
        }

        public static string ReadOption(string s_TenCot)
        {
            return ReadXML(sPathOptionFile, s_TenCot);
        }

        public static string ReadXML(string s_TenFile, string s_TenCot)
        {
            try
            {
                s_TenFile = s_TenFile.TrimEnd(new char[4] { '.', 'x', 'm', 'l' });
                string s_FileXML = PATHXML + "\\" + s_TenFile + ".xml";
                XmlDocument document = new XmlDocument();
                document.Load(s_FileXML);
                return document.GetElementsByTagName(s_TenCot).Item(0).InnerText;
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Ghi file xml xuống máy theo đường dẫn mặc định cùng cấp với thư mục gốc chứa
        /// </summary>
        /// <param name="s_TenFile"></param>
        /// <param name="s_TenCot"></param>
        /// <param name="s_Val"></param>
        /// <param name="b_WithSchema"></param>
        public static void SaveXml(string s_TenFile, string s_TenCot, string s_GiaTri)
        {
            try
            {
                s_TenFile = s_TenFile.TrimEnd(new char[4] { '.', 'x', 'm', 'l' });
                string s_FileXML = PATHXML + "\\" + s_TenFile + ".xml";
                if (System.IO.File.Exists(s_FileXML))
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(s_FileXML, XmlReadMode.ReadSchema);
                    try
                    {
                        ds.Tables[0].Rows[0][s_TenCot] = s_GiaTri;
                    }
                    catch
                    {
                        DataColumn column = new DataColumn();
                        column.ColumnName = s_TenCot;
                        column.DataType = Type.GetType("System.String");
                        ds.Tables[0].Columns.Add(column);
                        ds.Tables[0].Rows[0][s_TenCot] = s_GiaTri;
                    }
                    ds.WriteXml(s_FileXML, XmlWriteMode.WriteSchema);
                }
                else
                {
                    DataTable dt = new DataTable(s_TenFile);
                    dt.TableName = s_TenFile;
                    dt.Columns.Add(s_TenCot, typeof(string)).DefaultValue = s_GiaTri;
                    DataRow nr = dt.NewRow();
                    dt.Rows.Add(nr);
                    dt.AcceptChanges();
                    DataSet ds = new DataSet();
                    ds.Tables.Add(dt.Copy());
                    ds.WriteXml(s_FileXML, XmlWriteMode.WriteSchema);
                }
            }
            catch
            {
            }
        }
        
        public enum KeyMessage
        {
            KhongLoi = 0,
            ToanQuyen = 1,
            QuanTri = 2,
            NguoiDung = 3,
            Title = 7,
            TimKiem = 8,
            NgayInvalid = 9,
            NgayBlank = 10,
            NumberInvalid = 11,
            EmailInvalid = 12,

            ConfigDatabase = 10001,
            ConfigHost = 10002,
            ConfigPassword = 10003,
            ConfigPort = 10004,
            ConfigSchema = 10005,
            ConfigUser = 10006,
            TestKetNoiLoi = 10008,
            TestKetNoiOK = 10009,
            ConfigTablespaceBlank = 10010,
            ConfigServiceNameBlank = 10011,
            ConfigPasswordSystemBlank = 10012,
            ConfigUsernameBlank = 10013,
            ConfigPasswordBlank = 10014,
            ConfigLoginUsernameBlank = 10015,
            ConfigLoginPasswordBlank = 10016,
            ConfigLoginConfirmBlank = 10017,
            ConfigLoginPasswordInvalid = 10018,//password # confirm password
            ConfigServiceBNSystem = 10019,
            ConfigServiceBNUser = 10020,
            ConfigServiceBNUserLogin = 10021,
            ConfigServiceDuocSystem = 10022,
            ConfigServiceDuocUser = 10023,
            ConfigServiceDuocUserLogin = 10024,
            ConfigServiceVPSystem = 10025,
            ConfigServiceVPUser = 10026,
            ConfigServiceVPUserLogin = 10027,
            ConfigServiceCDHASystem = 10028,
            ConfigServiceCDHAUser = 10029,
            ConfigServiceCDHAUserLogin = 10030,
            ConfigServiceXNSystem = 10031,
            ConfigServiceXNUser = 10032,
            ConfigServiceXNUserLogin = 10033,
            ConfigTablespaceNotExist = 10034,
            ConfigUserNotExist = 10035,
            ConfigSaveError = 10036,

            LoiMatKhauTruyCap = 10037,
            LoginUserTrang = 10038,
            LoginPasswordTrang = 10039,

            //Có liên quan đến class database: enum loidatabase.
            DatabaseChuaTao = 10040,
            DatabaseTaoThanhCong = 10041,
            DatabaseKhongTaoDuocCauTruc = 10042,
            SchemaKhongTaoDuoc = 10043,
            SchemaTaoThanhCong = 10044,
            TableKhongTaoDuoc = 10045,
            TableTaoThanhCong = 10046,            

            IDTheBHKhongHopLe = 10047,
            SoTheBHKhongHopLe = 10048,
            UpdateError = 10049,
            DatabaseTaoKhongThanhCong = 10050,
            CauHinhSQLServerKhongThanhCong = 10051,
        }
    }
}
