using ElectronicJournal.Domain.Base;
using System.Collections.Generic;

namespace ElectronicJournal.Domain
{
    public class Subject : BaseModelWithName
    {
        public IList<SubjectInJournal> SubjectsInJournal { get; set; }
    }
}