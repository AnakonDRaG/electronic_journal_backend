using ElectronicJournal.DTO.ModelsDTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class StudyDayDto : EntityDTO
    {
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public IList<LessonsDTO> Lessons { get; set; }
    }
}
