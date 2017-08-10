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

namespace meLo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

        private void btnPlay1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFolder1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStop1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
