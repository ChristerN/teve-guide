//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace teve_guide.Models.db
{
    using System;
    using System.Collections.Generic;
    
    public partial class tv_shows
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<System.DateTime> Starttime { get; set; }
        public Nullable<System.DateTime> Endtime { get; set; }
        public string Substance { get; set; }
        public string Category { get; set; }
        public string Channel { get; set; }
    }
}
