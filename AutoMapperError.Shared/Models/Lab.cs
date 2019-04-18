using System;
using System.Collections.Generic;

namespace AutoMapperError.Shared
{
    public class Lab
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();

        public class View
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public Guid CourseId { get; set; }

            public ICollection<Assignment.View> Assignments { get; set; }
        }
    }
}
