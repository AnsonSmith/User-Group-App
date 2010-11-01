using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Models
{
    public interface ITwitterService
    {
        IEnumerable<TwitterSearchResult> Search(string searchText);
    }
}
