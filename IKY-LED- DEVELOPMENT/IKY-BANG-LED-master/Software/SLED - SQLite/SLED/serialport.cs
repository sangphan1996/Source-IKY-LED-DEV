using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace SLED
{
    public class ThuVienSerialPort
    {
        static SerialPort serialPort = null;
        static int comBufIndex = 0;
        static byte[] comInBuffer = new byte[1024];
        static byte[] comTempBuffer = new byte[1024];
        const byte COMM_START_CODE = 0xCA;
        const int LENGTH_OFFSET = 1;
        const int OPCODE_OFFSET = 3;
        const int DATA_OFFSET = 4;
        const int HEADER_SIZE = OPCODE_OFFSET + 1;
        const int CRC_SIZE = 1;
        const int TABLE_ID_OFFSET = 1;
        const byte TABLE_REPORT_TIME = 0x01;
        const byte TABLE_REPORT_ILDE = 0x02;
        public static void serialPort_Open(string s_SerialPort)
        {
            if ((serialPort != null) && (serialPort.IsOpen))
            {
                serialPort.Close();
            }
            // open COM Port
            serialPort = new SerialPort(s_SerialPort);
            serialPort.BaudRate = 115200;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            try
            {
                serialPort.Open();
            }
            catch (Exception)
            {                
            }
        }
        public static void serialPort_Open(string s_SerialPort, bool b_Restart)
        {
            if ((serialPort != null) && (serialPort.IsOpen))
            {
                if (b_Restart == false) return;
                serialPort.Close();
            }
            // open COM Port
            serialPort = new SerialPort(s_SerialPort);
            serialPort.BaudRate = 115200;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
            try
            {
                serialPort.Open();
            }
            catch (Exception)
            {
            }
        }
        public static void serialPort_Send(byte[] buffer, int offset, int count)
        {
            int retryCount;
            serialPort.WriteTimeout = 5000;
            retryCount = 0;
            while (true)
            {
                try
                {
                    serialPort.Write(buffer, offset, count);
                    break;
                }
                catch (Exception)
                {
                    if (retryCount++ > 5)
                    {
                        return;
                    }
                }
            }
        }

        public static void serialPort_Send(SerialPort _serialPort, byte[] buffer, int offset, int count)
        {
            int retryCount;
            _serialPort.WriteTimeout = 5000;
            retryCount = 0;
            while (true)
            {
                try
                {
                    _serialPort.Write(buffer, offset, count);
                    break;
                }
                catch (Exception)
                {
                    if (retryCount++ > 5)
                    {
                        return;
                    }
                }
            }
        }

        private static void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            //string indata = sp.ReadExisting();
            //Console.WriteLine("Data Received:");
            //Console.Write(indata);
            byte[] b;
            int length;
            int copyIndex;

            length = serialPort.BytesToRead;
            b = new byte[length];
            serialPort.Read(b, 0, length);
            if (comBufIndex == 0)
            {
                copyIndex = -1;
                for (int i = 0; i < b.Length; i++)
                {
                    if (b[i] == COMM_START_CODE)
                    {
                        copyIndex = i;
                        break;
                    }
                }
                if (copyIndex < 0)
                {
                    return;
                }
                Array.Clear(comTempBuffer, 0, comTempBuffer.Length);
                Array.Copy(b, copyIndex, comTempBuffer, 0, b.Length - copyIndex);
                comBufIndex += b.Length - copyIndex;
            }
            else
            {
                Array.Copy(b, 0, comTempBuffer, comBufIndex, b.Length);
                comBufIndex += b.Length;
            }
            if (comBufIndex >= (BitConverter.ToInt16(comTempBuffer, LENGTH_OFFSET) + HEADER_SIZE + CRC_SIZE))
            {
                comBufIndex = 0;
                Array.Copy(comTempBuffer, comInBuffer, comInBuffer.Length);
                ProcessReceivedCOMData();
            }
        }

        private static void ProcessReceivedCOMData()
        {
            byte crc;
            int length;
            byte opcode;
            UInt32 packetNo;

            // should have something in the buffer
            length = BitConverter.ToInt16(comInBuffer, LENGTH_OFFSET);
            if (length <= 0)
            {
                return;
            }
            // validate the CRC
            crc = comInBuffer[HEADER_SIZE + length];
            if (crc != calcCRC(comInBuffer, DATA_OFFSET, length))
            {
                return;
            }

            opcode = comInBuffer[OPCODE_OFFSET];
            switch (opcode)
            {
                case TABLE_REPORT_ILDE:
                    packetNo = BitConverter.ToUInt32(comInBuffer, TABLE_ID_OFFSET);                    
                    break;
                case 0x5A:  // ACK
                    break;
                case 0xA5:  // NACK
                    break;
            }
        }

        private static byte calcCRC(byte[] buf, int index, int length)
        {
            byte crc;

            crc = 0;
            for (int i = index; i < index + length; i++)
            {
                crc += buf[i];
            }

            return crc;
        }
    }
}
