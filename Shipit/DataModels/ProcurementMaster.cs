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
    
    public partial class ProcurementMaster
    {
        public ProcurementMaster()
        {
            this.ProcurementDetails = new HashSet<ProcurementDetail>();
        }
    
        public decimal PO_Pk { get; set; }
        public string PONum { get; set; }
        public Nullable<decimal> AtcId { get; set; }
        public Nullable<decimal> Supplier_Pk { get; set; }
        public Nullable<decimal> DeliveryTerms_Pk { get; set; }
        public Nullable<decimal> DeliveryMethod_Pk { get; set; }
        public Nullable<decimal> PaymentTermID { get; set; }
        public Nullable<decimal> PaymentModeID { get; set; }
        public Nullable<double> PO_value { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public Nullable<decimal> CurrencyID { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public string Remark { get; set; }
        public string IsApproved { get; set; }
        public string IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public string ApprovedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public Nullable<System.DateTime> Approveddate { get; set; }
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        public string POType { get; set; }
    
        public virtual ICollection<ProcurementDetail> ProcurementDetails { get; set; }
    }
}
