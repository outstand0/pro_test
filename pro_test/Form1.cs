#define testx
#define TM05

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.IO.Ports;

namespace pro_test
{
    public partial class Form1 : Form
    {

        static public string gDutName;
        static public string gSwVersion;
        static public string gManufactureDate;

        static public string gFwVersion;
        static public string gFwRegion;

        static public string gDefaultBdNap;
        static public string gDefaultBdUap;
        static public string gDefaultBdLap;

        static public string gBdNap;
        static public string gBdUap;
        static public string gBdLapStart;
        static public string gBdLapEnd;

        static public string dutFullBdAddress;

        static public string gBdLapWriteNext;

        static public string gLineInfoA;
        static public string gLineInfoB;

        public string comPort;
        public string comPort_num;

        static public string gAppName;
        static public string gCheckOnly;

        static public string gSoundNg1 = System.IO.Directory.GetCurrentDirectory() + "\\" + "sound\\" + "ng_merge.wav";

        static public string pathLogFile;
        static public string pathDupeLogFile;

        public UInt32 totalCount = 0;
        public UInt32 passCount = 0;
        public UInt32 failCount = 0;

        public string[] ngDesc = new string[30];
        static public string typeNg = "";

        static public int gCountSequence = 0;
        public string[] gtestSequence = new string[30];
        public string[] gtestValue = new string[30];
        public string[] gNgType = new string[30];

        static public int gLatestDupeRow = 0;

        string pathConfigFile;
        private string gNcCheck;

        public string program_name;

        public String msg;

        public Form1()
        {
            InitializeComponent();
#if test
            foreach (string portnumber in PortName)
            {
                Port_Combobox.Items.Add(portnumber);
            }
#endif
        }

        private void initDataGridView()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.ColumnHeadersVisible = true;

            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();

            columnHeaderStyle.BackColor = Color.Blue;
            columnHeaderStyle.Font = new Font("Arial", 8, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;

            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 257;
            dataGridView1.Columns[2].Width = 200;
            dataGridView1.Columns[3].Width = 200;
            dataGridView1.Columns[4].Width = 300;

            dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns[0].Name = "No.";
            dataGridView1.Columns[1].Name = "Item";
            dataGridView1.Columns[2].Name = "Config";
            dataGridView1.Columns[3].Name = "Value";
            dataGridView1.Columns[4].Name = "Result";

        }
        private void initDataGridView2()
        {
            dataGridView2.ColumnCount = 4;
            dataGridView2.ColumnHeadersVisible = true;

            DataGridViewCellStyle columnHeaderStyle2 = new DataGridViewCellStyle();

            columnHeaderStyle2.BackColor = Color.Blue;
            columnHeaderStyle2.Font = new Font("Arial", 8, FontStyle.Bold);
            dataGridView2.ColumnHeadersDefaultCellStyle = columnHeaderStyle2;

            dataGridView2.Columns[0].Width = 50;
            dataGridView2.Columns[1].Width = 250;
            dataGridView2.Columns[2].Width = 130;
            dataGridView2.Columns[3].Width = 130;

            dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView2.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView2.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView2.Columns[0].Name = "No.";
            dataGridView2.Columns[1].Name = "BD";
            dataGridView2.Columns[2].Name = "Result";
            dataGridView2.Columns[3].Name = "Dupe";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initDataGridView();
            initDataGridView2();

            loadConfig();
            Combobox_Data_Add();

            checkLogFile();
            checkDupeLogFile();

            //update count
            tb_totalCount.Text = totalCount.ToString();
            tb_passCount.Text = passCount.ToString();
            failCount = totalCount - passCount;
            tb_failCount.Text = (totalCount - passCount).ToString();                    
            if(program_name == "LR_PAIRING")
            {
                
            }
            else
            {
                if (serialPort1.IsOpen == false)
                {
                    port_open();
                }
                else
                    port_close();
                Console.WriteLine("[yspark]PORT OPEN : {0}", _Port.PortName);
            }

            
            //button2.PerformClick();

            btnStart.Focus();
        }

        private void clearDisp()
        {
            for (int row = 0; row < Form1.gCountSequence; row++)
            {
                dataGridView1.Rows[row].Cells[3].Value = "-";
                dataGridView1.Rows[row].Cells[4].Value = "-";
                dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Empty;
            }
            dataGridView2.Rows[gLatestDupeRow].DefaultCellStyle.BackColor = Color.Empty;

            lbResult.Text = "--";
            lbResult.ForeColor = Color.Empty;
            lbResult.BackColor = Color.Empty;
        }

        private void NgSound()
        {
            SoundPlayer sound1 = new SoundPlayer(gSoundNg1);

            sound1.Play();
        }

        private void Combobox_Data_Add()
        {
            cbTestSelect.Items.Add("BD_CHECKER");
            cbTestSelect.Items.Add("BDA");
            cbTestSelect.Items.Add("Charging");
            cbTestSelect.Items.Add("Crystal");
            cbTestSelect.Items.Add("Dongle_Pairing");
            cbTestSelect.Items.Add("FR_Confirmation");
            cbTestSelect.Items.Add("GAGE_IC");
            /*cbTestSelect.Items.Add("Howling");
            cbTestSelect.Items.Add("IR");
            cbTestSelect.Items.Add("L_R_Pairing");
            cbTestSelect.Items.Add("Loopback");
            cbTestSelect.Items.Add("RF");
            cbTestSelect.Items.Add("Seal");
            cbTestSelect.Items.Add("Thermistor");
            cbTestSelect.Items.Add("Touch");
            cbTestSelect.Items.Add("Uplink");*/
        }

#region log_relative

        private void writeLog(string bd, string result, string faildesc)
        {
            string date = DateTime.Now.ToString("yy-MM-dd");

            // open stream
            StreamWriter sw = new StreamWriter(pathLogFile, true, Encoding.Unicode);

            // write measure data
            sw.WriteLine("{0}, {1}, {2}, {3}", date, bd, result, faildesc);

            // close stream
            sw.Close();
        }
        private bool checkLogFile()
        {
            DateTime today = DateTime.Now;

            string strDatePrefix = today.ToString("yy-MM-dd");
            string strLogFile = strDatePrefix + "-" + gDutName + "-log.csv";

            // set file path
            pathLogFile = Directory.GetCurrentDirectory() + "\\" + "log\\" + strLogFile;

            if (File.Exists(pathLogFile))
            {
                // reset test sound
                StreamReader sr = new StreamReader(pathLogFile);
                string line;
                UInt32 lineCount = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    lineCount++;
                }
                sr.Close();
                totalCount = lineCount - 1;

                return true;
            }
            else
            {
                // make new log file
                StreamWriter sw = new StreamWriter(pathLogFile, true, Encoding.Unicode);

                // write basic data (index)
                sw.WriteLine("date" + "," + "bd" + "," + "result" + "," + "ng description");

                sw.Close();
                totalCount = 0;

                return false;
            }
        }

