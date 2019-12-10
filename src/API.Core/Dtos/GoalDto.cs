using System;

namespace API.Core.Dtos
{
    public class GoalDto
    {
        public int Id { get; set; }
        public DateTime GoalStart { get; set; }
        public DateTime GoalEnd { get; set; }
        public int MinAmount { get; set; }
    }
}