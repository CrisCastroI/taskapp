namespace Class13.Domain
{
    public class TaskE
    {
        public Guid TaskId { get; set; }

        public string TaskName { get; set; }
         
        public string TaskDescription { get; set; } = string.Empty;
        public string creationDate { get; set; } = string.Empty;
        public int isCompleted { get; set; } = 0;
        public string? completionDate { get; set; } = string.Empty;

        public Guid? UserId { get; set; }
        public UsersE? User { get; set; }

        public ICollection<GoalsE> Goals { get; set; } = new List<GoalsE>();


    }
}
