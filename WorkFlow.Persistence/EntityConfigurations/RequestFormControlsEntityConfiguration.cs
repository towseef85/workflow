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
    class RequestFormControlsEntityConfiguration : IEntityTypeConfiguration<RequestFormControls>
    {
        public void Configure(EntityTypeBuilder<RequestFormControls> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.RequestForms)
                .WithMany(x => x.FormControls)
                .HasForeignKey(x => x.RequestFormId);
           
        }
    }
}
