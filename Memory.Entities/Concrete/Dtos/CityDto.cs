using Memory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Entities.Concrete.Dtos
{
    public class CityDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       
    }
}
