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
    
    public partial class EmailReminder
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DestMailAddress { get; set; }
        public string SourceMailAddress { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Nullable<System.DateTime> TriggerTime { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<bool> IsSent { get; set; }
    }
}