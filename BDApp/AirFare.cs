//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BDApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class AirFare
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AirFare()
        {
            this.Flight_Schedule = new HashSet<Flight_Schedule>();
        }
    
        public int AfID { get; set; }
        public int Route { get; set; }
        public Nullable<double> Fare { get; set; }
        public Nullable<double> FSC { get; set; }
    
        public virtual Route Route1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Flight_Schedule> Flight_Schedule { get; set; }
    }
}