using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class ClassWithTeacherDto
    {
        public int ClassroomTeacherId { get; set; }
        public int CurrentJournalId { get; set; }
        public int HeadmanId { get; set; }
        public string Name { get; set; }
    }
}
