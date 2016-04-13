using System;
using System.ComponentModel.DataAnnotations;

namespace Contract
{
    public class FemaleParrentsMale
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string FemaleName { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        //[Range(typeof(DateTime), "2000-1-1", "2100-1-1")]
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
