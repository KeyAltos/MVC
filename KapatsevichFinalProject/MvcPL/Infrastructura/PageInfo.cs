using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcPL.Infrastructura
{
    public class PageInfo
    {
        public int CurrentPageNumber { get; set; }
        public int PageNumber { get; internal set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; } 
        public int TotalPages 
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}