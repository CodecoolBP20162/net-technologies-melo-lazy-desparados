using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Permissions;

namespace FileWatcher
{
    class Filewatcher
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Watch(string directoryPath)
        {
            string[] filters = { "*.mp3", "*.mp4", "*.jpg", "*.jpeg", "*.gif", "*.png" };
            List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();

            foreach (string f in filters)
            {
                FileSystemWatcher w = new FileSystemWatcher();
                w.Path = directoryPath;
                w.Filter = f;
                w.IncludeSubdirectories = true;

                // Add event handlers.
                w.Changed += new FileSystemEventHandler(OnChanged);
                w.Created += new FileSystemEventHandler(OnChanged);
                w.Deleted += new FileSystemEventHandler(OnChanged);
                w.Renamed += new RenamedEventHandler(OnRenamed);

                // Begin watching.
                w.EnableRaisingEvents = true;

                watchers.Add(w);
            }
        }

        // Define the event handlers.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is changed, created, or deleted.
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);

            if(e.ChangeType == WatcherChangeTypes.Created) {
                if (e.FullPath.Contains("mp3")) { FileManager.mp3List.Add(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("mp4")) { FileManager.mp4List.Add(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("jpg")) { FileManager.jpgList.Add(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("jpeg")) { FileManager.jpegList.Add(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("png")) { FileManager.jpegList.Add(new FileInfo(e.FullPath)); }
            }
            if (e.ChangeType == WatcherChangeTypes.Deleted)
            {
                if (e.FullPath.Contains("mp3")) { FileManager.mp3List.Remove(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("mp4")) { FileManager.mp4List.Remove(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("jpg")) { FileManager.jpgList.Remove(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("jpeg")) { FileManager.jpegList.Remove(new FileInfo(e.FullPath)); }
                else if (e.FullPath.Contains("png")) { FileManager.jpegList.Remove(new FileInfo(e.FullPath)); }
            }         
        }

        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            if (e.FullPath.Contains("mp3")) {
                FileManager.mp3List.Add(new FileInfo(e.Name));
                FileManager.mp3List.Remove(new FileInfo(e.OldName));
            }
            else if (e.FullPath.Contains("mp4")) { FileManager.mp4List.Add(new FileInfo(e.Name));
                FileManager.mp4List.Remove(new FileInfo(e.OldName));
            }
            else if (e.FullPath.Contains("jpg"))
            {
                FileManager.jpgList.Add(new FileInfo(e.Name));
                FileManager.jpgList.Remove(new FileInfo(e.OldName));
            }
            else if (e.FullPath.Contains("jpeg"))
            {
                FileManager.jpegList.Add(new FileInfo(e.Name));
                FileManager.jpegList.Remove(new FileInfo(e.OldName));
            }
            else if ( e.FullPath.Contains("png"))
            {
                FileManager.pngList.Add(new FileInfo(e.Name));
                FileManager.pngList.Remove(new FileInfo(e.OldName));
            }           
        }
    }
}
