using System;
using System.Collections.Generic;

namespace AutoMapperError.Shared.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<UserAssignment> UserAssignments { get; set; }
    }
}
