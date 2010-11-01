using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace UgBoard.ViewModels
{
    public class SwagItemViewModel:PropertyChangedBase
    {
        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyOfPropertyChange(() => Title);
            }
        }

        
        private string description;

        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                NotifyOfPropertyChange(() => Description);
            }
        }


        private string quantity;

        public string Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                NotifyOfPropertyChange(() => Quantity);
            }
        }


        private string itemValue;

        public string ItemValue
        {
            get { return itemValue; }
            set
            {
                itemValue = value;
                NotifyOfPropertyChange(() => ItemValue);
            }
        }

        private string company;

        public string Company
        {
            get { return company; }
            set
            {
                company = value;
                NotifyOfPropertyChange(() => Company);
            }
        }

        
    }
}
