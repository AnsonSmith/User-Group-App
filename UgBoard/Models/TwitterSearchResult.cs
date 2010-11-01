using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Models
{
    public class TwitterSearchResult
    {
        public string TweetText { get; set; }
        public string ProfileImageUrl { get; set; }
        public string UserName { get; set; }
        public string DateTime { get; set; }
        public string Source { get; set; }
    }
}
