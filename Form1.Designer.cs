namespace pcPutOut
{
    partial class frmPcPutOut
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPcPutOut));
            btn실행 = new Button();
            lbl현재일시 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            rdo10분 = new RadioButton();
            groupBox1 = new GroupBox();
            rdo3시간 = new RadioButton();
            rdo2시간30분 = new RadioButton();
            rdo2시간 = new RadioButton();
            rdo1시간30분 = new RadioButton();
            rdo1시간 = new RadioButton();
            rdo50분 = new RadioButton();
            rdo40분 = new RadioButton();
            rdo30분 = new RadioButton();
            rdo20분 = new RadioButton();
            btn정지 = new Button();
            timer2 = new System.Windows.Forms.Timer(components);
            btnOnTop = new Button();
            lblStatus = new Label();
            btn최대절전모드바로실행 = new Button();
            btn경제채널Open = new Button();
            btn테스트 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btn실행
            // 
            btn실행.Location = new Point(345, 68);
            btn실행.Name = "btn실행";
            btn실행.Size = new Size(93, 25);
            btn실행.TabIndex = 1;
            btn실행.Text = "실행";
            btn실행.UseVisualStyleBackColor = true;
            btn실행.Click += btn실행_Click;
            // 
            // lbl현재일시
            // 
            lbl현재일시.BorderStyle = BorderStyle.FixedSingle;
            lbl현재일시.Font = new Font("D2Coding", 48F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lbl현재일시.Location = new Point(2, 68);
            lbl현재일시.Name = "lbl현재일시";
            lbl현재일시.Size = new Size(337, 87);
            lbl현재일시.TabIndex = 2;
            lbl현재일시.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // rdo10분
            // 
            rdo10분.AutoSize = true;
            rdo10분.Location = new Point(4, 20);
            rdo10분.Name = "rdo10분";
            rdo10분.Size = new Size(51, 19);
            rdo10분.TabIndex = 3;
            rdo10분.Text = "10분";
            rdo10분.UseVisualStyleBackColor = true;
            rdo10분.MouseClick += rdo_MouseClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rdo3시간);
            groupBox1.Controls.Add(rdo2시간30분);
            groupBox1.Controls.Add(rdo2시간);
            groupBox1.Controls.Add(rdo1시간30분);
            groupBox1.Controls.Add(rdo1시간);
            groupBox1.Controls.Add(rdo50분);
            groupBox1.Controls.Add(rdo40분);
            groupBox1.Controls.Add(rdo30분);
            groupBox1.Controls.Add(rdo20분);
            groupBox1.Controls.Add(rdo10분);
            groupBox1.Location = new Point(2, -6);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(1);
            groupBox1.Size = new Size(436, 71);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            // 
            // rdo3시간
            // 
            rdo3시간.AutoSize = true;
            rdo3시간.Location = new Point(308, 44);
            rdo3시간.Name = "rdo3시간";
            rdo3시간.Size = new Size(56, 19);
            rdo3시간.TabIndex = 12;
            rdo3시간.Text = "3시간";
            rdo3시간.UseVisualStyleBackColor = true;
            rdo3시간.MouseClick += rdo_MouseClick;
            // 
            // rdo2시간30분
            // 
            rdo2시간30분.AutoSize = true;
            rdo2시간30분.Location = new Point(220, 45);
            rdo2시간30분.Name = "rdo2시간30분";
            rdo2시간30분.Size = new Size(82, 19);
            rdo2시간30분.TabIndex = 11;
            rdo2시간30분.Text = "2시간30분";
            rdo2시간30분.UseVisualStyleBackColor = true;
            rdo2시간30분.MouseClick += rdo_MouseClick;
            // 
            // rdo2시간
            // 
            rdo2시간.AutoSize = true;
            rdo2시간.Location = new Point(158, 44);
            rdo2시간.Name = "rdo2시간";
            rdo2시간.Size = new Size(56, 19);
            rdo2시간.TabIndex = 10;
            rdo2시간.Text = "2시간";
            rdo2시간.UseVisualStyleBackColor = true;
            rdo2시간.MouseClick += rdo_MouseClick;
            // 
            // rdo1시간30분
            // 
            rdo1시간30분.AutoSize = true;
            rdo1시간30분.Location = new Point(66, 45);
            rdo1시간30분.Name = "rdo1시간30분";
            rdo1시간30분.Size = new Size(86, 19);
            rdo1시간30분.TabIndex = 9;
            rdo1시간30분.Text = "1시간 30분";
            rdo1시간30분.UseVisualStyleBackColor = true;
            rdo1시간30분.MouseClick += rdo_MouseClick;
            // 
            // rdo1시간
            // 
            rdo1시간.AutoSize = true;
            rdo1시간.Location = new Point(4, 45);
            rdo1시간.Name = "rdo1시간";
            rdo1시간.Size = new Size(56, 19);
            rdo1시간.TabIndex = 8;
            rdo1시간.Text = "1시간";
            rdo1시간.UseVisualStyleBackColor = true;
            rdo1시간.MouseClick += rdo_MouseClick;
            // 
            // rdo50분
            // 
            rdo50분.AutoSize = true;
            rdo50분.Location = new Point(232, 20);
            rdo50분.Name = "rdo50분";
            rdo50분.Size = new Size(51, 19);
            rdo50분.TabIndex = 7;
            rdo50분.Text = "50분";
            rdo50분.UseVisualStyleBackColor = true;
            rdo50분.MouseClick += rdo_MouseClick;
            // 
            // rdo40분
            // 
            rdo40분.AutoSize = true;
            rdo40분.Location = new Point(175, 20);
            rdo40분.Name = "rdo40분";
            rdo40분.Size = new Size(51, 19);
            rdo40분.TabIndex = 6;
            rdo40분.Text = "40분";
            rdo40분.UseVisualStyleBackColor = true;
            rdo40분.MouseClick += rdo_MouseClick;
            // 
            // rdo30분
            // 
            rdo30분.AutoSize = true;
            rdo30분.Checked = true;
            rdo30분.Location = new Point(118, 20);
            rdo30분.Name = "rdo30분";
            rdo30분.Size = new Size(51, 19);
            rdo30분.TabIndex = 5;
            rdo30분.TabStop = true;
            rdo30분.Text = "30분";
            rdo30분.UseVisualStyleBackColor = true;
            rdo30분.MouseClick += rdo_MouseClick;
            // 
            // rdo20분
            // 
            rdo20분.AutoSize = true;
            rdo20분.Location = new Point(61, 20);
            rdo20분.Name = "rdo20분";
            rdo20분.Size = new Size(51, 19);
            rdo20분.TabIndex = 4;
            rdo20분.Text = "20분";
            rdo20분.UseVisualStyleBackColor = true;
            rdo20분.MouseClick += rdo_MouseClick;
            // 
            // btn정지
            // 
            btn정지.Location = new Point(345, 99);
            btn정지.Name = "btn정지";
            btn정지.Size = new Size(93, 25);
            btn정지.TabIndex = 5;
            btn정지.Text = "정지";
            btn정지.UseVisualStyleBackColor = true;
            btn정지.Click += btn정지_Click;
            // 
            // timer2
            // 
            timer2.Enabled = true;
            timer2.Interval = 60000;
            timer2.Tick += timer2_Tick;
            // 
            // btnOnTop
            // 
            btnOnTop.Location = new Point(345, 161);
            btnOnTop.Name = "btnOnTop";
            btnOnTop.Size = new Size(93, 25);
            btnOnTop.TabIndex = 6;
            btnOnTop.Text = "OnTop";
            btnOnTop.UseVisualStyleBackColor = true;
            btnOnTop.Click += btnOnTop_Click;
            // 
            // lblStatus
            // 
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("D2Coding", 22F);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(2, 165);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(337, 87);
            lblStatus.TabIndex = 7;
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn최대절전모드바로실행
            // 
            btn최대절전모드바로실행.Location = new Point(345, 130);
            btn최대절전모드바로실행.Name = "btn최대절전모드바로실행";
            btn최대절전모드바로실행.Size = new Size(93, 25);
            btn최대절전모드바로실행.TabIndex = 8;
            btn최대절전모드바로실행.Text = "최절전실행";
            btn최대절전모드바로실행.UseVisualStyleBackColor = true;
            btn최대절전모드바로실행.Click += btn최대절전모드바로실행_Click;
            // 
            // btn경제채널Open
            // 
            btn경제채널Open.Location = new Point(345, 192);
            btn경제채널Open.Name = "btn경제채널Open";
            btn경제채널Open.Size = new Size(93, 25);
            btn경제채널Open.TabIndex = 9;
            btn경제채널Open.Text = "경제채널";
            btn경제채널Open.UseVisualStyleBackColor = true;
            btn경제채널Open.Click += btn경제채널Open_Click;
            // 
            // btn테스트
            // 
            btn테스트.Location = new Point(345, 222);
            btn테스트.Name = "btn테스트";
            btn테스트.Size = new Size(93, 25);
            btn테스트.TabIndex = 10;
            btn테스트.Text = "테스트";
            btn테스트.UseVisualStyleBackColor = true;
            btn테스트.Visible = false;
            btn테스트.Click += btn테스트_Click;
            // 
            // frmPcPutOut
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(457, 256);
            Controls.Add(btn테스트);
            Controls.Add(btn경제채널Open);
            Controls.Add(btn최대절전모드바로실행);
            Controls.Add(lblStatus);
            Controls.Add(btnOnTop);
            Controls.Add(btn정지);
            Controls.Add(groupBox1);
            Controls.Add(lbl현재일시);
            Controls.Add(btn실행);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frmPcPutOut";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PC 종료";
            Load += frmPcPutOut_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Button btn실행;
        private Label lbl현재일시;
        private System.Windows.Forms.Timer timer1;
        private RadioButton rdo10분;
        private GroupBox groupBox1;
        private RadioButton rdo1시간;
        private RadioButton rdo50분;
        private RadioButton rdo40분;
        private RadioButton rdo30분;
        private RadioButton rdo20분;
        private RadioButton rdo1시간30분;
        private RadioButton rdo3시간;
        private RadioButton rdo2시간30분;
        private RadioButton rdo2시간;
        private Button btn정지;
        private System.Windows.Forms.Timer timer2;
        private Button btnOnTop;
        private Label lblStatus;
        private Button btn최대절전모드바로실행;
        private Button btn경제채널Open;
        private Button btn테스트;
    }
}
