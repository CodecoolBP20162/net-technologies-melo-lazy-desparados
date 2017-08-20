using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator
{
    public class Folder
    {
        public Folder()
        {
            this.Pictures = new ObservableCollection<Picture>();
            this.Audios = new ObservableCollection<Audio>();
            this.Videos = new ObservableCollection<Video>();
        }
        public int FolderId { get; set; }
        public string FolderName { get; set; }
        public string FolderPath { get; set; }

        public virtual ObservableCollection<Picture> Pictures { get; set; }
        public virtual ObservableCollection<Audio> Audios { get; set; }
        public virtual ObservableCollection<Video> Videos { get; set; }
    }
}
