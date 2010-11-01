using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Collections.ObjectModel;
using UgBoard.Models;
using UgBoard.Framework;

namespace UgBoard.ViewModels
{
    public class SwagViewModel:PropertyChangedBase, ISupportBusyIndicator
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
                busyOn = value;
                NotifyOfPropertyChange(() => BusyOn);
            }
        }

        #endregion

        private ObservableCollection<SwagItemViewModel> swagItems;

        public ObservableCollection<SwagItemViewModel> SwagItems
        {
            get
            {
                if (swagItems == null)
                {
                    swagItems = new ObservableCollection<SwagItemViewModel>();
                }
                return swagItems;
            }
            set
            {
                swagItems = value;
                NotifyOfPropertyChange(() => SwagItems);
            }
        }



        public SwagViewModel()
        {
            Coroutine.Execute(LoadSwag().GetEnumerator());
        }




        private IEnumerable<IResult> LoadSwag()
        {


            QueryResult<IEnumerable<SwagItemResult>> search = new SearchSwag()
            {
                SwagFileName = IoC.Get<IConfigurationService>().SwagFilePath
            }.AsResult();

            yield return Show.Busy(this);
            yield return search;

            int resultCount = search.Response.Count();

            if (resultCount > 0)
            {
                ObservableCollection<SwagItemViewModel> foundItems = new ObservableCollection<SwagItemViewModel>();
                foreach (SwagItemResult res in search.Response)
                {
                    SwagItemViewModel swagVM = new SwagItemViewModel() { Company = res.Company, Description = res.Description, ItemValue = res.ItemValue, Quantity = res.Qty, Title = res.Title };
                    foundItems.Add(swagVM);
                }

                SwagItems = foundItems;
            }


            yield return Show.NotBusy(this);

        }


    }
}
