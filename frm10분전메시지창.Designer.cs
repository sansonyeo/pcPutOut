namespace pcPutOut
{
    partial class frm10분전메시지창
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl10분전메시지 = new Label();
            btn닫기 = new Button();
            SuspendLayout();
            // 
            // lbl10분전메시지
            // 
            lbl10분전메시지.Font = new Font("D2Coding", 35.9999962F, FontStyle.Regular, GraphicsUnit.Point, 129);
            lbl10분전메시지.Location = new Point(3, 5);
            lbl10분전메시지.Margin = new Padding(4, 0, 4, 0);
            lbl10분전메시지.Name = "lbl10분전메시지";
            lbl10분전메시지.Size = new Size(853, 92);
            lbl10분전메시지.TabIndex = 8;
            lbl10분전메시지.Text = "10분 후에 종료 됩니다.";
            // 
            // btn닫기
            // 
            btn닫기.Location = new Point(875, 40);
            btn닫기.Margin = new Padding(4, 5, 4, 5);
            btn닫기.Name = "btn닫기";
            btn닫기.Size = new Size(107, 42);
            btn닫기.TabIndex = 9;
            btn닫기.Text = "닫기";
            btn닫기.UseVisualStyleBackColor = true;
            btn닫기.Click += btn닫기_Click;
            // 
            // frm10분전메시지창
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1005, 98);
            Controls.Add(btn닫기);
            Controls.Add(lbl10분전메시지);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm10분전메시지창";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frm10분전메시지창";
            ResumeLayout(false);
        }

        #endregion

        private Label lbl10분전메시지;
        private Button btn닫기;
    }
}