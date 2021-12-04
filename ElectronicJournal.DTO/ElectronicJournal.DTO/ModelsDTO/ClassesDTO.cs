using ElectronicJournal.DTO.ModelsDTO.Base;
using System.Collections.Generic;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class ClassesDTO : EntityDTO
    {
        public TeachersDTO ClassroomTeacher { get; set; }
        public StudentsDTO Headman { get; set; }
        public int JournalId{ get; set; }
        public string Name { get; set; }
    }
}