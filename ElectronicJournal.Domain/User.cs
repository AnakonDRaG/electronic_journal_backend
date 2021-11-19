using ElectronicJournal.Domain.Base;

namespace ElectronicJournal.Domain
{
    public class User : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public Human Human { get; set; }
    }
}