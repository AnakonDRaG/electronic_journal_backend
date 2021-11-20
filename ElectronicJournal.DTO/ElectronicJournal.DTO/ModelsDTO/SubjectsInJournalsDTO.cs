using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class SubjectsInJournalsDTO: EntityDTO
    {
        public TeachersDTO Teacher { get; set; }
        public SubjectsDTO Subject { get; set; }
        public JournalsDTO Journal { get; set; }
    }
}