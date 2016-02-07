using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructura
{
    public class PanginationViewModel<T>
    {
        public IEnumerable<T> ListOfItems { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}