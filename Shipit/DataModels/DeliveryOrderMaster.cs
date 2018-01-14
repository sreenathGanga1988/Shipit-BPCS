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
    
    public partial class DeliveryOrderMaster
    {
        public DeliveryOrderMaster()
        {
            this.DeliveryOrderDetails = new HashSet<DeliveryOrderDetail>();
            this.DeliveryReceiptMasters = new HashSet<DeliveryReceiptMaster>();
            this.GoodsInTransits = new HashSet<GoodsInTransit>();
        }
    
        public decimal DO_PK { get; set; }
        public string DONum { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public Nullable<decimal> FromLocation_PK { get; set; }
        public Nullable<decimal> ToLocation_PK { get; set; }
        public Nullable<System.DateTime> DODate { get; set; }
        public string ContainerNumber { get; set; }
        public string BoeNum { get; set; }
        public Nullable<decimal> Deliverymethod_Pk { get; set; }
        public Nullable<decimal> AtcID { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string DoType { get; set; }
    
        public virtual AtcMaster AtcMaster { get; set; }
        public virtual DeliveryMethodMaster DeliveryMethodMaster { get; set; }
        public virtual ICollection<DeliveryOrderDetail> DeliveryOrderDetails { get; set; }
        public virtual DeliveryOrderMaster DeliveryOrderMaster1 { get; set; }
        public virtual DeliveryOrderMaster DeliveryOrderMaster2 { get; set; }
        public virtual LocationMaster LocationMaster { get; set; }
        public virtual LocationMaster LocationMaster1 { get; set; }
        public virtual ICollection<DeliveryReceiptMaster> DeliveryReceiptMasters { get; set; }
        public virtual ICollection<GoodsInTransit> GoodsInTransits { get; set; }
    }
}
