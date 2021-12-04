using ElectronicJournal.Domain.Base;
using System.Collections.Generic;

namespace ElectronicJournal.Domain
{
    public class Student : BaseModel
    {
        public int? ClassId { get; set; }
        public Class Class { get; set; }
        public int HumanId { get; set; }
        public Human Human { get; set; }
        public IList<LessonScore> LessonsScores { get; set; } = new List<LessonScore>();
    }
}