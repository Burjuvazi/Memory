using Memory.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Entities.Concrete
{
    public class AppIdentityUser : IdentityUser<int>, IEntity
    {
        public AppIdentityUser()
        {
            CreatedDate = DateTime.Now;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Notebook> Notebooks { get; set; }
        public bool IsDeleted { get; set; }
    }
}
