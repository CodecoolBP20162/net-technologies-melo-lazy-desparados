using System;
using MediaLocator;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

            if (filePath.Contains("png"))
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

        public List<Folder> LoadFoldersFromDatabase(string path)
        {
            var folder = db.Folders
                                .Where(b => b.FolderPath == path)
                                .Include("Audios")
                                .Include("Videos")
                                .Include("Pictures")
                                .ToList();
            return folder;
        }


        public static bool CheckDataBaseFolder(string folderName, string folderPath, MedialocatorContext db)
        {
          var folder = db.Folders
                     .Where(b => b.FolderName == folderName)
                     .FirstOrDefault();
          var folder2 = db.Folders
                       .Where(b => b.FolderPath == folderPath)
                       .FirstOrDefault();
          if(folder == null && folder2 == null)
            {
                return true;
            } else { return false; }
        }

        public static bool CheckDataBaseFile(string fileName, MedialocatorContext db)
        {
            if (fileName.Contains("mp3"))
            {
                var file = db.Audios
                       .Where(b => b.FilePath == fileName)
                       .FirstOrDefault();
                if (file == null)
                {
                    return false;
                }
                else { return true; }
            } else if (fileName.Contains("mp4"))
            {
                var file = db.Videos
                       .Where(b => b.FilePath == fileName)
                       .FirstOrDefault();
                if (file == null)
                {
                    return false;
                }
                else { return true; }
            }
            else {
                var file = db.Pictures
                    .Where(b => b.FilePath == fileName)
                    .FirstOrDefault();
                if (file == null)
                {
                    return false;
                }
                else { return true; }
            }
   
        }
    } 
}
