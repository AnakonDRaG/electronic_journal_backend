using System;
using System.Collections.Generic;
using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class JournalsDTO : EntityDTO
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ClassesDTO Class { get; set; }
        public IList<SubjectsInJournalsDTO> SubjectsInJournal { get; set; }
    }
}