namespace YummyProject.WebApi.Entity
{
    public class Feedback
    {
        public int FeedbackId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public string ImageUrl { get; set; }
    }
}
