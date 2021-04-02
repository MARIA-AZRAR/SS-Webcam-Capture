using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Drawing;
using System.Diagnostics;

namespace SSApplication
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        int counter = 1;

        public Home()
        {
            InitializeComponent();

            //  DispatcherTimer setup
            var Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(SaveImages);
            Timer.Interval = new TimeSpan(0,10,0);
            Timer.Start();
        }

        private void SaveImages(object sender, EventArgs e)
        {
            String filename = "ScreenShot-" + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png";

            //setting the size according to our screen

            int left = (int)SystemParameters.VirtualScreenLeft;
            int top = (int)SystemParameters.VirtualScreenTop;
            int width = (int)SystemParameters.VirtualScreenWidth;
            int height = (int)SystemParameters.VirtualScreenHeight;

            //creating empty bitmap
            Bitmap bitmapImage = new Bitmap(width, height);

            //creating graphics using windows library
            Graphics graphic = Graphics.FromImage(bitmapImage);

            //getting ScreenShot

            graphic.CopyFromScreen(left, top, 0, 0, bitmapImage.Size);

            // saving the bitmap image

            bitmapImage.Save("E:\\semester 6\\FYP Trial\\ScreenShotImages\\Img" + filename);

            Console.WriteLine("Saving .....");

            PythonRun();

        }


        void PythonRun()
        {
            var psi = new ProcessStartInfo();
            psi.FileName = @"C:\Users\probook 430\AppData\Local\Programs\Python\Python38-32\python3.exe";

            var script = @"E:\semester 6\FYP Trial\SSApplication\SSApplication\a.py";
            psi.Arguments = $"\"{script}\" \"{counter++}\"";


            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;



            var errors = "";
            var result = "";
            using (var process = Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                result = process.StandardOutput.ReadToEnd();
            }
            Console.WriteLine("Saving Web...");
        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
