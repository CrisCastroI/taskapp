using Class13.Domain;

namespace Class11.DAO
{
    public class TaskDto
    {        
        public string name { get; set; }
        public string description { get; set; }            
        public Guid idUser { get; set; }
        public TaskDto(string taskName, string description, Guid idUser)
        {
            this.name = taskName;
            this.description = description;
            this.idUser = idUser;
        }

        public TaskDto()
        {
        }
    }
}
