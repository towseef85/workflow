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
    public class RequestConditionUsersEntityConfiguration : IEntityTypeConfiguration<RequestConditionUsers>
    {
        public void Configure(EntityTypeBuilder<RequestConditionUsers> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.RequestControlConditions)
                .WithMany(x => x.RequestConditionUsers);
        }
    }
}
