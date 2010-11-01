using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace UgBoard.Framework
{
    class DefaultConfigurationService:IConfigurationService
    {
        #region IConfigurationService Members

        public int ScrollTimerInterval {get; protected set;}

        public int TwitterRefreshInterval { get; protected set; }

        public string LogoImagesPath { get; protected set; }

        public string SwagFilePath { get; protected set; }

        public string TwitterSearchTerm { get; protected set; }

        #endregion



        public DefaultConfigurationService()
        {
            ScrollTimerInterval = Int16.Parse(ConfigurationManager.AppSettings["SrollTimerInterval"]);
            TwitterRefreshInterval = Int16.Parse(ConfigurationManager.AppSettings["TwitterRefreshInterval"]);
            TwitterSearchTerm = ConfigurationManager.AppSettings["TwitterSearchTerm"];
            LogoImagesPath = ConfigurationManager.AppSettings["LogoImagesPath"];
            SwagFilePath = ConfigurationManager.AppSettings["SwagFilePath"];

        }


        
    }
}
