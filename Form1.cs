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



        public DateTime �����Ͻ� = new DateTime();
        public DateTime dt10�����Ͻ� = new DateTime();
        public Boolean ���࿩�� = false;
        public Boolean ���࿩��_10�� = false;

        public frmPcPutOut()
        {
            InitializeComponent();
        }

        private void frmPcPutOut_Load(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer2.Stop();
        }

        private void btn����_Click(object sender, EventArgs e)
        {
            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            this.timer1.Start();
            this.timer2.Start();

            this.WindowState = FormWindowState.Minimized;

            DateTime �����Ͻ� = DateTime.Now;
            ���࿩�� = true;
            ���࿩��_10�� = true;

            if (rdo10��.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(10);
            }
            else if (rdo20��.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(20);
            }
            else if (rdo30��.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(30);
            }
            else if (rdo40��.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(40);
            }
            else if (rdo50��.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(50);
            }
            else if (rdo1�ð�.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(60);
            }
            else if (rdo1�ð�30��.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(90);
            }
            else if (rdo2�ð�.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(120);
            }
            else if (rdo2�ð�30��.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(150);
            }
            else if (rdo3�ð�.Checked == true)
            {
                �����Ͻ� = �����Ͻ�.AddMinutes(180);
            }

            dt10�����Ͻ� = �����Ͻ�.AddMinutes(-10);
            lblStatus.Text = �����Ͻ�.ToString("HH:mm") + " �� �ִ��������� ���� �˴ϴ�.";

            // �׽�Ʈ
            //�����Ͻ� = DateTime.Now.AddSeconds(20);
            //�ִ�����������();
            //dt10�����Ͻ� = �����Ͻ�.AddSeconds(-5);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //label1�� Text�� ����ð��� ǥ��
            DateTime �����Ͻ� = DateTime.Now;
            lbl�����Ͻ�.Text = �����Ͻ�.ToString("HH:mm:ss");

            if (���࿩�� == true)
            {
                if (�����Ͻ� > �����Ͻ�)
                {
                    //lbl����ð�.Text = �����Ͻ� + " �ִ�������� ����!!!";
                    �ִ�����������();
                }
            }

            if (���࿩��_10�� == true)
            {
                if (dt10�����Ͻ� < �����Ͻ�)
                {
                    �޽���â����_10����();
                }
            }


        }

        public void �ִ�����������()
        {
            //���࿩�� = false;

            ����();
            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            cmd.FileName = @"cmd";
            cmd.WindowStyle = ProcessWindowStyle.Normal;             // cmdâ�� ���������� �ϱ�
            //cmd.CreateNoWindow = true;                               // cmdâ�� ����� �ȵ��� �ϱ�

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;        // cmdâ���� �����͸� ��������
            cmd.RedirectStandardInput = true;          // cmdâ���� ������ ������
            cmd.RedirectStandardError = true;          // cmdâ���� ���� ���� ��������

            process.EnableRaisingEvents = false;

            process.StartInfo = cmd;
            process.Start();
            process.StandardInput.Write("powercfg -h on" + Environment.NewLine);
            process.StandardInput.Write("rundll32.exe powrprof.dll,SetSuspendState");
            process.StandardInput.Write(Environment.NewLine);

            // ��ɾ �������� �� �������� ����� �Ѵ�. �׷��� �������� NewLine�� �ʿ��ϴ�
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();
            StringBuilder sb = new StringBuilder();
            sb.Append("[Result Info]" + DateTime.Now + "\r\n");
            sb.Append(result);
            sb.Append("\r\n");

            process.WaitForExit();
            process.Close();

        }

        private void �޽���â����_10����()
        {
            ���࿩��_10�� = false;

            if (rdo10��.Checked == true) return;

            this.WindowState = FormWindowState.Normal;

            frm10�����޽���â frm = new frm10�����޽���â();
            frm.ShowDialog();
            frm.TopMost = true;
        }

        private void rdo_MouseClick(object sender, MouseEventArgs e)
        {
            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            //OO �� �Ŀ� �ִ�������� �� ���� �˴ϴ�.
            string ������ư�� = ((RadioButton)sender).Text;
            //groupBox1.Text = ������ư�� + " �Ŀ� �ִ��������� ���� �˴ϴ�.";
            lblStatus.Text = ������ư�� + " �Ŀ� �ִ��������� ���� �˴ϴ�.";
        }

        private void btn����_Click(object sender, EventArgs e)
        {
            ����();
        }

        private void ����()
        {
            ���࿩�� = false;
            ���࿩��_10�� = false;

            this.timer1.Stop();
            this.timer2.Stop();

            lblStatus.Font = new Font("D2Coding", 22F, FontStyle.Regular, GraphicsUnit.Point, 129);

            //groupBox1.Text = "�����Ǿ� �ֽ��ϴ�.";
            lblStatus.Text = "�����Ǿ� �ֽ��ϴ�.";
            this.lbl�����Ͻ�.Text = "";
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            lblStatus.Font = new Font("D2Coding", 38F, FontStyle.Regular, GraphicsUnit.Point, 129);

            TimeSpan dateDiff = DateTime.Now - �����Ͻ�;

            if (Math.Abs(dateDiff.Hours) > 0)
            {
                lblStatus.Text = �����Ͻ�.ToString("HH:mm") + "(" + (Math.Abs(dateDiff.Hours)).ToString() + "�� " + Math.Abs(dateDiff.Minutes).ToString() + "��)";
            }
            else
            {
                lblStatus.Text = �����Ͻ�.ToString("HH:mm") + "(" + Math.Abs(dateDiff.Minutes).ToString() + "��)";
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

        private void btn�ִ��������ٷν���_Click(object sender, EventArgs e)
        {
            �ִ�����������();
        }

        private void btn����ä��Open_Click(object sender, EventArgs e)
        {
            string url = string.Empty;

            RECT Rect = new RECT();
            Rect.left = 0;
            Rect.top = 0;
            Rect.bottom = 200;
            Rect.right = 620;

            url = "https://www.youtube.com/@Edaily_TV"; // �̵��ϸ�
            process1.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process1.StartInfo.Arguments = url + " --new-window";
            process1.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process1.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle = process1.MainWindowHandle;
            GetWindowRect(handle, ref Rect);

            url = "https://www.youtube.com/@hkwowtv"; // �ѱ�����
            process2.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process2.StartInfo.Arguments = url + " --new-window";
            process2.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process2.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle2 = process2.MainWindowHandle;
            GetWindowRect(handle2, ref Rect);

            url = "https://www.youtube.com/@MKeconomy_TV"; // ���ϰ���
            process3.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process3.StartInfo.Arguments = url + " --new-window";
            process3.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process3.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle3 = process3.MainWindowHandle;
            GetWindowRect(handle3, ref Rect);

            url = "https://www.youtube.com/@mtn"; // MTN �Ӵ������̹��
            process4.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process4.StartInfo.Arguments = url + " --new-window";
            process4.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process4.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle4 = process4.MainWindowHandle;
            GetWindowRect(handle4, ref Rect);

            url = "https://www.youtube.com/@TomatoTV_Official"; // �丶��������
            process5.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process5.StartInfo.Arguments = url + " --new-window";
            process5.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process5.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle5 = process5.MainWindowHandle;
            GetWindowRect(handle5, ref Rect);

            url = "https://www.youtube.com/@chsentv"; // �������
            process6.StartInfo.FileName = @"C:\Program Files\Google\Chrome\Application\chrome.exe";
            process6.StartInfo.Arguments = url + " --new-window";
            process6.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            process6.Start();

            System.Threading.Thread.Sleep(3000);
            IntPtr handle6 = process6.MainWindowHandle;
            GetWindowRect(handle6, ref Rect);

            #region �ּ�ó��
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
            //        case 1: // �̵��ϸ�


            //            break;
            //        case 2: // �ѱ�����



            //            break;
            //        //case 3: // ���ϰ���
            //        //    url = "https://www.youtube.com/@MKeconomy_TV";
            //        //    iX = 400;
            //        //    iY = 0;
            //        //    iWidth = 200;
            //        //    iHeight = 800;
            //        //    break;
            //        //case 4: // MTN �Ӵ������̹��
            //        //    url = "https://www.youtube.com/@mtn";
            //        //    iX = 0;
            //        //    iY = 800;
            //        //    iWidth = 200;
            //        //    iHeight = 800;
            //        //    break;
            //        //case 5: // �丶��������
            //        //    url = "https://www.youtube.com/@TomatoTV_Official";
            //        //    iX = 200;
            //        //    iY = 800;
            //        //    iWidth = 200;
            //        //    iHeight = 800;
            //        //    break;
            //        //case 6: // �������TV
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
            //        case 1: // �̵��ϸ�
            //            iX = 0;
            //            iY = 0;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 2: // �ѱ�����
            //            iX = 200;
            //            iY = 0;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 3: // ���ϰ���
            //            iX = 400;
            //            iY = 0;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 4: // MTN �Ӵ������̹��
            //            iX = 0;
            //            iY = 800;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 5: // �丶��������
            //            iX = 200;
            //            iY = 800;
            //            iWidth = 200;
            //            iHeight = 800;
            //            break;
            //        case 6: // �������TV
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
            //    if (i == 0) youtubeUrl = "https://www.youtube.com/@Edaily_TV";        // �̵��ϸ�tv
            //    //else if (i == 1) youtubeUrl = "https://www.youtube.com/watch?v=NJUjU9ALj4A";   // �ѱ�����tv
            //    //else if (i == 2) youtubeUrl = "https://www.youtube.com/watch?v=s9xL1DpBsfQ";   // ���ϰ���tv
            //    //else if (i == 3) youtubeUrl = "https://www.youtube.com/watch?v=CbjcNK6ae-s";   // �Ӵ�������tv (MTN)
            //    //else if (i == 4) youtubeUrl = "https://www.youtube.com/watch?v=x5co7zQHG1M";   // �丶��tv
            //    //else if (i == 5) youtubeUrl = "https://www.youtube.com/watch?v=yysa0q-Td0I";   // �������tv

            //    System.Diagnostics.Process.Start(youtubeUrl);

            //    i += 1;
            //}
            #endregion

        }

        private void btn�׽�Ʈ_Click(object sender, EventArgs e)
        {
            Process process = new Process();

            string url = "https://www.youtube.com/@chsentv"; // �������
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
