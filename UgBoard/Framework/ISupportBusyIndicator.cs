using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Framework
{
    public interface ISupportBusyIndicator
    {
        bool BusyOn { get; set; }
    }
}
