using Memory.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Entities.Concrete
{
    public class AppIdentityRole : IdentityRole<int>, IEntity
    {
        public bool IsDeleted { get; set;} 
    }
}
