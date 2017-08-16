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
        public static void AddToDatabase()
        {
            using (var db = new MedialocatorContext())
            {
                var Folder = new Folder { FolderName = "folder1", FolderPath = @"C:\" };
                var audio = new Audio { FileName = "test1.mp3" };
                db.Folders.Add(Folder);
                db.Audios.Add(audio);
                db.SaveChanges();
            }
        }
    }
}
