using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SLedComm;

namespace SLedCommExample
{
    class Program
    {
        static void Main(string[] args)
        {
            SLedPort sPort = new SLedPort();
            Console.WriteLine("SLedCommExample");
            sPort.Open("COM18"); //Mở cổng COM giao tiếp với module
            sPort.AdjustRepairTime(1,10); //Chỉnh lại thời gian sửa chữa
            sPort.RepairFinished(1,"Thong Tin Lay Xe"); //Trả xe hiển thị thông tin lên màn hình
            sPort.Greeting(1,"Thong Tin Quang Cao"); //Cấu hình nội dung hiển thị khi không sửa chữa
            sPort.UserInfor(1, "Thong Tin KH", "Bien So Xe", 30); //Nhập thông tin khách hàng sửa chữa
            Console.ReadLine();
        }
    }
}
