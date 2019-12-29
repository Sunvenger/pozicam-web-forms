//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pozicam_web_forms.Appcode.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ManagmentTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<System.DateTime> DeadlineDate { get; set; }
        public Nullable<int> Priority { get; set; }
        public Nullable<int> CreatorUserId { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<decimal> Rent { get; set; }
        public Nullable<int> ManagmentStateId { get; set; }
    
        public virtual ManagmentState ManagmentState { get; set; }
        public virtual User User { get; set; }
    }
}
