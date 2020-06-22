using System;
using System.Collections.Generic;

namespace Domain {
    public class Project {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public double Version { get; set; }
        public List<User> Members { get; set; }
    }
}