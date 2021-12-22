using System;
using System.Collections.Generic;
using System.Text;

namespace Idea
{
    internal class IdeaItem
    {
        public string id { get; set; }
        public string ideaText { get; set; }
        public Int32 upVote { get; set; }
        public Int32 downVote { get; set; }

        public IdeaItem(string Text, Int32 UpVote, Int32 DownVote)
        {
            this.ideaText = Text;
            this.upVote = UpVote;
            this.downVote = DownVote;
        }
    }
}
