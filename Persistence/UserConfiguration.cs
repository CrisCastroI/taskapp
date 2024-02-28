using Class13.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Class13.Persistence
{
    public class UserConfiguration : IEntityTypeConfiguration<UsersE>
    {        
        public void Configure(EntityTypeBuilder<UsersE> builder)
        {
            builder.ToTable("UserE");
            builder.HasKey(a => a.Id)
                .HasName("PK_User_Id");
            builder.Property(a => a.Email)
                .IsRequired();
            builder.Property(a => a.Password)
                .IsRequired();
            builder.Property(a => a.FirstName);
            builder.Property(a => a.LastName);
        }
    }
}