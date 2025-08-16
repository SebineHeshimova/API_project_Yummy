namespace YummyProject.WebUI.DTOs.AboutDTOs
{
    public class GetByIdAboutDTO
    {
        public int AboutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string VideoCover { get; set; }
        public string ReservationNumber { get; set; }
    }
}
