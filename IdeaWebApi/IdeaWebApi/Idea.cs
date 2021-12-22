namespace IdeaWebApi
{
    public class Idea
    {
        public int Id { get; set; }

        public string IdeaText { get; set; } = string.Empty;
        public int UpVote { get; set; }
        public int downVote { get; set; }

    }
}
