using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace meLo
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

        public static void recursiveFileAdding(DirectoryInfo actualDirectory, MediaLocator.MedialocatorContext db)
        {            
            var folder = new MediaLocator.Folder { FolderName = actualDirectory.Name, FolderPath = actualDirectory.FullName };
            db.Folders.Add(folder);
            foreach (FileInfo fileinfo in actualDirectory.GetFiles())
            {
                if (fileinfo.FullName.Contains("mp3") && !mp3List.Contains(fileinfo))
                {                
                    var audioFile = new MediaLocator.Audio { FileName = fileinfo.Name, FilePath = fileinfo.FullName, Folder = folder };
                    db.Audios.Add(audioFile);
                    db.SaveChanges();
                }
                else if (fileinfo.FullName.Contains("mp4") && !mp4List.Contains(fileinfo))
                {                   
                    var videoFile = new MediaLocator.Video { FileName = fileinfo.Name, FilePath = fileinfo.FullName, Folder = folder };
                    db.Videos.Add(videoFile);
                    db.SaveChanges();
                }
                else if (fileinfo.FullName.Contains("jpg") && !jpgList.Contains(fileinfo))
                {
                    var jpgFile = new MediaLocator.Picture { FileName = fileinfo.Name, FilePath = fileinfo.FullName, Folder = folder };
                    db.Pictures.Add(jpgFile);
                    db.SaveChanges();
                }
                else if (fileinfo.FullName.Contains("jpeg") && !jpegList.Contains(fileinfo))
                {
                    var jpegFile = new MediaLocator.Picture { FileName = fileinfo.Name, FilePath = fileinfo.FullName, Folder = folder };
                    db.Pictures.Add(jpegFile);
                    db.SaveChanges();
                }
                else if (fileinfo.FullName.Contains("png") && !pngList.Contains(fileinfo))
                {
                    var pngFile = new MediaLocator.Picture { FileName = fileinfo.Name, FilePath = fileinfo.FullName, Folder = folder };
                    db.Pictures.Add(pngFile);
                    db.SaveChanges();
                }
            }
            foreach (DirectoryInfo subdirectoryinfo in actualDirectory.GetDirectories())
            {
                recursiveFileAdding(subdirectoryinfo, db);
            }

        }
    }
}

