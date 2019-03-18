using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private Graphics m_graphic;
        private Timer m_timer;
        private float m_width;
        private float m_height;
        private Color m_bgcolor;    //背景颜色
        private Color m_backcolor;  //内圆颜色
        private Color m_scalecolor; //刻度颜色
        private Color m_seccolor;   //秒针颜色
        private Color m_mincolor;   //分针颜色
        private Color m_hourcolor;  //时针颜色
        private float m_radius;  //半径

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            m_timer = new Timer();
            m_timer.Interval = 1000;
            m_timer.Enabled = true;
            m_timer.Tick += new EventHandler(Timer_Tick);

            m_width = this.ClientSize.Width;
            m_height = this.ClientSize.Height;
            m_bgcolor = Color.AliceBlue;
            m_backcolor = Color.Gray;
            m_scalecolor = Color.Gray;
            m_seccolor = Color.Red;
            m_mincolor = Color.Blue;
            m_hourcolor = Color.Green;

            if (m_width > m_height)
            {
                m_radius = (float)(m_height - 8) / 2;
            }
            else
            {
                m_radius = (float)(m_width - 8) / 2;
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           // base.OnPaint(e);

            m_graphic = e.Graphics;
            m_graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            m_graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //设置坐标原点
            m_graphic.TranslateTransform((float)(m_width / 2), (float)(m_height / 2));
            m_graphic.FillEllipse(new SolidBrush(m_bgcolor), -m_radius, -m_radius, m_radius * 2, m_radius * 2);
            //画外边框
            Pen pen = new Pen(m_backcolor, 2);
            m_graphic.DrawEllipse(pen, m_radius * (-1), m_radius * (-1), m_radius * 2, m_radius * 2);
            //画小刻度
            for (int i = 0; i < 60; i++)
            {
                m_graphic.FillRectangle(new SolidBrush(m_scalecolor), -2, 2 - m_radius, 4, 10);
                m_graphic.RotateTransform(6);
            }
            //画大刻度
            for (int i = 0; i < 12; i++)
            {
                m_graphic.FillRectangle(new SolidBrush(m_scalecolor), -3, 2 - m_radius, 6, 18);
                m_graphic.RotateTransform(30);
            }
            //获取当期时间
            int second = DateTime.Now.Second;
            int minute = DateTime.Now.Minute;
            int hour = DateTime.Now.Hour;
            //画秒针
            pen.Color = m_seccolor;
            m_graphic.RotateTransform(6 * second);
            m_graphic.DrawLine(pen, 0, 0, 0, (-1) * (float)(m_radius / 1.5));
            //画分针
            pen.Color = m_mincolor;
            m_graphic.RotateTransform(-6 * second);
            m_graphic.RotateTransform((float)(0.1 * second + 6 * minute));
            m_graphic.DrawLine(pen, 0, 0, 0, (-1) * (float)(m_radius / 2));
            //画时针
            pen.Color = m_hourcolor;
            m_graphic.RotateTransform((float)(0.1 * second + 6 * minute) * (-1));
            m_graphic.RotateTransform((float)(30 / 3600 * second + 30 / 60 * minute + hour * 30));
            m_graphic.DrawLine(pen, 0, 0, 0, (-1) * (float)(m_radius / 2.5));
        }

        
    }


}
