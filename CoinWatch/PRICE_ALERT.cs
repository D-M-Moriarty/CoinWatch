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
    
    public partial class PRICE_ALERT
    {
        public int USER_ID { get; set; }
        public int COIN_ID { get; set; }
        public decimal PRICE { get; set; }
        public string IS_GREATER_THAN { get; set; }
    
        public virtual COIN_FOLLOW COIN_FOLLOW { get; set; }
    }
}