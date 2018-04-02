using BSBookstore.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSBookstore.Domain.Entity
{
    public class Book : IEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public virtual Category Category { get; set; }

        public virtual Author Author { get; set; }

        public int PublishedYear { get; set; }
    }
}
