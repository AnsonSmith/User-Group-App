using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace UgBoard.ViewModels
{
    public class TweetViewModel : PropertyChangedBase
    {

        public TweetViewModel()
        {
        }

        private string tweetText;

        public string TweetText
        {
            get { return tweetText; }
            set
            {
                tweetText = value;
                NotifyOfPropertyChange(() => TweetText);
            }
        }

        private string thumbNail;

        public string ThumbNail
        {
            get { return thumbNail; }
            set
            {
                thumbNail = value;
                NotifyOfPropertyChange(() => ThumbNail);
            }
        }


        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        private string dateTime;

        public string DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                NotifyOfPropertyChange(() => DateTime);
            }
        }


        private string source;

        public string Source
        {
            get { return source; }
            set
            {
                source = value;
                NotifyOfPropertyChange(() => Source);
            }
        }
        
    }
}