        private void writeDupeLog(string num, string bd, string result, string dupeCount)
        {
            string date = DateTime.Now.ToString("yy-MM-dd");

            // open stream
            StreamWriter swd = new StreamWriter(pathDupeLogFile, true, Encoding.Unicode);

            // write measure data
            swd.WriteLine("{0},{1},{2},{3}", num, bd, result, dupeCount);

            // close stream
            swd.Close();
        }

        private bool checkDupeLogFile()
        {
            DateTime today = DateTime.Now;
            string strDatePrefix = today.ToString("yy-MM-dd");
            string strLogFile = strDatePrefix + "_" + gDutName + "-dupelog.dat";

            // set file path
            pathDupeLogFile = System.IO.Directory.GetCurrentDirectory() + "\\" + "log\\" + strLogFile;

            if (File.Exists(pathDupeLogFile))
            {
                // re-set test Cound
                StreamReader srd = new StreamReader(pathDupeLogFile);
                string line;
                UInt32 lineCount = 0;
                while ((line = srd.ReadLine()) != null)
                {
                    lineCount++;
                    string[] rowrow = line.Split(',');
                    dataGridView2.Rows.Add(rowrow);
                }
                srd.Close();

                passCount = lineCount;

                return true;
            }
            else
            {
                //make new log file
                StreamWriter swd = new StreamWriter(pathDupeLogFile, true, Encoding.Unicode);

                // write basic data (index)
                //swd.WriteLine("date" + "," + "bd" + "," + "result" + "," + "ng description");
                swd.Close();

                return false;
            }
        }
#endregion


        public class backWork
        {
            public class CommandData
            {
                // FD Command
                public string fw_version_check = "fd version";
                public string main_fd_l = "main fd l ";
                public string main_fd_r = "main fd r ";
                public string hdu_fd_l = "hdu fd l";
                public string hdu_fd_r = "hdu fd r";
                public string fd_check = "fd hello";
                public string main_bd_check = "fd ble_binprop get own_identity_address";
                public string sub_bd_check = "fd ble_binprop get own_identity_address";
                public string main_bd_write = "fd ble_binprop set own_identity_address";
                public string sub_bd_write = "fd ble_binprop set lr_set_identity_address";
                public string main_bd_type_write = "fd ble_binprop set own_identity_address_type 1";
                public string sub_bd_type_write = "fd ble_binprop set lr_set_identity_address_type 1";
                public string auto_poweroff_disable = "fd app ecomode disable";
                public string vbus_disable = "fd app appstate PowerOffState";
                public string set_power_on = "fd app appstate CaseOutState";
                public string gageic_th_check = "fd app gauge read_th ";
                public string cxd3277_th_check = "fd app pmic read_th 3";
                public string cxd3277_th_set_cold = "fd app pmic set_cold_th";
                public string cxd3277_th_set_save = "fd prop writeback";
                public string cxd3277_th_set_check = "fd prop get pmic_cold_th";
                public string pwb_id_write = "fd prop set unique pwd_id  ***** PBA11****";
                public string app_mode_out = "fd prop set common initapp cmdif_start";
                public string ble_rftx_start = "fd ble_rftx start 0 1 19";
                public string ble_rftx_stop = "fd ble_rftx stop";
                public string capid_write = "fd pm xosctrim 612850";
                public string rf_analog_write = "fd rfanalog 612850";
                public string appmode_booting = "fd prop set common initapp system_server";
                public string connection_port_set = "fd prop set unique console1 2";
                public string connection_port_set_return = "fd prop set unique console 1";
                public string dtm_mode_on = "fd ble_dtm start";

                public string hdu_exit = "exit hdu";
                public string save_reboot = "fd app appstate RebootState";
                public string product_flag_clear = "fd app tracelog clear";
                public string product_flag_1 = "fd app tracelog write 1 1";
                public string product_flag_2 = "fd app tracelog write 2 1";
                public string product_flag_3 = "fd app tracelog write 3 1";
                public string product_flag_4 = "fd app tracelog write 4 1";
                public string product_flag_5 = "fd app tracelog write 5 1";
                public string product_flag_6 = "fd app tracelog write 6 1";
                public string product_flag_7 = "fd app tracelog write 7 1";
                public string product_flag_8 = "fd app tracelog write 8 1";
                public string product_flag_9 = "fd app tracelog write 9 1";
                public string product_flag_10 = "fd prop set unique ***** 10 1";
                public string product_flag_11 = "fd prop set unique ***** 11 1";

                // AT Command
                public string AT_SDKVer = "AT+EVERINFO=0";
                public string AT_FWVer = "AT+EVERINFO=1";
                public string AT_CAPIDRegwrite = "AT+CAPID=1,<VALUE>";
                public string AT_CAPIDNvdmwrite = "AT+CAPID=2,<VALUE>";
                public string AT_CAPIDRegread = "AT+CAPID=3";
                public string AT_CAPIDNvdmread = "AT+CAPID=4";
                public string AT_ListDelete = "AT+LEAUDIO=BOND,RM";
                public string AT_SIRKRead = "AT+LEAUDIO=SIRK,GET";
                public string AT_SIRKWrite = "AT+LEAUDIO=SIRK,SET,<PARAMS>";
                public string AT_BDARead = "AT+BTLOCALADDR=GET";
                public string AT_BDAWrite = "AT+BTLOCALADDR=SET,<PARAMS>";
                public string AT_DongleRssi = "AT+GETRSSI=<addr>";
                public string AT_PairingReset = "AT+FACTORY=GETCONN";

                // Yusen Command
                public string yusen_case_testmode = "yusen.exe set cradletest on";
                public string yusen_vchg_com_on = "yusen.exe set vchg com";
                public string yusen_pairing_command_on_case = "yusen.exe reasso";
                public string yusen_read_bd_address = "yusen.ee bda all";
                public string yusen_read_charging_state = "yusen.exe get mainbatinfo";
                public string yusen_main_charing_stop = "yusen.exe set vchg off";
                public string yusen_default_charging_set = "yusen.exe set vchg on";

                public string yusen_get_cradle_ver = "yusen.exe get cradlever";
                public string yusen_get_cover_status = "yusen.exe get coverstatus";
                public string yusen_get_mainver_l = "yusen.exe get mainver left";
                public string yusen_get_mainver_r = "yusen.exe get mainver right";
                public string yusen_get_bat_vol = "yusen.exe get batvol";
                public string yusen_get_bat_th = "yusen.exe get batth";
                public string yusen_set_cradle_testmode_on = "yusen.exe set cradletest on";
                public string yusen_set_cradle_orange_on = "yusen.exe set cradleled on orange";
                public string yusen_set_cradle_orange_off = "yusen.exe set cradleled off orange";
                public string yusen_set_cradle_green_on = "yusen.exe set cradleled on green";
                public string yusen_set_cradle_green_off = "yusen.exe set cradleled off green";
                public string yusen_set_cradle_blue_on = "yusen.exe set cradleled on blue";
                public string yusen_set_cradle_blue_off = "yusen.exe set cradleled off blue";
      
            }
            CommandData command_data = new CommandData();

