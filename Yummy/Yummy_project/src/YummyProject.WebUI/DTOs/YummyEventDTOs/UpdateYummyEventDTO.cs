namespace YummyProject.WebUI.DTOs.YummyEventDTOs
{
    public class UpdateYummyEventDTO
    {
        public int YummyEventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string imageUrl { get; set; }
        public bool Status { get; set; }
    }
}
