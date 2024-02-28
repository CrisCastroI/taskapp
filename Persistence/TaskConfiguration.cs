using Class13.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Class13.Persistence
{
    public class TaskConfiguration : IEntityTypeConfiguration<TaskE>
    {
        public void Configure(EntityTypeBuilder<TaskE> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(a => a.TaskId)
                .HasName("PK_Task_Id");
            builder.Property(a => a.TaskName)
                .IsRequired();
            builder.Property(a => a.TaskDescription);
        }
    }
}