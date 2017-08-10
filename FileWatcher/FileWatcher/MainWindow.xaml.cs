using System;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Timers;

namespace FileWatcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myMedia.Volume = 100;
            
        }

        void mediaPlay(Object sender, EventArgs e)
        {
            //ListBoxItem selectedListBoxItem = FileNamesListBox.SelectedItem as ListBoxItem;
            //string choosedFilePath = selectedListBoxItem.Content.ToString();
            //myMedia.Source = choosedFilePath;
            myMedia.Play();
        }

        void mediaPause(Object sender, EventArgs e)
        {
            myMedia.Pause();
        }

        void mediaMute(Object sender, EventArgs e)
        {

            if (myMedia.Volume == 100)
            {
                myMedia.Volume = 0;
                muteButt.Content = "Listen";
            }
            else
            {
                myMedia.Volume = 100;
                muteButt.Content = "Mute";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Filewatcher.Watch(pathTextBox.Text);

        }

        private void ListBox_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            pathTextBox.Text = @"C:\Users\Judit\Desktop\Demo\New folder";
            DirectoryInfo temporaryDirInfo = new DirectoryInfo(pathTextBox.Text);
            FileManager.recursiveFileSearch(temporaryDirInfo);
            CreateListBoxItemsForFiles();
            //SetTimer();
        }

        private void CreateListBoxItemsForFiles()
        {
            foreach (FileInfo filinfo in FileManager.mp3List)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;
                FileNamesListBox.Items.Add(listBoxItem);
            }
            foreach (FileInfo filinfo in FileManager.mp4List)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;
                FileNamesListBox.Items.Add(listBoxItem);
            }
            foreach (FileInfo filinfo in FileManager.jpgList)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;
                FileNamesListBox.Items.Add(listBoxItem);
            }
            foreach (FileInfo filinfo in FileManager.jpegList)
            {
                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = filinfo.Name;
                FileNamesListBox.Items.Add(listBoxItem);
            }
        }

        private void SetTimer()
        {
            // Create a timer with a two second interval.
            Timer aTimer = new System.Timers.Timer(3000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            this.Dispatcher.Invoke(() =>
            {
                pathTextBox.Text = @"C:\Users\Judit\Desktop\Demo\New folder";
                DirectoryInfo temporaryDirInfo = new DirectoryInfo(pathTextBox.Text);
                FileManager.recursiveFileSearch(temporaryDirInfo);
                FileNamesListBox.Items.Clear();
                CreateListBoxItemsForFiles();
            });            
        }

        private void Reload_Click(object sender, RoutedEventArgs e)
        {
            FileNamesListBox.Items.Clear();
            CreateListBoxItemsForFiles();
        }
    }
}
