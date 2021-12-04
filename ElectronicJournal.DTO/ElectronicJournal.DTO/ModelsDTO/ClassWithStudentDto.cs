using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicJournal.DTO.ModelsDTO
{
    class ClassWithStudentDto : ClassesDTO
    {
        public IList<StudentsDTO> Students { get; set; } = new List<StudentsDTO>();
    }
}
