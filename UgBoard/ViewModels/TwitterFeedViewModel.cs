using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using UgBoard.Framework;
using System.Windows.Threading;
using System.Threading;
using UgBoard.Framework.Results;
using UgBoard.Models;

namespace UgBoard.ViewModels
{
    public class TwitterFeedViewModel:PropertyChangedBase, ISupportBusyIndicator
    {
        // Timer used for automatic tweet updates
        private DispatcherTimer tweetTimer = new DispatcherTimer();



        

        #region ISupportBusyIndicator Members
        private bool busyOn;
        public bool BusyOn
        {
            get
            {
                return busyOn;
            }
            set
            {
                busyOn = value;
                NotifyOfPropertyChange(() => BusyOn);
            }
        }

        #endregion

        public TwitterFeedViewModel()
        {
            //Manually fetch first Twitter feeds
            Coroutine.Execute(UpdateTweets().GetEnumerator());

            tweetTimer.Interval = new TimeSpan(0, IoC.Get<IConfigurationService>().TwitterRefreshInterval, 0);
            tweetTimer.Tick += new EventHandler(tweetTimer_Tick);
            tweetTimer.Start();

           

        }

        private ObservableCollection<TweetViewModel> tweets;

        public ObservableCollection<TweetViewModel> Tweets
        {
            get {
                if (tweets == null)
                {
                    tweets = new ObservableCollection<TweetViewModel>();
                }
                return tweets; 
            }
            set
            {
                tweets = value;
                NotifyOfPropertyChange(() => Tweets);
            }
        }



        void tweetTimer_Tick(object sender, EventArgs e)
        {
            Coroutine.Execute(UpdateTweets().GetEnumerator());
        }

        private IEnumerable<IResult> UpdateTweets()
        {

          
            QueryResult<IEnumerable<TwitterSearchResult>> search = new SearchTwitter()
            {
                SearchText = IoC.Get<IConfigurationService>().TwitterSearchTerm
            }.AsResult();

            yield return Show.Busy(this);
            yield return search;

            int resultCount = search.Response.Count();

            if (resultCount > 0)
            {
                ObservableCollection<TweetViewModel> foundTweets = new ObservableCollection<TweetViewModel>();
                foreach (TwitterSearchResult tweet in search.Response)
                {
                    TweetViewModel tweetVM = new TweetViewModel() { ThumbNail = tweet.ProfileImageUrl, TweetText = tweet.TweetText, UserName = tweet.UserName, DateTime = tweet.DateTime, Source = tweet.Source };
                    foundTweets.Add(tweetVM);
                }

                Tweets = foundTweets;
            }


            yield return Show.NotBusy(this);

        }


     
       
    }
}
