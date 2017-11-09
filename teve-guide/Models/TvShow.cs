using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace teve_guide.Models
{
    public class TvShow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Starttime { get; set; }
        public DateTime Endtime { get; set; }
        public string Substance { get; set; }
        public string Category { get; set; }
        public string Channel { get; set; }
    }

    //public class ChannelList
    //{
    //    public List<TvShow> channel { get; set; }
    //}
}