//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication11.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_clubs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_clubs()
        {
            this.tbl_students = new HashSet<tbl_students>();
        }
    
        public byte CLUBID { get; set; }
        public string CLUBNAME { get; set; }
        public Nullable<short> CLUBQUOTA { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_students> tbl_students { get; set; }
    }
}