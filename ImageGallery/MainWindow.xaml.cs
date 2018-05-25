
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageGallery
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
        private BitmapImage img = null;
        private string[] images = null;
        private int currentIndex;

        public MainWindow()
        {
            openFileDialog.Title = "Load Image";
            InitializeComponent();
            KeyDown += new KeyEventHandler(MainWindow_Right);
            KeyDown += new KeyEventHandler(MainWindow_Left);
        }

        void MainWindow_Right(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Right)
            {
                OnClickRight(sender, e);
            }
        }

        void MainWindow_Left(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                OnClickLeft(sender, e);
            }
        }

        private void OnClickLeft(object sender, RoutedEventArgs e)
        {
            if(images != null)
            {
                if (currentIndex > 0)
                {
                    imgLoaded.Source = new BitmapImage(new Uri(images[--currentIndex]));
                }
                else
                {
                    currentIndex = images.Length - 1;
                    imgLoaded.Source = new BitmapImage(new Uri(images[currentIndex]));
                }
            }
        }

        private void OnClickRight(object sender, RoutedEventArgs e)
        {
            if(images != null)
            {
                if (currentIndex < images.Length - 1)
                {
                    imgLoaded.Source = new BitmapImage(new Uri(images[++currentIndex]));
                }
                else
                {
                    currentIndex = 0;
                    imgLoaded.Source = new BitmapImage(new Uri(images[currentIndex]));
                }
            }
        }

        private void OnClickAdd(object sender, RoutedEventArgs e)
        {
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fullDir = new Uri(openFileDialog.FileName);
                string[] parts = fullDir.LocalPath.Split('\\');
                string baseDir = "";
                for (int i = 0; i < parts.Length - 1; i++)
                {
                    baseDir += parts[i] + "\\";
                }
                Uri currentDir = new Uri(baseDir);
                img = new BitmapImage(new Uri(openFileDialog.FileName));
                imgLoaded.Source = img;
                string[] filters = new String[] { "jpg", "jpeg", "jpe", "jfif", "png" };
                images = GetFilesFrom(currentDir.ToString(), filters, false);
                //Array.Sort(images);
                currentIndex = Array.IndexOf(images, openFileDialog.FileName);
            }
        }

        private static String[] GetFilesFrom(String searchFolder, String[] filters, bool isRecursive)
        {
            List<String> filesFound = new List<String>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(new Uri(searchFolder).AbsolutePath, String.Format("*.{0}", filter), searchOption));
            }
            return filesFound.ToArray();
        }
    }
}
