using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScreenShot
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
        //    @"\" + "截圖_" + DateTime.Now.ToString("yyyyMMdd") + @"\";

        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
             @"\";


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            window_main.Visibility = Visibility.Hidden;
            //Thread.Sleep(400);
            await Task.Delay(500);

            //this.WindowState = WindowState.Minimized;
            //Thread.Sleep(500);

            //if (!Directory.Exists(@"C:\Users\user\Desktop\folderPath"))
            //{
            //    DirectoryInfo di = Directory.CreateDirectory(folderPath);
            //    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(folderPath));
            //}
            
            //double screenLeft = 0;
            //double screenTop = 0;
            double screenWidth = Screen.PrimaryScreen.Bounds.Width;
            double screenHeight = Screen.PrimaryScreen.Bounds.Height;
            //double screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            //double screenWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            //double screenHeight = SystemParameters.MaximizedPrimaryScreenHeight;

            string fileName = DateTime.Now.ToString("yyyyMMdd");
            //$"{DateTime.Now.Year.ToString()}{DateTime.Now.Month.ToString()}{DateTime.Now.Day.ToString()}";
            string newfileName = fileName;
            string filePath = folderPath + fileName + "_001.png";

            int fileNameCount = 1;
            while (File.Exists(filePath))
            {
                newfileName = $"{fileName}_{fileNameCount.ToString("000")}";
                filePath = folderPath + newfileName + ".png";
                fileNameCount++;
            }

            

            using (Bitmap bmp = new Bitmap((int)screenWidth,
            (int)screenHeight))
            {
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    //String filename = "ScreenCapture-" + DateTime.Now.ToString("ddMMyyyy-hhmmss") + ".png";
                    

                    //g.CopyFromScreen((int)screenLeft, (int)screenTop, 0, 0, bmp.Size);
                    g.CopyFromScreen(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 0), 
                        new System.Drawing.Size((int)screenWidth, (int)screenHeight));


                    bmp.Save(filePath);
                    //this.Opacity = 1;
                    window_main.Visibility = Visibility.Visible;
                }

            }

            //Bitmap myImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //Graphics g = Graphics.FromImage(myImage);
            //g.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height));
            //IntPtr dc1 = g.GetHdc();
            //g.ReleaseHdc(dc1);
            //string fileName =
            //    $"{DateTime.Now.Year.ToString()}{DateTime.Now.Month.ToString()}{DateTime.Now.Day.ToString()}";
            //string newfileName = fileName;
            //string filePath = @"C:\Users\user\Desktop\" + fileName + ".png";

            //int fileNameCount = 1;
            //while (File.Exists(filePath))
            //{
            //    newfileName = $"{fileName}_{fileNameCount}";
            //    filePath = @"C:\Users\user\Desktop\" + newfileName + ".png";
            //    fileNameCount++;
            //}

            //myImage.Save(filePath);
        }

        private void btn_desktop_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", folderPath);
        }
    }
}
