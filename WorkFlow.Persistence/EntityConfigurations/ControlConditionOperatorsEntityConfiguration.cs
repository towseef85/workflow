using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkFlow.Domain.Entities;

namespace WorkFlow.Persistence.EntityConfigurations
{
    public class ControlConditionOperatorsEntityConfiguration : IEntityTypeConfiguration<RequestConditionOperators>
    {
        public void Configure(EntityTypeBuilder<RequestConditionOperators> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.RequestControlConditions)
                .WithMany(x => x.RequestConditionOperators)
                .HasForeignKey(x => x.ControlConditionsId);
        }
    }
}
