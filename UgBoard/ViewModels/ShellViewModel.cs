namespace UgBoard.ViewModels
{
    using Caliburn.Micro;
    using System.Windows.Threading;
    using System;
    using UgBoard.Framework;

    public class ShellViewModel : PropertyChangedBase
    {

        private bool isInScrollMode = true;

        private TwitterFeedViewModel twitterFeed;
        public TwitterFeedViewModel TwitterFeed
        {
            get
            {
                if (twitterFeed == null)
                {
                    twitterFeed = new TwitterFeedViewModel();
                    NotifyOfPropertyChange(() => TwitterFeed);
                }
                return twitterFeed;
            }
        }

        private RaffleViewModel raffle = new RaffleViewModel();
        private SponsorsViewModel sponsors = new SponsorsViewModel();
        private SwagViewModel swag = new SwagViewModel();

      
        private PropertyChangedBase leftColumn;

        public PropertyChangedBase LeftColumn
        {
            get
            {
                return leftColumn;
            }
            set
            {
                leftColumn = value;
                NotifyOfPropertyChange(() => LeftColumn);
            }
        }



       
        // Timer used for automatic tweet updates
        private DispatcherTimer leftColumnScrollTimer = new DispatcherTimer();


       

        public ShellViewModel()
        {
  
            LeftColumn = sponsors;

            leftColumnScrollTimer.Interval = new TimeSpan(0, IoC.Get<IConfigurationService>().ScrollTimerInterval, 0);
            leftColumnScrollTimer.Tick += new EventHandler(leftColumnScrollTimer_Tick);
            leftColumnScrollTimer.Start();

            
        }

        void leftColumnScrollTimer_Tick(object sender, EventArgs e)
        {
            //Swap the LeftColumn Property
            var leftCol = LeftColumn as SponsorsViewModel;
            if (leftCol != null)
            {
                LeftColumn = swag;
            }
            else
            {
                LeftColumn = sponsors;
            }
        }



        public void ScrollMode()
        {
            //set the left col back to sponsors vm
            LeftColumn = sponsors;
            
            //Start the timer running again
            leftColumnScrollTimer.Start();


            isInScrollMode = true;
            NotifyOfPropertyChange(() => CanRaffleMode);
            NotifyOfPropertyChange(() => CanScrollMode);


        }

        public bool CanScrollMode
        {
            get { return !isInScrollMode; }
        }

        public void RaffleMode()
        {
            //stop the timer for scrolling
            leftColumnScrollTimer.Stop();

            //set the left Column to Raffle vm
            LeftColumn = raffle;

            //notify we are not in scroll mode anymore
            isInScrollMode = false;
            NotifyOfPropertyChange(() => CanRaffleMode);
            NotifyOfPropertyChange(() => CanScrollMode);
        }

        public bool CanRaffleMode
        {
            get { return isInScrollMode; }
        }

    }
}

