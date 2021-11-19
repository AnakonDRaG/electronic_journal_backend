using ElectronicJournal.Domain.Base;
using System.Collections.Generic;

namespace ElectronicJournal.Domain
{
    public class SubjectInJournal : BaseModel
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int JournalId { get; set; }
        public Journal Journal { get; set; }
        public IList<Lesson> Lessons { get; set; }
    }
}