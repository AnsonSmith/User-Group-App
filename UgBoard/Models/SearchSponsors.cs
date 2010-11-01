using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Models
{
    public class SearchSponsors: IQuery<IEnumerable<SponsorSearchResult>> 
    {
        public string DirectoryToScan { get; set; }
    }
}