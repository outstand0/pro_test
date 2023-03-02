namespace pro_test
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnTestStart = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.btnGreen = new System.Windows.Forms.Button();
            this.btnBlue = new System.Windows.Forms.Button();
            this.btnOrange = new System.Windows.Forms.Button();
            this.btnCradleteston = new System.Windows.Forms.Button();
            this.btnCradletestoff = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.tb_failCount = new System.Windows.Forms.TextBox();
            this.tb_passCount = new System.Windows.Forms.TextBox();
            this.tb_totalCount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.lbRegion = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.lb_AppName = new System.Windows.Forms.Label();
            this.cbTestSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnBdWrite = new System.Windows.Forms.Button();
            this.btnBdWritedumi = new System.Windows.Forms.Button();
            this.btnAutopoweroffDisable = new System.Windows.Forms.Button();
            this.btnReboot = new System.Windows.Forms.Button();
            this.btnFdl = new System.Windows.Forms.Button();
            this.btnHdul = new System.Windows.Forms.Button();
            this.btnReadbdDumil = new System.Windows.Forms.Button();
            this.btnReadbdl = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReadbdr = new System.Windows.Forms.Button();
            this.btnHdur = new System.Windows.Forms.Button();
            this.btnFdr = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.tbData = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSend2 = new System.Windows.Forms.Button();
            this.cbComport = new System.Windows.Forms.ComboBox();
            this.btngenguid = new System.Windows.Forms.Button();
            this.btnGpibSend = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tbGpibData = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btnGpibConnect = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTestStart
            // 
            this.btnTestStart.Location = new System.Drawing.Point(1087, 44);
            this.btnTestStart.Name = "btnTestStart";
            this.btnTestStart.Size = new System.Drawing.Size(75, 23);
            this.btnTestStart.TabIndex = 20;
            this.btnTestStart.TabStop = false;
            this.btnTestStart.Text = "START";
            this.btnTestStart.UseVisualStyleBackColor = true;
            this.btnTestStart.Click += new System.EventHandler(this.btnTestStart_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1087, 73);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 39);
            this.button2.TabIndex = 1;
            this.button2.Text = "UART OPEN";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1168, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1168, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 3;
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(1087, 549);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(240, 357);
            this.tbResult.TabIndex = 4;
            // 
            // btnGreen
            // 
            this.btnGreen.Location = new System.Drawing.Point(1087, 147);
            this.btnGreen.Name = "btnGreen";
            this.btnGreen.Size = new System.Drawing.Size(75, 23);
            this.btnGreen.TabIndex = 5;
            this.btnGreen.Text = "GREEN";
            this.btnGreen.UseVisualStyleBackColor = true;
            this.btnGreen.Click += new System.EventHandler(this.btnGreen_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Location = new System.Drawing.Point(1087, 176);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(75, 23);
            this.btnBlue.TabIndex = 6;
            this.btnBlue.Text = "BLUE";
            this.btnBlue.UseVisualStyleBackColor = true;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // btnOrange
            // 
            this.btnOrange.Location = new System.Drawing.Point(1087, 205);
            this.btnOrange.Name = "btnOrange";
            this.btnOrange.Size = new System.Drawing.Size(75, 23);
            this.btnOrange.TabIndex = 7;
            this.btnOrange.Text = "ORANGE";
            this.btnOrange.UseVisualStyleBackColor = true;
            this.btnOrange.Click += new System.EventHandler(this.btnOrange_Click);
            // 
            // btnCradleteston
            // 
            this.btnCradleteston.Location = new System.Drawing.Point(1087, 118);
            this.btnCradleteston.Name = "btnCradleteston";
            this.btnCradleteston.Size = new System.Drawing.Size(93, 23);
            this.btnCradleteston.TabIndex = 8;
            this.btnCradleteston.Text = "cradle test on";
            this.btnCradleteston.UseVisualStyleBackColor = true;
            this.btnCradleteston.Click += new System.EventHandler(this.btncradletest_Click);
            // 
            // btnCradletestoff
            // 
            this.btnCradletestoff.Location = new System.Drawing.Point(1186, 118);
            this.btnCradletestoff.Name = "btnCradletestoff";
            this.btnCradletestoff.Size = new System.Drawing.Size(93, 23);
            this.btnCradletestoff.TabIndex = 9;
            this.btnCradletestoff.Text = "cradle test off";
            this.btnCradletestoff.UseVisualStyleBackColor = true;
            this.btnCradletestoff.Click += new System.EventHandler(this.btnCradletestoff_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 3000;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(23, 44);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1049, 542);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(23, 632);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(609, 190);
            this.dataGridView2.TabIndex = 11;
            // 
            // tb_failCount
            // 
            this.tb_failCount.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_failCount.Location = new System.Drawing.Point(909, 593);
            this.tb_failCount.Name = "tb_failCount";
            this.tb_failCount.ReadOnly = true;
            this.tb_failCount.Size = new System.Drawing.Size(159, 35);
            this.tb_failCount.TabIndex = 15;
            this.tb_failCount.TabStop = false;
            this.tb_failCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_passCount
            // 
            this.tb_passCount.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_passCount.Location = new System.Drawing.Point(533, 592);
            this.tb_passCount.Name = "tb_passCount";
            this.tb_passCount.ReadOnly = true;
            this.tb_passCount.Size = new System.Drawing.Size(156, 35);
            this.tb_passCount.TabIndex = 16;
            this.tb_passCount.TabStop = false;
            this.tb_passCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tb_totalCount
            // 
            this.tb_totalCount.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tb_totalCount.Location = new System.Drawing.Point(129, 592);
            this.tb_totalCount.Name = "tb_totalCount";
            this.tb_totalCount.ReadOnly = true;
            this.tb_totalCount.Size = new System.Drawing.Size(167, 35);
            this.tb_totalCount.TabIndex = 17;
            this.tb_totalCount.TabStop = false;
            this.tb_totalCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(840, 599);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 24);
            this.label4.TabIndex = 12;
            this.label4.Text = "FAIL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(449, 599);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 24);
            this.label3.TabIndex = 13;
            this.label3.Text = "PASS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(32, 596);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 24);
            this.label2.TabIndex = 14;
            this.label2.Text = "TOTAL:";
            // 
            // lbResult
            // 
            this.lbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbResult.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResult.Location = new System.Drawing.Point(638, 632);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(250, 190);
            this.lbResult.TabIndex = 18;
            this.lbResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbRegion
            // 
            this.lbRegion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lbRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbRegion.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbRegion.Location = new System.Drawing.Point(899, 632);
            this.lbRegion.Name = "lbRegion";
            this.lbRegion.Size = new System.Drawing.Size(173, 190);
            this.lbRegion.TabIndex = 19;
            this.lbRegion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("굴림", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStart.Location = new System.Drawing.Point(21, 828);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(1051, 78);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lb_AppName
            // 
            this.lb_AppName.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lb_AppName.Location = new System.Drawing.Point(25, 4);
            this.lb_AppName.Name = "lb_AppName";
            this.lb_AppName.Size = new System.Drawing.Size(1047, 37);
            this.lb_AppName.TabIndex = 21;
            this.lb_AppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbTestSelect
            // 
            this.cbTestSelect.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbTestSelect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbTestSelect.FormattingEnabled = true;
            this.cbTestSelect.Location = new System.Drawing.Point(1087, 12);
            this.cbTestSelect.Name = "cbTestSelect";
            this.cbTestSelect.Size = new System.Drawing.Size(136, 20);
            this.cbTestSelect.TabIndex = 22;
            this.cbTestSelect.SelectedIndexChanged += new System.EventHandler(this.cbTestSelect_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1030, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "label1";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // btnBdWrite
            // 
            this.btnBdWrite.Location = new System.Drawing.Point(1087, 276);
            this.btnBdWrite.Name = "btnBdWrite";
            this.btnBdWrite.Size = new System.Drawing.Size(75, 23);
            this.btnBdWrite.TabIndex = 24;
            this.btnBdWrite.Text = "write bd";
            this.btnBdWrite.UseVisualStyleBackColor = true;
            this.btnBdWrite.Click += new System.EventHandler(this.btnBdWrite_Click);
            // 
            // btnBdWritedumi
            // 
            this.btnBdWritedumi.Location = new System.Drawing.Point(1087, 305);
            this.btnBdWritedumi.Name = "btnBdWritedumi";
            this.btnBdWritedumi.Size = new System.Drawing.Size(75, 23);
            this.btnBdWritedumi.TabIndex = 25;
            this.btnBdWritedumi.Text = "write dumi";
            this.btnBdWritedumi.UseVisualStyleBackColor = true;
            this.btnBdWritedumi.Click += new System.EventHandler(this.btnBdWritedumi_Click);
            // 
            // btnAutopoweroffDisable
            // 
            this.btnAutopoweroffDisable.Location = new System.Drawing.Point(1087, 334);
            this.btnAutopoweroffDisable.Name = "btnAutopoweroffDisable";
            this.btnAutopoweroffDisable.Size = new System.Drawing.Size(75, 38);
            this.btnAutopoweroffDisable.TabIndex = 26;
            this.btnAutopoweroffDisable.Text = "auto off disable";
            this.btnAutopoweroffDisable.UseVisualStyleBackColor = true;
            this.btnAutopoweroffDisable.Click += new System.EventHandler(this.btnAutopoweroffDisable_Click);
            // 
            // btnReboot
            // 
            this.btnReboot.Location = new System.Drawing.Point(1168, 334);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(75, 23);
            this.btnReboot.TabIndex = 27;
            this.btnReboot.Text = "reboot";
            this.btnReboot.UseVisualStyleBackColor = true;
            this.btnReboot.Click += new System.EventHandler(this.btnReboot_Click);
            // 
            // btnFdl
            // 
            this.btnFdl.Location = new System.Drawing.Point(1168, 147);
            this.btnFdl.Name = "btnFdl";
            this.btnFdl.Size = new System.Drawing.Size(78, 23);
            this.btnFdl.TabIndex = 28;
            this.btnFdl.Text = "fd_init l";
            this.btnFdl.UseVisualStyleBackColor = true;
            this.btnFdl.Click += new System.EventHandler(this.btnFd_Click);
            // 
            // btnHdul
            // 
            this.btnHdul.Location = new System.Drawing.Point(1168, 176);
            this.btnHdul.Name = "btnHdul";
            this.btnHdul.Size = new System.Drawing.Size(78, 23);
            this.btnHdul.TabIndex = 29;
            this.btnHdul.Text = "hdu_init l";
            this.btnHdul.UseVisualStyleBackColor = true;
            this.btnHdul.Click += new System.EventHandler(this.btnHdu_Click);
            // 
            // btnReadbdDumil
            // 
            this.btnReadbdDumil.Location = new System.Drawing.Point(1168, 305);
            this.btnReadbdDumil.Name = "btnReadbdDumil";
            this.btnReadbdDumil.Size = new System.Drawing.Size(78, 23);
            this.btnReadbdDumil.TabIndex = 31;
            this.btnReadbdDumil.Text = "read dumi l";
            this.btnReadbdDumil.UseVisualStyleBackColor = true;
            this.btnReadbdDumil.Click += new System.EventHandler(this.btnBdReadDumi_Click);
            // 
            // btnReadbdl
            // 
            this.btnReadbdl.Location = new System.Drawing.Point(1168, 276);
            this.btnReadbdl.Name = "btnReadbdl";
            this.btnReadbdl.Size = new System.Drawing.Size(78, 23);
            this.btnReadbdl.TabIndex = 30;
            this.btnReadbdl.Text = "read bd l";
            this.btnReadbdl.UseVisualStyleBackColor = true;
            this.btnReadbdl.Click += new System.EventHandler(this.btnBdRead_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1252, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "read dumi r";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnReadbdr
            // 
            this.btnReadbdr.Location = new System.Drawing.Point(1252, 276);
            this.btnReadbdr.Name = "btnReadbdr";
            this.btnReadbdr.Size = new System.Drawing.Size(84, 23);
            this.btnReadbdr.TabIndex = 32;
            this.btnReadbdr.Text = "read bd r";
            this.btnReadbdr.UseVisualStyleBackColor = true;
            // 
            // btnHdur
            // 
            this.btnHdur.Location = new System.Drawing.Point(1252, 176);
            this.btnHdur.Name = "btnHdur";
            this.btnHdur.Size = new System.Drawing.Size(78, 23);
            this.btnHdur.TabIndex = 35;
            this.btnHdur.Text = "hdu_init r";
            this.btnHdur.UseVisualStyleBackColor = true;
            // 
            // btnFdr
            // 
            this.btnFdr.Location = new System.Drawing.Point(1252, 147);
            this.btnFdr.Name = "btnFdr";
            this.btnFdr.Size = new System.Drawing.Size(78, 23);
            this.btnFdr.TabIndex = 34;
            this.btnFdr.Text = "fd_init r";
            this.btnFdr.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(1087, 378);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 36;
            this.btnSend.Text = "send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbData
            // 
            this.tbData.Location = new System.Drawing.Point(1087, 407);
            this.tbData.Name = "tbData";
            this.tbData.Size = new System.Drawing.Size(240, 21);
            this.tbData.TabIndex = 37;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(1255, 378);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 38;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSend2
            // 
            this.btnSend2.Location = new System.Drawing.Point(1168, 378);
            this.btnSend2.Name = "btnSend2";
            this.btnSend2.Size = new System.Drawing.Size(75, 23);
            this.btnSend2.TabIndex = 39;
            this.btnSend2.Text = "send2";
            this.btnSend2.UseVisualStyleBackColor = true;
            this.btnSend2.Click += new System.EventHandler(this.btnSend2_Click);
            // 
            // cbComport
            // 
            this.cbComport.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbComport.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cbComport.FormattingEnabled = true;
            this.cbComport.Location = new System.Drawing.Point(1256, 12);
            this.cbComport.Name = "cbComport";
            this.cbComport.Size = new System.Drawing.Size(74, 20);
            this.cbComport.TabIndex = 40;
            // 
            // btngenguid
            // 
            this.btngenguid.Location = new System.Drawing.Point(1252, 247);
            this.btngenguid.Name = "btngenguid";
            this.btngenguid.Size = new System.Drawing.Size(84, 23);
            this.btngenguid.TabIndex = 41;
            this.btngenguid.Text = "gen guid";
            this.btngenguid.UseVisualStyleBackColor = true;
            this.btngenguid.Click += new System.EventHandler(this.btngenguid_Click);
            // 
            // btnGpibSend
            // 
            this.btnGpibSend.Location = new System.Drawing.Point(1087, 486);
            this.btnGpibSend.Name = "btnGpibSend";
            this.btnGpibSend.Size = new System.Drawing.Size(75, 23);
            this.btnGpibSend.TabIndex = 42;
            this.btnGpibSend.Text = "send";
            this.btnGpibSend.UseVisualStyleBackColor = true;
            this.btnGpibSend.Click += new System.EventHandler(this.btnGpibSend_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1085, 435);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 43;
            this.label5.Text = "GPIB TEST";
            // 
            // tbGpibData
            // 
            this.tbGpibData.Location = new System.Drawing.Point(1087, 515);
            this.tbGpibData.Name = "tbGpibData";
            this.tbGpibData.Size = new System.Drawing.Size(240, 21);
            this.tbGpibData.TabIndex = 44;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1168, 456);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 47;
            this.button3.Text = "query";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1255, 456);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 46;
            this.button4.Text = "write";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btnGpibConnect
            // 
            this.btnGpibConnect.Location = new System.Drawing.Point(1087, 456);
            this.btnGpibConnect.Name = "btnGpibConnect";
            this.btnGpibConnect.Size = new System.Drawing.Size(75, 23);
            this.btnGpibConnect.TabIndex = 45;
            this.btnGpibConnect.Text = "connect";
            this.btnGpibConnect.UseVisualStyleBackColor = true;
            this.btnGpibConnect.Click += new System.EventHandler(this.btnGpibConnect_Click);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1339, 931);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnGpibConnect);
            this.Controls.Add(this.tbGpibData);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnGpibSend);
            this.Controls.Add(this.btngenguid);
            this.Controls.Add(this.cbComport);
            this.Controls.Add(this.btnSend2);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnHdur);
            this.Controls.Add(this.btnFdr);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnReadbdr);
            this.Controls.Add(this.btnReadbdDumil);
            this.Controls.Add(this.btnReadbdl);
            this.Controls.Add(this.btnHdul);
            this.Controls.Add(this.btnFdl);
            this.Controls.Add(this.btnReboot);
            this.Controls.Add(this.btnAutopoweroffDisable);
            this.Controls.Add(this.btnBdWritedumi);
            this.Controls.Add(this.btnBdWrite);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbTestSelect);
            this.Controls.Add(this.lb_AppName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lbRegion);
            this.Controls.Add(this.lbResult);
            this.Controls.Add(this.tb_failCount);
            this.Controls.Add(this.tb_passCount);
            this.Controls.Add(this.tb_totalCount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnCradletestoff);
            this.Controls.Add(this.btnCradleteston);
            this.Controls.Add(this.btnOrange);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnGreen);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnTestStart);
            this.Name = "Form1";
            this.Text = "pro_test";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTestStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Button btnGreen;
        private System.Windows.Forms.Button btnBlue;
        private System.Windows.Forms.Button btnOrange;
        private System.Windows.Forms.Button btnCradleteston;
        private System.Windows.Forms.Button btnCradletestoff;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox tb_failCount;
        private System.Windows.Forms.TextBox tb_passCount;
        private System.Windows.Forms.TextBox tb_totalCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbResult;
        public System.Windows.Forms.Label lbRegion;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lb_AppName;
        private System.Windows.Forms.ComboBox cbTestSelect;
        private System.Windows.Forms.Label label1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnBdWrite;
        private System.Windows.Forms.Button btnBdWritedumi;
        private System.Windows.Forms.Button btnAutopoweroffDisable;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.Button btnFdl;
        private System.Windows.Forms.Button btnHdul;
        private System.Windows.Forms.Button btnReadbdDumil;
        private System.Windows.Forms.Button btnReadbdl;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnReadbdr;
        private System.Windows.Forms.Button btnHdur;
        private System.Windows.Forms.Button btnFdr;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox tbData;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSend2;
        private System.Windows.Forms.ComboBox cbComport;
        private System.Windows.Forms.Button btngenguid;
        private System.Windows.Forms.Button btnGpibSend;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbGpibData;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnGpibConnect;
    }
}

