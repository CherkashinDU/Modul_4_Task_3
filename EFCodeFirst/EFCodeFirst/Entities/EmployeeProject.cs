﻿using System;

namespace EFCodeFirst.Entities
{
    public class EmployeeProject
    {
        public int Id { get; set; }
        public int Rate { get; set; }
        public DateTime StartedDate { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
