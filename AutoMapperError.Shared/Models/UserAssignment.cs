using System;

namespace AutoMapperError.Shared.Models
{
    public class UserAssignment
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public DateTime StartedAt { get; set; } = DateTime.UtcNow;

        public class View
        {
            public Guid UserId { get; set; }
            public Guid AssignmentId { get; set; }

            public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        }
    }
}
