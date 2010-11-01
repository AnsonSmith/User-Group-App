using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UgBoard.Framework.Results;

namespace UgBoard.Framework
{
    public static class Show
    {

        public static BusyResult Busy(ISupportBusyIndicator busyViewModel)
        {
            return new BusyResult(true, busyViewModel);
        }


        public static BusyResult NotBusy(ISupportBusyIndicator busyViewModel)
        {
            return new BusyResult(false, busyViewModel);
        }

    }
}
