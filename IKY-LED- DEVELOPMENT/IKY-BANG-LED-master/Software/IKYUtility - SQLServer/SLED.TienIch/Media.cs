using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace TienIch
{
    public class Media
    {
        //public enum SoundFlags : int
        //{
        //    SND_SYNC = 0x0000,  /* play synchronously (default) */
        //    SND_ASYNC = 0x0001,  /* play asynchronously */
        //    SND_NODEFAULT = 0x0002,  /* silence (!default) if sound not found */
        //    SND_MEMORY = 0x0004,  /* pszSound points to a memory file */
        //    SND_LOOP = 0x0008,  /* loop the sound until next sndPlaySound */
        //    SND_NOSTOP = 0x0010,  /* don't stop any currently playing sound */
        //    SND_NOWAIT = 0x00002000, /* don't wait if the driver is busy */
        //    SND_ALIAS = 0x00010000, /* name is a registry alias */
        //    SND_ALIAS_ID = 0x00110000, /* alias is a predefined ID */
        //    SND_FILENAME = 0x00020000, /* name is file name */
        //    SND_RESOURCE = 0x00040004  /* name is resource name or atom */
        //}

        //[DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        //static extern bool PlaySound(string pszSound, IntPtr hMod, SoundFlags sf);

        //[DllImport("winmm.dll")]
        //static extern bool PlaySound(string lpszName, int hModule, int dwFlags);

        static void PlaySound(string lpszName)
        {
            var player = new System.Media.SoundPlayer();
            player.SoundLocation = lpszName;
            player.PlaySync();            
        }

        private static string sMoiKHCoBienSoXe = "..\\AmThanh\\Chu\\MoiKHCoBienSoXe.wav";//Mời khách hàng có biển số xe
        private static string sDenNhanXe = "..\\AmThanh\\Chu\\DenNhanXe.wav";//Đến nhận xe
        private static string sSo = "..\\AmThanh\\So\\";//Số
        private static string sChuCai = "..\\AmThanh\\ChuCai\\";//Chữ cái
        private static string sSoNgan = "..\\AmThanh\\So\\Ngan.wav";//Ngàn
        private static string sSoTram = "..\\AmThanh\\So\\Tram.wav";//Trăm
        private static string sSoMuoi = "..\\AmThanh\\So\\Muoi.wav";//Mười
        private static string sSoMuoi_Muoi = "..\\AmThanh\\So\\Muoi_Muoi.wav";//Mươi
        private static string sSoLe = "..\\AmThanh\\So\\Le.wav";//Lẻ
        private static string sSoMot = "..\\AmThanh\\So\\Mot.wav";//Mốt
        private static string sSoLam = "..\\AmThanh\\So\\Lam.wav";//Lăm
        public static void GoiKhachHangNhanXe(string s_BienSoXe)
        {
            string s_path = Application.ExecutablePath;
            string sPath = Directory.GetParent(Directory.GetParent(s_path).FullName).FullName;
            string t_tmp = sMoiKHCoBienSoXe.Trim().Trim('\\').Trim();
            t_tmp = t_tmp.Trim().Trim('.').Trim();
            t_tmp = t_tmp.Trim().Trim('\\').Trim();
            t_tmp = t_tmp.Trim().Trim('.').Trim();
            string sPathAmThanh = sPath.Trim('\\') + "\\" + t_tmp.Trim().Trim('.').Trim();
            if (File.Exists(sPathAmThanh))
            {
                //PlaySound(sPathAmThanh, IntPtr.Zero, SoundFlags.SND_FILENAME | SoundFlags.SND_NOWAIT);
                PlaySound(sPathAmThanh);
            }
            PlayBienSoXe(s_BienSoXe);
            t_tmp = sDenNhanXe.Trim().Trim('\\').Trim();
            t_tmp = t_tmp.Trim().Trim('.').Trim();
            t_tmp = t_tmp.Trim().Trim('\\').Trim();
            t_tmp = t_tmp.Trim().Trim('.').Trim();
            sPathAmThanh = sPath.Trim('\\') + "\\" + t_tmp.Trim().Trim('.').Trim();
            if (File.Exists(sPathAmThanh))
            {
                //PlaySound(sPathAmThanh, IntPtr.Zero, SoundFlags.SND_FILENAME | SoundFlags.SND_NOWAIT);
                PlaySound(sPathAmThanh);
            }
        }

        private static void PlayBienSoXe(string num)
        {
            ArrayList m_afile = new ArrayList();            
            m_afile.Clear();
            for (int i = 0; i < num.Length; i++)
            {
                if (char.IsNumber(num[i]))
                {
                    m_afile.Add(sSo + num[i].ToString() + ".wav");
                }
                else
                {
                    m_afile.Add(sChuCai + num[i].ToString().ToUpper() + ".wav");
                }
            }
            if (m_afile.Count > 0)
            {
                string s_path = Application.ExecutablePath;
                string sPath = Directory.GetParent(Directory.GetParent(s_path).FullName).FullName;
                foreach (string t in m_afile.ToArray())
                {
                    string t_tmp = t.Trim().Trim('\\').Trim();
                    t_tmp = t_tmp.Trim().Trim('.').Trim();
                    t_tmp = t_tmp.Trim().Trim('\\').Trim();
                    t_tmp = t_tmp.Trim().Trim('.').Trim();
                    string sPathAmThanh = sPath.Trim('\\') + "\\" + t_tmp.Trim().Trim('.').Trim();
                    if (File.Exists(sPathAmThanh))
                    {
                        //PlaySound(sPathAmThanh, IntPtr.Zero, SoundFlags.SND_FILENAME | SoundFlags.SND_NOWAIT);
                        PlaySound(sPathAmThanh);
                    }
                }
            }
        }
    }
}
