namespace Class13.Domain
{
    public class UsersE
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<TaskE> Tasks { get; set; } = new List<TaskE>();
    }
}
