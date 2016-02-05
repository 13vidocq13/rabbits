using System;

namespace BusonessLogic.Help.Types
{
    public class ChildBirthParrents
    {
        public int Id { get; set; }
        public int FemaleId { get; set; }
        public int MaleId1 { get; set; }
        public int? MaleId2 { get; set; }
        public int ResultId { get; set; }
        public int CageNumber { get; set; }
        public DateTime StartDate1 { get; set; }
        public DateTime? StartDate2 { get; set; }
        public DateTime ExpectBirthday { get; set; }
        public DateTime Birthday { get; set; }
        public string CageName { get; set; }
        public string Notes { get; set; }
        public string FemaleName { get; set; }
        public string MaleName1 { get; set; }
        public string MaleName2 { get; set; }
        public string ResultName { get; set; }
    }
}
