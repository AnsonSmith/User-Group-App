using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UgBoard.Models
{
    public class SearchSwag:IQuery<IEnumerable<SwagItemResult>>
    {
        public string SwagFileName { get; set; }
    }
}
