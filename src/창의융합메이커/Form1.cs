using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenCvSharp;
using SpeechSystem;
using System.Net;
using System.IO;

namespace 창의융합메이커
{
	public partial class Form1 : Form
	{
		int infoFace=0;


		CvCapture cap;
		IplImage src;

		IplImage haarface;

		public IplImage FaceDetection(IplImage src)
		{
			haarface = new IplImage(src.Size, BitDepth.U8, 3);
			Cv.Copy(src, haarface);

			const double scale = 0.9;
			const double scaleFactor = 1.139;
			const int minNeighbors = 1;

			using (IplImage Detected_image = new IplImage(new CvSize(Cv.Round(src.Width / scale), Cv.Round(src.Height / scale)), BitDepth.U8, 1))
			{
				using (IplImage gray = new IplImage(src.Size, BitDepth.U8, 1))
				{
					Cv.CvtColor(src, gray, ColorConversion.BgrToGray);
					Cv.Resize(gray, Detected_image, Interpolation.Linear);
					Cv.EqualizeHist(Detected_image, Detected_image);
				}
				//Console.WriteLine(Application.StartupPath);
				using (CvHaarClassifierCascade cascade = CvHaarClassifierCascade.FromFile("haarcascade_frontalface_alt.xml"))
				using (CvMemStorage storage = new CvMemStorage())
				{
					CvSeq<CvAvgComp> faces = Cv.HaarDetectObjects(Detected_image, cascade, storage, scaleFactor, minNeighbors, HaarDetectionType.ScaleImage, new CvSize(90, 90), new CvSize(0, 0));
					infoFace = faces.Total;
					for (int i = 0; i < faces.Total; i++)
					{
						CvRect r = faces[i].Value.Rect;
						CvPoint center = new CvPoint
						{
							X = Cv.Round((r.X + r.Width * 0.5) * scale),
							Y = Cv.Round((r.Y + r.Height * 0.5) * scale)
						};
						int radius = Cv.Round((r.Width + r.Height) * 0.25 * scale);
						haarface.Circle(center, radius, CvColor.Black, 3, LineType.AntiAlias, 0);
					}
				}
				return haarface;
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			try
			{
				cap = CvCapture.FromCamera(CaptureDevice.DShow, 0);
				cap.SetCaptureProperty(CaptureProperty.FrameWidth, 640);
				cap.SetCaptureProperty(CaptureProperty.FrameHeight, 480);
			}
			catch
			{
				timer1.Enabled = false;
			}
		}
		private void timer1_Tick(object sender, EventArgs e)
		{
			//Console.WriteLine("w1" + cam);
			//Console.WriteLine("wwwww"+ cam.Visible);
			if (cam.Visible)
			{
				src = cap.QueryFrame();
				if(src!=null)
					cam.ImageIpl = FaceDetection(src);
			}
		}
		private void timer2_Tick(object sender, EventArgs e){
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://183.97.200.230:1080/sws/"+ infoFace + "/10");
			using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) { }
			//using (Stream stream = response.GetResponseStream()) 
			//using (StreamReader reader = new StreamReader(stream))
			//{
				//html = reader.ReadToEnd();
			//}

			//Console.WriteLine(html);
		}
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Cv.ReleaseImage(src);
			if (src != null) src.Dispose();
		}
		public Form1()
		{
			InitializeComponent();
			this.FormBorderStyle = FormBorderStyle.None;
			//this.WindowState = FormWindowState.Maximized;
			Form1_Load(null, null);
			Speech.init();
			//리스트 디자인
			listBox1.SetSelected(0, true);
			InitListBox();
			
		}

		private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
		{

			if (this.prevLBSelectedIndex != -1)
			{

				this.listBox1.Invalidate(this.listBox1.GetItemRectangle(this.prevLBSelectedIndex));
			}
			this.prevLBSelectedIndex = this.listBox1.SelectedIndex;
			if(op0.GetItemChecked(0))
				Speech.addSpeech((string)listBox1.SelectedItem);
			if (listBox1.SelectedItem == "지도" || listBox1.SelectedItem == "웹")
			{
				map.Visible = true;
				string str = listBox1.SelectedItem == "웹" ? "https://google.com" : "https://beta.map.naver.com/directions";
				map.Url = new System.Uri(str);
				clsVirtualKB.Open();
			}
			else map.Visible = false;
			if (listBox1.SelectedItem == "설정")
			{
				op0.Visible = true;
			}
			else
			{
				op0.Visible = false;
			}
			if (listBox1.SelectedItem == "내부 상황")
			{
				cam.Visible = true;
			}
			else{
				cam.Visible = false;
			}


			if (listBox1.SelectedItem == "현재 정보")
			{
				info00.Refresh();
				info0.Visible = true;
				info00.Visible = true;
			}
			else
			{
				info0.Visible = false;
				info00.Visible = false;

			}
			if (listBox1.SelectedItem == "종료")
			{
				DialogResult re = MessageBox.Show("CSSSFA System을 종료하시겠습니까?", "중요", MessageBoxButtons.YesNo);
				if (re.ToString() == "Yes")
					Application.Exit();
				else listBox1.SetSelected(0, true);
			}
		}
		private void lb_propertyList_DrawItem(object sender, DrawItemEventArgs e)
		{
			e.DrawBackground();

			Brush brush;
			if (this.listBox1.SelectedIndex == e.Index)
				brush = Brushes.White;
			else
				brush = Brushes.White;

			//Font의 Height를 더한 만큼 좌표를 변경합니다.
			int x = e.Bounds.X + e.Font.Height - 30;
			int y = e.Bounds.Y + e.Font.Height - 15;

			e.Graphics.DrawString(this.listBox1.Items[e.Index].ToString(),
				e.Font, brush, x, y, StringFormat.GenericDefault);
			e.DrawFocusRectangle();
		}
		int prevLBSelectedIndex = -1;
		private void InitListBox()
		{
			//ItemHeght는 아이템의 개수에 따라 달라집니다.
			this.listBox1.ItemHeight = (this.listBox1.Height /this.listBox1.Items.Count);
			this.listBox1.SelectedIndex = 0;
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void progressBar1_Click(object sender, EventArgs e)
		{

		}
	}
}
