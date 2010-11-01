using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;

namespace UgBoard.Framework.Results
{
    public class BusyResult : IResult
    {
        private readonly ISupportBusyIndicator _busyViewModel;
        private readonly bool _isBusy;

        public BusyResult(bool isBusy, ISupportBusyIndicator busyViewModel)
        {
            _isBusy = isBusy;
            _busyViewModel = busyViewModel;
        }



        #region IResult Members

        public void Execute(ActionExecutionContext context)
        {
            object sourceViewModel = context.Target;

            if (_isBusy)
                IoC.Get<IBusyService>().MarkAsBusy(_busyViewModel);
            else
                IoC.Get<IBusyService>().MarkAsNotBusy(_busyViewModel);

            Completed(this, new ResultCompletionEventArgs());
        }

        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        #endregion
    }
}
