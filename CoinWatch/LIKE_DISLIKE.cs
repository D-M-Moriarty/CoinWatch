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
    
    public partial class LIKE_DISLIKE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LIKE_DISLIKE()
        {
            this.NOTIFICATIONs = new ObservableCollection<NOTIFICATION>();
        }
    
        public int LIKE_ID { get; set; }
        public Nullable<int> USER_ID { get; set; }
        public Nullable<int> LIKED_OBJECT_TYPE_ID { get; set; }
        public Nullable<int> COMMENT_ID { get; set; }
        public Nullable<int> POST_ID { get; set; }
        public string TYPE { get; set; }
    
        public virtual COMMENT COMMENT { get; set; }
        public virtual LIKED_OBJECT_TYPE LIKED_OBJECT_TYPE { get; set; }
        public virtual POST POST { get; set; }
        public virtual USERT USERT { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ObservableCollection<NOTIFICATION> NOTIFICATIONs { get; set; }
    }
}
