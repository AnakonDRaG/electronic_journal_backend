using ElectronicJournal.Domain.Base;
using System.Collections.Generic;

namespace ElectronicJournal.Domain
{
    public class Teacher : BaseModel
    {
        public int CurrentClassId { get; set; }
        public Class CurrentClass { get; set; }
        public int HumanId { get; set; }
        public Human Human { get; set; }
        public IList<SubjectInJournal> SubjectsInJournal { get; set; }
    }
}