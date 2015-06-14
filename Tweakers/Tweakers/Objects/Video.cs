namespace Tweakers
{
    using System;
    using System.Collections.Generic;

    public class Video:Article
    {
        public Video(int articleId, Account editor, string title, string content, DateTime date, int views, List<Category> categories, List<Reaction> reactions, string videoPath)
            : base(articleId, editor, title, content, date, views, categories, reactions)
        {
            this.VideoPath = videoPath;
        }

        public string VideoPath { get; set; }
    }
}
