using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace pro_test
{
    class IniReadWrite
    {
        [DllImport("kernel32.dll")]

        private static extern int GetPrivateProfileString(

           String section, String key, String def, StringBuilder retVal, int Size, String filePat);


        [DllImport("Kernel32.dll")]

        private static extern long WritePrivateProfileString(

            String Section, String Key, String val, String filePath);

        public void IniWriteValue(String Section, String Key, String Value, string avaPath)
        {

            WritePrivateProfileString(Section, Key, Value, avaPath);

        }

        public String IniReadValue(String Section, String Key, string avsPath)
        {

            StringBuilder temp = new StringBuilder(2000);

            int i = GetPrivateProfileString(Section, Key, "", temp, 2000, avsPath);

            return temp.ToString();

        }
    }
}
