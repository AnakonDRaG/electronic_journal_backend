using ElectronicJournal.DTO.ModelsDTO.Base;

namespace ElectronicJournal.DTO.ModelsDTO
{
    public class UsersDTO : EntityDTO
    {
        public string UserName { get; set; }
        public string Role { get; set; }
    }
}