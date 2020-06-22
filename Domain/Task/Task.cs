using System;
using System.Collections.Generic;

namespace Domain {
    public enum Status {
        Backlog,
        Planned,
        Development,
        NeedsTesting,
        Testing,
        ToDeploy,
        Deployed
    }
    public class Task {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }
        public DateTime EstimatedTime { get; set; }
        public Status Status { get; set; }
        public Project Project { get; set; }
        public List<User> AssignedMembers { get; set; }
    }
}