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
    
    public partial class DeliveryOrderDetail
    {
        public DeliveryOrderDetail()
        {
            this.CutOrderDOes = new HashSet<CutOrderDO>();
            this.DeliveryReceiptDetails = new HashSet<DeliveryReceiptDetail>();
        }
    
        public decimal DODet_PK { get; set; }
        public Nullable<decimal> DO_PK { get; set; }
        public Nullable<decimal> InventoryItem_PK { get; set; }
        public Nullable<decimal> DeliveryQty { get; set; }
        public string Remark { get; set; }
    
        public virtual ICollection<CutOrderDO> CutOrderDOes { get; set; }
        public virtual DeliveryOrderMaster DeliveryOrderMaster { get; set; }
        public virtual InventoryMaster InventoryMaster { get; set; }
        public virtual ICollection<DeliveryReceiptDetail> DeliveryReceiptDetails { get; set; }
    }
}
