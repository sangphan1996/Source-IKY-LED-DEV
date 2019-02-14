using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TienIch
{
    public class TrangThai
    {
        public enum TraiThaiGoiLayXe
        {
            DaGoi = 0,
            DangGoi = 1,
        }

        public enum TrangThaiKichHoatBanNang
        {
            HoatDong = 0,
            KhongHoatDong = 1,
        }

        public enum TrangThaiBanNang
        {
            DangSuaChua = 0,
            DangRanh = 1,
            KhongHoatDong = 2,
            ChoNhanXe = 3,
            KhongXacDinh = 4,
        }

        public enum TrangThaiKhachHang
        {
            DangChoSuaChua = 0,
            DangSuaChua = 1,
            KetThucSuaChua = 2,
        }

        public static string TrangThaiKhachHang2String(TrangThaiKhachHang TT)
        {
            string sKQ = "";
            switch(TT)
            {
                case TrangThaiKhachHang.DangChoSuaChua:
                    sKQ = "Rảnh";
                    break;
                case TrangThaiKhachHang.DangSuaChua:
                    sKQ = "Đang sửa chữa";
                    break;
                default:
                    sKQ = "Ngừng hoạt động";
                    break;
            }
            return sKQ;
        }

        public static string TrangThaiBanNang2String(TrangThaiBanNang TT)
        {
            string sKQ = "";
            switch (TT)
            {
                case TrangThaiBanNang.ChoNhanXe:
                    sKQ = "Đã xong";//"Chờ nhận xe";
                    break;
                case TrangThaiBanNang.DangSuaChua:
                    sKQ = "Đang sửa";//"Đang sửa chữa";
                    break;
                case TrangThaiBanNang.DangRanh:
                    sKQ = "Đang rảnh";
                    break;
                default:
                    sKQ = "Ngừng hoạt động";
                    break;
            }
            return sKQ;
        }
    }
}
