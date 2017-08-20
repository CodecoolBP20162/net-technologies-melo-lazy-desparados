﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator
{
    public class Audio
    {
        public Audio()
        {

        }
        public int AudioID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }

        public virtual Folder Folder { get; set; }
        public virtual Playlist PLaylist { get; set; }
    }
}
