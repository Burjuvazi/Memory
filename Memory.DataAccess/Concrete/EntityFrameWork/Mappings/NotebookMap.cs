using Memory.Core.Map;
using Memory.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.DataAccess.Concrete.EntityFrameWork.Mappings
{
    public class NotebookMap : CoreMap<Notebook>
    {
        public override void Configure(EntityTypeBuilder<Notebook> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x=>x.Title).HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired();



            base.Configure(builder);
        }
    }
}
