using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using TaskInteview.Model;

namespace TaskInteview.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(100);
            builder.Property(p => p.Surname).IsRequired(true).HasMaxLength(100);
            builder.Property(p => p.BirthDate).IsRequired(true).HasMaxLength(20);
            //builder.Property(p => p.CreateDate).HasDefaultValueSql("GETUTCDATE()");
            builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.UtcNow);
        }

    }
}
