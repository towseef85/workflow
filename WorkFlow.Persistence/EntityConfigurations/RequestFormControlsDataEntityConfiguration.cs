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
    public class RequestFormControlsDataEntityConfiguration : IEntityTypeConfiguration<RequestFormControlsData>
    {
        public void Configure(EntityTypeBuilder<RequestFormControlsData> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.FormControls)
                .WithMany(x => x.RequestFormControlsData)
                .HasForeignKey(x => x.ControlId);
        }
    }
}
