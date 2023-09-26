using Memory.Core.DataAccess;
using Memory.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.DataAccess.Abstract
{
    public interface INoteBookDal : IRepository<Notebook> 
    {
       
    }
}
