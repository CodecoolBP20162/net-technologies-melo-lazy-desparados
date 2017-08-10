using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcher
{
    class FileManager
    {
        public static HashSet<FileInfo> mp3List = new HashSet<FileInfo>();
        public static HashSet<FileInfo> mp4List = new HashSet<FileInfo>();
        public static HashSet<FileInfo> jpgList = new HashSet<FileInfo>();
        public static HashSet<FileInfo> jpegList = new HashSet<FileInfo>();
        public static HashSet<FileInfo> pngList = new HashSet<FileInfo>();

        public static void recursiveFileSearch(DirectoryInfo actualDirectory)
        {
            foreach (FileInfo fileinfo in actualDirectory.GetFiles())
            {
                if (fileinfo.FullName.Contains("mp3") && !mp3List.Contains(fileinfo))
                {
                    mp3List.Add(fileinfo);
                }
                else if (fileinfo.FullName.Contains("mp4") && !mp4List.Contains(fileinfo))
                {
                    mp4List.Add(fileinfo);
                }
                else if (fileinfo.FullName.Contains("jpg") && !jpgList.Contains(fileinfo))
                {
                    jpgList.Add(fileinfo);
                }
                else if (fileinfo.FullName.Contains("jpeg") && !jpegList.Contains(fileinfo))
                {
                    jpegList.Add(fileinfo);
                }
                else if (fileinfo.FullName.Contains("png") && !pngList.Contains(fileinfo))
                {
                    jpegList.Add(fileinfo);
                }
            }
            foreach (DirectoryInfo subdirectoryinfo in actualDirectory.GetDirectories())
            {
                 recursiveFileSearch(subdirectoryinfo);
            }
            
        }
    }
}
