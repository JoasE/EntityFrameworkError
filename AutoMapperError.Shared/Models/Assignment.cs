using System;
using System.Collections.Generic;
using AutoMapperError.Shared.Models;

namespace AutoMapperError.Shared
{
    public class Assignment
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Guid LabId { get; set; }
        public Lab Lab { get; set; }
        
        public ICollection<UserAssignment> UserAssignments { get; set; } = new List<UserAssignment>();

        public class View
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public Guid LabId { get; set; }
            public Lab Lab { get; set; }

            public UserAssignment.View CurrentWork { get; set; }
        }
    }
}
