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
    
    public partial class COIN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COIN()
        {
            this.COIN_VALUE = new ObservableCollection<COIN_VALUE>();
            this.COIN_FOLLOW = new ObservableCollection<COIN_FOLLOW>();
            this.POSTs = new ObservableCollection<POST>();
            this.NOTIFICATIONs = new ObservableCollection<NOTIFICATION>();
            this.WALLETs = new ObservableCollection<WALLET>();
        }
    
        public int COIN_ID { get; set; }
        public string COIN_NAME { get; set; }
        public byte[] IMAGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<COIN_VALUE> COIN_VALUE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<COIN_FOLLOW> COIN_FOLLOW { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<POST> POSTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<NOTIFICATION> NOTIFICATIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<WALLET> WALLETs { get; set; }
    }
}
