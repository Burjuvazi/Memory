using Memory.Core.DataAccess.EntityFrameWork;
using Memory.DataAccess.Abstract;
using Memory.DataAccess.Concrete.EntityFrameWork.Context;
using Memory.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.DataAccess.Concrete.EntityFrameWork
{
    public class CityDal : RepositoryBase<City>, ICityDal
    {
        public CityDal(MemoryContext context) : base(context)
        {
                
        }
    }
}
