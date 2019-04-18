using System;
using System.Collections.Generic;

namespace AutoMapperError.Shared
{
    public class Course
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public ICollection<Lab> Labs { get; set; } = new List<Lab>();

        public class View
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Order { get; set; }

            public ICollection<Lab.View> Labs { get; set; }
        }
    }
}
