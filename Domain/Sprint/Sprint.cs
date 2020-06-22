using System;

namespace Domain {
    public class Sprint {
        public int Id { get; set; }
        public Project Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PointsPlanned { get; set; }
        public int PointsCompleted { get; set; }
        public bool IsArchived { get; set; }
    }
}