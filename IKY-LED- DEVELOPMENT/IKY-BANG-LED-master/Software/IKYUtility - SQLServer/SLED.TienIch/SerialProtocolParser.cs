using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TienIch
{
    public class SerialProtocolParser
    {
        const string PROTOCOL_HEADER = "$CID,";
        const string PROTOCOL_FOOTER = ",#";
        public static bool Check(string s_Data)
        {
            if (s_Data.IndexOf(PROTOCOL_HEADER) > -1 && s_Data.IndexOf(PROTOCOL_FOOTER) > -1)
            {
                return true;
            }
            return false;
        }

        public static string Parser(string s_Data)
        {
            int i_Start = s_Data.IndexOf(PROTOCOL_HEADER);
            int i_End = s_Data.IndexOf(PROTOCOL_FOOTER);
            if (i_Start > -1 && i_End > -1)
            {
                string[] s_DataArr = s_Data.Split(',');
                if (s_DataArr.Length > 1)
                {
                    return s_DataArr[1].Trim();
                }
            }
            return "";
        }
    }
}
