//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Top2000.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Song
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Song()
        {
            this.Lijst = new HashSet<Lijst>();
        }
    
        public int Songid { get; set; }
        public int Artiestid { get; set; }
        public string Titel { get; set; }
        public Nullable<int> Jaar { get; set; }
        public string Songtekst { get; set; }
    
        public virtual Artiest Artiest { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lijst> Lijst { get; set; }
    }
}
