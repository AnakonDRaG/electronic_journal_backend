using ElectronicJournal.Domain.Base;
using System.Collections.Generic;

namespace ElectronicJournal.Domain
{
    public class Class : BaseModelWithName
    {
        public int ClassroomTeacherId { get; set; }
        public Teacher ClassroomTeacher { get; set; }
        public int HeadmanId { get; set; }
        public Student Headman { get; set; }
        public int CurrentJournalId { get; set; }
        public Journal CurrentJournal { get; set; }
        public IList<Journal> Journals { get; set; }
        public IList<Student> Students { get; set; }
    }
}