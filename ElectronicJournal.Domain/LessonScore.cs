using ElectronicJournal.Domain.Base;

namespace ElectronicJournal.Domain
{
    public class LessonScore : BaseModel
    {
        public int Score { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}