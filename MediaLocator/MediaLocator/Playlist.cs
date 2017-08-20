using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator
{
    public class Playlist
    {
        public Playlist()
        {
            this.Audios = new ObservableCollection<Audio>();
        }
        public int PlaylistId { get; set; }
        public string PLaylistName { get; set; }

        public virtual ObservableCollection<Audio> Audios { get; set; }
    }
}
