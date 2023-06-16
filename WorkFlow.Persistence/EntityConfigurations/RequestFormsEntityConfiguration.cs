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
    class RequestFormsEntityConfiguration : IEntityTypeConfiguration<RequestForms>
    {
        public void Configure(EntityTypeBuilder<RequestForms> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x=>x.RequestType)
                .WithMany(x => x.RequestForms)
                .HasForeignKey(x=>x.RequestTypeId);
        }
    }
}
