using ElectronicJournal.Domain.Base;
using System;

namespace ElectronicJournal.Domain
{
    public class Human : BaseModelWithName
    {
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}