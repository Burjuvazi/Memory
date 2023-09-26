using Memory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Core.Map
{
    public class CoreMap<T> : IEntityTypeConfiguration<T> where T : class, IEntity, new()
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.IsDeleted).IsRequired();
        }
    }
}
