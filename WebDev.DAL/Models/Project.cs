using System;
using System.Collections.Generic;

namespace WebDev.DAL.Models
{
    public partial class Project
    {
        public decimal ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal ProjectVersion { get; set; }
        public string GitUrl { get; set; } = null!;
        public decimal? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
