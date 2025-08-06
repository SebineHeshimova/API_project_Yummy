namespace YummyProject.WebUI.DTOs.NotificationDTOs
{
    public class GetNotificationByIsReadDTO
    {
        public int NotificationId { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
