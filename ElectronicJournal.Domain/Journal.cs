using ElectronicJournal.Domain.Base;
using System;
using System.Collections.Generic;

namespace ElectronicJournal.Domain
{
    public class Journal : BaseModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Class Class { get; set; }
        public IList<SubjectInJournal> SubjectsInJournal { get; set; }
    }
}