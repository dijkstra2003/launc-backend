using System;

namespace API.Core.Dtos
{
    public class GoalDto
    {
        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MinAmount { get; set; }
    }
}