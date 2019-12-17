namespace API.Core.Dtos
{
    public class CampaignDto
    {
        public string CampaignName { get; set; }
        public string CampaignDescription { get; set; }
        public GoalDto Goal { get; set; }
    }
}