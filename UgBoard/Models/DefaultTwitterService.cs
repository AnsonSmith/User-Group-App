using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqToTwitter;
using System.Windows;
using System.Reflection;

namespace UgBoard.Models
{
    public class DefaultTwitterService:ITwitterService
    {

        private TwitterContext twitterCtx;

        public TwitterContext TwitterCtx
        {
            get
            {
                if (twitterCtx == null)
                {
                    twitterCtx = new TwitterContext();
                }
                return twitterCtx;
            }
            set { twitterCtx = value; }
        }
        
        #region ITwitterService Members

        public IEnumerable<TwitterSearchResult> Search(string searchText)
        {
            IList<TwitterSearchResult> foundTweets = new List<TwitterSearchResult>();
            try
            {


                var queryResults =
                   from search in TwitterCtx.Search
                   where search.Type == SearchType.Search &&
                         search.Query == searchText
                   select search;

                var queryResult = queryResults.SingleOrDefault();

                foreach (var entry in queryResult.Entries)
                {
                    var statusID = entry.ID.Substring(entry.ID.LastIndexOf(":") + 1);

                    var status =
                        (from tweet in twitterCtx.Status
                         where tweet.Type == StatusType.Show &&
                               tweet.ID == statusID
                         select tweet)
                         .SingleOrDefault();

                    TwitterSearchResult foundTweet = new TwitterSearchResult() { UserName = "@" + status.User.Identifier.ScreenName, ProfileImageUrl = status.User.ProfileImageUrl, TweetText = status.Text, DateTime = status.CreatedAt.ToLongDateString() + " " + status.CreatedAt.ToLongTimeString(), Source = "via: "+status.Source };
                    foundTweets.Add(foundTweet);

                }

            }
            catch (TargetInvocationException ex)
            {

                MessageBox.Show("Error Querying Twitter: " +  ex.InnerException.Message );
            }
            return foundTweets;
        }

        #endregion
    }
}
