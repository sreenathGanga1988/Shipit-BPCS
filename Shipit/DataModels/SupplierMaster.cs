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
    
    public partial class SupplierMaster
    {
        public SupplierMaster()
        {
            this.DocMasters = new HashSet<DocMaster>();
            this.LCMasters = new HashSet<LCMaster>();
            this.RecieptMasters = new HashSet<RecieptMaster>();
            this.StockPOMasters = new HashSet<StockPOMaster>();
            this.StockRecieptMasters = new HashSet<StockRecieptMaster>();
            this.SupplierInvoiceMasters = new HashSet<SupplierInvoiceMaster>();
            this.SupplierStockInvoiceMasters = new HashSet<SupplierStockInvoiceMaster>();
        }
    
        public decimal Supplier_PK { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPrefix { get; set; }
        public string SupplierAddress { get; set; }
        public string SupplierType { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string ContactPerson { get; set; }
        public Nullable<decimal> CurrencyID { get; set; }
        public Nullable<decimal> CountryID { get; set; }
        public Nullable<decimal> PaymentModeID { get; set; }
        public Nullable<decimal> PaymentTermID { get; set; }
        public string IsActive { get; set; }
        public Nullable<decimal> partner_id { get; set; }
        public string IsPogiven { get; set; }
    
        public virtual CountryMaster CountryMaster { get; set; }
        public virtual CurrencyMaster CurrencyMaster { get; set; }
        public virtual ICollection<DocMaster> DocMasters { get; set; }
        public virtual ICollection<LCMaster> LCMasters { get; set; }
        public virtual ICollection<RecieptMaster> RecieptMasters { get; set; }
        public virtual ICollection<StockPOMaster> StockPOMasters { get; set; }
        public virtual ICollection<StockRecieptMaster> StockRecieptMasters { get; set; }
        public virtual ICollection<SupplierInvoiceMaster> SupplierInvoiceMasters { get; set; }
        public virtual ICollection<SupplierStockInvoiceMaster> SupplierStockInvoiceMasters { get; set; }
    }
}
