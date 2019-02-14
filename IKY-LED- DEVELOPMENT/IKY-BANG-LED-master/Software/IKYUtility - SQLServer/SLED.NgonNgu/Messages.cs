using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TienIch;

namespace IKY.NgonNgu
{
    public class Messages
    {
        static string sNgonNgu = "";
        static TienIch.Access.KeyMessage Resource = 0;

        /// <summary>
        /// Không dùng phương thức khởi tạo này.
        /// </summary>
        protected Messages()
        {
        }

        public Messages(string s_Ngonngu)
        {
            if (s_Ngonngu == "")
            {
                s_Ngonngu = "_vn";
            }
            sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'v', 'n' });
            sNgonNgu = "_" + s_Ngonngu.Trim('_');
        }

        /// <summary>
        /// Dùng phương thức khởi tạo này thì chỉ cần dùng hàm Show() khi cần message thông báo
        /// </summary>
        /// <param name="s_Ngonngu"></param>
        /// <param name="s_Resource"></param>
        public Messages(string s_Ngonngu, TienIch.Access.KeyMessage s_Resource)
        {
            if (s_Ngonngu == "")
            {
                s_Ngonngu = "_vn";
            }
            sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'v', 'n' });
            sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'e', 'n' });
            sNgonNgu = "_" + s_Ngonngu.Trim('_');
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }

        }

        /// <summary>
        ///  Lấy nội dung của Resource, tùy theo ngôn ngữ lúc truyền vào
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <param name="s_NgonNgu"></param>
        /// <returns></returns>
        public static string Message(string s_Resource, string s_NgonNgu)
        {
            try
            {
                if (s_NgonNgu == "") { s_NgonNgu = "_vn"; }
                sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'v', 'n' });
                sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'e', 'n' });
                sNgonNgu = "_" + s_NgonNgu.Trim('_');
                ResourceManager res = new ResourceManager("IKY.NgonNgu.Messages" + sNgonNgu, System.Reflection.Assembly.GetAssembly(typeof(IKY.NgonNgu.Messages_vn)));
                string sMsg = res.GetString(s_Resource);
                return sMsg == null ? s_Resource : sMsg;
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                return s_Resource;
            }
        }

        /// <summary>
        /// Trả về nội dung của KeyMessage, tùy vào ngôn ngữ lúc khởi tạo, phải khỏi tạo biến ngôn ngữ trước.
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <returns></returns>
        static string Message(TienIch.Access.KeyMessage s_Resource)
        {
            try
            {
                if (sNgonNgu == "") { sNgonNgu = "_vn"; }
                string sMsg = Message(s_Resource.ToString(), sNgonNgu);
                return sMsg;
            }
            catch (Exception ex)
            {
                string s = ex.ToString();
                return s_Resource.ToString();
            }
        }

        /// <summary>
        /// Lấy nội dung của KeyMessage, tùy theo ngôn ngữ lúc truyền vào
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <param name="s_Ngonngu">Nếu ngôn ngữ là rỗng, mặc định sẽ là ngôn ngữ tiếng việt</param>
        /// <returns></returns>
        public static string Message(TienIch.Access.KeyMessage s_Resource, string s_NgonNgu)
        {
            string sMsg = Message(s_Resource.ToString(), s_NgonNgu);
            return sMsg;
        }

        /// <summary>
        /// Lấy nội dung của KeyMessage, tùy theo ngôn ngữ lúc truyền vào
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <param name="s_Ngonngu">Nếu ngôn ngữ là rỗng, mặc định sẽ là ngôn ngữ tiếng việt</param>
        /// <returns></returns>
        //public static string Message(Module s_Resource, string s_NgonNgu)
        //{
        //    string sMsg = Message(s_Resource.ToString(), s_NgonNgu);
        //    return sMsg;
        //}

        /// <summary>
        /// Lấy nội dung của KeyMessage, tùy theo ngôn ngữ lúc truyền vào
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <param name="s_Ngonngu">Nếu ngôn ngữ là rỗng, mặc định sẽ là ngôn ngữ tiếng việt</param>
        /// <returns></returns>
        //public static string Message(DanhMucNhomPhieu s_Resource, string s_NgonNgu)
        //{
        //    string sMsg = Message(s_Resource.ToString(), s_NgonNgu);
        //    return sMsg;
        //}

        /// <summary>
        /// Chỉ dùng cảnh báo trong các trường hợp lỗi, không dùng trong trường hợp hỏi để user lựa chọn.
        /// </summary>
        /// <param name="s_Ngonngu"></param>
        /// <param name="s_Resource"></param>
        public static void Show(string s_Ngonngu, TienIch.Access.KeyMessage s_Resource)
        {
            if (s_Ngonngu == "")
            {
                s_Ngonngu = "_vn";
            }
            sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'v', 'n' });
            sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'e', 'n' });
            sNgonNgu = "_" + s_Ngonngu.Trim('_');
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            string sMsg = Message(s_Resource).Trim();
            if (sMsg == "")
            {
                //sMsg = PMS.NgonNgu.Messages.Message(s_Resource.ToString(), s_Ngonngu);
            }
            XtraMessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo, tức là đã truyền biến ngôn ngữ ít nhất 1 lần;
        /// Chỉ dùng cảnh báo trong các trường hợp lỗi, không dùng trong trường hợp hỏi để user lựa chọn;
        /// </summary>
        /// <param name="s_Resource"></param>
        public static void Show(TienIch.Access.KeyMessage s_Resource)
        {
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            string sMsg = Message(s_Resource);
            XtraMessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo 2 biến ngôn ngữ và Resource;
        /// Chỉ dùng cảnh báo trong các trường hợp lỗi, không dùng trong trường hợp hỏi để user lựa chọn;
        /// </summary>
        public static void Show()
        {
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            if (Resource == 0)
            {
                throw new Exception("không có thông tin resource");
            }
            string msg = Message(Resource);
            XtraMessageBox.Show(msg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //HaiDV - 21/10/15
        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo, tức là đã truyền biến ngôn ngữ ít nhất 1 lần;
        /// Chỉ dùng cảnh báo trong các trường hợp lỗi, không dùng trong trường hợp hỏi để user lựa chọn;
        /// </summary>
        /// <param name="s_Resource"></param>
        public static void ShowBMS(TienIch.Access.KeyMessage s_Resource)
        {
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            string sMsg = Message(s_Resource);
            XtraMessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //ThanhCuong - 06/04/2014
        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo, tức là đã truyền biến ngôn ngữ ít nhất 1 lần;
        /// Chỉ dùng cảnh báo trong các trường hợp lỗi, không dùng trong trường hợp hỏi để user lựa chọn;
        /// </summary>
        /// <param name="s_Resource"></param>
        public static void ShowMMS(TienIch.Access.KeyMessage s_Resource)
        {
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            string sMsg = Message(s_Resource);
            XtraMessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo, tức là đã truyền biến ngôn ngữ ít nhất 1 lần;
        /// Chỉ dùng cảnh báo trong các trường hợp lỗi, không dùng trong trường hợp hỏi để user lựa chọn;
        /// </summary>
        /// <param name="s_Resource"></param>
        public static void ShowBLMS(TienIch.Access.KeyMessage s_Resource)
        {
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            string sMsg = Message(s_Resource);
            XtraMessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo, tức là đã truyền biến ngôn ngữ ít nhất 1 lần;
        /// Chỉ dùng cảnh báo trong các trường hợp lỗi, không dùng trong trường hợp hỏi để user lựa chọn;
        /// </summary>
        /// <param name="s_Resource"></param>
        public static void ShowAMS(TienIch.Access.KeyMessage s_Resource)
        {
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            string sMsg = Message(s_Resource);
            XtraMessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Không cần phương thức khởi tạo;
        /// Chỉ dùng trong trường hợp hỏi để user lựa chọn,không dùng trong các trường hợp cảnh báo lỗi;
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <returns>Dữ liệu trả về kiểu Yes / No</returns>
        public static DialogResult QuestionMMS(TienIch.Access.KeyMessage s_Resource)
        {
            string msg = Message(s_Resource);
            DialogResult diag = XtraMessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return diag;
        }

        /// <summary>
        /// Không cần phương thức khởi tạo;
        /// Chỉ dùng trong trường hợp hỏi để user lựa chọn,không dùng trong các trường hợp cảnh báo lỗi;
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <returns>Dữ liệu trả về kiểu Yes / No</returns>
        public static DialogResult QuestionBLMS(TienIch.Access.KeyMessage s_Resource)
        {
            string msg = Message(s_Resource);
            DialogResult diag = XtraMessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return diag;
        }

        /// <summary>
        /// Không cần phương thức khởi tạo;
        /// Chỉ dùng trong trường hợp hỏi để user lựa chọn,không dùng trong các trường hợp cảnh báo lỗi;
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <returns>Dữ liệu trả về kiểu Yes / No</returns>
        public static DialogResult QuestionAMS(TienIch.Access.KeyMessage s_Resource)
        {
            string msg = Message(s_Resource);
            DialogResult diag = XtraMessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return diag;
        }
        //end

        /// <summary>
        /// Không cần phương thức khởi tạo;
        /// Chỉ dùng trong trường hợp hỏi để user lựa chọn,không dùng trong các trường hợp cảnh báo lỗi;
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <returns>Dữ liệu trả về kiểu Yes / No</returns>
        public static DialogResult Question(TienIch.Access.KeyMessage s_Resource)
        {
            string msg = Message(s_Resource);
            DialogResult diag = XtraMessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return diag;
        }

        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo, tức là đã truyền biến ngôn ngữ ít nhất 1 lần;
        /// Chỉ dùng trong trường hợp hỏi để user lựa chọn,không dùng trong các trường hợp cảnh báo lỗi;
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <param name="s_NgonNgu"></param>
        /// <returns>Dữ liệu trả về kiểu Yes / No</returns>
        public static DialogResult Question(TienIch.Access.KeyMessage s_Resource, string s_NgonNgu)
        {
            sNgonNgu = s_NgonNgu;
            string msg = Message(s_Resource);
            DialogResult diag = XtraMessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return diag;
        }

        /// <summary>
        /// Chỉ dùng khi đã có phương thức khởi tạo, tức là đã truyền biến ngôn ngữ ít nhất 1 lần;
        /// Chỉ dùng trong trường hợp hỏi để user lựa chọn,không dùng trong các trường hợp cảnh báo lỗi;
        /// </summary>
        /// <param name="s_Resource"></param>
        /// <param name="s_NgonNgu"></param>
        /// <returns>Dữ liệu trả về kiểu Yes / No</returns>
        public static DialogResult QuestionAMS(TienIch.Access.KeyMessage s_Resource, string s_NgonNgu)
        {
            sNgonNgu = s_NgonNgu;
            string msg = Message(s_Resource);
            DialogResult diag = XtraMessageBox.Show(msg, Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            return diag;
        }

        public string Title
        {
            get { return Application.ProductName; }
        }

        public static string NgonNgu
        {
            get { return sNgonNgu; }
            set { sNgonNgu = value; }
        }

        //Tú:30/07/2014
        /// <summary>
        /// Chỉ dùng để hiện thông báo, không dùng trong trường hợp lỗi
        /// </summary>
        /// <param name="s_Ngonngu"></param>
        /// <param name="s_Resource"></param>
        public static void ShowInfo(string s_Ngonngu, TienIch.Access.KeyMessage s_Resource)
        {
            if (s_Ngonngu == "")
            {
                s_Ngonngu = "_vn";
            }
            sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'v', 'n' });
            sNgonNgu = sNgonNgu.TrimEnd(new char[3] { '_', 'e', 'n' });
            sNgonNgu = "_" + s_Ngonngu.Trim('_');
            if (sNgonNgu == "") { sNgonNgu = "_vn"; }
            string sMsg = Message(s_Resource).Trim();
            if (sMsg == "")
            {
                // sMsg = PMS.NgonNgu.Messages.Message(s_Resource.ToString(), s_Ngonngu);
            }
            XtraMessageBox.Show(sMsg, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
