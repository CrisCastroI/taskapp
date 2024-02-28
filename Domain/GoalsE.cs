using System.ComponentModel.DataAnnotations;

namespace Class13.Domain
{
    public class GoalsE
    {
        [Key]
        public Guid GoalId { get; set; }

        public string GoalName { get; set; }

        public string GoalDescription { get; set; } = string.Empty;
        public string GoalCondition { get; set; } = string.Empty;
        public string creationDate { get; set; } = string.Empty;
        public int isCompleted { get; set; } = 0;
        public string? completionDate { get; set; } = string.Empty;

        public Guid? TaskId { get; set; }
        public TaskE? Task { get; set; }

        public Guid? ProficiencyId { get; set; }
        public ProficienciesE? Proficiency { get; set; }

        public ICollection<MilestonesE> Milestones { get; set; } = new List<MilestonesE>();
    }
}
