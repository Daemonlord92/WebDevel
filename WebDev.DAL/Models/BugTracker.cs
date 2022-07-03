using System;
using System.Collections.Generic;

namespace WebDev.DAL.Models
{
    public partial class BugTracker
    {
        public decimal BugId { get; set; }
        public string BugName { get; set; } = null!;
        public string BugDescription { get; set; } = null!;
        public string GitUrl { get; set; } = null!;
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
