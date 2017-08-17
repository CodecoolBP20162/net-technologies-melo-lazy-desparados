using Microsoft.Win32;
using FileWatcher;
using System;
using System.Collections.Generic;
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
using System.Reflection;
using System.Windows.Threading;
using MediaLocator;

namespace meLo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            CreateImagesForButtons();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
        }

       private void CreateImagesForButtons()
        {
            string pathPlay = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\pictures\play.png");
            btnPlay1.Content = new Image
            {
                Source = new BitmapImage(new Uri(pathPlay))
            };

            string pathStop = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\pictures\stop.png");
            btnStop1.Content = new Image
            {
                Source = new BitmapImage(new Uri(pathStop))
            };

            string pathPause = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\pictures\pause.png");
            btnPause1.Content = new Image
            {
                Source = new BitmapImage(new Uri(pathPause))
            };

            string pathFolder = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"..\..\pictures\folder.png");
            btnFolder1.Content = new Image
            {
                Source = new BitmapImage(new Uri(pathFolder))
            };
        }


        private void btnPlay1_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Play();
        }
   

        private void UpdateFolderBtn_Click(object sender, RoutedEventArgs e)
        {
            FileManager.jpegList.Clear();
            FileManager.jpgList.Clear();
            FileManager.mp3List.Clear();
            FileManager.mp4List.Clear();
            FileManager.pngList.Clear();
            FolderViewBox.Items.Clear();
            DirectoryInfo temporaryDirInfo = new  DirectoryInfo(DirectoryPathTextBox.Text);
            FileManager.recursiveFileSearch(temporaryDirInfo);
            CreateListBoxItemsForFiles();

            CreateListBoxItemForFolders(); 
        }

        private void CreateListBoxItemForFolders()
        {
            List<string> folders = new List<string>();
            folders.Add(DirectoryPathTextBox.Text);

            foreach (var item in folders)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = item;
                FolderBox.Items.Add(listBoxItem);
            }
        }

        private void CreateListBoxItemsForFiles()
        {
            foreach (FileInfo filinfo in FileManager.mp3List)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;

                FolderViewBox.Items.Add(listBoxItem);
            }
            foreach (FileInfo filinfo in FileManager.mp4List)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;
                FolderViewBox.Items.Add(listBoxItem);
            }
            foreach (FileInfo filinfo in FileManager.jpgList)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;

                FolderViewBox.Items.Add(listBoxItem);
            }
            foreach (FileInfo filinfo in FileManager.jpegList)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;
                FolderViewBox.Items.Add(listBoxItem);
            }
        }

      
        private void btnStop1_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Stop();
        }

        private void btnPause1_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Pause();
        }

        private void btnFolder1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd;
            ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "*.*";
            ofd.Filter = "Media Files (*.*)|*.*";
            ofd.ShowDialog();
            string fullPath = ofd.FileName;
            string directoryPath = System.IO.Path.GetDirectoryName(fullPath);
            DirectoryPathTextBox.Text = directoryPath;


            try { mediaPlayer.Source = new Uri(ofd.FileName); }
            catch { new NullReferenceException("error"); }

            System.Windows.Threading.DispatcherTimer dispatchertimer = new System.Windows.Threading.DispatcherTimer();
            dispatchertimer.Tick += new EventHandler(timer_Tick);
            dispatchertimer.Interval = new TimeSpan(0, 0, 1);
            dispatchertimer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            mediaSlider.Value = mediaPlayer.Position.TotalSeconds;
        }
        
        private void mediaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Position = TimeSpan.FromSeconds(mediaSlider.Value);
        }

        private void slider_vol_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Volume = (double)Volume.Value;
        }

        private void mediaPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSpan ts = mediaPlayer.NaturalDuration.TimeSpan;
            mediaSlider.Maximum = ts.TotalSeconds;
            timer.Start();
        }

        private void btnOpenPic_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd;
            ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.DefaultExt = "*.*";
            ofd.Filter = "Media Files (*.*)|*.*";
            ofd.ShowDialog();

            PictureView pv = new PictureView();
            pv.imagebox.Source = new BitmapImage(new Uri(ofd.FileName));
            pv.ShowDialog();
        }
    }
}