            Form1 mainForm = new Form1();


            static public bool TM05_ConnState;
            static public int TM05_BTHandle;

            string bdFromDUT;
            string nameFromDUT;
            string swVersionInfoFromDUT;
            byte[] bdAddress = new Byte[6];

            public static string tempNap;
            public static string tempUap;
            public static string tempLap;

            public string tempVersion { get; private set; }
            public string tempName { get; private set; }
            public string tempRegion { get; private set; }

            public backWork(Form1 frm)
            {
                mainForm = frm;
            }

            public void Dowork()
            {
                int flag_ng = 0;

                mainForm.toggleBtn(false);

                // start sequence
                for (int i = 0; i < Form1.gCountSequence; i++)
                {
                    //mainForm.toggleBtn(true);
                    if (procTestSequence(mainForm.gtestSequence[i], i) == false)
                    {
                        flag_ng = 1;
                        mainForm.ShowProgress2(i, "FAIL");
                        break;
                    }
                    else
                    {
                        mainForm.ShowProgress2(i, "PASS");
                    }
                }
                // show final result
                mainForm.showResult(flag_ng, dutFullBdAddress);

                // write dupe data (pass only)
                if (flag_ng == 0)
                {
                    mainForm.writeDupeData(dutFullBdAddress);
                }

                mainForm.toggleBtn(true);
            }

            private bool checkName(string name)
            {
                if (name == Form1.gDutName) { return true; }
                else { return false; }
            }

            private bool checkSwVer(string swVersion)
            {
                return false;
            }
            private bool procTestSequence(string seqName, int index)
            {
                bool retVal = false;

                if (seqName == "TEST_CONNECT") { retVal = procTestOpenPort(index); }
                else if (seqName == "TEST_CONNECT_YUSEN") { retVal = procTestOpenYusen(index); }
                else if (seqName == "MAIN_FD_L") { retVal = procTestMainFDL(index); }
                else if (seqName == "MAIN_FD_R") { retVal = procTestMainFDR(index); }
                else if (seqName == "HDU_FD_L") { retVal = procTestMainHDUL(index); }
                else if (seqName == "HDU_FD_R") { retVal = procTestMainHDUR(index); }
                else if (seqName == "FD_L_CHECK") { retVal = procTestMainFDCheck(index); }
                else if (seqName == "FD_R_CHECK") { retVal = procTestMainFDCheck(index); }
                else if (seqName == "BD_CHECK") { retVal = procTestMainBDCheck(index); }
                else if (seqName == "BD_DUPE_CHECK") { retVal = procTestCheckDupe(index); }
                else if (seqName == "TH_CHECK_GAGEIC") { retVal = procTestMainTHGageIC(index); }
                else if (seqName == "TH_CHECK_CXD3277") { return true; }
                else if (seqName == "TH_CHECK_PMIC") { return true; }
                else if (seqName == "EXIT_FD_L") { retVal = procTestExitFDL(index); }
                else if (seqName == "EXIT_FD_R") { return true; }
                else if (seqName == "WRITE_FLAG") { return true; }
                else if (seqName == "SAVE_REBOOT") { retVal = procTestSaveReboot(index); }
                else if (seqName == "SET_CRADLE_TESTMODE") { retVal = procTestLRPairing(index); }

                return retVal;
            }
            public bool procTestOpenYusen(int index)
            {
                int flag_ng = 0;

                ProcessStartInfo cmd = new ProcessStartInfo();
                Process process = new Process();
                //cmd.FileName = @"yusen.exe";
                cmd.FileName = "cmd.exe";
                cmd.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.CreateNoWindow = true;

                cmd.UseShellExecute = false;
                cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
                cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
                cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

                process.EnableRaisingEvents = false;
                process.StartInfo = cmd;
                process.Start();
                

                process.StandardInput.Write(command_data.yusen_set_cradle_testmode_on + Environment.NewLine);
                return true;
            }
            public bool procTestLRPairing(int index)
            {
                int flag_ng = 0;

                ProcessStartInfo cmd = new ProcessStartInfo();
                Process process = new Process();
                //cmd.FileName = @"yusen.exe";
                cmd.FileName = "cmd.exe";
                cmd.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.CreateNoWindow = true;

                cmd.UseShellExecute = false;
                cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
                cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
                cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

                process.EnableRaisingEvents = false;
                process.StartInfo = cmd;
                process.Start();

                process.StandardInput.Write(command_data.yusen_set_cradle_testmode_on + Environment.NewLine);
                mainForm.Delay(500);

                process.StandardInput.Write(command_data.yusen_set_cradle_orange_off + Environment.NewLine);                
                process.StandardInput.Write(command_data.yusen_set_cradle_blue_off + Environment.NewLine);                
                process.StandardInput.Write(command_data.yusen_set_cradle_green_on + Environment.NewLine);
                                
                mainForm.Delay(2000);
                process.StandardInput.Write(command_data.yusen_set_cradle_orange_off + Environment.NewLine);                
                process.StandardInput.Write(command_data.yusen_set_cradle_green_off + Environment.NewLine);                
                process.StandardInput.Write(command_data.yusen_set_cradle_blue_on + Environment.NewLine);

                mainForm.Delay(2000);
                process.StandardInput.Write(command_data.yusen_set_cradle_blue_off + Environment.NewLine);
                process.StandardInput.Write(command_data.yusen_set_cradle_green_off + Environment.NewLine);
                process.StandardInput.Write(command_data.yusen_set_cradle_orange_on + Environment.NewLine);

                mainForm.Delay(2000);
                process.StandardInput.Write(command_data.yusen_set_cradle_orange_off + Environment.NewLine);

                process.StandardInput.Close();

                string result = process.StandardOutput.ReadToEnd();


                //string str = result.Substring(result.IndexOf('='), 12);

                StringBuilder sb = new StringBuilder();
                sb.Append("[Result Info]" + DateTime.Now + "\r\n");
                sb.Append(result);
                sb.Append("\r\n");
                
                mainForm.tbResult.Invoke(new MethodInvoker(delegate { mainForm.tbResult.Text = sb.ToString(); }));
                process.WaitForExit();
                process.Close();
                return true;
            }
            private bool procTestOpenPort(int index)
            {
                int flag_ng = 0;

                if (mainForm._Port.IsOpen == true)
                {
                    Console.WriteLine("[yspark]port is open");
                    return true;
                }
                else
                {
                    flag_ng = 1;
                    Console.WriteLine("[yspark]port is closed");
                    return false;
                }
            }
            private bool procTestMainFDL(int index)
            {
                int flag_ng = 0;

                try
                {
                    mainForm.SendMessage(command_data.main_fd_l);
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main FD L Fail";
                    return false;
                }
                else
                    return true;

            }
            private bool procTestMainFDR(int index)
            {
                int flag_ng = 0;

                try
                {
                    mainForm.SendMessage(command_data.main_fd_r);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main FD R Fail";
                    return false;
                }
                else
                    return true;
            }

