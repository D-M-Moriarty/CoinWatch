﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CoinWatchEntities : DbContext
    {
        public CoinWatchEntities()
            : base("name=CoinWatchEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<COIN> COINs { get; set; }
        public virtual DbSet<COIN_FOLLOW> COIN_FOLLOW { get; set; }
        public virtual DbSet<COIN_VALUE> COIN_VALUE { get; set; }
        public virtual DbSet<COMMENT> COMMENTs { get; set; }
        public virtual DbSet<INVALID_LOGIN> INVALID_LOGIN { get; set; }
        public virtual DbSet<LIKE_DISLIKE> LIKE_DISLIKE { get; set; }
        public virtual DbSet<LIKED_OBJECT_TYPE> LIKED_OBJECT_TYPE { get; set; }
        public virtual DbSet<NOTIFICATION> NOTIFICATIONs { get; set; }
        public virtual DbSet<NOTIFICATION_TYPE> NOTIFICATION_TYPE { get; set; }
        public virtual DbSet<NOTIFIED_USER> NOTIFIED_USER { get; set; }
        public virtual DbSet<POST> POSTs { get; set; }
        public virtual DbSet<PRICE_ALERT> PRICE_ALERT { get; set; }
        public virtual DbSet<USERT> USERTs { get; set; }
        public virtual DbSet<VALID_LOGIN> VALID_LOGIN { get; set; }
        public virtual DbSet<WALLET> WALLETs { get; set; }
        public virtual DbSet<WALLET_LIST> WALLET_LIST { get; set; }
        public virtual DbSet<COINS_FOLLOWED_PRICES> COINS_FOLLOWED_PRICES { get; set; }
        public virtual DbSet<FOLLOWING_POSTS> FOLLOWING_POSTS { get; set; }
        public virtual DbSet<USER_COMMENT_LIKES> USER_COMMENT_LIKES { get; set; }
    
        public virtual int LOGINUSER(Nullable<decimal> v_USER_ID, string v_USERNAME, string v_PASSWORD)
        {
            var v_USER_IDParameter = v_USER_ID.HasValue ?
                new ObjectParameter("V_USER_ID", v_USER_ID) :
                new ObjectParameter("V_USER_ID", typeof(decimal));
    
            var v_USERNAMEParameter = v_USERNAME != null ?
                new ObjectParameter("V_USERNAME", v_USERNAME) :
                new ObjectParameter("V_USERNAME", typeof(string));
    
            var v_PASSWORDParameter = v_PASSWORD != null ?
                new ObjectParameter("V_PASSWORD", v_PASSWORD) :
                new ObjectParameter("V_PASSWORD", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("LOGINUSER", v_USER_IDParameter, v_USERNAMEParameter, v_PASSWORDParameter);
        }
    }
}
