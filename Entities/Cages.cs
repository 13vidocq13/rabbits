//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Entities
{
    using System.Collections.Generic;

    public partial class Cages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cages()
        {
            this.Females = new HashSet<Females>();
        }
    
        public int Id { get; set; }
        [Required(ErrorMessage = "���� �� ����� ���� ������")]
        [StringLength(3, ErrorMessage="�������� ������ �� ����� ��������� ����� 3� ��������")]
        public string Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Females> Females { get; set; }
    }
}
