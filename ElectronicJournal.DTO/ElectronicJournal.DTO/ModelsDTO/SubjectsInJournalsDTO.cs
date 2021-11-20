using ElectronicJournal.DTO.ModelsDTO.Base;
using System.Collections.Generic;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class SubjectsInJournalsDTO: EntityDTO
    {
        public TeachersDTO Teacher { get; set; }
        public SubjectsDTO Subject { get; set; }
        public JournalsDTO Journal { get; set; }
        public IList<LessonsDTO> Lessons { get; set; }
    }
}