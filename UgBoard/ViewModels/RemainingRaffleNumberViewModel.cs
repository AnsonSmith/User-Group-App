using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace UgBoard.ViewModels
{
    public class RemainingRaffleNumberViewModel:PropertyChangedBase
    {
        private int number;

        public int Number
        {
            get { return number; }
            set
            {
                number = value;
                NotifyOfPropertyChange(() => Number);
            }
        }
        
    }
}