            private bool procTestMainHDUL(int index)
            {
                int flag_ng = 0;

                try
                {
                    mainForm.SendMessage(command_data.hdu_fd_l);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main HDU L Fail";
                    return false;
                }
                else
                    return true;
            }
            private bool procTestMainHDUR(int index)
            {
                int flag_ng = 0;

                try
                {
                    mainForm.SendMessage(command_data.hdu_fd_r);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main HDU R Fail";
                    return false;
                }
                else
                    return true;
            }
            private bool procTestMainFDCheck(int index)
            {
                int flag_ng = 0;

                try
                {
                    mainForm.SendMessage(command_data.fd_check);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main FD CHECK Fail";
                    return false;
                }
                else
                    return true;
            }
            private bool procTestMainBDCheck(int index)
            {
                int flag_ng = 0;

                mainForm.gtestValue[index] = dutFullBdAddress;

                try
                {
                    mainForm.SendMessage(command_data.main_bd_check);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main BD CHECK Fail";
                    return false;
                }
                else
                    return true;
            }

            private bool procTestMainTHGageIC(int index)
            {
                int flag_ng = 0;

                try
                {
                    mainForm.SendMessage(command_data.gageic_th_check);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main GAGEIC TH CHECK Fail";
                    return false;
                }
                else
                    return true;
            }
            private bool procTestSaveReboot(int index)
            {
                int flag_ng = 0;
                try
                {
                    mainForm.SendMessage(command_data.save_reboot);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Main Save Reboot Fail";
                    return false;
                }
                else
                    return true;
            }
            private bool procTestExitFDL(int index)
            {
                int flag_ng = 0;
                try
                {
                    mainForm.SendMessage(command_data.hdu_exit);
                }
                catch
                {
                    flag_ng = 1;
                }
                finally
                {
                    if (mainForm.Check_Data(index) == false)
                    {
                        flag_ng = 1;
                    }
                }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "Exit HDU Fail";
                    return false;
                }
                else
                    return true;
            }
            private bool procTestCheckDupe(int index)
            {
                int flag_ng = 0;

                try
                {
                    mainForm.gtestValue[index] = "-";
                }
                catch
                {
                    flag_ng = 1;
                }
                finally { if (mainForm.findDupeData(Form1.dutFullBdAddress)) { flag_ng = 1; } }
                if (flag_ng == 1)
                {
                    mainForm.gNgType[index] = "BD Address Dupe";
                    return false;
                }
                else
                    return true;
            }
            private bool validateBd(string xnap, string xuap, string xlap, string type)
            {
                int flag_ng = 0;

                switch (type)
                {
                    case "check_default_for_check":
                        {
                            if ((Form1.gDefaultBdNap == xnap) && (Form1.gDefaultBdUap == xuap) && (Form1.gDefaultBdLap == xlap)) { flag_ng = 1; }
                        }
                        break;
                    case "check_default_for_write":
                        {
                            if ((Form1.gDefaultBdNap != xnap) || (Form1.gDefaultBdUap != xuap) || (Form1.gDefaultBdLap != xlap)) { flag_ng = 1; }
                        }
                        break;
                    case "check_range":
                        {
                            // convert
                            UInt16 tempConfigNap = Convert.ToUInt16(Form1.gBdNap, 16);
                            Byte tempConfigUap = Convert.ToByte(Form1.gBdUap, 16);
                            UInt32 tempConfigLapStart = Convert.ToUInt32(Form1.gBdLapStart, 16);
                            UInt32 tempConfigLapEnd = Convert.ToUInt32(Form1.gBdLapEnd, 16);

                            UInt16 tempNap = Convert.ToUInt16(xnap, 16);
                            Byte tempUap = Convert.ToByte(xuap, 16);
                            UInt32 tempLap = Convert.ToUInt32(xlap, 16);

                            if ((tempLap < tempConfigLapStart) || (tempLap > tempConfigLapEnd) || (tempNap != tempConfigNap) || (tempUap != tempConfigUap)) { flag_ng = 1; }
                        }
                        break;
                    default:
                        {

                        }
                        break;
                }

                if (flag_ng == 1) { return false; }
                else { return true; }
            }


        }

        private void btnTestStart_Click(object sender, EventArgs e)
        {

            //textBox3.Text = String.Empty;
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            //cmd.FileName = @"yusen.exe";
            cmd.FileName = "cmd.exe";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
            cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
            cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

            process.StandardInput.Write("yusen.exe get cradlever" + Environment.NewLine);
            //process.StandardInput.Close();

            process.StandardInput.Write("yusen.exe get coverstatus" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe get mainver left" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe get mainver right" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe get batvol" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe get batth" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradletest on" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled off orange" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled off green" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled off blue" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled on green" + Environment.NewLine);
            Delay(2000);
            process.StandardInput.Write("yusen.exe set cradleled off green" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled on blue" + Environment.NewLine);
            Delay(2000);
            process.StandardInput.Write("yusen.exe set cradleled off blue" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled on orange" + Environment.NewLine);
            Delay(2000);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();



            string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            tbResult.Text = sb.ToString();
            if (str == "=> " + "Ver 00.06")
            {
                textBox2.Text = "OK";
            }
            else
                textBox2.Text = "NG";
            /*string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(str);
            sb.Append("\r\n");
            */
            //textBox3.Text = sb.ToString();

            process.WaitForExit();
            process.Close();



            /*try
            {
                Process myProc = new Process();
                myProc.StartInfo.FileName = "TM05_Earbud_BD_Checker.exe";
                myProc.Start();

                myProc.CloseMainWindow();
                myProc.Close();
            }
            catch(Win32Exception w)
            {
                Console.WriteLine(w.Message);
                Console.WriteLine(w.ErrorCode.ToString());
                Console.WriteLine(w.NativeErrorCode.ToString());
                Console.WriteLine(w.StackTrace);
                Console.WriteLine(w.Source);
                Exception x = w.GetBaseException();
                Console.WriteLine(x.Message);
            }
            */
        }
        private void work()
        {
            //textBox3.Text = String.Empty;
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            //cmd.FileName = @"yusen.exe";
            cmd.FileName = "cmd.exe";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
            cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
            cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

            process.StandardInput.Write("yusen.exe get batvol" + Environment.NewLine);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();



            string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            tbResult.Text = sb.ToString();

            process.WaitForExit();
            process.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                port_open();
            }
            else
                port_close();

            Console.WriteLine("[yspark]PORT OPEN : {0}", _Port.PortName);
        }

        private void btnGreen_Click(object sender, EventArgs e)
        {
            //textBox3.Text = String.Empty;
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            //cmd.FileName = @"yusen.exe";
            cmd.FileName = "cmd.exe";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
            cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
            cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

            process.StandardInput.Write("yusen.exe set cradleled off orange" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled off blue" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled on green" + Environment.NewLine);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();



            //string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            tbResult.Text = sb.ToString();

            process.WaitForExit();
            process.Close();

        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            //textBox3.Text = String.Empty;
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            //cmd.FileName = @"yusen.exe";
            cmd.FileName = "cmd.exe";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
            cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
            cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

            process.StandardInput.Write("yusen.exe set cradleled off orange" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled off green" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled on blue" + Environment.NewLine);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();



            string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            tbResult.Text = sb.ToString();

            process.WaitForExit();
            process.Close();
        }

        private void btnOrange_Click(object sender, EventArgs e)
        {
            //textBox3.Text = String.Empty;
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            //cmd.FileName = @"yusen.exe";
            cmd.FileName = "cmd.exe";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
            cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
            cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

            process.StandardInput.Write("yusen.exe set cradleled off green" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled off blue" + Environment.NewLine);
            process.StandardInput.Write("yusen.exe set cradleled on orange" + Environment.NewLine);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();



            string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            tbResult.Text = sb.ToString();

            process.WaitForExit();
            process.Close();
        }

        private void btncradletest_Click(object sender, EventArgs e)
        {
            //textBox3.Text = String.Empty;
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            //cmd.FileName = @"yusen.exe";
            cmd.FileName = "cmd.exe";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
            cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
            cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

            process.StandardInput.Write("yusen.exe set cradletest on" + Environment.NewLine);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();


            //string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            tbResult.Text = sb.ToString();

            process.WaitForExit();
            process.Close();
        }

        private void btnCradletestoff_Click(object sender, EventArgs e)
        {
            //textBox3.Text = String.Empty;
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            //cmd.FileName = @"yusen.exe";
            cmd.FileName = "cmd.exe";
            cmd.WindowStyle = ProcessWindowStyle.Hidden;
            cmd.CreateNoWindow = true;

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;    // cmd창에서 데이터 get
            cmd.RedirectStandardInput = true;    // cmd창으로 데이터 set
            cmd.RedirectStandardError = true;    // cmd창으로 error내용 get

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();

            process.StandardInput.Write("yusen.exe set cradletest off" + Environment.NewLine);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();



            string str = result.Substring(result.IndexOf('='), 12);

            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");
            tbResult.Text = sb.ToString();

            process.WaitForExit();
            process.Close();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            clearDisp();

            backWork bg = new backWork(this);
            Thread workThread = new Thread(bg.Dowork);
            workThread.Start();
        }
        private void DiseaseUpdateEventMethod(object sender)
        {
            program_name = sender.ToString();
        }
#region delegate

        delegate void writeDupeDataDelegate(string bd);

        public void writeDupeData(string bd)
        {
            if (InvokeRequired)
            {
                writeDupeDataDelegate writeDupeDel = new writeDupeDataDelegate(writeDupeData);
                Invoke(writeDupeDel, bd);
            }
            else
            {
                // add dupe data to datagrid2
                string[] rowrow = { passCount.ToString(), bd, "OK", "0" };
                dataGridView2.Rows.Add(rowrow);

                // add dupe data to log
                writeDupeLog(passCount.ToString(), bd, "OK", "0");
            }
        }

        delegate bool findDupeDataDelegate(string bd);
        public bool findDupeData(string bd)
        {
            if (InvokeRequired)
            {
                findDupeDataDelegate findDupeDel = new findDupeDataDelegate(findDupeData);
                return (bool)Invoke(findDupeDel, bd);
            }
            else
            {
                int count = 0;
                int row = 0;
                bool isDupe = false;

                count = dataGridView2.Rows.Count - 1;

                if (count != 0)
                {
                    for (row = 0; row < count; row++)
                    {
                        string ttt = dataGridView2.Rows[row].Cells[1].Value.ToString();
                        if (bd == dataGridView2.Rows[row].Cells[1].Value.ToString())
                        {
                            // focus?
                            dataGridView2.FirstDisplayedScrollingRowIndex = dataGridView2.Rows[row].Index;

                            // change dupe count
                            string strTempCount = dataGridView2.Rows[row].Cells[3].Value.ToString();
                            dataGridView2.Rows[row].Cells[3].Value = (Convert.ToInt32(strTempCount) + 1).ToString();

                            dataGridView2.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                            gLatestDupeRow = row;
                            isDupe = true;
                            break;
                        }
                    }
                }
                if (!isDupe) { return false; }
                else { return true; }
            }
        }


        delegate void showResultDelegate(int result, string bd); // show final result and write log
        public void showResult(int result, string bd)
        {
            if (InvokeRequired)
            {
                showResultDelegate resultDel = new showResultDelegate(showResult);
                Invoke(resultDel, result, bd);
            }
            else
            {
                if (result == 1) // flag_ng == 1
                {
                    // write log
                    writeLog(bd, "FAIL", typeNg);

                    totalCount++;
                    failCount++;

                    tb_totalCount.Text = totalCount.ToString();
                    tb_failCount.Text = failCount.ToString();

                    lbResult.Text = "FAIL";
                    //lbResult.ForeColor = Color.Red;
                    lbResult.BackColor = Color.Red;

                    NgSound();
                }
                else
                {
                    // write log
                    writeLog(bd, "PASS", "-");

                    totalCount++;
                    passCount++;

                    tb_totalCount.Text = totalCount.ToString();
                    tb_passCount.Text = passCount.ToString();

                    lbResult.Text = "PASS";
                    //lbResult.ForeColor = Color.SkyBlue;
                    //lbResult.BackColor = Color.LightBlue;
                    lbResult.BackColor = Color.Blue;
                }
            }
        }

        delegate void toggleBtnDelegate(Boolean x);
        public void toggleBtn(Boolean x)
        {
            if (InvokeRequired)
            {
                toggleBtnDelegate btnDel = new toggleBtnDelegate(toggleBtn);
                Invoke(btnDel, x);
            }
            else
            {
                if (x == true) { btnStart.Enabled = true; btnStart.Focus(); }
                else { btnStart.Enabled = false; }
            }
        }

        delegate void ShowErrorDelegates(string s);
        public void showError(string s)
        {
            if (InvokeRequired)
            {
                ShowErrorDelegates eDel = new ShowErrorDelegates(showError);
                Invoke(eDel, s);
            }
            else
            {
                this.label1.Text = s;
                this.label1.ForeColor = Color.Red;
            }
        }

        delegate void ShowDelegate2(int row, string result);
        public void ShowProgress2(int row, string result)
        {
            if (InvokeRequired)
            {
                ShowDelegate2 del = new ShowDelegate2(ShowProgress2);
                Invoke(del, row, result);
            }
            else
            {
                dataGridView1.Rows[row].Cells[3].Value = gtestValue[row];
                dataGridView1.Rows[row].Cells[4].Value = result;

                if (result == "FAIL")
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.Red;
                    typeNg = gNgType[row];
                }
                else if (result == "PASS")
                {
                    dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.SkyBlue;
                }
            }
        }

#endregion

#region config_relative

#if TM05
        private void loadConfig()
        {
            Form2 f2 = new Form2();
            f2.FormSendEvent += new Form2.FormSendDataHandler(DiseaseUpdateEventMethod);
            f2.ShowDialog();

            if (program_name == "BDA")
            {
                pathConfigFile = System.IO.Directory.GetCurrentDirectory() + "\\config" + "\\program_config_BDA.ini";
            }
            else if (program_name == "BD_CHECKER")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_BD_CHECKER.ini";
            }
            else if (program_name == "CHARGING")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_CHARGING.ini";
            }
            else if (program_name == "CRYSTAL")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_CRYSTAL.ini";
            }
            else if (program_name == "DONGLE_PAIRING")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_DONGLE_PAIRING.ini";
            }
            else if (program_name == "FR_CONFIRM")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_FR_CONFIRM.ini";
            }
            else if (program_name == "GAGE_IC")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_GAGE_IC.ini";
            }
            else if (program_name == "HOWLING")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_HOWLING.ini";
            }
            else if (program_name == "IR")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_IR.ini";
            }
            else if (program_name == "LR_PAIRING")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_LR_PAIRING.ini";
            }
            else if (program_name == "LOOPBACK")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_LOOPBACK.ini";
            }
            else if (program_name == "RF")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_RF.ini";
            }
            else if (program_name == "SEAL")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_SEAL.ini";
            }
            else if (program_name == "THERMISTOR")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_THERMISTOR.ini";
            }
            else if (program_name == "TOUCH")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_TOUCH.ini";
            }
            else if (program_name == "UPLINK")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_UPLINK.ini";
            }

            /*
            if(cbTestSelect.Text == "BDA")
            {
                pathConfigFile = System.IO.Directory.GetCurrentDirectory() + "\\config" + "\\program_config_BDA.ini";
            }*/

            //pathConfigFile = System.IO.Directory.GetCurrentDirectory() + "\\config" + "\\program_config.ini";
            string tempString;

            IniReadWrite IniReader = new IniReadWrite();

            tempString = IniReader.IniReadValue("CONFIG", "MODEL_NAME", pathConfigFile);
            gDutName = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "SW_VERSION", pathConfigFile);
            gSwVersion = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "MANUFACTURE_DATE", pathConfigFile);
            gManufactureDate = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "DEFAULT_BD_NAP", pathConfigFile);
            gDefaultBdNap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "DEFAULT_BD_UAP", pathConfigFile);
            gDefaultBdUap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "DEFUALT_BD_LAP", pathConfigFile);
            gDefaultBdLap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_NAP", pathConfigFile);
            gBdNap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_UAP", pathConfigFile);
            gBdUap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_LAP_START", pathConfigFile);
            gBdLapStart = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_LAP_END", pathConfigFile);
            gBdLapEnd = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_LAP_WRITE_NEXT", pathConfigFile);
            gBdLapWriteNext = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "PORT", pathConfigFile);
            comPort = tempString;
            comPort_num = tempString.Replace("COM", "");

            tempString = IniReader.IniReadValue("CONFIG", "LINE_INFO_A", pathConfigFile);
            gLineInfoA = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "LINE_INFO_B", pathConfigFile);
            gLineInfoB = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "APPNAME", pathConfigFile);
            gAppName = tempString;
            lb_AppName.Text = program_name + " " + gAppName;
            lb_AppName.BackColor = Color.LightYellow;
            lb_AppName.ForeColor = Color.Green;


            // setup test list
            // max item of sequence is 30
            string tempProc = "";
            for (int i = 0; i < 30; i++)
            {
                tempProc = String.Format("TEST_{0}", i.ToString("D2"));
                tempString = IniReader.IniReadValue("SEQUENCE", tempProc, pathConfigFile);
                if (tempString == "END")
                {
                    gCountSequence = i;
                    break;
                }
                else
                {
                    gtestSequence[i] = tempString;
                }
            }

            // add display
            for (int j = 0; j < gCountSequence; j++)
            {
                if (gtestSequence[j] == "CHECK_MODEL_NAME")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], gDutName, "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else if (gtestSequence[j] == "CHECK_SW_VERSION")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], gSwVersion, "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else if (gtestSequence[j] == "CHECK_BD_RANGE")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], String.Format("{0} ~ {1}", gBdLapStart, gBdLapEnd, "-", "-") };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else if (gtestSequence[j] == "CHECK_REGION")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], gFwRegion, "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else if (gtestSequence[j] == "WRITE_BD_ADDRESS")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], gBdNap + gBdUap + gBdLapWriteNext, "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], "-", "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
            }


            // check bd setting range
            // check bd range

            UInt32 tempConfigLapStart = Convert.ToUInt32(Form1.gBdLapStart, 16);
            UInt32 tempConfigLapEnd = Convert.ToUInt32(Form1.gBdLapEnd, 16);
            UInt32 tempLap = Convert.ToUInt32(Form1.gBdLapWriteNext, 16);

            if ((tempLap > tempConfigLapEnd) || (tempLap < tempConfigLapStart))
            {
                MessageBox.Show("Check BD Address Range Config");
                Close();
            }
        }
