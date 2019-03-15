using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        int r = 200;


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           Graphics g = e.Graphics;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |ControlStyles.ResizeRedraw |ControlStyles.AllPaintingInWmPaint, true);

            //绘制圆形轮廓
            g.ResetTransform();

            g.TranslateTransform(300, 300);

            g.FillEllipse(Brushes.White, -200, -200, 395, 395);

            g.DrawEllipse(new Pen(Color.Red, 3), -200, -200, 395, 395);

           // g.DrawEllipse(new Pen(Color.DarkGray, 1), -200, -200, 397, 397);


            g.ResetTransform();    //恢复默认状态
           // g.Dispose();

            Rectangle r1 = new Rectangle(225,350, 150, 40);

            //参数分别为左上角矩形坐标，宽度和长度

            g.FillRectangle(Brushes.Chocolate, r1);//填充颜色

            int ss = DateTime.Now.Second;

            int  mm = DateTime.Now.Minute;

            int hh = DateTime.Now.Hour;

            String s = Convert.ToString(ss);

            String m = Convert.ToString(mm);

            String h = Convert.ToString(hh);

            if (ss >= 0 && ss <= 9)

                s ="0"+s;

            if (mm >= 0 && mm <= 9)

                m ="0"+m;

            if (hh >= 0 && hh <= 9)

                h ="0"+h;

            Font f1 = new Font("宋体",25,FontStyle.Bold);

            StringFormat sf1 = new StringFormat();

            SolidBrush s1 = new SolidBrush(Color.White);

            g.DrawString(h +":"+m +":"+s, f1, s1, r1, sf1);


            //绘制数字刻度

            g.ResetTransform();

            g.TranslateTransform(300, 300);  //重新定位坐标

            Font drawFont = new Font("Arial", 16,FontStyle.Bold);

            SolidBrush drawBrush = new SolidBrush(Color.Black);

            e.Graphics.DrawString("6", drawFont, drawBrush, -10,150 );

            e.Graphics.DrawString("12", drawFont, drawBrush, -10, -150);

            e.Graphics.DrawString("3", drawFont, drawBrush, 150, -10);

            e.Graphics.DrawString("9", drawFont, drawBrush, -150, -10);

            //绘制刻度

            for (int z = 0; z < 60; z++)

            {

                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                //使画出的指针更平滑、高质量

                g.ResetTransform();

                g.TranslateTransform(300, 300); //更改坐标原点

                g.RotateTransform(z * 6);  //旋转，每一秒旋转6度

                if (z % 5 == 0)

                    g.DrawLine(new Pen(Color.Black, 3.0f),r - 20, 0, r - 5, 0);

                //小时刻度             

                else

                    g.DrawLine(new Pen(Color.Black, 1.5f), r - 13, 0, r - 5, 0);

                //分钟标准刻度

            }

            //绘制秒针

            g.ResetTransform();    //恢复默认状态

            g.TranslateTransform(300, 300);

            g.RotateTransform((ss * 6)+180);

            //以水平线为x轴，从垂直上方开始旋转，每次旋转6度。     

            Pen secPen = new Pen(Color.Red, 2);

            secPen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

            //画线，从圆点开始   

            secPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

　　//画线，结束于箭头

　　        g.DrawLine(secPen, 0, 0, 0, 130);     

            //绘制分针

            g.ResetTransform();

            g.TranslateTransform(300, 300);

            g.RotateTransform(mm * 6 +ss*1/10+ 270);

            Pen minPen = new Pen(Color.Blue, 4);

            minPen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;

            minPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(minPen, 0, 0, 100, 0);

            //绘制时针

            g.ResetTransform();

            g.TranslateTransform(300,300);

            g.RotateTransform(hh * 30 + mm * 1 / 2 + 270);

            Pen hourPen = new Pen(Color.Black, 6);

            hourPen.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;

            g.DrawLine(hourPen, 0, 0, 70, 0);
        }

        private Graphics DrawLine(object p, int v1, int v2, int v3)
        {
            throw new NotImplementedException();
        }

        

        private void timer2_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
