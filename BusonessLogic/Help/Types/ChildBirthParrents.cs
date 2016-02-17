using System;
using System.ComponentModel.DataAnnotations;

namespace BusonessLogic.Help.Types
{
    public class ChildBirthParrents
    {
        public int Id { get; set; }
        public int FemaleId { get; set; }
        public int MaleId1 { get; set; }
        public int? MaleId2 { get; set; }
        public int ResultId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public DateTime StartDate1 { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public DateTime? StartDate2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public DateTime ExpectBirthday { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Поле не может быть пустым")]
        public string CageName { get; set; }
        public string Notes { get; set; }
        public string FemaleName { get; set; }
        public string MaleName1 { get; set; }
        public string MaleName2 { get; set; }
        public string ResultName { get; set; }
    }
}
