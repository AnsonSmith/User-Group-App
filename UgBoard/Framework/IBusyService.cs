using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Framework
{
    public interface IBusyService
    {
        void MarkAsBusy(ISupportBusyIndicator viewModel);
        void MarkAsNotBusy(ISupportBusyIndicator viewModel);
    }
}
