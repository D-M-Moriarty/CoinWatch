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
    
    public partial class COIN_VALUE
    {
        public int COIN_ID { get; set; }
        public System.DateTime DATETIME { get; set; }
        public Nullable<decimal> COIN_VALUE1 { get; set; }
    
        public virtual COIN COIN { get; set; }
    }
}