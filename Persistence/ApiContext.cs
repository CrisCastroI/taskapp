using Class11.DAO;
using Class13.Domain;
using Microsoft.EntityFrameworkCore;
namespace Class13.Persistence
{
    public class ApiContext : DbContext
    {
        public ApiContext() { }

        public ApiContext(DbContextOptions<ApiContext> options):base(options) { }
        
        public DbSet<UsersE> UserE { get; set; }
        public DbSet<TaskE> TasksE { get; set; }
        public DbSet<ProficienciesE> ProficienciesE { get; set; }
        public DbSet<GoalsE> GoalsE { get; set; }
        public DbSet<MilestonesE> MilestonesE { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApiContext).Assembly);

            modelBuilder.Entity<UsersE>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<UsersE>()
                .HasMany(e => e.Tasks)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);                

            modelBuilder.Entity<TaskE>()
                .HasKey(e => e.TaskId);

            modelBuilder.Entity<TaskE>()
                .HasMany(e => e.Goals)
                .WithOne(e => e.Task)
                .HasForeignKey(e => e.TaskId);                

            modelBuilder.Entity<ProficienciesE>()
                .HasKey(e => e.IdProficiency);

            modelBuilder.Entity<ProficienciesE>()
                .HasMany(e => e.Goals)
                .WithOne(e => e.Proficiency)
                .HasForeignKey(e => e.ProficiencyId)
                .IsRequired();

            modelBuilder.Entity<GoalsE>()
                .HasKey(e => e.GoalId);

            modelBuilder.Entity<GoalsE>()
                .HasMany(e => e.Milestones)
                .WithOne(e => e.Goal)
                .HasForeignKey(e => e.GoalId)
                .IsRequired();

            modelBuilder.Entity<MilestonesE>()
                .HasKey(e => e.IdMilestone);            

            modelBuilder.Entity<UsersE>()
                .HasData(
                    new UsersE
                    {
                        Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36"),
                        Email = "user1@gmail.com",
                        Password = "password",
                        FirstName = "first",
                        LastName = "last"
                    },
                    new UsersE
                    {
                        Id = Guid.NewGuid(),
                        Email = "user2@gmail.com",
                        Password = "password",
                        FirstName = "second",
                        LastName = "last"
                    }
                );

            modelBuilder.Entity<TaskE>()
                .HasData(
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Task 1",
                        TaskDescription = "Desc 1",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy"),
                        UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36")
                    },
                    new TaskE
                    {
                        TaskId = Guid.Parse("0179fed6-7ff9-44b4-b017-3eaf9368350b"),
                        TaskName = "English",
                        TaskDescription = "Improve your english from start",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy"),
                        UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Math 2",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Math 3",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Math 4",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Calculus",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Calculus 2",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Calculus 3",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Calculus 4",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Gym Routine",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy"),
                        UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Chore list",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Fix Procastrination",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Cooking",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "Cooking 2",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy"),
                        UserId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b36")
                    },
                    new TaskE
                    {
                        TaskId = Guid.NewGuid(),
                        TaskName = "French",
                        TaskDescription = "Improve your task",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy")
                    }                   
                );
            modelBuilder.Entity<ProficienciesE>()
                .HasData(
                    new ProficienciesE
                    {
                        IdProficiency = Guid.Parse("d7e9c485-22f9-49bc-9ca0-b07730a040c5"),
                        Level = "Initial"
                    },
                    new ProficienciesE
                    {
                        IdProficiency = Guid.NewGuid(),
                        Level = "Medium"
                    },
                    new ProficienciesE
                    {
                        IdProficiency = Guid.NewGuid(),
                        Level = "Expert"
                    }
                );
            modelBuilder.Entity<GoalsE>()
                .HasData(
                    new GoalsE
                    {
                        GoalId = Guid.NewGuid(),
                        GoalName = "Read English text",
                        GoalDescription = "Practice reading",
                        GoalCondition = "Finish Text",
                        creationDate= DateTime.Now.ToString("dd-MM-yyyy"),
                        TaskId = Guid.Parse("0179fed6-7ff9-44b4-b017-3eaf9368350b"),
                        ProficiencyId = Guid.Parse("d7e9c485-22f9-49bc-9ca0-b07730a040c5")
                    },
                    new GoalsE
                    {
                        GoalId = Guid.Parse("1aae8ba5-0251-4845-9f3f-bba4779189fb"),                        
                        GoalName = "Improve Listening",
                        GoalDescription = "Practice listening",
                        GoalCondition = "Understand conversations",
                        creationDate = DateTime.Now.ToString("dd-MM-yyyy"),
                        TaskId = Guid.Parse("0179fed6-7ff9-44b4-b017-3eaf9368350b"),
                        ProficiencyId = Guid.Parse("d7e9c485-22f9-49bc-9ca0-b07730a040c5")
                    }
                );
            modelBuilder.Entity<MilestonesE>()
                .HasData(
                    new MilestonesE
                    {
                        IdMilestone = Guid.Parse("476d5695-d378-47a9-9c11-0915715355c7"),
                        Name = "Watch movie in English",
                        Description = "Practice listening",
                        SuccessCondition = "Understand Movie Dialog",
                        GoalId = Guid.Parse("1aae8ba5-0251-4845-9f3f-bba4779189fb")
                    }
                );
        }
    }
}
