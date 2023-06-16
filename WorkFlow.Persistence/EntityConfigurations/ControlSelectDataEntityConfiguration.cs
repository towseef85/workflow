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
    public class ControlSelectDataEntityConfiguration : IEntityTypeConfiguration<ControlSelectData>
    {
        public void Configure(EntityTypeBuilder<ControlSelectData> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.RequestFormControls)
                .WithMany(x => x.ControlSelectData)
                .HasForeignKey(x => x.FormControlId);
        }
    }
}
