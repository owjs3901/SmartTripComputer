namespace 창의융합메이커
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
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.info00 = new System.Windows.Forms.ProgressBar();
			this.info0 = new System.Windows.Forms.Label();
			this.map = new System.Windows.Forms.WebBrowser();
			this.cam = new OpenCvSharp.UserInterface.PictureBoxIpl();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.op0 = new System.Windows.Forms.CheckedListBox();
			this.timer2 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.cam)).BeginInit();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.BackColor = System.Drawing.Color.DimGray;
			this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.listBox1.Font = new System.Drawing.Font("맑은 고딕", 20F);
			this.listBox1.ForeColor = System.Drawing.SystemColors.ButtonFace;
			this.listBox1.FormattingEnabled = true;
			this.listBox1.ItemHeight = 30;
			this.listBox1.Items.AddRange(new object[] {
            "현재 정보",
            "내부 상황",
            "지도",
            "웹",
            "설정",
            "종료"});
			this.listBox1.Location = new System.Drawing.Point(0, 0);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(208, 602);
			this.listBox1.TabIndex = 1;
			this.listBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lb_propertyList_DrawItem);
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// info00
			// 
			this.info00.Location = new System.Drawing.Point(214, 117);
			this.info00.MarqueeAnimationSpeed = 1;
			this.info00.Name = "info00";
			this.info00.Size = new System.Drawing.Size(494, 23);
			this.info00.TabIndex = 2;
			this.info00.Value = 50;
			this.info00.Click += new System.EventHandler(this.progressBar1_Click);
			// 
			// info0
			// 
			this.info0.AutoSize = true;
			this.info0.Location = new System.Drawing.Point(214, 102);
			this.info0.Name = "info0";
			this.info0.Size = new System.Drawing.Size(53, 12);
			this.info0.TabIndex = 3;
			this.info0.Text = "주행거리";
			this.info0.Click += new System.EventHandler(this.label1_Click);
			// 
			// map
			// 
			this.map.Location = new System.Drawing.Point(205, 0);
			this.map.MinimumSize = new System.Drawing.Size(20, 20);
			this.map.Name = "map";
			this.map.Size = new System.Drawing.Size(911, 602);
			this.map.TabIndex = 4;
			// 
			// cam
			// 
			this.cam.Enabled = false;
			this.cam.Location = new System.Drawing.Point(205, 0);
			this.cam.Name = "cam";
			this.cam.Size = new System.Drawing.Size(820, 602);
			this.cam.TabIndex = 5;
			this.cam.TabStop = false;
			this.cam.Visible = false;
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 33;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// op0
			// 
			this.op0.Enabled = false;
			this.op0.FormattingEnabled = true;
			this.op0.Items.AddRange(new object[] {
            "음성 안내",
            "음성 비서의 먼저 말걸기"});
			this.op0.Location = new System.Drawing.Point(431, 188);
			this.op0.Name = "op0";
			this.op0.Size = new System.Drawing.Size(357, 244);
			this.op0.TabIndex = 7;
			this.op0.Visible = false;
			// 
			// timer2
			// 
			this.timer2.Enabled = true;
			this.timer2.Interval = 1000;
			this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1024, 600);
			this.Controls.Add(this.op0);
			this.Controls.Add(this.info0);
			this.Controls.Add(this.info00);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.map);
			this.Controls.Add(this.cam);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.cam)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ProgressBar info00;
        private System.Windows.Forms.Label info0;
        private System.Windows.Forms.WebBrowser map;
        private OpenCvSharp.UserInterface.PictureBoxIpl cam;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.CheckedListBox op0;
		private System.Windows.Forms.Timer timer2;
	}
}

