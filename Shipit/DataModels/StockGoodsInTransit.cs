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
    
    public partial class StockGoodsInTransit
    {
        public decimal SGt_PK { get; set; }
        public Nullable<decimal> SInventoryItem_PK { get; set; }
        public Nullable<decimal> TransitQty { get; set; }
        public Nullable<decimal> SDO_PK { get; set; }
    
        public virtual DeliveryOrderStockMaster DeliveryOrderStockMaster { get; set; }
        public virtual StockInventoryMaster StockInventoryMaster { get; set; }
    }
}
