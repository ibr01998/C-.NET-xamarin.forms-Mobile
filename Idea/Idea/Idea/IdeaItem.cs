using System;
using System.Collections.Generic;
using System.Text;

namespace Idea
{
    internal class IdeaItem
    {
        public string IdeaText { get; set; }
        public Int32 UpVode { get; set; }
        public Int32 DownVode { get; set; }

        public IdeaItem(string Text, Int32 UpVode, Int32 DownVode)
        {
            this.IdeaText = Text;
            this.UpVode = UpVode;
            this.DownVode = DownVode;
        }
    }
}
