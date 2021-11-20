using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class LessonScoresDTO : EntityDTO
    {
        public int Score { get; set; }
        public LessonsDTO Lesson { get; set; }
        public StudentsDTO Student { get; set; }
    }
}