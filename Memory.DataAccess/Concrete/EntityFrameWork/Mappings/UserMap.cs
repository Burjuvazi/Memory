using Memory.Core.Entities;
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
    public class UserMap : CoreMap<AppIdentityUser> 
    {
        public override void Configure(EntityTypeBuilder<AppIdentityUser> builder)
        {
            builder.HasMany(x=>x.Notebooks).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            base.Configure(builder);
        }
    }
}
