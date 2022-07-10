namespace WebDev.API.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? Description { get; set; }
        public string? GitUrl { get; set; }
        public int UserId { get; set; }

    }
}
