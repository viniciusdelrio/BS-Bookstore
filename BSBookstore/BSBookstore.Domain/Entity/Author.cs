using BSBookstore.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Entity
{
    public class Author : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
