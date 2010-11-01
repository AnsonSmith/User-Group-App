using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using System.Windows;
using System.Reflection;
using System.Windows.Markup;
using System.Windows.Media;

namespace UgBoard.Framework
{
    public class DefaultBusyService:IBusyService
    {


        #region IBusyService Members

        public void MarkAsBusy(ISupportBusyIndicator viewModel)
        {
            viewModel.BusyOn = true;
        }

        public void MarkAsNotBusy(ISupportBusyIndicator viewModel)
        {
            viewModel.BusyOn = false;
        }

        #endregion
    }
}
