namespace YummyProject.WebApi.DTOs.ServiceDTOs
{
    public class GetServiceDto
    {
        public int ServiceId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
    }
}
