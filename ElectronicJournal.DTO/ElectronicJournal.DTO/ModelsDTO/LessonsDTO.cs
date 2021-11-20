using System;
using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class LessonsDTO : EntityDTO
    {
        public DateTime Date { get; set; }
        public  SubjectsDTO Subject { get; set; }
    }
}