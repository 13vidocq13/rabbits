using System;
using System.ComponentModel.DataAnnotations;

namespace BusonessLogic.Help.Types
{
    public class FemaleParrentsMale
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string FemaleName { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        [Range(typeof(DateTime), "1-Jan-1940", "1-Jan-2100")]
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
