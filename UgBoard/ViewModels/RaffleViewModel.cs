using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Collections.ObjectModel;

namespace UgBoard.ViewModels
{
    public class RaffleViewModel:PropertyChangedBase
    {
        private RaffleWinnerViewModel lastWinner;

        public RaffleWinnerViewModel LastWinner
        {
            get { return lastWinner; }
            set
            {
                lastWinner = value;
                NotifyOfPropertyChange(() => LastWinner);
            }
        }

        private ObservableCollection<RemainingRaffleNumberViewModel> remainingNumbers;


        public ObservableCollection<RemainingRaffleNumberViewModel> RemainingNumbers
        {
            get
            {
                if (remainingNumbers == null)
                {
                    remainingNumbers = new ObservableCollection<RemainingRaffleNumberViewModel>();
                }
                return remainingNumbers;
            }
            set
            {
                remainingNumbers = value;
                NotifyOfPropertyChange(() => RemainingNumbers);
                NotifyOfPropertyChange(() => CanDrawNumber);
            }
        }

        private int numAttendees;

        public int NumAttendees
        {
            get { return numAttendees; }
            set
            {
                numAttendees = value;
                NotifyOfPropertyChange(() => NumAttendees);
                NotifyOfPropertyChange(() => CanSaveSetup);
            }
        }
        

        private bool inSetupMode;

        public bool ShowSetupModeButton
        {
            get { return !inSetupMode; }
            set
            {
                inSetupMode = !value;
                NotifyOfPropertyChange(() => ShowSetupModeButton);
                NotifyOfPropertyChange(() => ShowSetupModeInputs);
            }
        }

        public bool ShowSetupModeInputs
        {
            get { return inSetupMode; }
            set
            {
                inSetupMode = value;
                NotifyOfPropertyChange(() => ShowSetupModeButton);
                NotifyOfPropertyChange(() => ShowSetupModeInputs);
            }
        }



        public RaffleViewModel()
        {
            //RaffleWinnerViewModel winner = new RaffleWinnerViewModel() { Number = 23 };
            //LastWinner = winner;


            //RemainingRaffleNumberViewModel num1 = new RemainingRaffleNumberViewModel() { Number = 1 };
            //RemainingRaffleNumberViewModel num2 = new RemainingRaffleNumberViewModel() { Number = 2 };
            //RemainingRaffleNumberViewModel num3 = new RemainingRaffleNumberViewModel() { Number = 3 };
            //RemainingRaffleNumberViewModel num4 = new RemainingRaffleNumberViewModel() { Number = 4 };
            //RemainingRaffleNumberViewModel num5 = new RemainingRaffleNumberViewModel() { Number = 5 };
            //RemainingRaffleNumberViewModel num6 = new RemainingRaffleNumberViewModel() { Number = 6 };
            //RemainingRaffleNumberViewModel num7 = new RemainingRaffleNumberViewModel() { Number = 7 };
            //RemainingRaffleNumberViewModel num8 = new RemainingRaffleNumberViewModel() { Number = 8 };
            //RemainingRaffleNumberViewModel num9 = new RemainingRaffleNumberViewModel() { Number = 9 };
            //RemainingRaffleNumberViewModel num10 = new RemainingRaffleNumberViewModel() { Number = 10 };

            //RemainingNumbers.Add(num1);
            //RemainingNumbers.Add(num2);
            //RemainingNumbers.Add(num3);
            //RemainingNumbers.Add(num4);
            //RemainingNumbers.Add(num5);
            //RemainingNumbers.Add(num6);
            //RemainingNumbers.Add(num7);
            //RemainingNumbers.Add(num8);
            //RemainingNumbers.Add(num9);
            //RemainingNumbers.Add(num10);
            //NotifyOfPropertyChange(() => RemainingNumbers);
        }


        public void SetupMode()
        {
            ShowSetupModeInputs = true;

        }

        public void SaveSetup()
        {
            ShowSetupModeButton = true;

            //create a new ObservableCollection of RemainingRaffleNumberViewModels for the specified # of Attendees
            ObservableCollection<RemainingRaffleNumberViewModel> raffleNumbers = new ObservableCollection<RemainingRaffleNumberViewModel>();
            for (int i = 1; i <= NumAttendees; i++)
            {
                RemainingRaffleNumberViewModel vm = new RemainingRaffleNumberViewModel() { Number = i };
                raffleNumbers.Add(vm);
            }

            RemainingNumbers = raffleNumbers;
        }



        public bool CanSaveSetup
        {
            get { return NumAttendees > 0; }
        }

        public void DrawNumber()
        {
            //get a random number from the remaining numbers 
            Random rndm = new Random(DateTime.Now.Millisecond);
            int i = rndm.Next(0, RemainingNumbers.Count);
            RemainingRaffleNumberViewModel vm = RemainingNumbers[i];
            RaffleWinnerViewModel winnerVm = new RaffleWinnerViewModel() { Number = vm.Number };
            RemainingNumbers.RemoveAt(i);
            LastWinner = winnerVm;
            NotifyOfPropertyChange(() => CanDrawNumber);

        }

        public bool CanDrawNumber
        {
            get { return RemainingNumbers.Count > 0; }
        }

    }
}
