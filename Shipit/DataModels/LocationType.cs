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
    
    public partial class LocationType
    {
        public LocationType()
        {
            this.LocationMasters = new HashSet<LocationMaster>();
        }
    
        public decimal LocationType_Pk { get; set; }
        public string LocationType1 { get; set; }
        public string TypeFor { get; set; }
    
        public virtual ICollection<LocationMaster> LocationMasters { get; set; }
    }
}