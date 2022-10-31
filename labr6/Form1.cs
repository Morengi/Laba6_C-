using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace labr6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Font font;
        SolidBrush brush;



        private void Form1_Load(object sender, EventArgs e)
        {
            font = fontDialog1.Font;
            brush = new SolidBrush(Color.Black);
        

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                font = fontDialog1.Font;
                brush.Color = fontDialog1.Color;
            }
            pictureBox1.Invalidate();

        }
        
        private double func(double x)
        {
            //return Math.Exp(-4 * x) * Math.Abs(Math.Cos(15 * x));

            return 2 *  Math.Pow(Math.Tan(x),2) - (2/( Math.Pow(Math.Sin(x/2),2)));
        }

        private void button2_Click(object sender, EventArgs e)
        {

            pictureBox1.Invalidate();

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //Начало координат графика
            int x0 = pictureBox1.Width/8;

            //int y0 = (int)(pictureBox1.Height-20);
            int y0 = pictureBox1.Height/4;
           // Console.WriteLine("Height = " + pictureBox1.Height + " Width = "+ pictureBox1.Width);
            
            //Масштаб по оси Х
            int Mx = (pictureBox1.Width-40)/8;
            //Масштаб по оси Y
            int My = (pictureBox1.Height-20)/4;

            //Число точек графика
            int M = (int)numericUpDown1.Value;
            
            Graphics G = e.Graphics;

            //pictureBox1.CreateGraphics();
            G.Clear(Color.White);

            G.DrawLine(Pens.Black, x0 - pictureBox1.Width / 8 + 20, y0, x0 + 7* pictureBox1.Width / 8 -20, y0);
            G.DrawLine(Pens.Black, x0, y0-pictureBox1.Height/4 + 10, x0, y0 + 3*pictureBox1.Height / 4 - 10);



            Point[] p = new Point[M+1];

            double x_start = 2.4;
            double xt = x_start;
            double x_end = 3.4;
            double increment = (x_end-x_start)/M;


            for (int n = 0; n<=M; n++)
            {
                if (n != 0)
                    xt = Math.Round(xt + increment, 3);
                double y = Math.Round(func(xt),5);
                
                Console.WriteLine("x = " + xt + " y= " + y);
                //int xi = (int)(((xt*Mx + x0)-2.4*Mx)*7 - 6.25*Mx -4);
                //int xi = (int)((n*xt*Mx/M) + x0);
                int xi = (int)(7* Mx  * n/M + x0);
               // Console.WriteLine( "xi = "+xi);
                int yi = (int)((y0 - y*My*1.5));

                p[n] = new Point(xi, yi);
                //G.DrawLine(Pens.Black, xi, y0, xi, yi);
                //G.DrawLine(Pens.Black, x0, yi, xi, yi);
            }
            Console.WriteLine("=================");
            float tensition = (float)numericUpDown2.Value;
            G.DrawCurve(Pens.Blue, p, tensition);

            // double y_point = -10;


            for (int n = 0; n < 11; n++)
            {
                double x = n / 10.0;
                

                int xi = (int)(7*Mx * x + x0);
                

                G.DrawString((x+2.4).ToString(), font, brush, xi, y0);
               // G.DrawLine(Pens.Red, xi, y0, xi, y0 - 20);

                //  Console.WriteLine("|| xi = " + xi);


                for (int n_y = 0; n_y < 21; n_y++)
                {
                    double y = -n_y / 10.0;

                    int yi = (int)(y0 - y * My*1.5);
                    G.DrawString(y.ToString(), font, brush, x0 - 30, yi);


                  //  G.DrawLine(Pens.Red, x0, yi, x0 - 10, yi);
                    //if (x == 2.4)
                       // G.DrawLine(Pens.Black, x0, yi, xi, yi);
    
                }



            }

           

            //Цикл по числу точек
            //for (int n = 0; n < M ; n++)
            //{
            //    if(n != 0)
            //        xt = xt + increment;

            //    double y = func(xt);
            //    Console.WriteLine("x = " + xt + " y= " + y);
            //    int xi = (int)((Mx*xt+x0));
            //    int yi = (int)((y0-y*My));
            //    Console.WriteLine("xi =" + xi + " yi =" + yi);
            //    //Console.WriteLine("------------------");


            //    p[n] = new Point(xi, yi);

            //}
            //float tensition = (float)numericUpDown2.Value;

            //G.DrawCurve(Pens.Blue, p, tensition);
            //G.DrawLine(Pens.Black, x0, pictureBox1.Height / 8, pictureBox1.Width - 30, pictureBox1.Height / 8);
            //G.DrawLine(Pens.Black, x0, y0, x0, y0 - pictureBox1.Height + 30);

            //// x_fact = 1;
            //     int num_y = -20;

            //for (int n = 0; n <= 34; n++)
            //{   
            //    double x = n / 10.0;
            //    double y = num_y / 10.0;


            //    int xi = (int)(x0 + Mx * x);
            //    int yi = (int)(y0 + My * y);
            //    // G.DrawLine(Pens.Black, xi, y0, xi+1, y0+1);

            //   // Console.WriteLine("draw xi = " + xi + "|| draw yi =  "+ yi);
            //    //Console.WriteLine("--------------------------------------");
            //    G.DrawString((x).ToString(), font, brush, xi, pictureBox1.Height / 8 + 4);
            //    // G.DrawLine(Pens.Green, xi, pictureBox1.Height / 8, xi, pictureBox1.Height / 8 + 10);
            //        if(x == 2.4)
            //            G.DrawLine(Pens.Red, x0, (float)(yi+0.5*My) , xi, (float)(yi+0.5*My));

            //    G.DrawString((y-0.5).ToString(), font, brush, x0 - 25, yi -  6 * pictureBox1.Height/8 + pictureBox1.Height/8  );
            //    //G.DrawLine(Pens.Green, x0, yi, x0+10, yi);

            //    num_y++;
            //}

        }




        private void button3_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }

}
