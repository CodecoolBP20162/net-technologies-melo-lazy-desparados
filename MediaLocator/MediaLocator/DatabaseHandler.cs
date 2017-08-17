using System;
using MediaLocator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator
{
    class DatabaseHandler
    {
        MedialocatorContext db = new MedialocatorContext();

        public Folder AddFolderToDatabase( String folderName, String folderPath)
        {
         
            var folder = new Folder { FolderName = folderName, FolderPath = folderPath};
            db.Folders.Add(folder);
            db.SaveChanges();

            return folder;
        }

        public void AddFilesToDatabase (string fileName, string filePath, Folder folder)
        {
            if (filePath.Contains("jpg"))
            {
                var pictureFile = new Picture { FileName = fileName, FilePath = filePath, Folder = folder };
                db.Pictures.Add(pictureFile);
                db.SaveChanges();
            }

            if (filePath.Contains("mp3"))
            {
                var audioFile = new Audio { FileName = fileName, FilePath = filePath, Folder = folder };
                db.Audios.Add(audioFile);
                db.SaveChanges();
            }

            if (filePath.Contains("mp4"))
            {
                var videoFile = new Video { FileName = fileName, FilePath = filePath, Folder = folder };
                db.Videos.Add(videoFile);
                db.SaveChanges();
            }

        }

        public List<Folder> LoadFoldersFromDatabase()
        {
            var folders1 = db.Folders.ToList();
            return folders1;
        }

    } 
}
