using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Framework
{
    public interface IConfigurationService
    {
        int ScrollTimerInterval { get; }
        int TwitterRefreshInterval { get; }
        string LogoImagesPath { get;  }
        string SwagFilePath { get;}
        string TwitterSearchTerm { get; }
    }
}
