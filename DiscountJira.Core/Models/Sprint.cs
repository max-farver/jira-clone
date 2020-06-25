using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountJira.Core.Models
{
    public class Sprint
    {
        public int Id { get; set; }
        public Project Project { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PointsPlanned { get; set; }
        public int PointsCompleted { get; set; }
        public bool IsArchived { get; set; }
        public bool isDeleted { get; set; }
    }
}