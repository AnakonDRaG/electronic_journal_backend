using ElectronicJournal.Domain.Base;
using System;
using System.Collections.Generic;

namespace ElectronicJournal.Domain
{
    public class Lesson : BaseModel
    {
        public DateTime Date { get; set; }
        public int SubjectInJournalId { get; set; }
        public string HomeTask { get; set; }
        public SubjectInJournal SubjectInJournal { get; set; }
        public IList<LessonScore> LessonScores { get; set; }
    }
}