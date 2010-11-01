using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using UgBoard.Framework;
using UgBoard.Models;

namespace UgBoard.ViewModels
{
    public class SponsorsViewModel : PropertyChangedBase, ISupportBusyIndicator
    {

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
                busyOn = BusyOn;
                NotifyOfPropertyChange(() => BusyOn);
            }
        }

        #endregion

        private ObservableCollection<IndividualSponsorViewModel> sponsorList;

        public ObservableCollection<IndividualSponsorViewModel> SponsorList
        {
            get
            {
                if (sponsorList == null)
                {
                    sponsorList = new ObservableCollection<IndividualSponsorViewModel>();
                }
                return sponsorList;
            }
            set
            {
                sponsorList = value;
                NotifyOfPropertyChange(() => SponsorList);
            }
        }

        public SponsorsViewModel()
        {
           
            Coroutine.Execute(LoadSponsors().GetEnumerator());
        }


        private IEnumerable<IResult> LoadSponsors()
        {
            QueryResult<IEnumerable<SponsorSearchResult>> search = new SearchSponsors()
            {
                DirectoryToScan = IoC.Get<IConfigurationService>().LogoImagesPath
            }.AsResult();

            yield return Show.Busy(this);

            yield return search;

            if (search.Response.Count() > 0)
            {
                ObservableCollection<IndividualSponsorViewModel> sponsors = new ObservableCollection<IndividualSponsorViewModel>();

                foreach (SponsorSearchResult res in search.Response)
                {
                    IndividualSponsorViewModel sponsorVM = new IndividualSponsorViewModel() { Height = res.Height, Width = res.Width, Logo = res.Path };
                    sponsors.Add(sponsorVM);
                }

                SponsorList = sponsors;
            }

            yield return Show.NotBusy(this);
        }

    }
}
