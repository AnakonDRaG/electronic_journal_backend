using ElectronicJournal.DTO.ModelsDTO.Base;
using System.Collections.Generic;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class ClassesDTO : EntityDTO
    {
        public HumansDTO ClassroomTeacher { get; set; }
        public HumansDTO Headman { get; set; }
        public int JournalId{ get; set; }
        public string Name { get; set; }
    }
}
