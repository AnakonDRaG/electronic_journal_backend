using System;
using System.Collections.Generic;
using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class LessonsDTO : EntityDTO
    {
        public DateTime Date { get; set; }
        public  SubjectsDTO Subject { get; set; }
        public string HomeTask { get; set; }
        public IList<LessonScoresDTO> LessonScores { get; set; }
    }
}