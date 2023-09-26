using Memory.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memory.Entities.Concrete
{
    public class City : IEntity
    {
        public City()
        {
            UpdateDate = DateTime.Now;
            Notebooks = new List<Notebook>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        private DateTime UpdateDate { get; set; }
        public virtual ICollection<Notebook> Notebooks { get; set; }

    }
}
