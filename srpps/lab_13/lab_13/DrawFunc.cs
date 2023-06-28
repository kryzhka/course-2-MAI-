using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;

namespace lab_13
{
    internal class DrawFunc
    {
        public static void draw(Graphics plot, int Height,int Width,double a, double b, double c)
        {
            SolidBrush brush = new SolidBrush(Color.White);
            Pen pen = new Pen(Color.DarkSeaGreen, 2);
            double Xmin = 2.0, Xmax = Math.PI * 4;
            double Ymin = -3, Ymax = 3;
            double Mx = (Xmax - Xmin) / Width,
                   My = (Ymax - Ymin) / Height;
            //double xp, yp, ypp;
            plot.FillRectangle(brush, 0, 0, Width, Height);
            //ypp = Height - ((a+b*Xmin+Math.Tan(c * Xmin) - Ymin) / My);
            //for (xp = 1; xp < Width; xp++)
            //{RY - ((a * Math.Sin(b * (Xmin) + c) - Ymin) / My);
            //    yp = Height - ((a+b*xp+Math.Tan(c * (Xmin + xp * Mx)) - Ymin) / My);
            //    plot.DrawLine(pen, (int)(xp - 1), (int)ypp, (int)xp, (int)yp);
            //    ypp = yp;RY - ((a * Math.Sin(b * (Xmin + xp * Mx) + c) - Ymin) / My);
            //}
            double y, yl;
            yl = Height - (( Math.Sin(c * (Xmin)+a) - Ymin) / My);

            for (int i = 0; i < Width; i++)
            {
                y= Height - ((Math.Sin(c* (Xmin + i * Mx))+a- Ymin) / My);
                plot.DrawLine(pen, (int)(i - 1), (int)y, (int)i, (int)yl);
                yl = y;
            }
        }
    }
}
