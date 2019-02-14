using Microsoft.Win32;
using NAudio.Wave;
using OpenFpt.TTS;
using IKYDatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TienIch;

namespace IKY.CallServer
{
    public partial class frmMain : Form
    {
        public const int PORTGOILOATRUNGTAM = 3939;
        public const int THOIGIANNGHI = 5000; //ms
        static string FPT_TOKEN = "0435b221e03a48fdb46e2d3aed568730";

        SqlConnection SqlConn = null;
        bool bDuocPhepGoi = false;
        bool bDuocPhepThongBao = false;

        #region Default Instance

        private static frmMain defaultInstance;

        /// <summary>
        /// Added by the VB.Net to C# Converter to support default instance behavour in C#
        /// </summary>
        public static frmMain Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new frmMain();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion
        
        public frmMain()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.SqlConn == null || this.SqlConn.State != ConnectionState.Open)
            {
                Database.Open(ref this.SqlConn);
            }
            if (this.bDuocPhepGoi)
            {
                try
                {
                    if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
                    {
                        DsTraXe ds_TraXe = new DsTraXe();
                        DataTable dtDSGoi = ds_TraXe.LoadDsGoiLayXe(SqlConn);
                        if (dtDSGoi != null && dtDSGoi.Rows.Count > 0)
                        {
                            tmrThongBao.Stop();                            
                            foreach (DataRow r in dtDSGoi.Select("", ""))
                            {
                                string s_BienSoXe = r["biensoxe"].ToString();
                                string s_TenKH = r["hoten"].ToString();
                                string s_MaQL = r["maql"].ToString();
                                if (chkGoiTenKH.Checked == false)
                                {
                                    TienIch.Media.GoiKhachHangNhanXe(s_BienSoXe.Replace("-", "").Trim());
                                }
                                else
                                {
                                    string text = "Mời khách hàng " + s_TenKH + " biển số xe " + s_BienSoXe + " đến nhận xe";
                                    PlayMp3FromUrl("nhanxe.mp3", text, Voice.hatieumai);
                                }
                                ds_TraXe.UpdateTrangThaiGoiLayXe(this.SqlConn, s_MaQL, TrangThai.TraiThaiGoiLayXe.DaGoi);
                                //Thread.Sleep(THOIGIANNGHI);
                            }
                            tmrThongBao.Start();
                        }
                    }
                }
                catch { }
            }
            if (this.bDuocPhepThongBao)
            {
                this.bDuocPhepThongBao = false;

                tmrThongBao.Stop();
                try
                {
                    if (this.SqlConn != null && this.SqlConn.State == ConnectionState.Open)
                    {
                        DsThongBao ds_Thongbao = new DsThongBao();
                        DataTable dt_ThongBao = ds_Thongbao.LoadDsHienThiThongBao(SqlConn);
                        if (dt_ThongBao != null && dt_ThongBao.Rows.Count > 0)
                        {
                            DataRow r = dt_ThongBao.Rows[0];
                            string s_ThongBao = r["noidung"].ToString();
                            if (chkGoiTenKH.Checked == true)
                            {
                                PlayMp3FromUrl("thongbao.mp3", s_ThongBao, Voice.hatieumai);
                            }
                        }
                    }
                }
                catch { }
                finally
                {
                    tmrThongBao.Stop();
                    tmrThongBao.Start();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (this.SqlConn == null || this.SqlConn.State != ConnectionState.Open)
            {
                Database.Open(ref this.SqlConn);
            }
            

            try { this.chkRun.Checked = Convert.ToBoolean(TienIch.Access.ReadOption(this.Name + "_" + this.chkRun.Name)); }
            catch { }
            try { this.chkGoiKH.Checked = Convert.ToBoolean(TienIch.Access.ReadOption(this.Name + "_" + this.chkGoiKH.Name)); }
            catch { }
            try { this.chkGoiTenKH.Checked = Convert.ToBoolean(TienIch.Access.ReadOption(this.Name + "_" + this.chkGoiTenKH.Name)); }
            catch { }

            this.bDuocPhepGoi = this.chkGoiKH.Checked;

            try
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (chkRun.Checked)
                {
                    rkApp.SetValue("MedilinkCallServer", Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp.DeleteValue("MedilinkCallServer", false);
                }
            }
            catch
            {
            }
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Save();
        }

        void Save()
        {
            try { TienIch.Access.WriteOption(this.Name + "_" + this.chkRun.Name, this.chkRun.Checked ? "true" : "false"); }
            catch { }
            try { TienIch.Access.WriteOption(this.Name + "_" + this.chkGoiKH.Name, this.chkGoiKH.Checked ? "true" : "false"); }
            catch { }
            try { TienIch.Access.WriteOption(this.Name + "_" + this.chkGoiTenKH.Name, this.chkGoiTenKH.Checked ? "true" : "false"); }
            catch { }
            try
            {
                RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (chkRun.Checked)
                {
                    rkApp.SetValue("IKYCallServer", Application.ExecutablePath.ToString());
                }
                else
                {
                    rkApp.DeleteValue("IKYCallServer", false);
                }
            }
            catch
            {
            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            notifyIconApp.Visible = true;
        }

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIconApp.Visible = true;
            }
        }

        private void notifyIconApp_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIconApp.Visible = false;
        }

        private WaveOut _waveOut;
        public void PlayMp3FromUrl(string url, string text, Voice voice)
        {
            try
            {
                Text2Speech tts = new Text2Speech(FPT_TOKEN, "");

                AsyncResponseData responseData = tts.Speech(text, voice);

                DownloadFile(responseData.async, url);                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void chkGoiKH_CheckedChanged(object sender, EventArgs e)
        {
            this.bDuocPhepGoi = chkGoiKH.Checked;
        }

        WebClient webClient;
        public void DownloadFile(string urlAddress, string location)
        {
            using (webClient = new WebClient())
            {
                try
                {
                    Uri URL = new Uri(urlAddress);
                    // Start downloading the file
                    webClient.DownloadFile(URL, location);
                    using (FileStream memoryStream = File.OpenRead(location))
                    {
                        memoryStream.Position = 0;
                        using (
                            WaveStream blockAlignedStream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(memoryStream))))
                        {
                            using (_waveOut = new WaveOut(WaveCallbackInfo.FunctionCallback()))
                            {
                                _waveOut.Init(blockAlignedStream);
                                _waveOut.Play();
                                while (_waveOut.PlaybackState == PlaybackState.Playing)
                                {
                                    Thread.Sleep(100);
                                }
                                _waveOut.Stop();
                                _waveOut.Dispose();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void tmrThongBao_Tick(object sender, EventArgs e)
        {
            this.bDuocPhepThongBao = true;            
        }
    }
}
