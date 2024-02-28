using System.ComponentModel.DataAnnotations;

namespace Class13.Domain
{
    public class ProficienciesE
    {
        [Key]
        public Guid IdProficiency { get; set; }
        public string Level { get; set; }

        public ICollection<GoalsE> Goals { get; set; } = new List<GoalsE>();
    }
}