#else

        private void loadConfig()
        {
            Form2 f2 = new Form2();
            f2.FormSendEvent += new Form2.FormSendDataHandler(DiseaseUpdateEventMethod);
            f2.ShowDialog();            
                        
            if (program_name == "BDA")
            {
                pathConfigFile = System.IO.Directory.GetCurrentDirectory() + "\\config" + "\\program_config_BDA.ini";
            }                        
            else if (program_name == "BD_CHECKER")
            {
                pathConfigFile = Directory.GetCurrentDirectory() + "\\config" + "\\program_config_BD_CHECKER.ini";
            }
            /*
            if(cbTestSelect.Text == "BDA")
            {
                pathConfigFile = System.IO.Directory.GetCurrentDirectory() + "\\config" + "\\program_config_BDA.ini";
            }*/
            
            //pathConfigFile = System.IO.Directory.GetCurrentDirectory() + "\\config" + "\\program_config.ini";
            string tempString;

            IniReadWrite IniReader = new IniReadWrite();

            tempString = IniReader.IniReadValue("CONFIG", "MODEL_NAME", pathConfigFile);
            gDutName = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "SW_VERSION", pathConfigFile);
            gSwVersion = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "MANUFACTURE_DATE", pathConfigFile);
            gManufactureDate = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "DEFAULT_BD_NAP", pathConfigFile);
            gDefaultBdNap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "DEFAULT_BD_UAP", pathConfigFile);
            gDefaultBdUap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "DEFUALT_BD_LAP", pathConfigFile);
            gDefaultBdLap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_NAP", pathConfigFile);
            gBdNap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_UAP", pathConfigFile);
            gBdUap = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_LAP_START", pathConfigFile);
            gBdLapStart = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_LAP_END", pathConfigFile);
            gBdLapEnd = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "BD_LAP_WRITE_NEXT", pathConfigFile);
            gBdLapWriteNext = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "PORT", pathConfigFile);
            comPort = tempString;
            comPort_num = tempString.Replace("COM", "");

            tempString = IniReader.IniReadValue("CONFIG", "LINE_INFO_A", pathConfigFile);
            gLineInfoA = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "LINE_INFO_B", pathConfigFile);
            gLineInfoB = tempString;

            tempString = IniReader.IniReadValue("CONFIG", "APPNAME", pathConfigFile);
            gAppName = tempString;
            lb_AppName.Text = program_name + " " + gAppName;
            lb_AppName.BackColor = Color.LightYellow;
            lb_AppName.ForeColor = Color.Green;


            // setup test list
            string tempProc = "";
            for (int i = 0; i < gCountSequence; i++)
            {
                tempProc = String.Format("TEST_{0}", i.ToString("D2"));
                tempString = IniReader.IniReadValue("SEQUENCE", tempProc, pathConfigFile);
                if (tempString == "END")
                {
                    gCountSequence = i;
                    break;
                }
                else
                {
                    gtestSequence[i] = tempString;
                }
            }

            // add display
            for (int j = 0; j < gCountSequence; j++)
            {
                if (gtestSequence[j] == "CHECK_MODEL_NAME")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], gDutName, "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else if (gtestSequence[j] == "CHECK_SW_VERSION")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], gSwVersion, "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else if (gtestSequence[j] == "CHECK_BD_RANGE")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], String.Format("{0} ~ {1}", gBdLapStart, gBdLapEnd, "-", "-") };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else if (gtestSequence[j] == "CHECK_REGION")
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], gFwRegion, "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
                else
                {
                    string[] rowInfo = { j.ToString(), gtestSequence[j], "-", "-", "-" };
                    dataGridView1.Rows.Add(rowInfo);
                }
            }


            // check bd setting range
            // check bd range

            UInt32 tempConfigLapStart = Convert.ToUInt32(Form1.gBdLapStart, 16);
            UInt32 tempConfigLapEnd = Convert.ToUInt32(Form1.gBdLapEnd, 16);
            UInt32 tempLap = Convert.ToUInt32(Form1.gBdLapWriteNext, 16);

            if ((tempLap > tempConfigLapEnd) || (tempLap < tempConfigLapStart))
            {
                MessageBox.Show("Check BD Address Range Config");
                Close();
            }
        }
