//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoinWatch
{
    using System;
    using System.Collections.ObjectModel;
    
    public partial class NOTIFIED_USER
    {
        public int NOTIFIED_ID { get; set; }
        public int USER_ID { get; set; }
        public string NOTIFICATION_SEEN { get; set; }
    
        public virtual NOTIFICATION NOTIFICATION { get; set; }
        public virtual USERT USERT { get; set; }
        public virtual NOTIFICATION NOTIFICATION1 { get; set; }
        public virtual USERT USERT1 { get; set; }
    }
}
