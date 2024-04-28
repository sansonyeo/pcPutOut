using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;

namespace pcPutOut
{
    public partial class frmPcPutOut : Form
    {

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, ref RECT Rect);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int Width, int Height, bool Repaint);

        Process process1 = new Process();
        Process process2 = new Process();
        Process process3 = new Process();
        Process process4 = new Process();
        Process process5 = new Process();
        Process process6 = new Process();



        public DateTime 종료일시 = new DateTime();
        public DateTime dt10분전일시 = new DateTime();
        public Boolean 실행여부 = false;
        public Boolean 실행여부_10전 = false;

        public frmPcPutOut()
        {
            InitializeComponent();
        }

        private void frmPcPutOut_Load(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer2.Stop();
        }

        private void btn실행_Click(object sender, EventArgs e)
        {
            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            this.timer1.Start();
            this.timer2.Start();

            this.WindowState = FormWindowState.Minimized;

            DateTime 현재일시 = DateTime.Now;
            실행여부 = true;
            실행여부_10전 = true;

            if (rdo10분.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(10);
            }
            else if (rdo20분.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(20);
            }
            else if (rdo30분.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(30);
            }
            else if (rdo40분.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(40);
            }
            else if (rdo50분.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(50);
            }
            else if (rdo1시간.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(60);
            }
            else if (rdo1시간30분.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(90);
            }
            else if (rdo2시간.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(120);
            }
            else if (rdo2시간30분.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(150);
            }
            else if (rdo3시간.Checked == true)
            {
                종료일시 = 현재일시.AddMinutes(180);
            }

            dt10분전일시 = 종료일시.AddMinutes(-10);
            lblStatus.Text = 종료일시.ToString("HH:mm") + " 에 최대절전모드로 종료 됩니다.";

            // 테스트
            //종료일시 = DateTime.Now.AddSeconds(20);
            //최대절전모드실행();
            //dt10분전일시 = 종료일시.AddSeconds(-5);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1의 Text에 현재시각을 표출
            DateTime 현재일시 = DateTime.Now;
            lbl현재일시.Text = 현재일시.ToString("HH:mm:ss");

            if (실행여부 == true)
            {
                if (현재일시 > 종료일시)
                {
                    //lbl경과시간.Text = 종료일시 + " 최대절전모드 실행!!!";
                    최대절전모드실행();
                }
            }

            if (실행여부_10전 == true)
            {
                if (dt10분전일시 < 현재일시)
                {
                    메시지창띄우기_10분전();
                }
            }


        }

        public void 최대절전모드실행()
        {
            //실행여부 = false;

            정지();
            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            cmd.FileName = @"cmd";
            cmd.WindowStyle = ProcessWindowStyle.Normal;             // cmd창이 숨겨지도록 하기
            //cmd.CreateNoWindow = true;                               // cmd창을 띄우지 안도록 하기

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;        // cmd창에서 데이터를 가져오기
            cmd.RedirectStandardInput = true;          // cmd창으로 데이터 보내기
            cmd.RedirectStandardError = true;          // cmd창에서 오류 내용 가져오기

            process.EnableRaisingEvents = false;

            process.StartInfo = cmd;
            process.Start();
            process.StandardInput.Write("powercfg -h on" + Environment.NewLine);
            process.StandardInput.Write("rundll32.exe powrprof.dll,SetSuspendState");
            process.StandardInput.Write(Environment.NewLine);

            // 명령어를 보낼때는 꼭 마무리를 해줘야 한다. 그래서 마지막에 NewLine가 필요하다
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();
            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");

            process.WaitForExit();
            process.Close();

        }

        private void 메시지창띄우기_10분전()
        {
            실행여부_10전 = false;

            if (rdo10분.Checked == true) return;

            this.WindowState = FormWindowState.Normal;

            frm10분전메시지창 frm = new frm10분전메시지창();
            frm.ShowDialog();
            frm.TopMost = true;
        }

        private void rdo_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            //OO 한 후에 최대절전모드 로 종료 됩니다.
            string 라디오버튼명 = ((RadioButton)sender).Text;
            //groupBox1.Text = 라디오버튼명 + " 후에 최대절전모드로 종료 됩니다.";
            lblStatus.Text = 라디오버튼명 + " 후에 최대절전모드로 종료 됩니다.";
        }

        private void btn정지_Click(object sender, EventArgs e)
        {
            정지();
        }

        private void 정지()
        {
            실행여부 = false;
            실행여부_10전 = false;

            this.timer1.Stop();
            this.timer2.Stop();

            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            //groupBox1.Text = "정지되어 있습니다.";
            lblStatus.Text = "정지되어 있습니다.";
            this.lbl현재일시.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblStatus.Font = new Font("D2Coding", 38F, FontStyle.Regular, GraphicsUnit.Point, 129);

            TimeSpan dateDiff = DateTime.Now - 종료일시;

            if (Math.Abs(dateDiff.Hours) > 0)
            {
                lblStatus.Text = 종료일시.ToString("HH:mm") + "(" + (Math.Abs(dateDiff.Hours)).ToString() + "시 " + Math.Abs(dateDiff.Minutes).ToString() + "분)";
            }
            else
            {
                lblStatus.Text = 종료일시.ToString("HH:mm") + "(" + Math.Abs(dateDiff.Minutes).ToString() + "분)";
            }

        }



        private void btnOnTop_Click(object sender, EventArgs e)
        {
            if (this.TopMost == true)
            {
                this.TopMost = false;
            }
            else
            {
                this.TopMost = true;
            }
        }

        private void btn최대절전모드바로실행_Click(object sender, EventArgs e)
        {
            최대절전모드실행();
        }

        private void btn경제채널Open_Click(object sender, EventArgs e)
        {
            string url = string.Empty;

            RECT Rect = new RECT();
            Rect.left = 0;
            Rect.top = 0;
            Rect.bottom = 200;
            Rect.right = 620;

            url = "https://www.youtube.com/@Edaily_TV"; // 이데일리
            process1.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process1.StartInfo.Arguments = url + " --new-window";
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process1.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle = process1.MainWindowHandle;
            GetWindowRect(handle, ref Rect);

            url = "https://www.youtube.com/@hkwowtv"; // 한국경제
            process2.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process2.StartInfo.Arguments = url + " --new-window";
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process2.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle2 = process2.MainWindowHandle;
            GetWindowRect(handle2, ref Rect);

            url = "https://www.youtube.com/@MKeconomy_TV"; // 매일경제
            process3.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process3.StartInfo.Arguments = url + " --new-window";
            process3.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process3.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle3 = process3.MainWindowHandle;
            GetWindowRect(handle3, ref Rect);

            url = "https://www.youtube.com/@mtn"; // MTN 머니투데이방송
            process4.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process4.StartInfo.Arguments = url + " --new-window";
            process4.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process4.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle4 = process4.MainWindowHandle;
            GetWindowRect(handle4, ref Rect);

            url = "https://www.youtube.com/@TomatoTV_Official"; // 토마토증권통
            process5.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process5.StartInfo.Arguments = url + " --new-window";
            process5.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process5.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle5 = process5.MainWindowHandle;
            GetWindowRect(handle5, ref Rect);

            url = "https://www.youtube.com/@chsentv"; // 서울경제
            process6.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process6.StartInfo.Arguments = url + " --new-window";
            process6.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process6.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle6 = process6.MainWindowHandle;
            GetWindowRect(handle6, ref Rect);

            #region 주석처리
            //System.Threading.Thread.Sleep(1000);

            //IntPtr handle2 = process2.MainWindowHandle;
            //RECT Rect2 = new RECT();
            ////if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, Rect.left, Rect.right, Rect.right - Rect.left, Rect.bottom - Rect.top + 50, true);
            //if (GetWindowRect(handle2, ref Rect2)) MoveWindow(handle2, 200, 0, 200, 800, true);
            ////MoveWindow(handle2, 200, 0, 200, 800, true);

            //for (int i=1; i<=6; i++)
            //{
            //    switch (i)
            //    {
            //        case 1: // 이데일리


            //            break;
            //        case 2: // 한국경제



            //            break;
            //        //case 3: // 매일경제
            //        //    url = "https://www.youtube.com/@MKeconomy_TV";
            //        //    iX = 400;
            //        //    iY = 0;
            //        //    iWidth = 200;
            //        //    iHeight = 800;
            //        //    break;
            //        //case 4: // MTN 머니투데이방송
            //        //    url = "https://www.youtube.com/@mtn";
            //        //    iX = 0;
            //        //    iY = 800;
            //        //    iWidth = 200;
            //        //    iHeight = 800;
            //        //    break;
            //        //case 5: // 토마토증권통
            //        //    url = "https://www.youtube.com/@TomatoTV_Official";
            //        //    iX = 200;
            //        //    iY = 800;
            //        //    iWidth = 200;
            //        //    iHeight = 800;
            //        //    break;
            //        //case 6: // 서울경제TV
            //        //    url = "https://www.youtube.com/@chsentv";
            //        //    iX = 400;
            //        //    iY = 1600;
            //        //    iWidth = 200;
            //        //    iHeight = 800;
            //        //    break;
            //    }

            //Process process = new Process();
            //process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            //process.StartInfo.Arguments = url + " --new-window";
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            //process.Start();

            //System.Threading.Thread.Sleep(6000);

            //IntPtr handle = process.MainWindowHandle;
            //RECT Rect = new RECT();
            //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, Rect.left, Rect.right, Rect.right - Rect.left, Rect.bottom - Rect.top + 50, true);
            //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, iX, iY, iWidth, iHeight, true);

            //i += 1;
            //}

            //System.Threading.Thread.Sleep(6000);

            //for (int i = 1; i <= 6; i++)
            //{
            //    switch (i)
            //    {
            //        case 1: // 이데일리
            //            iX = 0;
            //            iY = 0;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 2: // 한국경제
            //            iX = 200;
            //            iY = 0;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 3: // 매일경제
            //            iX = 400;
            //            iY = 0;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 4: // MTN 머니투데이방송
            //            iX = 0;
            //            iY = 800;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 5: // 토마토증권통
            //            iX = 200;
            //            iY = 800;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 6: // 서울경제TV
            //            iX = 400;
            //            iY = 1600;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //    }

            //    IntPtr handle = process.MainWindowHandle;
            //    RECT Rect = new RECT();
            //    //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, Rect.left, Rect.right, Rect.right - Rect.left, Rect.bottom - Rect.top + 50, true);
            //    if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, iX, iY, iWidth, iHeight, true);

            //    i += 1;
            //}




            //string url = "https://www.youtube.com/@Edaily_TV";

            //Process process = new Process();
            //process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            //process.StartInfo.Arguments = url + " --new-window";
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;

            //process.Start();

            //System.Threading.Thread.Sleep(3000);

            //IntPtr handle = process.MainWindowHandle;
            //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, Rect.left, Rect.right, Rect.width, Rect.height, true);

            //RECT Rect = new RECT();
            //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, Rect.left, Rect.right, Rect.right - Rect.left, Rect.bottom - Rect.top + 50, true);
            //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, 0, 0, 200, 800, true);




            //string command = $"start microsoft-edge:{url}";
            //Process process = new Process();
            //process.EnableRaisingEvents = true;
            //process.StartInfo.FileName = "cmd.exe";
            //process.StartInfo.Arguments = string.Format("/C {0}", command);
            //process.StartInfo.WindowStyle = ProcessWindowStyle.Minimized;
            //process.StartInfo.CreateNoWindow = true;
            //process.StartInfo.UseShellExecute = false;
            //process.StartInfo.RedirectStandardOutput = true;
            //process.Start();


            //Process.Start(@"C:\Program Files\Google\Chrome\Application\chrome.exe", "https://www.youtube.com/@Edaily_TV");

            //string url = "www.google.co.kr";
            //Process.Start("chrome.exe", url);

            //string youtubeUrl = string.Empty;
            //for (var i=0; i<1; i++)
            //{
            //    if (i == 0) youtubeUrl = "https://www.youtube.com/@Edaily_TV";        // 이데일리tv
            //    //else if (i == 1) youtubeUrl = "https://www.youtube.com/watch?v=NJUjU9ALj4A";   // 한국경제tv
            //    //else if (i == 2) youtubeUrl = "https://www.youtube.com/watch?v=s9xL1DpBsfQ";   // 매일경제tv
            //    //else if (i == 3) youtubeUrl = "https://www.youtube.com/watch?v=CbjcNK6ae-s";   // 머니투데이tv (MTN)
            //    //else if (i == 4) youtubeUrl = "https://www.youtube.com/watch?v=x5co7zQHG1M";   // 토마토tv
            //    //else if (i == 5) youtubeUrl = "https://www.youtube.com/watch?v=yysa0q-Td0I";   // 서울경제tv

            //    System.Diagnostics.Process.Start(youtubeUrl);

            //    i += 1;
            //}
            #endregion

        }

        private void btn테스트_Click(object sender, EventArgs e)
        {
            Process process = new Process();

            string url = "https://www.youtube.com/@chsentv"; // 서울경제
            process.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process.StartInfo.Arguments = url + " --new-window";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle = process.MainWindowHandle;
            RECT Rect = new RECT();
            Rect.left = 0;
            Rect.top = 0;
            Rect.bottom = 200;
            Rect.right = 620;
            GetWindowRect(handle, ref Rect);

            //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, Rect.left, Rect.right, Rect.right - Rect.left, Rect.bottom - Rect.top + 50, true);
            //if (GetWindowRect(handle, ref Rect)) MoveWindow(handle, 0, 0, 0, 650, true);
        }
    }
}
