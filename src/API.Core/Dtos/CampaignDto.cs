namespace API.Core.Dtos
{
    public class CampaignDto
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public GoalDto goalDto { get; set; }
    }
}