﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Top2000Entities : DbContext
    {
        public Top2000Entities()
            : base("name=Top2000Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Artiest> Artiest { get; set; }
        public virtual DbSet<Lijst> Lijst { get; set; }
        public virtual DbSet<Song> Song { get; set; }
        public virtual DbSet<Top2000Jaar> Top2000Jaar { get; set; }
    
        public virtual ObjectResult<fsspTOP2000DefUnlistedSongs_Result> fsspTOP2000DefUnlistedSongs(Nullable<int> year, Nullable<int> currentyear)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            var currentyearParameter = currentyear.HasValue ?
                new ObjectParameter("Currentyear", currentyear) :
                new ObjectParameter("Currentyear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<fsspTOP2000DefUnlistedSongs_Result>("fsspTOP2000DefUnlistedSongs", yearParameter, currentyearParameter);
        }
    
        public virtual ObjectResult<fsspTOP2000New_Result> fsspTOP2000New(Nullable<int> yEAR, Nullable<int> fROM, Nullable<int> tO)
        {
            var yEARParameter = yEAR.HasValue ?
                new ObjectParameter("YEAR", yEAR) :
                new ObjectParameter("YEAR", typeof(int));
    
            var fROMParameter = fROM.HasValue ?
                new ObjectParameter("FROM", fROM) :
                new ObjectParameter("FROM", typeof(int));
    
            var tOParameter = tO.HasValue ?
                new ObjectParameter("TO", tO) :
                new ObjectParameter("TO", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<fsspTOP2000New_Result>("fsspTOP2000New", yEARParameter, fROMParameter, tOParameter);
        }
    
        public virtual ObjectResult<fsspTOP2000ReEntries_Result> fsspTOP2000ReEntries(Nullable<int> currentTop2000Year)
        {
            var currentTop2000YearParameter = currentTop2000Year.HasValue ?
                new ObjectParameter("CurrentTop2000Year", currentTop2000Year) :
                new ObjectParameter("CurrentTop2000Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<fsspTOP2000ReEntries_Result>("fsspTOP2000ReEntries", currentTop2000YearParameter);
        }
    
        public virtual ObjectResult<fsspTOP2000UnlistedSongs_Result> fsspTOP2000UnlistedSongs(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<fsspTOP2000UnlistedSongs_Result>("fsspTOP2000UnlistedSongs", yearParameter);
        }
    
        public virtual int spImport(string aRTIEST, string tITEL, Nullable<int> jAAR, Nullable<int> pOSITIE, Nullable<int> tOP2000JAAR)
        {
            var aRTIESTParameter = aRTIEST != null ?
                new ObjectParameter("ARTIEST", aRTIEST) :
                new ObjectParameter("ARTIEST", typeof(string));
    
            var tITELParameter = tITEL != null ?
                new ObjectParameter("TITEL", tITEL) :
                new ObjectParameter("TITEL", typeof(string));
    
            var jAARParameter = jAAR.HasValue ?
                new ObjectParameter("JAAR", jAAR) :
                new ObjectParameter("JAAR", typeof(int));
    
            var pOSITIEParameter = pOSITIE.HasValue ?
                new ObjectParameter("POSITIE", pOSITIE) :
                new ObjectParameter("POSITIE", typeof(int));
    
            var tOP2000JAARParameter = tOP2000JAAR.HasValue ?
                new ObjectParameter("TOP2000JAAR", tOP2000JAAR) :
                new ObjectParameter("TOP2000JAAR", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spImport", aRTIESTParameter, tITELParameter, jAARParameter, pOSITIEParameter, tOP2000JAARParameter);
        }
    
        public virtual ObjectResult<fsspTOP2000Year_Result> fsspTOP2000Year(Nullable<int> yEAR, Nullable<int> aMOUNT)
        {
            var yEARParameter = yEAR.HasValue ?
                new ObjectParameter("YEAR", yEAR) :
                new ObjectParameter("YEAR", typeof(int));
    
            var aMOUNTParameter = aMOUNT.HasValue ?
                new ObjectParameter("AMOUNT", aMOUNT) :
                new ObjectParameter("AMOUNT", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<fsspTOP2000Year_Result>("fsspTOP2000Year", yEARParameter, aMOUNTParameter);
        }
    }
}
