using System.Collections.Generic;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class StudentsDTO: HumansDTO
    {
        public ClassesDTO Class { get; set; }
        public IList<LessonScoresDTO> LessonsScores { get; set; }
    }
}