using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Models
{
    public class SearchTwitter:IQuery<IEnumerable<TwitterSearchResult>>
    {
        public string SearchText { get; set; }
    }
}
