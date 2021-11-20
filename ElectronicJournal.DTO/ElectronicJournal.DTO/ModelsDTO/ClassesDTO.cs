using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class ClassesDTO : EntityDTO
    {
        public TeachersDTO ClassroomTeacher { get; set; }
        public StudentsDTO Headman { get; set; }
        public JournalsDTO Journal { get; set; }
        public string Name { get; set; }
    }
}