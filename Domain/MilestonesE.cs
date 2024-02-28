using System.ComponentModel.DataAnnotations;

namespace Class13.Domain
{
    public class MilestonesE
    {
        [Key]
        public Guid IdMilestone { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = string.Empty;
        public string SuccessCondition { get; set; } = string.Empty;

        public string? CompletionDate { get; set; } = string.Empty;
        public int isCompleted { get; set; } = 0;

        public Guid? GoalId { get; set; }
        public GoalsE? Goal { get; set; }
    }
}
