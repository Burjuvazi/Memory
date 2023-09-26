using Memory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Entities.Concrete.Dtos
{
    public class NotebookDto : IDto
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

    }
}
