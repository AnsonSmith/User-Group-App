using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace UgBoard.ViewModels
{
    public class IndividualSponsorViewModel : PropertyChangedBase
    {
        private string logo;

        public string Logo
        {
            get { return logo; }
            set
            {
                logo = value;
                NotifyOfPropertyChange(() => Logo);
            }
        }


        private int height;

        public int Height
        {
            get { return height; }
            set
            {
                height = value;
                NotifyOfPropertyChange(() => Height);
            }
        }


        private int width;

        public int Width
        {
            get { return width; }
            set
            {
                width = value;
                NotifyOfPropertyChange(() => Width);
            }
        }
        

        public IndividualSponsorViewModel()
        {

        }
    }
}
