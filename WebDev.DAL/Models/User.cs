using System;
using System.Collections.Generic;

namespace WebDev.DAL.Models
{
    public partial class User
    {
        public User()
        {
            BugTrackers = new HashSet<BugTracker>();
            Projects = new HashSet<Project>();
        }

        public decimal UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string EmailId { get; set; } = null!;

        public virtual ICollection<BugTracker> BugTrackers { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }
}
