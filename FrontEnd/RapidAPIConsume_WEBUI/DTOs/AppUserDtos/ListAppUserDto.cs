using RapidAPIConsume_EntityLayer.Concrete;

namespace RapidAPIConsume_WEBUI.DTOs.AppUserDtos
{
    public class ListAppUserDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Email { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? WorkDepartment { get; set; }
        public int WorkLocationID { get; set; }
        public WorkLocation WorkLocation { get; set; }
    }
}
