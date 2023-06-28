using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AFClass
{
    public abstract class AbstractFactory
    {
        public abstract PictureBox CreatePicture(Point p);
    }
    public class ConcreteFactory1 : AbstractFactory
    {
        private static readonly ConcreteFactory1 instance = new ConcreteFactory1();
        public static ConcreteFactory1 Instance { get { return instance; } }

        public override PictureBox CreatePicture(Point p)
        {
            string[] cats = { "pic\\kotik1.jpg", "pic\\kotik2.jpg", "pic\\kotik3.jpg", "pic\\kotiksad(.jpg" };
            PictureBox pictureBox = new PictureBox();
            pictureBox.Height = 300;
            pictureBox.Width = 400;

            pictureBox.Location = p;
            //pictureBox.Load("pic\\kotik1.jpg");
            //pictureBox.im
            Random random = new Random();
            int Cat = random.Next(cats.Length);
            pictureBox.BackgroundImage = System.Drawing.Image.FromFile(cats[Cat]); //"/Resources/kotik1";
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            return pictureBox;
        }

    }

    public class ConcreteFactory2 : AbstractFactory
    {
        private static readonly ConcreteFactory2 instance = new ConcreteFactory2();
        public static ConcreteFactory2 Instance { get { return instance; } }

        public override PictureBox CreatePicture(Point p)
        {
            Random random = new Random();

            string[] dogs = { "pic\\pes1.jpg", "pic\\pes2.jpg", "pic\\pes3.jfif", "pic\\pes4.jpg" };
            PictureBox pictureBox = new PictureBox();
            pictureBox.Height = 300;
            pictureBox.Width = 400;
            int Dog = random.Next(dogs.Length);
            pictureBox.Location = p;
            //pictureBox.Load("pic\\kotik1.jpg");
            //pictureBox.im
            pictureBox.BackgroundImage = System.Drawing.Image.FromFile(dogs[Dog]); //"/Resources/kotik1";
            pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
            return pictureBox;
        }
    }
}
