//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Term
    {
        public Term()
        {
            this.Contains = new HashSet<Contain>();
        }
    
        public int ID { get; set; }
        public string value { get; set; }
    
        public virtual ICollection<Contain> Contains { get; set; }
    }
}