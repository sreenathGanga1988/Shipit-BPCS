//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Shipit.DataModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class POPackDetail
    {
        public decimal PoPack_Detail_PK { get; set; }
        public Nullable<decimal> POPackId { get; set; }
        public Nullable<decimal> OurStyleID { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public string SizeName { get; set; }
        public string SIzeCode { get; set; }
        public Nullable<decimal> PoQty { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
    
        public virtual AtcDetail AtcDetail { get; set; }
        public virtual PoPackMaster PoPackMaster { get; set; }
    }
}
