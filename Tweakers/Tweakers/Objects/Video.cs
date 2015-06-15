namespace Tweakers
{
    using System;
    using System.Collections.Generic;

    public class Video:Article
    {
        public Video(int articleId, Account editor, string title, string content, DateTime date, int views, List<Category> categories, List<Reaction> reactions, int videoID, string videoPath)
            : base(articleId, editor, title, content, date, views, categories, reactions)
        {
            this.VideoID = videoID;
            this.VideoPath = videoPath;
        }

        public string VideoPath { get; set; }

        public int VideoID { get; set; }
    }
}