#endif
#endregion

#region serial_communication
        // serial test - 0
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.Invoke(new EventHandler(MySerialReceived));
        }
        private void MySerialReceived(object s, EventArgs e)
        {
            string ReceiveData = serialPort1.ReadExisting();
            tbResult.Text += string.Format("{0:X2}", ReceiveData);
            Console.WriteLine("[yspark][receive] \r\n" + ReceiveData);
        }
        private void MySerialSend(string data)
        {
            _Port.Write(data);
            tbResult.Text += "[yspark][send] \r\n" + data;
            Console.WriteLine("[yspark][send] \r\n" + data);
        }

        // serialport control info
        public SerialPort _Port;
        public SerialPort Port
        {
            get
            {
                if (_Port == null)
                {
                    _Port = new SerialPort();
                    //_Port.PortName = "COM243";
                    _Port.PortName = "COM56";
                    _Port.BaudRate = 115200;
                    _Port.DataBits = 8;
                    _Port.Parity = Parity.None;
                    _Port.Handshake = Handshake.None;
                    _Port.StopBits = StopBits.One;
                }
                return _Port;
            }
        }
        private void port_open()
        {
            //serialPort1 = new SerialPort();
            if (Port.IsOpen == false)
            {
                Port.PortName = _Port.PortName;
                Port.BaudRate = _Port.BaudRate;
                Port.DataBits = _Port.DataBits;
                Port.StopBits = _Port.StopBits;
                Port.Parity = _Port.Parity;
                _Port.DataReceived += Port_DataReceived;

                try
                {
                    // connect
                    Port.Open();
                    tbResult.Text += "port is open" + Environment.NewLine;
                    Console.WriteLine("PORT OPEN:{0}", _Port.PortName);
                }
                catch (Exception ex)
                {
                    tbResult.Text += String.Format("[yspark][err] {0}\r\n", ex.Message);
                    Console.WriteLine("[yspark][err] {0}", ex.Message);
                }
            }
            else
            {
                Port.Close();
            }
            IsOpen = Port.IsOpen;
        }
        // serialport state and control 
        private Boolean IsOpen
        {
            get { return Port.IsOpen; }
            set
            {
                if (value)
                {
                    Strings = "serial port connected";
                }
                else
                {
                    Strings = "serial port disconnected";
                }

            }
        }
        // Log control
        private StringBuilder _Strings;

        // Log object
        private String Strings
        {
            set
            {
                if (_Strings == null)
                {
                    _Strings = new StringBuilder(1024);
                }
                if (_Strings.Length >= (1024 - value.Length))
                {
                    _Strings.Clear();
                    // add log and display on screen
                    _Strings.AppendLine(value);
                    tbResult.Invoke(new MethodInvoker(delegate { tbResult.Select(tbResult.Text.Length, 0); }));
                    tbResult.Invoke(new MethodInvoker(delegate { tbResult.ScrollToCaret(); }));
                    //tbResult.Text += "[yspark]" + _Strings.ToString() + "\r\n";
                    tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text += "[yspark]" + _Strings.ToString() + "\r\n"; }));
                    Console.WriteLine(_Strings.ToString());
                }
                else
                {
                    _Strings.Clear();
                    _Strings.AppendLine(value);
                    tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text += "[yspark]" + _Strings.ToString() + "\r\n"; }));
                    //tbResult.Text += "[yspark]" + _Strings.ToString() + "\r\n";
                    tbResult.Invoke(new MethodInvoker(delegate { tbResult.Select(tbResult.Text.Length, 0); }));
                    tbResult.Invoke(new MethodInvoker(delegate { tbResult.ScrollToCaret(); }));
                    Console.WriteLine(_Strings.ToString());
                }
            }
        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            msg = _Port.ReadExisting();
            Delay(500);
            this.Invoke(new EventHandler(delegate
            {
                Strings = String.Format("[receive] {0} ", msg);
                //Check_Data();
                //Console.WriteLine("[yspark][receive] \r\n" + msg);
            }));
        }
        public void Delay(int ms)
        {
            DateTime dateTimeNow = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
            DateTime dateTimeAdd = dateTimeNow.Add(duration);
            while (dateTimeAdd >= dateTimeNow)
            {
                System.Windows.Forms.Application.DoEvents();
                dateTimeNow = DateTime.Now;
            }
            return;
        }

        private void SendMessage(String text)
        {
            // send data
            // text = "fd ble_binprop get own_identity_address";
            if (String.IsNullOrEmpty(text)) return;

            try
            {                
                if (text == "exit hdu")
                {
                    Delay(500);
                    Port.WriteLine(text);
                    Strings = String.Format("[send] {0}", text);
                    Delay(500);
                }
                else
                {
                    Port.WriteLine(text);
                    Strings = String.Format("[send] {0}", text);
                    Delay(500);
                }
            }
            catch (Exception ex)
            {
                Strings = String.Format("[send] {0}", ex.Message);
            }
        }
        // using bool style
        public bool Check_Data(int num)
        {
            //String msg = _Port.ReadExisting();
            Delay(700);
            if (msg.Contains("0x"))
            {
                int index = msg.IndexOf("0x");
                //Console.WriteLine(msg.Substring(index + 2, 12));

                string bddata = msg.Substring(index + 2, 12);

                string bddata1 = bddata.Substring(0, 2);
                string bddata2 = bddata.Substring(2, 2);
                string bddata3 = bddata.Substring(4, 2);
                string bddata4 = bddata.Substring(6, 2);
                string bddata5 = bddata.Substring(8, 2);
                string bddata6 = bddata.Substring(10, 2);

                string resultbd = bddata6 + bddata5 + bddata4 + bddata3 + bddata2 + bddata1;

                backWork.tempNap = bddata6 + bddata5;
                backWork.tempUap = bddata4;
                backWork.tempLap = bddata3 + bddata2 + bddata1;

                Console.WriteLine(resultbd);
                gtestValue[num] = resultbd;
                dutFullBdAddress = resultbd;


                findDupeData(resultbd);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = resultbd + " success!"; }));
                return true;
                /*int index = msg.IndexOf("success");
                Console.WriteLine(msg.Substring(index, 7));
                tbResult.Text = msg.Substring(index, 7);*/
            }
            else if (msg.Contains("Temperature"))
            {
                int index = msg.IndexOf("Temperature");
                Console.WriteLine(msg.Substring(index + 14, 5));
                gtestValue[num] = msg.Substring(index + 14, 5);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 15) + " success!"; }));
                return true;
            }
            else if (msg.Contains("RebootState"))
            {
                int index = msg.IndexOf("RebootState");
                Console.WriteLine(msg.Substring(index, 11));
                gtestValue[num] = msg.Substring(index, 11);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 11) + " success!"; }));
                return true;
            }
            else if (msg.Contains("CHANGE_FD_MODE"))
            {
                int index = msg.IndexOf("CHANGE_FD_MODE");
                Console.WriteLine(msg.Substring(index, 14));
                gtestValue[num] = msg.Substring(index, 14);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 14) + " success!"; }));
                return true;
            }
            else if (msg.Contains(" L:OK"))
            {
                int index = msg.IndexOf(" L:OK");
                Console.WriteLine(msg.Substring(index, 5));
                gtestValue[num] = msg.Substring(index, 5);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 5) + " success!"; }));
                return true;
            }
            else if (msg.Contains(" R:OK"))
            {
                int index = msg.IndexOf(" R:OK");
                Console.WriteLine(msg.Substring(index, 5));
                gtestValue[num] = msg.Substring(index, 5);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 5) + " success!"; }));
                return true;
            }
            else if (msg.Contains("enter FD mode"))
            {
                int index = msg.IndexOf("enter FD mode");
                Console.WriteLine(msg.Substring(index, 13));
                gtestValue[num] = msg.Substring(index, 13);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 13) + " success!"; }));
                return true;
            }
            else if (msg.Contains("fd hello"))
            {
                int index = msg.IndexOf("fd hello");

                Console.WriteLine(msg.Substring(index, 8));
                gtestValue[num] = msg.Substring(index, 8);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 8) + " success!"; }));
                return true;
            }
            else if (msg.Contains("success"))
            {
                int index = msg.IndexOf("success");
                Console.WriteLine(msg.Substring(index, 7));
                gtestValue[num] = msg.Substring(index, 7);
                //tbResult.Invoke(new MethodInvoker(delegate { tbResult.Text = msg.Substring(index, 7) + " success!"; }));
                return true;
            }
            else
            {
                gtestValue[num] = "-";
                return false;
            }
            return false;


        }

        public bool Check_Data_Yusen(int num)
        {
            Delay(500);


            return false;
        }
        private void port_close()
        {
            if (_Port.IsOpen == true)
            {
                _Port.Close();
                tbResult.Text += "port is closing" + Environment.NewLine;
            }
            else
                tbResult.Text += "port is already closed" + Environment.NewLine;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        // serial test - 1
        /*
                // data send
                static void Send(string sendMsg)
                {
                    _serialPort.WriteLine(sendMsg);
                }

                // data receive
                static void Read()
                {
                    string readData = string.Empty;
                    Console.WriteLine("[yspark]Data Read Ready");

                    while(_continue)
                    {
                        try
                        {
                            readData = _serialPort.ReadLine();
                            Console.WriteLine("ReadData : {0}", readData);
                        }
                        catch (System.TimeoutException)
                        {
                        }
                    }
                }
        */
#endregion

        private void cbTestSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTestSelect.Text == "BD_CHECKER")
            {
                MessageBox.Show("BD_Checker Program Execute!!");
            }
            else if (cbTestSelect.Text == "Charging")
            {
                MessageBox.Show("Charging Program Execute!!");
            }
            else if (cbTestSelect.Text == "BDA")
            {
                MessageBox.Show("BDA Program Execute!!");
            }
        }

        private void btnBdWrite_Click(object sender, EventArgs e)
        {
            MySerialSend("fd ble_binprop set own_identity_address 0x3694A0E8C988");
        }

        private void btnBdWritedumi_Click(object sender, EventArgs e)
        {
            MySerialSend("fd ble_binprop set lr_set_identity_address 0x111111AAAAAA");
        }

        private void btnAutopoweroffDisable_Click(object sender, EventArgs e)
        {
            MySerialSend("fd app ecomode disable");
        }

        private void btnReboot_Click(object sender, EventArgs e)
        {
            Port.WriteLine("exit hdu ");
        }
        // data class      

        private void btnFd_Click(object sender, EventArgs e)
        {
            //SendMessage(command_data.main_init_r);
            //MySerialSend("main fd l");
        }

        private void btnHdu_Click(object sender, EventArgs e)
        {
            //SendMessage(command_data.hdu_init_r);
            //MySerialSend("hdu fd l");
        }

        private void btnBdRead_Click(object sender, EventArgs e)
        {
            //MySerialSend("fd ble_binprop get own_identity_address");
            //SendMessage("fd ble_binprop get own_identity_address", null, EventArgs.Empty);
            //SendMessage(backWork.CommandData.main_bd_check);
            //_Port.DataReceived += Port_DataReceived;
        }

        private void btnBdReadDumi_Click(object sender, EventArgs e)
        {
            MySerialSend("fd ble_binprop get lr_set_identity_address");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(tbData.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbResult.Clear();
        }

        private void btnSend2_Click(object sender, EventArgs e)
        {
            SendMessage(tbData.Text);
        }
    }
}
