//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Parrents
    {
        public int Id { get; set; }
        public int FemaleId { get; set; }
        public Nullable<int> FatherId1 { get; set; }
        public Nullable<int> FatherId2 { get; set; }
        public int MotherId { get; set; }
    
        public virtual Females Females { get; set; }
        public virtual Males Males { get; set; }
        public virtual Males Males1 { get; set; }
    }
}