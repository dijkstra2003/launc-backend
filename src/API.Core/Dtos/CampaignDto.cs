namespace API.Core.Dtos
{
    public class CampaignDto
    {
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public GoalDto goalDto { get; set; }
    }
}