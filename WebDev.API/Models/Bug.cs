namespace WebDev.API.Models
{
    public class Bug
    {
        public int BugId { get; set; }
        public string? BugName { get; set; }
        public string? BugDescription { get; set; }
        public string? GitUrl { get; set; }
        public int UserId { get; set; }
    }
}
