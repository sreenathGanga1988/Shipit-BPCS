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
    
    public partial class SupplierInvoiceMaster
    {
        public SupplierInvoiceMaster()
        {
            this.SupplierInvoiceDetails = new HashSet<SupplierInvoiceDetail>();
        }
    
        public decimal SupplierInvoice_PK { get; set; }
        public string SupplierInvoiceNum { get; set; }
        public Nullable<decimal> Location_PK { get; set; }
        public string AddedBy { get; set; }
        public Nullable<System.DateTime> AddedDate { get; set; }
        public Nullable<decimal> Currency_PK { get; set; }
        public Nullable<decimal> Supplier_Pk { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<System.DateTime> AccountDate { get; set; }
        public string IsAdvance { get; set; }
        public string IsPosted { get; set; }
        public string SupInvnum { get; set; }
    
        public virtual ICollection<SupplierInvoiceDetail> SupplierInvoiceDetails { get; set; }
        public virtual SupplierMaster SupplierMaster { get; set; }
    }
}