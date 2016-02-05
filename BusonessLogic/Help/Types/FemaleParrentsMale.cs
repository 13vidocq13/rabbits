using System;
using System.ComponentModel.DataAnnotations;

namespace BusonessLogic.Help.Types
{
    public class FemaleParrentsMale
    {
        public int Id { get; set; }
        public string FemaleName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }
        public int? CageId { get; set; }
        public string CageName { get; set; }
        public int? FatherId1 { get; set; }
        public string FatherName1 { get; set; }
        public int? FatherId2 { get; set; }
        public string FatherName2 { get; set; }
        public int MotherId { get; set; }
        public string MotherName { get; set; }
    }
}
