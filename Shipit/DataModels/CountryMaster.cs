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
    
    public partial class CountryMaster
    {
        public CountryMaster()
        {
            this.SupplierMasters = new HashSet<SupplierMaster>();
            this.LocationMasters = new HashSet<LocationMaster>();
        }
    
        public decimal CountryID { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
        public string FactoryStores { get; set; }
    
        public virtual ICollection<SupplierMaster> SupplierMasters { get; set; }
        public virtual ICollection<LocationMaster> LocationMasters { get; set; }
    }
}