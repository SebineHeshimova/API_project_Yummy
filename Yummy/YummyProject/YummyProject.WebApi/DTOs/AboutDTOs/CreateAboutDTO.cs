namespace YummyProject.WebApi.DTOs.AboutDTOs
{
    public class CreateAboutDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoCover { get; set; }
        public string ReservationNumber { get; set; }
    }
}
