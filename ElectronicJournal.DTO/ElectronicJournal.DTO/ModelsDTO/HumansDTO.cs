using System;
using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class HumansDTO : EntityDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string UserName { get; set; }
    }
}